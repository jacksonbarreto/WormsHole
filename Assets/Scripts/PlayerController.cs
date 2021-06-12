using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private Rigidbody rigidBody;
    public GameController gameController;
    public GameObject ExplosionPrefab;
    public float lateralForce = 3600;
    public float speed = 900;
    public float maximumSpeed = 1200;
    public float score;
    private const float targetAngle = 30;
    private float rotationCoefficient = 5;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.useGravity = false; 
     
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rigidBody.velocity.z < maximumSpeed)
        {
            rigidBody.AddForce(0, 0, speed * Time.fixedDeltaTime);
        }
        
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rigidBody.AddForce(-lateralForce * Time.fixedDeltaTime, 0, 0);
            rotationPlayer(targetAngle);
        } else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rigidBody.AddForce(lateralForce * Time.fixedDeltaTime, 0, 0);
            rotationPlayer(-targetAngle);
        }
        else
        {
            rotationPlayer(0);
        }
        
    }

    private void rotationPlayer(float currentTargetAngle)
    {
        Quaternion currentRotation = rigidBody.rotation;
        Quaternion targetRotation = Quaternion.Euler(0, 0, currentTargetAngle);
        Quaternion newRotation = Quaternion.Lerp(currentRotation, targetRotation, rotationCoefficient * Time.fixedDeltaTime);
        rigidBody.MoveRotation(newRotation);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            GameObject.Instantiate(ExplosionPrefab, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
            gameController.gameOver();
        }
    }

    void OnTriggerEnter(Collider trigger)
    {
        
        gameController.createSegmentLevels();
    }
}
