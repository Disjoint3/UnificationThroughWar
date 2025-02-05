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
    /// �첽������Դ
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="path">��Դ·����д��ResUrlö����)</param>
    /// <param name="onLoadComplete"></param>
    /// <param name="showProgress">�Ƿ�չʾ������</param>
    /// <param name="progressBar">��������ʽ���̳�IProgressBar�ӿڣ�</param>
    public void LoadResourceAsync<T>(string path, UnityAction<T> onLoadComplete, bool showProgress = false, IProgressBar progressBar = null) where T : UnityEngine.Object
    {
        //StartCoroutine(LoadResourceCoroutine(path, onLoadComplete, showProgress, progressBar));
        MonoController.Instance.PlayCoroutineMono(LoadResourceCoroutine(path, onLoadComplete, showProgress, progressBar));
    }

    /// <summary>
    /// ������Դ
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="path"></param>
    /// <param name="onLoadComplete"></param>
    /// <param name="showProgress"></param>
    /// <param name="progressBar"></param>
    /// <returns></returns>
    private IEnumerator LoadResourceCoroutine<T>(string path, UnityAction<T> onLoadComplete, bool showProgress, IProgressBar progressBar) where T : UnityEngine.Object
    {
        // �����첽��������
        ResourceRequest request = Resources.LoadAsync<T>(path);

        // ��ʾ�������������Ҫ��
        if (showProgress && progressBar != null)
        {
            while (!request.isDone)
            {
                progressBar.fillAmount = request.progress;
                yield return null;
            }
        }

        // �������
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

//public class ResourceLoaderExample : MonoBehaviour
//{
//    public Image progressBar; // ָ��������UI

//    void Start()
//    {
//        // �첽����һ��Ԥ����
//        ResourceManager.Instance.LoadResourceAsync<GameObject>("Prefabs/MyPrefab", OnLoadComplete, true, progressBar);
//    }

//    private void OnLoadComplete(GameObject obj)
//    {
//        if (obj != null)
//        {
//            Debug.Log("Resource loaded successfully!");
//            // �ڳ�����ʵ�������ص�Ԥ����
//            Instantiate(obj);
//        }
//        else
//        {
//            Debug.LogError("Failed to load resource.");
//        }
//    }
//}