using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Image itemImg;
    public string itemName;
    public bool full = false;

    private void Start()
    {
        ClearItemImage();
    }

    public void SetItemImage()
    {
        itemImg.gameObject.SetActive(true);
        itemImg.sprite = Resources.Load<Sprite>(itemName);
        full = true;
    }

    public void ClearItemImage()
    {
        itemImg.sprite = null;
        full = false;
        itemImg.gameObject.SetActive(false);
    }
}
