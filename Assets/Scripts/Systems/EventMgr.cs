using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// �¼�������
/// </summary>
public class EventMgr
{
    /// <summary>
    /// ֱ�ӽ����¼������������е��¼�
    /// </summary>
    public Dictionary<E_EventDef, UnityAction> eventList = new Dictionary<E_EventDef, UnityAction>();

    //public Dictionary<IBaseScript,IBaseScript> scripts = new Dictionary<IBaseScript, IBaseScript> ();

    //ע���ڰ� ��Ҫʹ��ʱ��ϵͳ�Ľű���
    public List<IBaseScript> scripts = new List<IBaseScript>();

    /// <summary>
    /// ע��ű������������¼�
    /// </summary>
    /// <param name="script"></param>
    public void RegisterScript(IBaseScript script)
    {
        //this.scripts.Add(script, script);
        this.scripts.Add(script);
    }

    public void UnRegisterScript(IBaseScript script)
    {
        //this.scripts.Remove(script);
        this.scripts.Remove(script);
    }

    /// <summary>
    /// �����¼�
    /// </summary>
    /// <param name="eventDef"></param>
    public void TriggerEvent(E_EventDef eventDef)
    {
        foreach (IBaseScript sc in this.scripts)
        {
            sc.UpdateEvent(eventDef);
        }
        this.eventList[eventDef]?.Invoke();
    }

    /// <summary>
    /// ����¼�ϵͳע�ᵽ�����нű�
    /// </summary>
    public void printScripts()
    {
        string str = "-----------�¼�ϵͳdebug���-----------\n";
        int index = 0;
        foreach (IBaseScript item in this.scripts)
        {
            str += ++index + ": " + item.GetType().Name + "\n";
        }

        str += "\n*********�йܵ��¼�ϵͳ������¼��������£�\n";

        foreach (var item in eventList.Keys)
        {
            str += ++index + ": " + item.GetType().Name + "\n";
        }

        str += "-----------�¼�ϵͳdebug������-----------\n";

        Debug.Log(str);
    }

}

/// <summary>
/// �¼������ӿ�
/// </summary>
public interface IEventListen
{
    public void UpdateEvent(E_EventDef eventDef);
}