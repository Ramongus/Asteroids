using System;
using System.Collections.Generic;
using Interfaces;

namespace DefaultNamespace
{
    public class ObjectPool<T> where T : IPoolObject
    {
        private List<T> _pool;
        private readonly Func<T> _createObject;

        public ObjectPool(int initialSize, Func<T> createObject)
        {
            _pool = new List<T>(initialSize);
            _createObject = createObject;
            
            for (int i = 0; i < initialSize; i++)
            {
                T newObject = _createObject();
                newObject.TurnOff();
                _pool.Add(newObject);
            }
        }
        
        public T GetObject()
        {
            for (int i = 0; i < _pool.Count; i++)
            {
                if (!_pool[i].IsActive())
                {
                    _pool[i].TurnOn();
                    return _pool[i];
                }
            }
            
            var newObject = _createObject();
            _pool.Add(newObject);
            return newObject;
        }
    }
}