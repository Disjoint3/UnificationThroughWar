using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LoginView : BaseView
{
    [Header("UI组件")]
    public Toggle saveIdCodeToggle;
    public InputField idInput;
    public Button closeBtn;
    public Button startBtn;
    public Text HyperLinkText;
    public Animator aniController;

    [Header("身份码")]
    public bool isSaveIdCode;
    public string isSaveIdCodePrefs = "saveIdCode";
    public string idCode;
    public string idCodePrefs = "idCode";

    [Header("超链接")]
    public string hyperLinkUrl;

    [Header("动画")]
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
        HyperLinkText.text = $"<a href={hyperLinkUrl}>去获取</a>";

        //init aniamtion hash
        showHash = Animator.StringToHash("Show");
        hideHash = Animator.StringToHash("Hide");

        Show();
    }

    /// <summary>
    /// 修改Id Code
    /// </summary>
    /// <param name="code"></param>
    public void onChangeIdCode(string code)
    {
        //处理错误字符
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
    /// 修改是否保存Id Code
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
    /// 点击开启玩法时触发
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
    /// 连接成功时触发
    /// </summary>
    protected void LinkSuccess()
    {
        if (isSaveIdCode)
        {
            MyPlayerPrefs.SetString(idCodePrefs, idCode);
        }

#if UNITY_EDITOR
        Debug.Log("连接成功");
#endif
        Hide();
        IncludeMgr.eventMgr.TriggerEvent(E_EventDef.LINK_SUCESS);
    }

    /// <summary>
    /// 连接失败时触发
    /// </summary>
    protected void LinkFailed()
    {
#if UNITY_EDITOR
        Debug.LogError("连接失败");
#endif
    }

    /// <summary>
    /// 显示UI
    /// </summary>
    protected void Show()
    {
        if (aniController != null)
        {
            aniController.Play(showHash);
        }
#if UNITY_EDITOR
        Debug.Log("显示身份码弹框");
#endif
    }

    /// <summary>
    /// 关闭UI
    /// </summary>
    protected void Hide()
    {
        if (aniController != null)
        {
            aniController.Play(hideHash);
        }
#if UNITY_EDITOR
        Debug.Log("关闭身份码弹框");
#endif
    }
}
