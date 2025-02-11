using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

/// <summary>
/// ����һЩͶ��mono ֡���� ������
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

    //����ע���ڰ��̳���IBaseScript����Ҫ��������֡���£�Ŀǰ��BaseView���Ľű���
    private List<IBaseScript> _scripts = new List<IBaseScript>();

    /// <summary>
    /// ע��ű���������֡��������
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
    /// ��Э��
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

