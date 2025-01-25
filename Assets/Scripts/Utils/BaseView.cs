using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseView : BaseScript
{
    public void Awake()
    {
        //base.Awake();
        this.transform.parent = GlobalUI.canvas.transform;
    }
}
