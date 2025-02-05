using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// �¼�������
/// </summary>
public class EventController
{
    /// <summary>
    /// ֱ�ӽ����¼������������е��¼�
    /// </summary>
    public Dictionary<E_EventDef, UnityAction> eventList = new Dictionary<E_EventDef, UnityAction>();

    /// <summary>
    /// �����¼�
    /// </summary>
    /// <param name="eventDef"></param>
    public void TriggerEvent(E_EventDef eventDef)
    {
        for (int i = 0; i < MonoController.Instance._scripts.Count; i++)
        {
            MonoController.Instance._scripts[i].UpdateEvent(eventDef);
        }

        //MonoCore.Instance.OnceMono(this.eventList[eventDef]);
        this.eventList[eventDef]?.Invoke();
    }

    /// <summary>
    /// ����¼�ϵͳע�ᵽ�����нű�
    /// </summary>
    public void printScripts()
    {
        string str = "-----------�¼�ϵͳdebug���-----------\n";
        int index = 0;
        foreach (var item in MonoController.Instance._scripts)
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