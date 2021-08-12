using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour
{
    public string reqItemName;
    public Material doorMat, correctMat, incorrectMat;

    public UnityEvent OnDoorBecameCorrect;

    [HideInInspector] public bool correct;

    private MeshRenderer rend;

    private void Start()
    {
        rend = GetComponent<MeshRenderer>();    
    }

    public void CorrectKey()
    {
        rend.material = correctMat;
        correct = true;
        OnDoorBecameCorrect?.Invoke();
    }

    public void IncorrectKey()
    {
        rend.material = incorrectMat;
        Invoke("ApplyDoorMat", 0.5f);
    }

    public void ApplyDoorMat()
    {
        rend.material = doorMat;
    }
}
