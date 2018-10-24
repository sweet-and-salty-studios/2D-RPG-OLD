using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singelton<UIManager>
{
    //private GameObject inventoryPanel;
    //public DialogPanel DialogPanel { get; private set; }

    private void Awake()
    {
        //inventoryPanel = transform.GetChild(0).transform.Find("InventoryPanel").gameObject;
        //DialogPanel = transform.GetChild(0).transform.Find("DialogPanel").GetComponent<DialogPanel>();
    }

    private void Start()
    {
        //inventoryPanel.SetActive(false);
        //DialogPanel.ClosePanel();
    }

    private void Update()
    {
        
    }
}
