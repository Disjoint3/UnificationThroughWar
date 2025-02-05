using System;
using System.Collections;
using System.Net.Mail;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ResManager: BaseMgr
{
    /// <summary>
    /// 异步加载资源
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="path">资源路径（写到ResUrl枚举中)</param>
    /// <param name="onLoadComplete"></param>
    /// <param name="showProgress">是否展示进度条</param>
    /// <param name="progressBar">进度条样式（继承IProgressBar接口）</param>
    public void LoadResourceAsync<T>(string path, UnityAction<T> onLoadComplete, bool showProgress = false, IProgressBar progressBar = null) where T : UnityEngine.Object
    {
        //StartCoroutine(LoadResourceCoroutine(path, onLoadComplete, showProgress, progressBar));
        MonoController.Instance.PlayCoroutineMono(LoadResourceCoroutine(path, onLoadComplete, showProgress, progressBar));
    }

    /// <summary>
    /// 加载资源
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="path"></param>
    /// <param name="onLoadComplete"></param>
    /// <param name="showProgress"></param>
    /// <param name="progressBar"></param>
    /// <returns></returns>
    private IEnumerator LoadResourceCoroutine<T>(string path, UnityAction<T> onLoadComplete, bool showProgress, IProgressBar progressBar) where T : UnityEngine.Object
    {
        // 创建异步加载请求
        ResourceRequest request = Resources.LoadAsync<T>(path);

        // 显示进度条（如果需要）
        if (showProgress && progressBar != null)
        {
            while (!request.isDone)
            {
                progressBar.fillAmount = request.progress;
                yield return null;
            }
        }

        // 加载完成
        if (request.asset != null)
        {
            onLoadComplete?.Invoke(request.asset as T);
        }
        else
        {
            Debug.LogError("Failed to load resource: " + path);
        }
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

//public class ResourceLoaderExample : MonoBehaviour
//{
//    public Image progressBar; // 指定进度条UI

//    void Start()
//    {
//        // 异步加载一个预制体
//        ResourceManager.Instance.LoadResourceAsync<GameObject>("Prefabs/MyPrefab", OnLoadComplete, true, progressBar);
//    }

//    private void OnLoadComplete(GameObject obj)
//    {
//        if (obj != null)
//        {
//            Debug.Log("Resource loaded successfully!");
//            // 在场景中实例化加载的预制体
//            Instantiate(obj);
//        }
//        else
//        {
//            Debug.LogError("Failed to load resource.");
//        }
//    }
//}