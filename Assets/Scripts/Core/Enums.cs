
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
