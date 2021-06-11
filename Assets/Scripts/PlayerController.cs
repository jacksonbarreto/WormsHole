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
            this.rigidBody.AddForce(-lateralForce * Time.fixedDeltaTime, 0, 0);
            Debug.Log(this.lateralForce);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            this.rigidBody.AddForce(lateralForce * Time.fixedDeltaTime, 0, 0);
        }
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

}
