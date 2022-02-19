using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Reference/SoundManagerReference")]
public class SoundManagerReference : Reference<SoundManager>
{
    public void PlaySound(AudioClip clip) => Instance.PlaySound(clip);
}
