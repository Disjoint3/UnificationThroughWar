using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BaseScript : MonoBehaviour,IEventListen
{
    public void Awake()
    {
        SingleMgr.eventMgr._scripts.Add(this);
        Debug.Log("BaseScript Awake");
    }

    /// <summary>
    /// �¼����������������Ҫʹ���¼���ֱ����������д�ú������ɣ�
    /// </summary>
    /// <param name="eventDef"></param>
    public virtual void UpdateEvent(E_EventDef eventDef)
    {
        Debug.Log("�¼�" + eventDef.ToString() + "��" + this + "����");
    }
}
