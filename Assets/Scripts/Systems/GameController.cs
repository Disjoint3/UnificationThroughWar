using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : BaseMonoSingle<GameController>
{
    [Header("项目设置（先暂时这么搞）")]
    public GameObject canvas;
    //public string accessKeySecret;
    //public string accessKeyId;
    //public string appId;

    private void Awake()
    {

        //GlobalUI
        GlobalUI.canvas = canvas;
        GlobalUI.poolFather = Instantiate(new GameObject("poolFather"));
        GlobalUI.scriptObj = Instantiate(new GameObject("scriptObj"));



    }
}

//顺序如下：
//1.ResManager加载所有注册好的资源
//2.GlobalUI加载所有全局UI
//3.让继承BaseScript的、目前处于激活状态的Init跑一遍
//4.让MonoCore打开帧更新

//游戏帧更新管理：
//继承BaseScript的所有脚本，均为