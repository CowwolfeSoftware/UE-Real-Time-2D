using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlanetLauncher : MonoBehaviour
{
    public GameObject[] PlanetPrefabs = new GameObject[5];
    public Button StartButton;
    public Button QuitButton;
    public Button LaunchButton;
    public Button DropButton;
    public TMP_Text GameOverText;
    public TMP_Text FinalScoreText;

    private bool gameOver;
    private GameObject fallingPlanet;

    // Start is called before the first frame update
    void Start()
    {
        SetGameOver();
    }

    // Update is called once per frame
    void Update()
    {
        if(fallingPlanet == null && !gameOver  && !LaunchButton.IsActive())
            SetGameOver();
    }

    private void SetGameOver()
    {
        gameOver = true;

        QuitButton.gameObject.SetActive(true);
        StartButton.gameObject.SetActive(true);
        GameOverText.gameObject.SetActive(true);
        FinalScoreText.gameObject.SetActive(true);
        LaunchButton.gameObject.SetActive(false);
        DropButton.gameObject.SetActive(false);

        MusicControl.Instance.TurnMusicOn(false);
    }

    private void LaunchPlanet()
    {
        var index = Random.Range(0, PlanetPrefabs.Length);
        fallingPlanet = Instantiate(PlanetPrefabs[index]);
        fallingPlanet.transform.position = new Vector3(1,1,1);
    }

    public void LauchPlanetClick()
    {
        LaunchPlanet();
        LaunchButton.gameObject.SetActive(false);
        DropButton.gameObject.SetActive(true);
    }

    public void DropPlanetClick()
    {
        DropButton.gameObject.SetActive(false);
    }

    public void StartGameClick()
    {
        gameOver = false;
        LaunchButton.gameObject.SetActive(true);
        QuitButton.gameObject.SetActive(false);
        StartButton.gameObject.SetActive(false);
        GameOverText.gameObject.SetActive(false);
        FinalScoreText.gameObject.SetActive(false);
        MusicControl.Instance.TurnMusicOn();
    }

    public void QuitGameClick()
    {
        Application.Quit();
    }
}
