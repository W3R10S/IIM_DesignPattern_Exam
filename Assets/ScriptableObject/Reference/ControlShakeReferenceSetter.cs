using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlShakeReferenceSetter : MonoBehaviour
{
    [SerializeField] ControlShake controlShake;
    [SerializeField] ControlShakeReference controlShakeReference;

    void Awake()
    {
        (controlShakeReference as IReferenceSetter<ControlShake>).SetInstance(controlShake);
    }
}
