using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    float restartTimer = 5;

    public static int level = 1;
    public TextMeshProUGUI restartText;
    public TextMeshProUGUI levelText;
    public BrickGenerator generator;


    // Start is called before the first frame update
    void Start()
    {
        restartText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        levelText.text = "Level: " + level;

        int bricks = generator.transform.childCount;
        if(bricks == 0)
        {
            if(level < 3)
            {
                level++;
                SceneManager.LoadScene(0);
            }
            else
            {
                ManageRestart(false);
            }
        }
    }

    public void ManageRestart(bool isLost) {
        string msg = (isLost ? "You lost!" : "You won!") + $"\nRestart in\n{restartTimer}.";
        
        if(restartTimer > 0)
        {
            restartTimer -= Time.deltaTime;
        }
        else
        {
            restartTimer = 5;
            level = 1;
            SceneManager.LoadScene(0);
        }

        restartText.enabled = true;
        restartText.text = msg;
    }
}
