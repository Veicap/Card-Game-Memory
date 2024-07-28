using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class SoundEffectSO : ScriptableObject
{
    public AudioClip loseSound;
    public AudioClip matchSound;
    public AudioClip notMatchSound;
    public AudioClip winGameSound;
}
