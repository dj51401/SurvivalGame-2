using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Game State", menuName = "Scriptable Objects/Game State")]
public class GameState : ScriptableObject
{
    public enum States { paused, notPaused}
    public States states;

    private void Awake()
    {
        states = States.notPaused;
    }
}
