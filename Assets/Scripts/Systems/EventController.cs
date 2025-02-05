using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 事件管理器
/// </summary>
public class EventController
{
    /// <summary>
    /// 直接交给事件管理器来运行的事件
    /// </summary>
    public Dictionary<E_EventDef, UnityAction> eventList = new Dictionary<E_EventDef, UnityAction>();

    /// <summary>
    /// 触发事件
    /// </summary>
    /// <param name="eventDef"></param>
    public void TriggerEvent(E_EventDef eventDef)
    {
        for (int i = 0; i < MonoController.Instance._scripts.Count; i++)
        {
            MonoController.Instance._scripts[i].UpdateEvent(eventDef);
        }

        //MonoCore.Instance.OnceMono(this.eventList[eventDef]);
        this.eventList[eventDef]?.Invoke();
    }

    /// <summary>
    /// 输出事件系统注册到的所有脚本
    /// </summary>
    public void printScripts()
    {
        string str = "-----------事件系统debug输出-----------\n";
        int index = 0;
        foreach (var item in MonoController.Instance._scripts)
        {
            str += ++index + ": " + item.GetType().Name + "\n";
        }

        str += "\n*********托管到事件系统处理的事件类型如下：\n";

        foreach (var item in eventList.Keys)
        {
            str += ++index + ": " + item.GetType().Name + "\n";
        }

        str += "-----------事件系统debug输出完毕-----------\n";

        Debug.Log(str);
    }

}

/// <summary>
/// 事件监听接口
/// </summary>
public interface IEventListen
{
    public void UpdateEvent(E_EventDef eventDef);
}