using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public GameObject bgSoundHolder;
    public GameObject fxSoundHolder;
    [Header("Background Sounds")]
    public AudioClip bgIngameSound;
    public AudioClip bgLobbySound;

    [Header("Effect Sounds")]
    public AudioClip creatureDeathSound;
    public AudioClip drawCardSound;
    public AudioClip endTurnSound;
    public AudioClip creatureSummonedSound;
    public AudioClip manaPipSound;
    public AudioClip uiClickSound;
    public AudioClip swordAttackSound;
    public AudioClip victorySound;
    public AudioClip defeatSound;
    public AudioClip notificationSound;
    [Header("Audio Source")]
    [SerializeField] private AudioSource bgAudioSource;
    [SerializeField] private AudioSource fxAudioSource;
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("duplicate sfx", gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        bgAudioSource = bgSoundHolder.GetComponent<AudioSource>();
        fxAudioSource = fxSoundHolder.GetComponent<AudioSource>();
    }
    public void PlayBackgroundSound(AudioClip clip)
    {
        if (bgAudioSource.isPlaying)
            bgAudioSource.Stop();

        bgAudioSource.clip = clip;
        bgAudioSource.loop = true;
        bgAudioSource.Play();
    }
    public void PlayEffectSound(AudioClip clip)
    {
        fxAudioSource.PlayOneShot(clip);
    }

    public void PlaySound(string soundType)
    {
        switch (soundType)
        {
            case "Notification":
                PlayEffectSound(notificationSound);
                break;
            case "victory":
                PlayEffectSound(victorySound);
                break;
            case "defeat":
                PlayEffectSound(defeatSound);
                break;
            case "CreatureDeath":
                PlayEffectSound(creatureDeathSound);
                break;
            case "DrawCard":
                PlayEffectSound(drawCardSound);
                break;
            case "EndTurn":
                PlayEffectSound(endTurnSound);
                break;
            case "CreatureSummoned":
                PlayEffectSound(creatureSummonedSound);
                break;
            case "ManaPip":
                PlayEffectSound(manaPipSound);
                break;
            case "UIClick":
                PlayEffectSound(uiClickSound);
                break;
            case "SwordAttack":
                PlayEffectSound(swordAttackSound);
                break;
            case "BgIngame":
                PlayBackgroundSound(bgIngameSound);
                break;
            case "BgLobby":
                PlayBackgroundSound(bgLobbySound);
                break;
            default:
                Debug.LogWarning($"Sound type '{soundType}' not recognized.");
                break;
        }
    }
}