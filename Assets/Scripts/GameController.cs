using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{

    public Text textScore;
    public PlayerController player;
    public GameObject panelGameOver;
    public GameObject panelVictory;
    public float scoringFactor = 20;
    public AudioController audioController;
    public AudioClip victorySong;
    private Vector3 startingPosition;

    // Start is called before the first frame update
    void Start()
    {
        panelGameOver.SetActive(false);
        panelVictory.SetActive(false);
        startingPosition = player.transform.position;
        if (scoringFactor <= 0)
            scoringFactor = 20;
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

    public void gameOver()
    {
        panelGameOver.SetActive(true);
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void exit()
    {

    }

    public void winGame()
    {
        audioController.playAudioSFX(victorySong);
        panelVictory.SetActive(true);
    }
}
