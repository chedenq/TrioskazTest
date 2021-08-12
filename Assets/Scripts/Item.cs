using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName;
    public void PutItemInInventory()
    {
        if (Inventory.Instance.AddItem(itemName))
        {
            Destroy(gameObject);
        }
    }
}
