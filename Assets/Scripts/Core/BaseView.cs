using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseView : MonoBehaviour,IBaseScript,IEventListen
{
    public void Construct()
    {
        MonoController.Instance._scripts.Add(this);
        Debug.Log("BaseView Construct");
        this.transform.parent = GlobalUI.canvas.transform;
    }

    public virtual void ShowView()
    {
        this.gameObject.SetActive(true);
    }

    public virtual void HideView()
    {
        this.gameObject.SetActive(false);
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

