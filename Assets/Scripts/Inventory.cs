using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance { get; private set; }

    public List<Slot> slots;
    public ToggleGroup inventory;

    public Transform playerTransform;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if(GamemodeController.Instance.gameMode == GameMode.inventoryMode)
        {
            if (Input.GetButtonDown("Drop"))
            {
                DropItem();
            }
        }
    }

    public bool AddItem(string itemName)
    {
        foreach(Slot s in slots)
        {
            if (!s.full)
            {
                s.itemName = itemName;
                s.SetItemImage();
                return true;
            }
        }

        return false;
    }

    public void DropItem()
    {
        Vector3 instantiatePos = new Vector3(playerTransform.position.x, 0.737f, playerTransform.position.z);
        Quaternion instantiateRotation = new Quaternion(21.645f, -7.775f, 32.374f, 0);
        foreach (Toggle t in inventory.ActiveToggles())
        {
            Instantiate(Resources.Load("Prefabs/" + t.GetComponent<Slot>().itemName), instantiatePos, instantiateRotation);
            t.isOn = false;
            t.GetComponent<Slot>().ClearItemImage();
            return;
        }
    }

    public string UseItem()
    {
        foreach (Toggle t in inventory.ActiveToggles())
        {
            return t.GetComponent<Slot>().itemName;
        }

        return null;
    }

    public void ClearSlot()
    {
        foreach (Toggle t in inventory.ActiveToggles())
        {
            t.isOn = false;
            t.GetComponent<Slot>().ClearItemImage();          
            return;
        }
    }

    public void UncheckSlot()
    {
        foreach (Toggle t in inventory.ActiveToggles())
        {
            t.isOn = false;
            return;
        }
    }

    
}
