using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// ��Դ������
/// </summary>
public class ResManager: BaseMgr
{
    private Dictionary<E_ResUrl,object> _resDic = new Dictionary<E_ResUrl, object>();

    private int _loadedCnt = 0;

    /// <summary>
    /// ����ȫ��ע�����Դ
    /// </summary>
    public void LoadAllResources()
    {
        this._loadedCnt = 0;
        this.LoadResourceAsync();
    }

    /// <summary>
    /// �첽������Դ
    /// </summary>
    /// <param name="path">��Դ·����д��ResUrlö����)</param>
    /// <param name="onLoadComplete"></param>
    /// <param name="showProgress">�Ƿ�չʾ������</param>
    /// <param name="progressBar">��������ʽ���̳�IProgressBar�ӿڣ�</param>
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
                    onLoadComplete?.Invoke(); // ���ü�������¼�
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
    /// ��ȡ��Դ
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="resourceType">��Դ��ʶ</param>
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
/// ������UIҪ�̳еĽӿ�
/// </summary>
public interface IProgressBar
{
    /// <summary>
    /// ������UI����ֵ�ο�
    /// </summary>
    public float fillAmount { set; get; }

    public void SetValue() { }
}