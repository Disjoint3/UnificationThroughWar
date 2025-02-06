using UnityEngine;

/// <summary>
/// ���������࣬���̳�mono
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
        Debug.Log("�¼�" + eventDef.ToString() + "��" + this + "����");
    }

    #region ֡���º���
    public void UpdateData(params object[] args) { }
    public void UpdateView(params object[] args) { }
    public void FixUpdate(params object[] args) { }
    public void PreDestroy(params object[] args) { }
    #endregion
}
