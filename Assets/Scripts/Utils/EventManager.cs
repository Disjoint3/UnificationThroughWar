using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �¼�������
/// </summary>
public class EventManager
{
    public List<BaseScript> _scripts = new List<BaseScript>();

    /// <summary>
    /// �����¼�
    /// </summary>
    /// <param name="eventDef"></param>
    public void TriggerEvent(E_EventDef eventDef)
    {
        for (int i = 0; i < this._scripts.Count; i++)
        {
            this._scripts[i].UpdateEvent(eventDef);
        }
    }

    /// <summary>
    /// ����¼�ϵͳע�ᵽ�����нű�
    /// </summary>
    public void printScripts()
    {
        string str = "-----------�¼�ϵͳdebug���-----------\n";
        int index = 0;
        foreach (var item in _scripts)
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