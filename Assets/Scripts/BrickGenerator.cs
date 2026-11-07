using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickGenerator : MonoBehaviour
{
    public BrickScript brick;

    // Start is called before the first frame update
    void Start()
    {
        for (float x = -3; x <= 3; x+=1.5f)
        {
            for (float z = 0; z <= 3; z+=1.5f)
            {
                Instantiate(
                    brick, 
                    new Vector3(x, 0.25f, z), 
                    Quaternion.identity, 
                    transform
                );
            }  
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
