using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        GlobalUI.canvas = canvas;
        GlobalUI.poolFather = Instantiate(new GameObject("poolFather"));
        GlobalUI.scriptObj = Instantiate(new GameObject("scriptObj"));



    }
}

//˳�����£�
//1.ResManager��������ע��õ���Դ
//2.GlobalUI��������ȫ��UI
//3.�ü̳�BaseScript�ġ�Ŀǰ���ڼ���״̬��Init��һ��
//4.��MonoCore��֡����

//��Ϸ֡���¹���
//�̳�BaseScript�����нű�����Ϊ