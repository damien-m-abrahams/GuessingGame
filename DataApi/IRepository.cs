using System;
using System.Collections.Generic;
using System.Linq;

namespace GuessingGame.DataApi
{
    /// <summary>Data access</summary>
    /// <typeparam name="T">The type of data</typeparam>
    public interface IRepository<T> : IDisposable
    {
        IEnumerable<T> GetAll();

        T GetById(int key);

        void Insert(T subject);

        void Update(T subject);

        void Remove(T subject);
    }
}
