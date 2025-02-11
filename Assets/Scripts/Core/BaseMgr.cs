using UnityEngine;

/// <summary>
/// ���������࣬���̳�mono
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
        Debug.Log("�¼�" + eventDef.ToString() + "��" + this + "����");
    }

    #region ֡���º���
    public void UpdateData() { }
    public void UpdateView() { }
    public void FixUpdate() { }
    public void PreDestroy() { }
    #endregion
}
