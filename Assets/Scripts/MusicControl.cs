using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour
{
    private bool masterMusicOn = true;
    private bool playMusic;
    public static MusicControl Instance {get; private set;}
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

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.M))
        {
            masterMusicOn = !masterMusicOn;
            Debug.LogFormat("Master Music is ", masterMusicOn ? "ON" : "OFF");
            TurnMusicOn(playMusic);
        }
    }

    public void TurnMusicOn(bool play = true)
    {
        playMusic = play;
        if(masterMusicOn)
        {
            // audio.IsActive(playMusic);
        }
    }
}
