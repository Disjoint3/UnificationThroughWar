using UnityEngine;

/// <summary>
/// 单例模式（不继承mono的纯单例）管理器（先暂时这么放、后续想想到底怎么处理比较好）
/// </summary>
public static class SingleMgr   //所有的单例直接在这个脚本注册
{
    public static EventManager eventMgr = new EventManager();
    public static BConectMgr bConectMgr = new BConectMgr();
    public static PoolManager poolMgr = new PoolManager();
    public static BPlayerManager danmuMgr = new BPlayerManager();

}
/// <summary>
/// 项目设置（先暂时这么放、后续想想到底怎么处理比较好）
/// </summary>
public static class GameData
{
    public readonly static string accessKeySecret = "TA3KtwluHvXMxBawji6XoScchFATN8";
    public readonly static string accessKeyId = "TQMoRhFy2lSvBzjYjHXEuzXx";
    public readonly static string appId = "1729566058692";   //测试用项目id，后续记得改下
}

/// <summary>
/// 项目使用到的全局UI（先暂时这么放、后续想想到底怎么处理比较好）
/// </summary>
public static class GlobalUI
{
    public static GameObject canvas;
    public static GameObject poolFather;
}

/// <summary>
/// 项目用到的资源地址（先暂时这么放、后续想想到底怎么处理比较好）
/// </summary>
public static class ResUrl
{
    //Prefab：位于Assets/Resources/Prefab/enemy.prefab    --->    Resources.Load<GameObject>("Prefab/enemy")
    public readonly static string pool_test1 = "Prefab/test1";

}
