using TMPro;
using UnityEngine;

public class MusicControl : MonoBehaviour
{
    public TMP_Text MusicText;
    private bool masterMusicOn = true;
    private bool playMusic;
    private readonly float musicVolume = 0.2f;
    public static MusicControl Instance {get; private set;}

    private AudioSource music;
    // Start is called before the first frame update
    void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        music = GetComponent<AudioSource>();
        music.Play();
        TurnMusicOn(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.M))
        {
            masterMusicOn = !masterMusicOn;
            TurnMusicOn(playMusic);
        }
    }

    public void TurnMusicOn(bool play = true)
    {
        playMusic = play;
        if(masterMusicOn && playMusic)
               music.volume = musicVolume;
        else
            music.volume = 0;

        MusicText.text = masterMusicOn ? "[M]usic: on" : "[M]usic: off";
    }
}
