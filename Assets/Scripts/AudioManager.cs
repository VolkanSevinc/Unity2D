using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource[] sfx;
    public AudioSource[] bgm;

    public static AudioManager instance;

    void Start()
    {
        instance = this;

        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            playSfx(0);
        }
    }

    public void playSfx(int sountToPlay)
    {
        if (sountToPlay < sfx.Length)
        {
            sfx[sountToPlay].Play();
        }
    }

    public void playMusic(int sountToPlay)
    {
        stopMusic();
        if (sountToPlay < bgm.Length)
        {
            bgm[sountToPlay].Play();
        }
    }

    public void stopMusic()
    {
        foreach (AudioSource source in bgm)
        {
            source.Stop();
        }
    }
}