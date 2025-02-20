using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��̬������ʼ����
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
