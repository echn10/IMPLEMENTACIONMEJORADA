using System;
using System.Collections.Generic;
using System.Linq;
using SchoolManager.Models;

namespace SchoolManager.Services
{
    public class DataService<T> where T : class
    {
        private List<T> _items = new List<T>();

        public void Add(T item)
        {
            _items.Add(item);
        }

        public void Remove(T item)
        {
            _items.Remove(item);
        }

        public List<T> GetAll()
        {
            return _items;
        }

        public List<T> Find(Func<T, bool> predicate)
        {
            return _items.Where(predicate).ToList();
        }
    }
}