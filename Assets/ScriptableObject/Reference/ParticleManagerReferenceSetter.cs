using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManagerReferenceSetter : MonoBehaviour
{
    [SerializeField] ParticleManager particleManager;
    [SerializeField] ParticleManagerReference particleManagerReference;

    void Awake()
    {
        (particleManagerReference as IReferenceSetter<ParticleManager>).SetInstance(particleManager);
    }
}
