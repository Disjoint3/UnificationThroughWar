public interface IBaseScript:IEventListen
{
    /// <summary>
    /// 代替原先的构造函数使用，构造时运行一次。
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
    /// 销毁前执行，然后销毁
    /// </summary>
    /// <param name="args"></param>
    public void PreDestroy();
}

//Construct，代替原先的构造函数使用，构造时运行一次。
//initdata和initview，mgr只运行一次，在其构造出来的时候
//                    view则在每次打开关闭时，都会运行一次。
//执行顺序依次是：  Construct--->InitData--->InitView
//循环中则是：    UpdateData--->UpdateView
//				  FixUpdate
//PreDestroy：销毁前执行，然后销毁



