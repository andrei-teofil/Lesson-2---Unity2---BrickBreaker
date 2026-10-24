using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform leftWall;
    public Transform rightWall;
    private int speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var mousePos = Input.mousePosition;
        
        // the nearest plane to the camera where objects are still visible
        mousePos.z = Camera.main.nearClipPlane;
        // Converts screen coords (0-1920,0-1080) to world(scene) coords
        var worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);

        var rEdgeX = rightWall.transform.position.x - rightWall.transform.localScale.x/2;
        var lEdgeX = leftWall.transform.position.x + leftWall.transform.localScale.x/2;

        var rBoundaryX = rEdgeX - transform.localScale.x/2;
        var lBoundaryX = lEdgeX + transform.localScale.x/2;
        
        var targetX = worldMousePos.x * speed;
        // Clamp(x,a,b) = x, if x between a,b; a if x<a; b if x>b
        var clampedX = Mathf.Clamp(targetX, lBoundaryX, rBoundaryX);
        
        transform.position = new Vector3(
            clampedX, 
            transform.position.y, 
            transform.position.z
        );
    }
}
