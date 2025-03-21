// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/03/06 16:03
// @version: 1.0
// @description:
// *****************************************************************************

using System.Collections.Generic;
using Godot;
using LumiVerseFramework.Base.Interfaces;

namespace LumiVerseFramework.Base;

public class ObjectPool<T> where T : Node2D, IObjPool
{
    private readonly Node _parent;
    private readonly Queue<T> _pool = new();
    private readonly PackedScene _prefab;

    /// <summary>
    /// 初始化对象池
    /// </summary>
    /// <param name="prefab">对象预制体</param>
    /// <param name="parent">父物体</param>
    /// <param name="initSize">初始大小</param>
    public ObjectPool(PackedScene prefab, Node parent, int initSize = 10)
    {
        _prefab = prefab;
        _parent = parent;
        for (int i = 0; i < initSize; i++)
        {
            T obj = CreateNewObj();
            obj.Disable();
            _pool.Enqueue(obj);
        }
    }

    /// <summary>
    /// 获取一个对象
    /// </summary>
    /// <param name="enable">是否立即启用</param>
    /// <returns></returns>
    public T GetObj(bool enable = true)
    {
        // 队列中没有对象，创建新对象
        if (_pool.Count <= 0) return CreateNewObj();
        // 队列中有对象，直接返回
        T obj = _pool.Dequeue();
        if (enable) obj.Enable();
        return obj;
    }

    /// <summary>
    /// 回收销毁对象
    /// </summary>
    /// <param name="obj"></param>
    public void ReleaseObj(T obj)
    {
        obj.Disable();
        _pool.Enqueue(obj);
    }

    /// <summary>
    /// 创建新物体
    /// </summary>
    /// <returns></returns>
    private T CreateNewObj()
    {
        T newObj = _prefab.Instantiate<T>();
        _parent.AddChild(newObj);
        return newObj;
    }
}
