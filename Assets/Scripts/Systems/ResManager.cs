using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 资源管理器
/// </summary>
public class ResManager: BaseMgr
{
    private Dictionary<E_ResUrl,object> _resDic = new Dictionary<E_ResUrl, object>();

    private int _loadedCnt = 0;

    /// <summary>
    /// 加载全部注册的资源
    /// </summary>
    public void LoadAllResources()
    {
        this._loadedCnt = 0;
        this.LoadResourceAsync();
    }

    /// <summary>
    /// 异步加载资源
    /// </summary>
    /// <param name="path">资源路径（写到ResUrl枚举中)</param>
    /// <param name="onLoadComplete"></param>
    /// <param name="showProgress">是否展示进度条</param>
    /// <param name="progressBar">进度条样式（继承IProgressBar接口）</param>
    private void LoadResourceAsync(UnityAction onLoadComplete = null, bool showProgress = false, IProgressBar progressBar = null)
    {
        //StartCoroutine(LoadResourceCoroutine(path, onLoadComplete, showProgress, progressBar));
        //MonoController.Instance.PlayCoroutineMono(LoadResourcesAsync(onLoadComplete, showProgress, progressBar));
        IncludeCtl.mono.PlayCoroutineMono(LoadResourcesAsync(onLoadComplete, showProgress, progressBar));
    }

    private IEnumerator LoadResourcesAsync(UnityAction onLoadComplete, bool showProgress = false, IProgressBar progressBar = null)
    {
        List<string> urlList = new List<string>();
        foreach (E_ResUrl item in Enum.GetValues(typeof(E_ResUrl)))
        {
            urlList.Add(item.GetValue());
        }

        foreach (string path in urlList)
        {
            ResourceRequest request = Resources.LoadAsync(path);
            request.completed += (AsyncOperation op) =>
            {
                this._loadedCnt++;
                if (showProgress)
                {
                    UpdateProgress(progressBar);
                }
                if (this._loadedCnt == urlList.Count)
                {
                    onLoadComplete?.Invoke(); // 调用加载完成事件
                }
            };

            while (!request.isDone)
            {
                if (showProgress)
                {
                    UpdateProgress(progressBar);
                }
                yield return null;
            }
        }
    }

    private void UpdateProgress(IProgressBar progressBar)
    {
        progressBar.fillAmount = (float)this._loadedCnt / (float)this._resDic.Count;
    }

    /// <summary>
    /// 获取资源
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="resourceType">资源标识</param>
    /// <returns></returns>
    public T GetResource<T>(E_ResUrl resourceType) where T : class
    {
        object res = null;
        this._resDic.TryGetValue(resourceType, out res);
#if UNITY_EDITOR
        if (!(res is T))
        {
            Debug.Log("[ResManager: ] res is not " + typeof(T).Name);
        }
#endif
        return res as T;
    }
}

/// <summary>
/// 进度条UI要继承的接口
/// </summary>
public interface IProgressBar
{
    /// <summary>
    /// 进度条UI的数值参考
    /// </summary>
    public float fillAmount { set; get; }

    public void SetValue() { }
}