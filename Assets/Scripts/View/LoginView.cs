using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LoginView : BaseView
{
    [Header("UI���")]
    public Toggle saveIdCodeToggle;
    public InputField idInput;
    public Button closeBtn;
    public Button startBtn;
    public Text HyperLinkText;
    public Animator aniController;

    [Header("�����")]
    public bool isSaveIdCode;
    public string isSaveIdCodePrefs = "saveIdCode";
    public string idCode;
    public string idCodePrefs = "idCode";

    [Header("������")]
    public string hyperLinkUrl;

    [Header("����")]
    public int showHash;
    public int hideHash;

    public void InitView()
    {
        base.InitView();
        this.Initial();
    }

    public void UpdateEvent(E_EventDef eventDef)
    {
        base.UpdateEvent(eventDef);
        switch (eventDef)
        {
            case E_EventDef.LINK_SUCESS:
                if (IncludeMgr.bConectMgr != null) LinkSuccess();
                break;
            case E_EventDef.LINK_FAILED:
                if (IncludeMgr.bConectMgr != null) LinkFailed();
                break;
        }
    }

    public void Initial()
    {
        //config read and init
        isSaveIdCode = MyPlayerPrefs.GetBool(isSaveIdCodePrefs);
        saveIdCodeToggle.isOn = isSaveIdCode;
        if (saveIdCodeToggle)
        {
            idCode = MyPlayerPrefs.GetString(idCodePrefs);
        }
        else
        {
            idCode = string.Empty;
            MyPlayerPrefs.SetString(idCodePrefs, idCode);
        }
        idInput.text = idCode;

        //add ui listener
        idInput.onValueChanged.AddListener(onChangeIdCode);
        saveIdCodeToggle.onValueChanged.AddListener(onChangeIsSaveIdCode);
        startBtn.onClick.AddListener(onStartToPlay);
        closeBtn.onClick.AddListener(onClose);

        //init url
        HyperLinkText.text = $"<a href={hyperLinkUrl}>ȥ��ȡ</a>";

        //init aniamtion hash
        showHash = Animator.StringToHash("Show");
        hideHash = Animator.StringToHash("Hide");

        Show();
    }

    /// <summary>
    /// �޸�Id Code
    /// </summary>
    /// <param name="code"></param>
    public void onChangeIdCode(string code)
    {
        //��������ַ�
        var result = code.Replace(" ", string.Empty);
        result = result.Replace("\n", string.Empty);
        result = result.Replace("\r", string.Empty);
        result = result.Replace("\f", string.Empty);

        idInput.SetTextWithoutNotify(result);
        idCode = result;

        if (isSaveIdCode)
        {
            MyPlayerPrefs.SetString(isSaveIdCodePrefs, idCode);
        }
    }

    /// <summary>
    /// �޸��Ƿ񱣴�Id Code
    /// </summary>
    /// <param name="isOn"></param>
    public void onChangeIsSaveIdCode(bool isOn)
    {
        isSaveIdCode = isOn;
        MyPlayerPrefs.SetBool(isSaveIdCodePrefs, isSaveIdCode);

        if (!isSaveIdCode)
        {
            MyPlayerPrefs.SetString(idCodePrefs, string.Empty);
        }
    }

    /// <summary>
    /// ��������淨ʱ����
    /// </summary>
    public void onStartToPlay()
    {
        IncludeMgr.bConectMgr?.LinkStart(idCode);
        IncludeMgr.eventMgr.TriggerEvent(E_EventDef.START_TO_PLAY);
    }

    public void onClose()
    {
        //StartCoroutine(lateClose());
        //MonoController.Instance.PlayCoroutineMono(lateClose());
        IncludeCtl.mono.PlayCoroutineMono(lateClose());
    }

    IEnumerator lateClose()
    {
        Hide();
        yield return new  WaitForSeconds(1.0f);
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    /// <summary>
    /// ���ӳɹ�ʱ����
    /// </summary>
    protected void LinkSuccess()
    {
        if (isSaveIdCode)
        {
            MyPlayerPrefs.SetString(idCodePrefs, idCode);
        }

#if UNITY_EDITOR
        Debug.Log("���ӳɹ�");
#endif
        Hide();
        IncludeMgr.eventMgr.TriggerEvent(E_EventDef.LINK_SUCESS);
    }

    /// <summary>
    /// ����ʧ��ʱ����
    /// </summary>
    protected void LinkFailed()
    {
#if UNITY_EDITOR
        Debug.LogError("����ʧ��");
#endif
    }

    /// <summary>
    /// ��ʾUI
    /// </summary>
    protected void Show()
    {
        if (aniController != null)
        {
            aniController.Play(showHash);
        }
#if UNITY_EDITOR
        Debug.Log("��ʾ����뵯��");
#endif
    }

    /// <summary>
    /// �ر�UI
    /// </summary>
    protected void Hide()
    {
        if (aniController != null)
        {
            aniController.Play(hideHash);
        }
#if UNITY_EDITOR
        Debug.Log("�ر�����뵯��");
#endif
    }
}
