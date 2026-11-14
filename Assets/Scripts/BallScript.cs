using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    int speed = 5;
    Rigidbody ballRb;

    // Start is called before the first frame update
    void Start()
    {
        ballRb = GetComponent<Rigidbody>();
        ballRb.AddForce(0,0,-speed, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space)){
            ballRb.AddForce(0,0,-speed, ForceMode.Force);
        }
    }

    void FixedUpdate() {
        // reset speed to 5 while keeping direction
        ballRb.velocity = ballRb.velocity.normalized * speed;
    }

    void OnCollisionEnter(Collision col){
        if(col.gameObject.CompareTag("Player")) {
            // initial dir after the bounce (up)
            var initialDir = transform.position - col.transform.position;

            // take "some"(0.3) of the player's velocity on x
            initialDir.x += col.rigidbody.velocity.x * 0.3f;

            ballRb.velocity = initialDir.normalized * speed;
        }
    }
}
