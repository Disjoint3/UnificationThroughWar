public interface IBaseScript:IEventListen
{
    /// <summary>
    /// ����ԭ�ȵĹ��캯��ʹ�ã�����ʱ����һ�Ρ�
    /// </summary>
    public void Construct();

    public void InitData();

    public void InitView();

    public void UpdateData();

    public void UpdateView();

    public void FixUpdate();

    //public void Construct(params object[] args);

    //public void InitData(params object[] args);

    //public void InitView(params object[] args);

    //public void UpdateData(params object[] args);

    //public void UpdateView(params object[] args);

    //public void FixUpdate(params object[] args);
    //public void PreDestroy(params object[] args);

    /// <summary>
    /// ����ǰִ�У�Ȼ������
    /// </summary>
    /// <param name="args"></param>
    public void PreDestroy();
}

//Construct������ԭ�ȵĹ��캯��ʹ�ã�����ʱ����һ�Ρ�
//initdata��initview��mgrֻ����һ�Σ����乹�������ʱ��
//                    view����ÿ�δ򿪹ر�ʱ����������һ�Ρ�
//ִ��˳�������ǣ�  Construct--->InitData--->InitView
//ѭ�������ǣ�    UpdateData--->UpdateView
//				  FixUpdate
//PreDestroy������ǰִ�У�Ȼ������



