using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Orangotango.Core.Messages;
using System;
using System.Collections.Generic;

namespace Orangotango.Core.DomainObjects
{
    public abstract class Entity : IAggregateRoot
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ObjectId { get; set; }
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime? LastUpdated { get; set; }
        public bool Active { get; set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
            Active = true;
        }

        #region EVENTS

        private List<Event> _eventNotification;
        public IReadOnlyCollection<Event> GetEvents() => _eventNotification?.AsReadOnly();

        public bool ExistEvents()
        {
            return GetEvents()?.Count > 0;
        }

        public void AddEvent(Event eventMessage)
        {
            _eventNotification ??= new List<Event>();
            _eventNotification.Add(eventMessage);
        }

        public void RemoveEvent(Event eventItem) =>
            _eventNotification?.Remove(eventItem);

        public void ClearEvents() =>
            _eventNotification?.Clear();

        #endregion

        #region METHODS

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;

            if (ReferenceEquals(this, compareTo)) return true;
            if (compareTo is null) return false;

            return Id.Equals(compareTo.Id);
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return GetType().GetHashCode() * 907 + Id.GetHashCode();
        }

        public override string ToString()
        {
            return GetType().Name + " [Id=" + Id + "]";
        }

        #endregion
    }
}
