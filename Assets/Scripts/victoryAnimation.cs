using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class victoryAnimation : MonoBehaviour
{
    public PlayerController player;
    public GameObject planet;
    public CameraController cameraController; 
    public float speedTowardPlanet = 1000;
    private float planetSurface = 150;
    // Start is called before the first frame update
    void Start()
    {
        this.enabled = false;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
        Vector3 towardsPlanet = planet.transform.position - player.transform.position;
        if(towardsPlanet.magnitude > planetSurface)
        {
            this.enabled = false;
            player.rigidBody.velocity = new Vector3(0, 0, 0);
        } else
        {
          
        }
        towardsPlanet.Normalize();
        player.rigidBody.AddForce(towardsPlanet * Time.fixedDeltaTime * speedTowardPlanet);

    }

    public void winAnimation()
    {
        this.enabled = true;
        planet = GameObject.FindGameObjectWithTag("House");
        cameraController.enabled = false;
        player.enabled = false;
    }
}
