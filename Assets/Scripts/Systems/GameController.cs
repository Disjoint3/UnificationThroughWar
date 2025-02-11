using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��Ϸ���̴���
/// </summary>
public class GameController : BaseMonoSingle<GameController>
{
    [Header("��Ŀ���ã�����ʱ��ô�㣩")]
    public GameObject canvas;
    //public string accessKeySecret;
    //public string accessKeyId;
    //public string appId;


    private void Awake()
    {
        //GlobalUI
        GlobalDef.canvas = canvas;
        GlobalDef.poolFather = Instantiate(new GameObject("poolFather"));
        GlobalDef.scriptObj = Instantiate(new GameObject("scriptObj"));

    }
}

//˳�����£�
//1.ResManager��������ע��õ���Դ
//2.GlobalUI��������ȫ��UI
//3.�ü̳�BaseScript�ġ�Ŀǰ���ڼ���״̬��Init��һ��
//4.��MonoCore��֡����

//��Ϸ֡���¹���
//�̳�BaseScript�����нű����ű�������update��Щ֡���£����÷�װ�õĺ���������