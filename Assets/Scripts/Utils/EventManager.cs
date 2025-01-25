using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 事件管理器
/// </summary>
public class EventManager
{
    public List<BaseScript> _scripts = new List<BaseScript>();

    /// <summary>
    /// 触发事件
    /// </summary>
    /// <param name="eventDef"></param>
    public void TriggerEvent(E_EventDef eventDef)
    {
        for (int i = 0; i < this._scripts.Count; i++)
        {
            this._scripts[i].UpdateEvent(eventDef);
        }
    }

    /// <summary>
    /// 输出事件系统注册到的所有脚本
    /// </summary>
    public void printScripts()
    {
        string str = "-----------事件系统debug输出-----------\n";
        int index = 0;
        foreach (var item in _scripts)
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