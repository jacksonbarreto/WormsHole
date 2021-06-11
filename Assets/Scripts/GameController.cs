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
    public float scoringFactor = 20;
    private Vector3 startingPosition;

    // Start is called before the first frame update
    void Start()
    {
        panelGameOver.SetActive(false);
       startingPosition = player.transform.position;
        if (scoringFactor <= 0)
            scoringFactor = 20;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 travelledDistance = player.transform.position - startingPosition;
        player.score = travelledDistance.z / scoringFactor;
        updateTextScore(player.score);
    }

    private void updateTextScore(float newScore)
    {
        textScore.text = newScore.ToString("0");
    }

    public void gameOver()
    {
        panelGameOver.SetActive(true);
    }
}
