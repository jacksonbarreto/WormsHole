using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private Rigidbody rigidBody;
    public GameController gameController;
    public float lateralForce = 3600;
    public float velocity = 900;
    public float score;

    // Start is called before the first frame update
    void Start()
    {
        this.rigidBody = GetComponent<Rigidbody>();
        this.rigidBody.useGravity = false;
     
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.rigidBody.AddForce(0, 0, this.velocity * Time.fixedDeltaTime);

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
            gameController.gameOver();
        }
    }

}
