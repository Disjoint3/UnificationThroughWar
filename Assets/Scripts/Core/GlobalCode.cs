using UnityEngine;

/// <summary>
/// 单例模式管理器（纯单例，只用于处理逻辑的。原则上不能直接用mono，实在需要就用MonoCore处理帧更新问题）
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
/// 项目设置（gamecontroller处理）
/// </summary>
public static class GameData
{
    public readonly static string accessKeySecret = "TA3KtwluHvXMxBawji6XoScchFATN8";
    public readonly static string accessKeyId = "TQMoRhFy2lSvBzjYjHXEuzXx";
    public readonly static string appId = "1729566058692";   //测试用项目id，后续记得改下
}

/// <summary>
/// 项目使用到的全局UI（gamecontroller处理）
/// </summary>
public static class GlobalUI
{
    public static GameObject canvas;
    public static GameObject poolFather;
    public static GameObject scriptObj;
}

/// <summary>
/// 项目用到的资源地址（resmanager处理）
/// </summary>
public static class ResUrl
{
    //Prefab：位于Assets/Resources/Prefab/enemy.prefab    --->    Resources.Load<GameObject>("Prefab/enemy")
    public readonly static string pool_test1 = "Prefab/test1";

}
