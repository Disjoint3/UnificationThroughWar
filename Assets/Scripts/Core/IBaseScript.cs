public interface IBaseScript:IEventListen
{
    public void Construct();

    public void InitData(params object[] args);

    public void InitView(params object[] args);

    public void UpdateData(params object[] args);

    public void UpdateView(params object[] args);

    public void Destroy(params object[] args);
}





