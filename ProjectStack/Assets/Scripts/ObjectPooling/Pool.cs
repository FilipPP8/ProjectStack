using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool<TItem> : MonoBehaviour

    where TItem : MonoBehaviour, IPoolable

{
    private Stack<TItem> _pooledObjects = new Stack<TItem>();
    private TItem _originalPrefab;
    private int _size;

    public void InitializePool(TItem originalPrefab, int size)
    {
        this._originalPrefab = originalPrefab;
        this._size = size;

        for(int i = 0; i < size; i++)
        {
            var obj = Instantiate(_originalPrefab);
            obj.PrepareForDeactivate(transform);
            _pooledObjects.Push(obj);
        }
    }

    public TItem GetFromPool(Vector3 position)
    {
        if(_pooledObjects.Count > 0)
        {
            var obj = _pooledObjects.Pop();
            obj.PrepareForActivate(position);
            return obj;
        }
        else
        {
            var obj = Instantiate(_originalPrefab);
            obj.PrepareForActivate(position);
            return obj;
        }
    }

    public void ReturnToPool(TItem _item)
    {
        if (_pooledObjects.Count <= _size)
        {
            _item.PrepareForDeactivate(this.transform);
            _pooledObjects.Push(_item);
        }
        else
        {
            Destroy(_item.gameObject);
        }
    }
    
}
