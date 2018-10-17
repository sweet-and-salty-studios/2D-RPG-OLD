using UnityEngine;

public class UIManager : MonoBehaviour
{
    private GameObject inventoryPanel;

    private void Awake()
    {
        inventoryPanel = transform.Find("InventoryPanel").gameObject;
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
