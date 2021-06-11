using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    private Text textScore;
    public PlayerController player;
    public GameObject panelCurrentGame;
    public GameObject panelGameOver;
    public GameObject panelVictory;
    public float scoringFactor = 20;
    public AudioController audioController;
    public AudioClip victorySong;
    private Vector3 startingPosition;

    // Start is called before the first frame update
    void Start()
    {
        panelCurrentGame.SetActive(true);
        panelGameOver.SetActive(false);
        panelVictory.SetActive(false);
        selectPanelElements();
        startingPosition = player.transform.position;
        if (scoringFactor <= 0)
            scoringFactor = 20;
    }

    private void selectPanelElements()
    {
        Component[] component = panelCurrentGame.GetComponentsInChildren<Text>();
        foreach(Text c in component)
        {
            if (c.CompareTag("TextScore"))
            {
                textScore = c;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            Vector3 travelledDistance = player.transform.position - startingPosition;
            player.score = travelledDistance.z / scoringFactor;
            updateTextScore(player.score);
        }
    }

    private void updateTextScore(float newScore)
    {
        textScore.text = newScore.ToString("0");
    }

  public void pauseGame()
    {
        Time.timeScale = 0;
    }

    public void startGame()
    {
        Time.timeScale = 1;
    }
    public void gameOver()
    {
        panelGameOver.SetActive(true);
        panelCurrentGame.SetActive(false);
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void exit()
    {
        Application.Quit();
    }

    public void winGame()
    {
        audioController.playAudioSFX(victorySong);
        panelVictory.SetActive(true);
    }
}
