using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// ����һЩͶ��mono֡���µ�����
/// </summary>
public class MonoController : BaseMonoSingle<MonoController>
{
    private UnityAction _initEvent;
    private UnityAction _updateEvent;
    private UnityAction _lateEvent;
    private UnityAction _destroyEvent;

    public List<IBaseScript> _scripts = new List<IBaseScript>();

    private bool startUpdate = false;

    public void InitMono(UnityAction dosomthing)
    {
        dosomthing?.Invoke();
    }

    public void UpdateMono(UnityAction dosomthing)
    {
        this._updateEvent += dosomthing;
    }

    public void LateUpdateMono(UnityAction dosomthing)
    {
        this._lateEvent += dosomthing;
    }

    public void OnceMono(UnityAction dosomthing)
    {
        dosomthing?.Invoke();
    }

    public void PlayCoroutineMono(IEnumerator enu)
    {
        StartCoroutine(enu);
    }

    private void Update()
    {
        if (startUpdate)
        {
            this._updateEvent?.Invoke();
            this._lateEvent?.Invoke();
        }
    }
}

