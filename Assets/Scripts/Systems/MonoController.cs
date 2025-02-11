using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

/// <summary>
/// 处理一些投入mono 帧更新 的问题
/// </summary>
public class MonoController : BaseMonoSingle<MonoController>
{
    //update-->lateUpdate-->viewUpdate
    //fixUpdate
    private UnityAction _updateEvent;
    private UnityAction _lateEvent;
    private UnityAction _viewUpdateEvent;
    private UnityAction _fixUpdateEvent;
    //private UnityAction _awakeEvent;

    //public List<IBaseScript> _scripts = new List<IBaseScript>();
    //private bool startUpdate = false;

    //所有注册在案继承了IBaseScript且需要批量进入帧更新（目前有BaseView）的脚本们
    private List<IBaseScript> _scripts = new List<IBaseScript>();

    /// <summary>
    /// 注册脚本批量处理帧更新问题
    /// </summary>
    /// <param name="script"></param>
    public void RegisterScriptUpdate(IBaseScript script)
    {
        this.AddFixUpdateMono(script.FixUpdate);
        this.AddUpdateMono(script.UpdateData);
        this.AddViewUpdateMono(script.UpdateView);
    }

    //public void RegisterScriptAwake(IBaseScript script)
    //{
    //    this.AddAwakeMono(script.Construct);
    //}

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

    //public void AddAwakeMono(UnityAction dosomthing)
    //{
    //    this._awakeEvent += dosomthing;
    //}
    //public void RemoteAwakeMono(UnityAction dosomthing)
    //{
    //    this._awakeEvent -= dosomthing;
    //}

    /// <summary>
    /// 开协程
    /// </summary>
    /// <param name="enu"></param>
    public void PlayCoroutineMono(IEnumerator enu)
    {
        StartCoroutine(enu);
    }

    //private void Awake()
    //{
    //    this._awakeEvent?.Invoke();
    //}

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

