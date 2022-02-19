using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hodoor : MonoBehaviour
{
    public int toggleNumber;

    public void OpenDoor(int amount)
    {
        toggleNumber += amount;
        Debug.Log(toggleNumber);

        if (toggleNumber >= 3)
        {
            gameObject.SetActive(false);
        }
    }
}
