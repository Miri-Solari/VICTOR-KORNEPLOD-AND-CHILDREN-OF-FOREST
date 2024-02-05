using System.Collections;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [SerializeField] private AudioClip[] sounds; // Массив звуков
    [SerializeField] private float[] slowdownFactors; // Массив замедления времени
    [SerializeField] private AudioSource audioSource;

    private bool isSoundPlaying = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
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
            Debug.LogWarning("Неверный индекс или звук уже воспроизводится");
        }
    }

    private IEnumerator PlaySoundRoutine(AudioClip clip, float slowdownFactor)
    {
        isSoundPlaying = true;
        Time.timeScale = slowdownFactor;
        audioSource.PlayOneShot(clip);

        float waitTime = clip.length;
        yield return new WaitForSecondsRealtime(waitTime);

        Time.timeScale = 1f;

        
        yield return new WaitForSecondsRealtime(1f);

        isSoundPlaying = false;
    }
}