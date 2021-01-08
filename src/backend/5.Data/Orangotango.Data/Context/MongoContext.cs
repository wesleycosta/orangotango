using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Orangotango.Core.Mediator;
using Orangotango.Business.Intefaces.Infrastructure;
using Orangotango.Core.Settings;

namespace Orangotango.Data.Context
{
    public class MongoContext : IMongoContext
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly List<Func<Task>> _commands;
        private readonly AppSettings _appSettings;
        private IMongoDatabase _database;

        public IClientSessionHandle Session { get; set; }
        public MongoClient MongoClient { get; set; }

        public MongoContext(AppSettings appSettings,
                            IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
            _appSettings = appSettings;
            _commands = new List<Func<Task>>();
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

            //TODO
            //if (success)
            //    await _mediatorHandler.PublishEvent(this);

            return success;
        }

        public void Dispose()
        {
            Session?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
