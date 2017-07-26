using System;
using System.Collections.Generic;
using System.Linq;
using GuessingGame.DataApi;
using GuessingGame.Subjects;
using LiteDB;

namespace GuessingGame.Data.Sources
{
    public class LiteAnimalData : IRepository<Animal>
    {
        private readonly LiteDatabase database;

        private readonly LiteCollection<Animal> collection;

        public LiteAnimalData(string collectionName)
        {
            if (collectionName == null) throw new ArgumentNullException(nameof(collectionName));

            // LiteDB is not thread-safe and is only used to for a higher level abstraction over File I/O
            // Database name should be declared in configuration file
            database = new LiteDatabase("GuessingGameData.db");
            collection = database.GetCollection<Animal>(collectionName);
        }

        public IEnumerable<Animal> GetAll()
        {
            return collection.FindAll();
        }

        public Animal GetById(int key)
        {
            var subject = collection.Find(item => item.Id == key).FirstOrDefault();
            return subject;
        }

        public void Insert(Animal subject)
        {
            collection.Insert(subject);
        }

        public void Update(Animal subject)
        {
            collection.Update(subject);
        }

        public void Remove(Animal subject)
        {
            collection.Delete(subject.Id);
        }

        public void Dispose()
        {
            database.Dispose();
        }
    }
}
