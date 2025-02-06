using UnityEngine;

/// <summary>
/// 管理器基类，不继承mono
/// </summary>
public class BaseMgr : IBaseScript, IEventListen
{

    public void Construct(params object[] args)
    {
        Debug.Log("BaseMgr Construct");
        IncludeMgr.eventMgr.RegisterScript(this);
    }

    public void InitData(params object[] args)
    {

    }

    public void InitView(params object[] args)
    {

    }

    public void UpdateEvent(E_EventDef eventDef)
    {
        Debug.Log("事件" + eventDef.ToString() + "在" + this + "触发");
    }

    #region 帧更新函数
    public void UpdateData(params object[] args) { }
    public void UpdateView(params object[] args) { }
    public void FixUpdate(params object[] args) { }
    public void PreDestroy(params object[] args) { }
    #endregion
}
