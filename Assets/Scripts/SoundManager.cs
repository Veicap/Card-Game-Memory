using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private SoundEffectSO soundEffectSo;
    private void Start()
    {
        CardManager.Instance.OnMatch += CardManager_OnMatch;
        CardManager.Instance.OnWin += CardManager_OnWin;
        EventManager.Instance.OnLose += EventManager_OnLose;
        CardManager.Instance.OnNotMatch += CardManager_OnNotMatch;
    }

    private void CardManager_OnNotMatch(object sender, System.EventArgs e)
    {
        CardManager card = (CardManager)sender;
        PlaySound(soundEffectSo.notMatchSound, card.transform.position);
    }

    private void EventManager_OnLose(object sender, System.EventArgs e)
    {
        EventManager eventManager = (EventManager)sender;
        PlaySound(soundEffectSo.loseSound, eventManager.transform.position);
    }

    private void CardManager_OnWin(object sender, System.EventArgs e)
    {
        CardManager card = (CardManager)sender;
        PlaySound(soundEffectSo.winGameSound, card.transform.position);
    }

    private void CardManager_OnMatch(object sender, System.EventArgs e)
    {
        CardManager card = (CardManager)sender;
        PlaySound(soundEffectSo.matchSound, card.transform.position);
    }

    private void PlaySound(AudioClip audioClip, Vector3 position, float volume = 1f)
    {
        AudioSource.PlayClipAtPoint(audioClip, position, volume);
    }
}
