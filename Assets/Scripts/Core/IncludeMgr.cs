using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 单例模式管理器（纯单例，只用于处理逻辑的。原则上不能直接用mono，实在需要就用MonoCore处理帧更新问题）
/// </summary>
public static class IncludeMgr
{
    public static EventMgr eventMgr = new EventMgr();
    public static BConectMgr bConectMgr = new BConectMgr();
    public static PoolManager poolMgr = new PoolManager();
    public static BPlayerManager danmuMgr = new BPlayerManager();
}