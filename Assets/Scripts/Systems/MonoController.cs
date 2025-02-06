using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

/// <summary>
/// 处理一些投入mono 帧更新 的问题
/// </summary>
public class MonoController : BaseMonoSingle<MonoController>
{
    private UnityAction _updateEvent;
    private UnityAction _lateEvent;
    private UnityAction _viewUpdateEvent;
    private UnityAction _fixUpdateEvent;

    //public List<IBaseScript> _scripts = new List<IBaseScript>();
    //private bool startUpdate = false;

    public void AddViewUpdateMono(UnityAction dosomthing)
    {
        this._viewUpdateEvent += dosomthing;
    }

    public void RemoteViewUpdateMono(UnityAction dosomthing)
    {
        this._viewUpdateEvent -= dosomthing;
    }

    public void AddUpdateMono(UnityAction dosomthing)
    {
        this._updateEvent += dosomthing;
    }
    public void RemoteUpdateMono(UnityAction dosomthing)
    {
        this._updateEvent -= dosomthing;
    }

    public void AddLateUpdateMono(UnityAction dosomthing)
    {
        this._lateEvent += dosomthing;
    }
    public void RemoteLateUpdateMono(UnityAction dosomthing)
    {
        this._lateEvent -= dosomthing;
    }

    public void AddFixUpdateMono(UnityAction dosomthing)
    {
        this._fixUpdateEvent += dosomthing;
    }
    public void RemoteFixUpdateMono(UnityAction dosomthing)
    {
        this._fixUpdateEvent -= dosomthing;
    }

    /// <summary>
    /// 开协程
    /// </summary>
    /// <param name="enu"></param>
    public void PlayCoroutineMono(IEnumerator enu)
    {
        StartCoroutine(enu);
    }

    private void Update()
    {
        if (GlobalDef.startUpdate)
        {
            this._updateEvent?.Invoke();
            this._lateEvent?.Invoke();
            this._viewUpdateEvent?.Invoke();
        }
    }

    private void FixedUpdate()
    {
        if (GlobalDef.startUpdate)
        {
            this._fixUpdateEvent?.Invoke();
        }
    }
}

