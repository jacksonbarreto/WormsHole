using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    private Text textScore;
    public PlayerController player;
    public int victoryThreshold = 900;
    public GameObject panelCurrentGame;
    public GameObject panelGameOver;
    public GameObject panelVictory;
    public victoryAnimation victoryAnimation;
    public GameObject[] segmentLevelsPrefabs;
    public GameObject startSegmentLevel;
    public GameObject finalSegmentLevelPrefab;
    public GameObject PlanetPrefab;
    private GameObject currentSegmentLevel;
    private GameObject previusSegmentLevel;
    public float scoringFactor = 20;
    public AudioController audioController;
    public AudioClip victorySong;
    private Vector3 startingPosition;
    private bool pauseStatus = false;
    private float segmentSize = 900;

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
        currentSegmentLevel = startSegmentLevel;
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
        if(player != null && !player.win)
        {
            Vector3 travelledDistance = player.transform.position - startingPosition;
            player.score = travelledDistance.z / scoringFactor;
            updateTextScore(player.score);
            destroyPreviousSegment();
        }
    }

    private void updateTextScore(float newScore)
    {
        textScore.text = newScore.ToString("0");
    }

  public void pauseGame()
    {
        if (pauseStatus)
        {
            Time.timeScale = 1;
            pauseStatus = false;
            audioController.playBackgroundMusic(true);
        }
        else
        {
            Time.timeScale = 0;
            pauseStatus = true;
            audioController.playBackgroundMusic(false);
        }
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
        player.win = true;
        panelCurrentGame.SetActive(false);
        Destroy(currentSegmentLevel);
        victoryAnimation.winAnimation();
        audioController.playAudioSFX(victorySong);
        panelVictory.SetActive(true);
    }

   

    public void createSegmentLevels()
    {
        Vector3 nextPosition = currentSegmentLevel.transform.position + new Vector3(0, 0, segmentSize);
        int indexSegmentsPrefab = Random.Range(0, segmentLevelsPrefabs.Length);
        GameObject nextSegmentPrefab;
        if (player.score > victoryThreshold)
        {
            nextSegmentPrefab = finalSegmentLevelPrefab;
            GameObject.Instantiate(PlanetPrefab);
        }
        else
        {
            nextSegmentPrefab = segmentLevelsPrefabs[indexSegmentsPrefab];
        }
        previusSegmentLevel = currentSegmentLevel;
        currentSegmentLevel = GameObject.Instantiate(nextSegmentPrefab, nextPosition, currentSegmentLevel.transform.rotation);
    }

    private void destroyPreviousSegment()
    {
        if (previusSegmentLevel != null && player.transform.position.z > previusSegmentLevel.transform.position.z + segmentSize)
        {
            Destroy(previusSegmentLevel);
        }
    }
}
