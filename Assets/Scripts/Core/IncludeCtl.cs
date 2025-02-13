using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class IncludeCtl
{
    /// <summary>
    /// mono处理器
    /// </summary>
    public static MonoController mono = MonoController.Instance;

    public static GameController game = GameController.Instance;
    /// <summary>
    /// 地图处理器
    /// </summary>
    public static MapController map = MapController.Instance;
}
