using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    [SerializeField] GameObject m_ps;

    public void PlayParticle(Transform pos)
    {
        ParticleSystem _ps = Instantiate(m_ps, pos.position, Quaternion.identity).GetComponent<ParticleSystem>();
        _ps.Play();
        Destroy(_ps.gameObject, _ps.main.duration);
    }
}
