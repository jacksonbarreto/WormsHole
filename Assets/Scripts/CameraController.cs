using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public PlayerController player;
    public Vector3 distanceFromPlayer = new Vector3(0,6.5f,-16);
    public float rotateSkyboxSpeed = 1.1f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            this.transform.position = this.player.transform.position + distanceFromPlayer;
        }
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * rotateSkyboxSpeed);
    }
}
