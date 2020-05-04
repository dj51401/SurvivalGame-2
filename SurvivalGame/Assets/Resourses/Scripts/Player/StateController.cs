using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    public GameState gameState;
    GameObject player;

    void Start()
    {
        player = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameState.states == GameState.States.notPaused)
            {
                gameState.states = GameState.States.paused;
            }
            else
            {
                gameState.states = GameState.States.notPaused;
            }
        }

        if (gameState.states == GameState.States.paused)
        {
            player.GetComponent<PlayerController>().enabled = false;
            Time.timeScale = 0;
        }
        else
        {
            player.GetComponent<PlayerController>().enabled = true;
            Time.timeScale = 1;
        }
    }
}
