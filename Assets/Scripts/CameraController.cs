using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{  
    public float sensivity = 2.5f;
    public float maxVerticalAngle = 90;
    public float minVerticalAngle = -90;

    public Transform horizontalRotation;
    public Transform verticalRotation;

    private Vector2 lookDirection;
    private Vector3 pointerPos;

    void Start()
    {
        pointerPos = new Vector3(Screen.width / 2, Screen.height / 2, 0);
    }

    void Update()
    {
        if (GamemodeController.Instance.gameMode == GameMode.playMode)
        {
            lookDirection = new Vector2(lookDirection.x + Input.GetAxis("Mouse X") * sensivity, Mathf.Clamp(lookDirection.y - Input.GetAxis("Mouse Y") * sensivity, minVerticalAngle, maxVerticalAngle));

            verticalRotation.localRotation = Quaternion.Euler(lookDirection.y, verticalRotation.localEulerAngles.y, verticalRotation.localEulerAngles.z);
            horizontalRotation.localRotation = Quaternion.Euler(horizontalRotation.localEulerAngles.x, lookDirection.x, horizontalRotation.localEulerAngles.z);

            if (Input.GetButtonDown("Use"))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(pointerPos);

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.CompareTag("Item"))
                    {
                        hit.collider.GetComponent<Item>().PutItemInInventory();
                    }

                    if (hit.collider.CompareTag("Door"))
                    {
                        Door door = hit.collider.GetComponent<Door>();
                        if(Inventory.Instance.UseItem() == null)
                        {
                            return;
                        }

                        if (door.reqItemName == Inventory.Instance.UseItem())
                        {
                            door.CorrectKey();
                            Inventory.Instance.ClearSlot();
                        }
                        else
                        {
                            door.IncorrectKey();
                            Inventory.Instance.UncheckSlot();
                        }
                    }
                }
            }
        }
    }
}
