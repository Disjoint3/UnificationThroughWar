using UnityEngine;

/// <summary>
/// ����ģʽ����������������ֻ���ڴ����߼��ġ�ԭ���ϲ���ֱ����mono��ʵ����Ҫ����MonoCore����֡�������⣩
/// </summary>
public static class SingleMgr
{
    public static EventController eventMgr = new EventController();
    public static BConectMgr bConectMgr = new BConectMgr();
    public static PoolManager poolMgr = new PoolManager();
    public static BPlayerManager danmuMgr = new BPlayerManager();

    public static MonoController monoHelper = new MonoController();

}
/// <summary>
/// ��Ŀ���ã�gamecontroller����
/// </summary>
public static class GameData
{
    public readonly static string accessKeySecret = "TA3KtwluHvXMxBawji6XoScchFATN8";
    public readonly static string accessKeyId = "TQMoRhFy2lSvBzjYjHXEuzXx";
    public readonly static string appId = "1729566058692";   //��������Ŀid�������ǵø���
}

/// <summary>
/// ��Ŀʹ�õ���ȫ��UI��gamecontroller����
/// </summary>
public static class GlobalUI
{
    public static GameObject canvas;
    public static GameObject poolFather;
    public static GameObject scriptObj;
}

/// <summary>
/// ��Ŀ�õ�����Դ��ַ��resmanager����
/// </summary>
public static class ResUrl
{
    //Prefab��λ��Assets/Resources/Prefab/enemy.prefab    --->    Resources.Load<GameObject>("Prefab/enemy")
    public readonly static string pool_test1 = "Prefab/test1";

}
