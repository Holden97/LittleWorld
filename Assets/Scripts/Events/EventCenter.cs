using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IEventInfo
{

}

public class EventInfo<T> : IEventInfo
{
    public UnityAction<T> actions;

    public EventInfo(UnityAction<T> action)
    {
        actions += action;
    }
}

public class EventInfo<T1, T2> : IEventInfo
{
    public UnityAction<T1, T2> actions;

    public EventInfo(UnityAction<T1, T2> action)
    {
        actions += action;
    }
}


public class EventInfo : IEventInfo
{
    public UnityAction actions;

    public EventInfo(UnityAction action)
    {
        actions += action;
    }
}
/// <summary>
/// 事件中心模块
/// 1.委托
/// 2.Dictionary
/// 3.观察者设计模式
/// </summary>
public class EventCenter : MonoSingleton<EventCenter>
{
    /// <summary>
    /// 事件中心模块的Dictionary容器
    /// key对应事件名称
    /// value对应监听事件对应的函数委托
    /// </summary>
    private Dictionary<string, IEventInfo> eventDic = new Dictionary<string, IEventInfo>();

    public void Register<T1, T2>(string name, UnityAction<T1, T2> action)
    {
        if (eventDic.ContainsKey(name))
        {
            (eventDic[name] as EventInfo<T1, T2>).actions += action;
        }
        else
        {
            eventDic.Add(name, new EventInfo<T1, T2>(action));
        }
    }

    /// <summary>
    /// 添加事件监听（需要参数）
    /// </summary>
    /// <param name="name">事件名称</param>
    /// <param name="action">执行的方法</param>
    public void Register<T>(string name, UnityAction<T> action)
    {
        if (eventDic.ContainsKey(name))
        {
            (eventDic[name] as EventInfo<T>).actions += action;
        }
        else
        {
            eventDic.Add(name, new EventInfo<T>(action));
        }
    }
    /// <summary>
    /// 添加事件监听（不需要参数）
    /// </summary>
    /// <param name="name">事件名称</param>
    /// <param name="action">执行的方法</param>
    public void Register(string name, UnityAction action)
    {
        if (eventDic.ContainsKey(name))
        {
            (eventDic[name] as EventInfo).actions += action;
        }
        else
        {
            eventDic.Add(name, new EventInfo(action));
        }
    }
    /// <summary>
    /// 移除事件监听（需要参数）
    /// </summary>
    /// <param name="name">事件名称</param>
    /// <param name="action">执行的方法</param>
    public void Unregister<T>(string name, UnityAction<T> action)
    {
        if (eventDic.ContainsKey(name))
        {
            (eventDic[name] as EventInfo<T>).actions -= action;
        }
    }

    public void Unregister<T1, T2>(string name, UnityAction<T1, T2> action)
    {
        if (eventDic.ContainsKey(name))
        {
            (eventDic[name] as EventInfo<T1, T2>).actions -= action;
        }
    }

    /// <summary>
    /// 移除事件监听（不需要参数）
    /// </summary>
    /// <param name="name">事件名称</param>
    /// <param name="action">执行的方法</param>
    public void Unregister(string name, UnityAction action)
    {
        if (eventDic.ContainsKey(name))
        {
            (eventDic[name] as EventInfo).actions -= action;
        }
    }
    /// <summary>
    /// 触发事件（需要参数）
    /// </summary>
    /// <param name="name">事件名称</param>
    public void Trigger<T>(string name, T info)
    {
        if (eventDic.ContainsKey(name))
        {
            (eventDic[name] as EventInfo<T>).actions?.Invoke(info);
        }
    }

    public void Trigger<T1, T2>(string name, T1 Param1, T2 Param2)
    {
        if (eventDic.ContainsKey(name))
        {
            if ((eventDic[name] as EventInfo<T1, T2>) == null)
            {
                Debug.LogError($"未注册对应{typeof(T1)},{typeof(T2)}的事件");
            }
            (eventDic[name] as EventInfo<T1, T2>).actions?.Invoke(Param1, Param2);
        }
    }
    /// <summary>
    /// 触发事件（不需要参数）
    /// </summary>
    /// <param name="name">事件名称</param>
    public void Trigger(string name)
    {
        if (eventDic.ContainsKey(name))
        {
            (eventDic[name] as EventInfo).actions?.Invoke();
            //也可以写成eventDic[name].Invoke(info);
        }
    }

    /// <summary>
    /// 清除容器内容
    /// 主要用于场景转换时完全清空容器
    /// </summary>
    public void Clear()
    {
        eventDic.Clear();

    }
}
