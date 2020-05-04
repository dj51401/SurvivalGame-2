using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Health Pack", menuName = "Scriptable Objects/ Health Pack")]
public class HealthPacks : ScriptableObject
{
    public int hp;
    public GameObject model;
    public int respawnTimer;
}
