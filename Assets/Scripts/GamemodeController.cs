using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameMode
{
    playMode,
    inventoryMode
}

public class GamemodeController : MonoBehaviour
{
    public static GamemodeController Instance { get; private set; }

    public GameMode gameMode;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        EnterPlayMode();
    }

    void Update()
    {
        if (Input.GetButtonDown("GameMode"))
        {
            if(gameMode == GameMode.playMode)
            {
                EnterInventoryMode();
                return;
            }

            if(gameMode == GameMode.inventoryMode)
            {
                EnterPlayMode();
                return;
            }
        }
    }

    void EnterInventoryMode()
    {
        gameMode = GameMode.inventoryMode;
        Cursor.visible = true;
    }

    void EnterPlayMode()
    {
        gameMode = GameMode.playMode;
        Cursor.visible = false;       
    }

}
