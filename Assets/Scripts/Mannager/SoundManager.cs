using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

    public AudioSource audioSourceBGMusicPrefab;
    private AudioSource audioSourceBGMusicCreated;

    public AudioClip[] arrAudioClip;

    #region Singleton
    private static SoundManager _instance;

    public static SoundManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = GameObject.FindObjectOfType<SoundManager>();
            return _instance;
        }
    }
    #endregion

    void Awake()
    {
        PlayBGMusic();
        DontDestroyOnLoad(this.gameObject);
    }

    void PlayBGMusic()
    {
        audioSourceBGMusicCreated =
            GameObject.Instantiate
            (
                audioSourceBGMusicPrefab
            ) as AudioSource;
        audioSourceBGMusicCreated.loop = true;
        audioSourceBGMusicCreated.Play();

        DontDestroyOnLoad
        (
            audioSourceBGMusicCreated
        );
    }

    public void rePlayBGMusic()
    {
        audioSourceBGMusicCreated.Play();
    }

    public void PauseBGMusic()
    {
        audioSourceBGMusicCreated.Pause();
    }

    public void PlayAudioCick()
    {
        tk2dUIAudioManager.Instance.Play(arrAudioClip[0]);
    }
    public void PlayAudioTrue()
    {
        tk2dUIAudioManager.Instance.Play(arrAudioClip[1]);
    }
    public void PlayAudioEmty()
    {
        tk2dUIAudioManager.Instance.Play(arrAudioClip[2]);
    }
    public void PlayAudioGameOver()
    {
        tk2dUIAudioManager.Instance.Play(arrAudioClip[3]);
    }
    public void PlayAudioOdu()
    {
        tk2dUIAudioManager.Instance.Play(arrAudioClip[4]);
        tk2dUIAudioManager.Instance.Play(arrAudioClip[4]);
    }
    public void PlayAudioContinute()
    {
        tk2dUIAudioManager.Instance.Play(arrAudioClip[5]);
    }

    public void Stop()
    {
       // tk2dUIAudioManager.Instance.curentStop();
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
