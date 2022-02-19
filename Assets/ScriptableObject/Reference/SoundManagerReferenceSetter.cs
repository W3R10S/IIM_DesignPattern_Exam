using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerReferenceSetter : MonoBehaviour
{
    [SerializeField] SoundManager soundManager;
    [SerializeField] SoundManagerReference soundManagerReference;

    void Awake()
    {
        (soundManagerReference as IReferenceSetter<SoundManager>).SetInstance(soundManager);
    }
}
