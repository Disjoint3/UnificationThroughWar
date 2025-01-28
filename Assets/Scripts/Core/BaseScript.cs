using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BaseScript : MonoBehaviour,IEventListen
{
    public void Awake()
    {
        SingleMgr.eventMgr._scripts.Add(this);
        Debug.Log("BaseScript Awake");
    }

    /// <summary>
    /// 事件触发函数（如果需要使用事件，直接在类中重写该函数即可）
    /// </summary>
    /// <param name="eventDef"></param>
    public virtual void UpdateEvent(E_EventDef eventDef)
    {
        Debug.Log("事件" + eventDef.ToString() + "在" + this + "触发");
    }
}
