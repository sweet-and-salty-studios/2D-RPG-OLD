public class UIPanel : Singelton<UIPanel>
{
    public bool IsOpen
    {
        get;
        private set;
    }

    public virtual void OpenPanel()
    {
        IsOpen = true;
    }

    public virtual void ClosePanel()
    {
        IsOpen = false;
    }
}
