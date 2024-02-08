using System.Collections;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [SerializeField] private AudioClip[] sounds;
    [SerializeField] private float[] slowdownFactors;
    [SerializeField] private AudioSource audioSource;

    private bool isSoundPlaying = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void PlaySound(int index)
    {
        if (index >= 0 && index < sounds.Length && index < slowdownFactors.Length && !isSoundPlaying)
        {
            StartCoroutine(PlaySoundRoutine(sounds[index], slowdownFactors[index]));
        }
        
        else
        {
            Debug.LogWarning("Ќеверный индекс или звук уже воспроизводитс€");
        }
    }

   
    public void PlayAttackSound(int index)
    {
        if (index >= 0 && index < sounds.Length)
        {
            audioSource.PlayOneShot(sounds[index]); 
        }
    }

    private IEnumerator PlaySoundRoutine(AudioClip clip, float slowdownFactor)
    {
        isSoundPlaying = true;
        Time.timeScale = slowdownFactor*Speed.TimeSpeed;
        audioSource.PlayOneShot(clip);
        float waitTime = clip.length;
        yield return new WaitForSecondsRealtime(waitTime);
        while (PAUSEPOCHINKA.ISPAUSED)
        {
            yield return new WaitForSecondsRealtime(0.1f);
        }
        Time.timeScale = 1f * Speed.TimeSpeed;
        yield return new WaitForSecondsRealtime(1f);

        isSoundPlaying = false;
    }
}