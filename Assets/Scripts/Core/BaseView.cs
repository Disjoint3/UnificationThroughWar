using UnityEngine;

public class BaseView : MonoBehaviour,IBaseScript,IEventListen
{
    public void Construct(params object[] args)
    {
        Debug.Log("BaseView Construct");
        IncludeMgr.eventMgr.RegisterScript(this);
        this.InitData();
        this.InitView();
        this.transform.parent = GlobalDef.canvas.transform;
    }

    public virtual void ShowView()
    {
        this.gameObject.SetActive(true);
    }

    public virtual void HideView()
    {
        this.gameObject.SetActive(false);
    }

    public void PreDestroy(params object[] args)
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

    public void FixUpdate(params object[] args)
    {

    }

    public void UpdateEvent(E_EventDef eventDef)
    {
        Debug.Log("事件" + eventDef.ToString() + "在" + this + "触发");
    }

    private void Update()
    {
        if (GlobalDef.startUpdate)
        {
            this.UpdateData();
            this.UpdateView();
        }
    }

    private void FixedUpdate()
    {
        if (GlobalDef.startUpdate)
        {
            this.FixedUpdate();
        }
    }
}

