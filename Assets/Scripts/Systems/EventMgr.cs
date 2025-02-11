using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 事件管理器
/// </summary>
public class EventMgr
{
    /// <summary>
    /// 直接交给事件管理器来运行的事件
    /// </summary>
    public Dictionary<E_EventDef, UnityAction> eventList = new Dictionary<E_EventDef, UnityAction>();

    //public Dictionary<IBaseScript,IBaseScript> scripts = new Dictionary<IBaseScript, IBaseScript> ();

    //注册在案 需要使用时间系统的脚本们
    public List<IBaseScript> scripts = new List<IBaseScript>();

    /// <summary>
    /// 注册脚本进行来监听事件
    /// </summary>
    /// <param name="script"></param>
    public void RegisterScript(IBaseScript script)
    {
        //this.scripts.Add(script, script);
        this.scripts.Add(script);
    }

    public void UnRegisterScript(IBaseScript script)
    {
        //this.scripts.Remove(script);
        this.scripts.Remove(script);
    }

    /// <summary>
    /// 触发事件
    /// </summary>
    /// <param name="eventDef"></param>
    public void TriggerEvent(E_EventDef eventDef)
    {
        foreach (IBaseScript sc in this.scripts)
        {
            sc.UpdateEvent(eventDef);
        }
        this.eventList[eventDef]?.Invoke();
    }

    /// <summary>
    /// 输出事件系统注册到的所有脚本
    /// </summary>
    public void printScripts()
    {
        string str = "-----------事件系统debug输出-----------\n";
        int index = 0;
        foreach (IBaseScript item in this.scripts)
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