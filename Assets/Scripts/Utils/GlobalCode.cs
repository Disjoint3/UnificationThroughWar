using UnityEngine;

/// <summary>
/// ����ģʽ�����̳�mono�Ĵ�������������������ʱ��ô�š��������뵽����ô����ȽϺã�
/// </summary>
public static class SingleMgr   //���еĵ���ֱ��������ű�ע��
{
    public static EventManager eventMgr = new EventManager();
    public static BConectMgr bConectMgr = new BConectMgr();
    public static PoolManager poolMgr = new PoolManager();
    public static BPlayerManager danmuMgr = new BPlayerManager();

}
/// <summary>
/// ��Ŀ���ã�����ʱ��ô�š��������뵽����ô����ȽϺã�
/// </summary>
public static class GameData
{
    public readonly static string accessKeySecret = "TA3KtwluHvXMxBawji6XoScchFATN8";
    public readonly static string accessKeyId = "TQMoRhFy2lSvBzjYjHXEuzXx";
    public readonly static string appId = "1729566058692";   //��������Ŀid�������ǵø���
}

/// <summary>
/// ��Ŀʹ�õ���ȫ��UI������ʱ��ô�š��������뵽����ô����ȽϺã�
/// </summary>
public static class GlobalUI
{
    public static GameObject canvas;
    public static GameObject poolFather;
}

/// <summary>
/// ��Ŀ�õ�����Դ��ַ������ʱ��ô�š��������뵽����ô����ȽϺã�
/// </summary>
public static class ResUrl
{
    //Prefab��λ��Assets/Resources/Prefab/enemy.prefab    --->    Resources.Load<GameObject>("Prefab/enemy")
    public readonly static string pool_test1 = "Prefab/test1";

}
