using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����ģʽ����������������ֻ���ڴ����߼��ġ�ԭ���ϲ���ֱ����mono��ʵ����Ҫ����MonoCore����֡�������⣩
/// </summary>
public static class IncludeMgr
{
    public static EventMgr eventMgr = new EventMgr();
    public static BConectMgr bConectMgr = new BConectMgr();
    public static PoolManager poolMgr = new PoolManager();
    public static BPlayerManager danmuMgr = new BPlayerManager();
}