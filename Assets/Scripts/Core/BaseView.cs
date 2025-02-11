using UnityEngine;

public class BaseView : MonoBehaviour,IBaseScript,IEventListen
{
    public void Construct()
    {
        Debug.Log("BaseView Construct");
        IncludeMgr.eventMgr.RegisterScript(this);
        IncludeCtl.mono.RegisterScriptUpdate(this);
        this.InitData();
        this.InitView();
        this.transform.parent = GlobalDef.canvas.transform;
    }

    /// <summary>
    /// 触发界面显示
    /// </summary>
    public virtual void ShowView()
    {
        this.gameObject.SetActive(true);
    }

    /// <summary>
    /// 触发界面隐藏
    /// </summary>
    public virtual void HideView()
    {   
        this.gameObject.SetActive(false);
    }

    public void PreDestroy()
    {

    }

    public void InitData()
    {

    }

    public void InitView()
    {

    }

    public void UpdateData()
    {

    }

    public void UpdateView()
    {

    }

    public void FixUpdate()
    {

    }

    public void UpdateEvent(E_EventDef eventDef)
    {
        Debug.Log("事件" + eventDef.ToString() + "在" + this + "触发");
    }

    private void Awake()
    {
        this.Construct();        
    }

    private void OnDestroy()
    {
        this.PreDestroy();
    }

    //private void Update()
    //{
    //    if (GlobalDef.startUpdate)
    //    {
    //        this.UpdateData();
    //        this.UpdateView();
    //    }
    //}

    //private void FixedUpdate()
    //{
    //    if (GlobalDef.startUpdate)
    //    {
    //        this.FixedUpdate();
    //    }
    //}
}

