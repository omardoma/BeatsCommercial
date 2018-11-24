using UnityEngine;

public class MusicController : MonoBehaviour
{
    private static MusicController instance;
    private int currentMusicIndex;
    private float interval;
    public AudioSource source;
    public AudioClip intervalSound;
    public AudioClip musicChange;
    public AudioClip[] musicClips;

    public static MusicController Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        //DontDestroyOnLoad(this.gameObject);
    }

    public void Start()
    {
        interval = 10.0f;
        PlayMusic(0);
    }

    public void Update()
    {
        interval -= Time.deltaTime;
        if (interval <= 0)
        {
            source.PlayOneShot(intervalSound);
            interval = 10.0f;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayMusic(currentMusicIndex + 1);
        }
    }

    public void PauseMusic()
    {
        source.Pause();
    }

    public void ResumeMusic()
    {
        source.UnPause();
    }

    public void PlayMusic(int index)
    {
        if (source.isPlaying)
        {
            source.Stop();
        }
        source.PlayOneShot(musicChange);
        currentMusicIndex = index % musicClips.Length;
        source.clip = musicClips[currentMusicIndex];
        source.Play();
    }
}
