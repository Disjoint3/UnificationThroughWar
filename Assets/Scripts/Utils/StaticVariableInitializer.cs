using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 静态变量初始化器
/// </summary>
public class StaticVariableInitializer : MonoBehaviour
{
    [Header("GlobalDef")]
    public GameObject canvas;
    private void Awake()
    {
        //UI
        GlobalDef.canvas = canvas;
        GlobalDef.poolFather = Instantiate(new GameObject("poolFather"));
        GlobalDef.scriptObj = Instantiate(new GameObject("scriptObj"));
    }
}
