using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test2 :BaseView
{
    public void UpdateEvent(E_EventDef eventDef)
    {
        base.UpdateEvent(eventDef);
        switch (eventDef)
        {
            default:
                break;
        }
    }

    void Start()
    {
        IncludeMgr.eventMgr.printScripts();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
