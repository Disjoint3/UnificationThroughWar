using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : BaseMgr
{
    [Header("��Ŀ���ã�����ʱ��ô�㣩")]
    public GameObject canvas;
    public string accessKeySecret;
    public string accessKeyId;
    public string appId;

    private void Awake()
    {
        GlobalUI.canvas = canvas;
        GlobalUI.poolFather = Instantiate(new GameObject("Pool"));
        
    }


    void testFun()
    {

    }
}
