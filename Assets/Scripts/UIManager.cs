using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singelton<UIManager>
{
    private GameObject inventoryPanel;

    private void Awake()
    {
        inventoryPanel = transform.GetChild(0).transform.Find("InventoryPanel").gameObject;
    }

    private void Start()
    {
        inventoryPanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryPanel.SetActive(!inventoryPanel.activeSelf);
        }
    }
}
