using UnityEngine.UI;

public class DialogPanel : UIPanel
{
    private Image dialogBoxImage;
    private Text dialogBoxText;

    private void Awake()
    {
        dialogBoxImage = GetComponent<Image>();
        dialogBoxText = GetComponentInChildren<Text>();
    }

    public void StartDialog(string newDialog)
    {
        dialogBoxText.text = newDialog;

        OpenPanel();
    }

    public override void OpenPanel()
    {
        base.OpenPanel();
        dialogBoxImage.enabled = true;
        dialogBoxText.enabled = true;
    }

    public override void ClosePanel()
    {
        base.ClosePanel();
        dialogBoxImage.enabled = false;
        dialogBoxText.enabled = false;
    }
}
