using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Orangotango.Core.Mediator;
using Orangotango.Business.Intefaces.Infrastructure;
using Orangotango.Core.Settings;
using Orangotango.Core.DomainObjects;
using Orangotango.Data.Extensions;

namespace Orangotango.Data.Context
{
    public class MongoContext : IMongoContext
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly List<Func<Task>> _commands;
        private readonly AppSettings _appSettings;
        private IMongoDatabase _database;
        private List<Entity> _tracking;

        public IClientSessionHandle Session { get; set; }
        public MongoClient MongoClient { get; set; }

        public MongoContext(AppSettings appSettings,
                            IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
            _appSettings = appSettings;

            _commands = new List<Func<Task>>();
            _tracking = new List<Entity>();
        }

        public async Task<int> SaveChanges()
        {
            ConfigureMongo();

            using (Session = await MongoClient.StartSessionAsync())
            {
                Session.StartTransaction();

                var commandTasks = _commands.Select(c => c());

                await Task.WhenAll(commandTasks);

                await Session.CommitTransactionAsync();
            }

            return _commands.Count;
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            ConfigureMongo();

            return _database.GetCollection<T>(name);
        }

        public void AddCommand(Func<Task> func)
        {
            _commands.Add(func);
        }

        public void AddCommand(Func<Task> func, List<Entity> entities)
        {
            AddTracking(entities);
            _commands.Add(func);
        }

        public void AddCommand(Func<Task> func, Entity entity)
        {
            AddTracking(entity);
            _commands.Add(func);
        }

        private void AddTracking(Entity entity)
        {
            _tracking.Add(entity);
        }

        private void AddTracking(List<Entity> entities)
        {
            _tracking.AddRange(entities);
        }

        public IReadOnlyList<Entity> GetTracking()
        {
            return _tracking;
        }

        private void ConfigureMongo()
        {
            if (MongoClient != null)
                return;

            MongoClient = new MongoClient(_appSettings.ConnectionString);
            _database = MongoClient.GetDatabase(_appSettings.DataBase);
        }

        public async Task<bool> Commit()
        {
            var success = await SaveChanges() > 0;
            if (success)
                await _mediatorHandler.PublishContext(this);

            return success;
        }

        public void Dispose()
        {
            Session?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
