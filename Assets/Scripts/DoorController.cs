using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public List<Door> doors;
    public GameObject winText;

    bool CheckDoors()
    {
        foreach(Door d in doors)
        {
            if (!d.correct)
            {
                return false;
            }
        }
        return true;
    }

    public void CheckWin()
    {
        if (CheckDoors())
        {
            winText.SetActive(true);
        }
    }

}
