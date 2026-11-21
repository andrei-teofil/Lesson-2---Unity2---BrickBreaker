using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickScript : MonoBehaviour
{
    Color[] colors = {
        new(1,0,0), //red
        new(1,0.5f,0), // orange
        new(1,1,0), // yellow
        new(0,1,0), // green
        new(0,0,1), // blue
    };

    public int health;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.color = colors[health-1];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col) {
        if(col.gameObject.CompareTag("Ball")) {
            health--;

            if(health == 0){
                Destroy(gameObject);
            }
            else {
                GetComponent<Renderer>().material.color = colors[health-1];
            }
        }
    }
}
