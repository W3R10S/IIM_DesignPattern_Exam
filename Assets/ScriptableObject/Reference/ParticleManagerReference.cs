using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Reference/ParticleManagerReference")]
public class ParticleManagerReference : Reference<ParticleManager>
{
    public void PlayParticle(Transform pos) => Instance.PlayParticle(pos);
}
