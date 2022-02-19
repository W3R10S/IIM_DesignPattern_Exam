using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorExplosion : MonoBehaviour
{
    public GameObject ps;
    public KeyDoorDetector detector;

    private void Start()
    {
        detector.OnExplosion += SpawnParticle;
    }

    private void OnDestroy()
    {
        detector.OnExplosion -= SpawnParticle;
    }

    public void SpawnParticle(Vector3 pos)
    {
        ParticleSystem currentPs = Instantiate(ps, pos, Quaternion.identity).GetComponent<ParticleSystem>();
        Destroy(currentPs, currentPs.main.duration);
    }
}
