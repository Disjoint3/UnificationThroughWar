using UnityEngine;

/// <summary>
/// 管理器基类，不继承mono
/// </summary>
public class BaseMgr : IBaseScript, IEventListen
{

    public BaseMgr()
    {
        this.Construct();
    }

    public void Construct()
    {
        Debug.Log("BaseMgr Construct");
        IncludeMgr.eventMgr.RegisterScript(this);
    }

    public void InitData()
    {

    }

    public void InitView()
    {

    }

    public void UpdateEvent(E_EventDef eventDef)
    {
        Debug.Log("事件" + eventDef.ToString() + "在" + this + "触发");
    }

    #region 帧更新函数
    public void UpdateData() { }
    public void UpdateView() { }
    public void FixUpdate() { }
    public void PreDestroy() { }
    #endregion
}
