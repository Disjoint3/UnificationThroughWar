using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class IncludeCtl
{
    /// <summary>
    /// mono������
    /// </summary>
    public static MonoController mono = MonoController.Instance;

    public static GameController game = GameController.Instance;
    /// <summary>
    /// ��ͼ������
    /// </summary>
    public static MapController map = MapController.Instance;
}
