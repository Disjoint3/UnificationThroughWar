
//类型统一用enum。
//若要枚举字符串的效果，直接用枚举特性Description即可。

using System.ComponentModel;

/// <summary>
/// 事件定义
/// </summary>
public enum E_EventDef
{
    //bilibili连接
    START_TO_PLAY,   //点击开启玩法按钮时触发
    LINK_SUCESS,   //连接成功时触发
    LINK_FAILED,    //连接失败时触发

 
    CONNECT_SUCESS, //
    CONNECT_FAILED,


    RESOURCE_LOAD_SUCESS, //资源加载完毕
}

/// <summary>
/// 对象池的对象类都注册一个
/// </summary>
public enum E_PoolType
{
    //弹幕互动数据
    VISITOR,    //(like enter)
    DANMU,
    GIFT,
    SUPER_CHAT,
    GUARD_BUY,

    //测试用
    TEST,
    
}

/// <summary>
/// 项目用到的资源地址（resmanager处理）
/// </summary>
public enum E_ResUrl
{
    //public const string pool_test1 = "Prefab/test1";
    //public const string LoginView = "Prefab/Views/LoginView";

    //Prefab：位于Assets/Resources/Prefab/enemy.prefab    --->    Resources.Load<GameObject>("Prefab/enemy")
    [Description("Prefab/test")]
    pool_test1,
    [Description("Prefab/Views/LoginView")]
    LoginView,
}