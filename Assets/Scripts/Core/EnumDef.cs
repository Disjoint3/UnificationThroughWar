
//����ͳһ��enum��
//��Ҫö���ַ�����Ч����ֱ����ö������Description���ɡ�

using System.ComponentModel;

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

/// <summary>
/// ��Ŀ�õ�����Դ��ַ��resmanager����
/// </summary>
public enum E_ResUrl
{
    //public const string pool_test1 = "Prefab/test1";
    //public const string LoginView = "Prefab/Views/LoginView";

    //Prefab��λ��Assets/Resources/Prefab/enemy.prefab    --->    Resources.Load<GameObject>("Prefab/enemy")
    [Description("Prefab/test")]
    pool_test1,
    [Description("Prefab/Views/LoginView")]
    LoginView,
}