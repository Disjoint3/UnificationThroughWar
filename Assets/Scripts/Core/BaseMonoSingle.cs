using UnityEngine;

/// <summary>
/// �̳�mono�ĵ�������
/// </summary>
/// <typeparam name="T"></typeparam>
public class BaseMonoSingle<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    /// <summary>
    /// �߳���
    /// </summary>
    private static readonly object _lock = new object();
    /// <summary>
    /// �����Ƿ������˳�
    /// </summary>
    protected static bool ApplicationIsQuitting { get; private set; }
    /// <summary>
    /// �Ƿ�Ϊȫ�ֵ���
    /// </summary>
    protected static bool isGolbal = true;

    static BaseMonoSingle()
    {
        ApplicationIsQuitting = false;
    }

    public static T Instance
    {
        get
        {
            if (ApplicationIsQuitting)
            {
                if (Debug.isDebugBuild)
                {
                    Debug.LogWarning("[MonoSingle] " + typeof(T));
                }

                return null;
            }

            lock (_lock)
            {
                if (_instance == null)
                {
                    // ���ڳ�������Ѱ
                    _instance = FindObjectsOfType(typeof(T)) as T;

                    if (FindObjectsOfType(typeof(T)).Length > 1)
                    {
                        if (Debug.isDebugBuild)
                        {
                            Debug.LogWarning("[MonoSingle] " + typeof(T).Name + " should never be more than 1 in scene!");
                        }

                        return _instance;
                    }

                    // �������Ҳ����ʹ������������
                    if (_instance == null)
                    {
                        GameObject singletonObj = new GameObject();
                        _instance = singletonObj.AddComponent<T>();
                        singletonObj.name = "[MonoSingle] " + typeof(T);
                        singletonObj.transform.parent = GlobalDef.scriptObj.transform;

                        if (isGolbal && Application.isPlaying)
                        {
                            DontDestroyOnLoad(singletonObj);
                        }

                        return _instance;
                    }
                }

                return _instance;
            }
        }
    }

    /// <summary>
    /// ���������н��������˳�ʱ����������ʵ���
    /// </summary>
    public void OnApplicationQuit()
    {
        ApplicationIsQuitting = true;
    }
}

