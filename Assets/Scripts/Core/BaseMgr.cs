using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BaseMgr : IBaseScript, IEventListen
{

    public void Construct()
    {
        MonoController.Instance._scripts.Add(this);
        Debug.Log("BaseMgr Construct");
    }

    public void Destroy(params object[] args)
    {

    }

    public void InitData(params object[] args)
    {

    }

    public void InitView(params object[] args)
    {

    }

    public void UpdateData(params object[] args)
    {

    }

    public void UpdateView(params object[] args)
    {

    }

    public void UpdateEvent(E_EventDef eventDef)
    {
        Debug.Log("事件" + eventDef.ToString() + "在" + this + "触发");
    }
}
