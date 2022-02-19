using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Key : MonoBehaviour, ICatchable
{
    public void Use(PlayerEntity playerEntity)
    {
        Debug.Log("BOOOOOOOOOOM !"); 
    }
}
