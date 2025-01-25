using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 对象池对象必须继承
/// </summary>
public interface IPoolItem
{

}

public class PoolTypeItem
{
    private List<IPoolItem> _items = new List<IPoolItem>();
    public List<IPoolItem> items { get { return _items; } }
    public void push(IPoolItem item)
    {
        _items.Add(item);
    }

    public IPoolItem pop()
    {
        IPoolItem item = _items[0];
        _items.RemoveAt(0);
        return item;
    }
}

/// <summary>
/// 对象池
/// </summary>
public class PoolManager
{
    private Dictionary<E_PoolType, PoolTypeItem> _poolDic = new Dictionary<E_PoolType, PoolTypeItem>();
    public Dictionary<E_PoolType, PoolTypeItem> poolDic {  get { return _poolDic; } }

    public PoolManager()
    {
        foreach(E_PoolType item in Enum.GetValues(typeof(E_PoolType)))
        {
            _poolDic.Add(item, new PoolTypeItem());
        }
    }

    public void PushItem(E_PoolType poolType, IPoolItem item)
    {
        _poolDic[poolType].push(item);
    }

    public IPoolItem PopItem(E_PoolType poolType)
    {
        return _poolDic[poolType].pop();
    }

    public void Print()
    {
        string str = "--------------PoolManager Print--------------";
        int index = 0;
        foreach (E_PoolType poolType in Enum.GetValues(typeof(E_PoolType)))
        {
            str += ++index + ". " + poolType.ToString() + "\n";
            foreach (IPoolItem item in this._poolDic[poolType].items)
            {
                str += item.ToString() + "\n";
            }
            str += "--1." + poolType.ToString() + "\n\n";
        }
        str += "--------------end--------------";
        Debug.Log(str);
    }
}
