using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Audio Sources")]
    public AudioSource musicSource;

    [Header("Scene-Based Music")]
    public AudioClip[] sceneMusicClips;
    private int currentSceneIndex = -1;

    [Header("Volume Settings")]
    public float louderMusicVolume = 1f;
    public float defaultMusicVolume = 0.5f;
    public float quieterMusicVolume = 0.2f;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        PlayMusicForScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayMusicForScene(scene.buildIndex);
    }

    private void PlayMusicForScene(int sceneIndex)
    {
        if (sceneIndex != currentSceneIndex && sceneIndex < sceneMusicClips.Length)
        {
            currentSceneIndex = sceneIndex;
            AudioClip newClip = sceneMusicClips[sceneIndex];
            if (newClip.name.EndsWith("louder"))
            {
                Debug.Log("louder");
                musicSource.volume = louderMusicVolume;
            }
            else if (newClip.name.EndsWith("quieter"))
            {
                Debug.Log("quieter");
                musicSource.volume = quieterMusicVolume;
            }
            else
            {
                musicSource.volume = defaultMusicVolume;
            }
            PlayMusic(newClip);
        }
    }

    public void PlayMusic(AudioClip clip)
    {
        if (clip != null && musicSource.clip != clip)
        {
            musicSource.clip = clip;
            musicSource.loop = true;
            musicSource.Play();
        }
    }

    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }
}
