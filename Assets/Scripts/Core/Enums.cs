
/// <summary>
/// �¼�����
/// </summary>
public enum E_EventDef
{
    //bilibili����
    START_TO_PLAY,   //��������淨��ťʱ����
    LINK_SUCESS,   //���ӳɹ�ʱ����
    LINK_FAILED,    //����ʧ��ʱ����

 
    CONNECT_SUCESS, //
    CONNECT_FAILED,


    RESOURCE_LOAD_SUCESS, //��Դ�������
}

/// <summary>
/// ����صĶ����඼ע��һ��
/// </summary>
public enum E_PoolType
{
    //��Ļ��������
    VISITOR,    //(like enter)
    DANMU,
    GIFT,
    SUPER_CHAT,
    GUARD_BUY,

    //������
    TEST,
    
}
