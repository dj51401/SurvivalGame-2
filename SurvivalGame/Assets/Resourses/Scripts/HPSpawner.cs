using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPSpawner : MonoBehaviour
{
    public HealthPacks[] healthPacks;

    public enum Size { small, medium, large }

    public Size size;

    PlayerController player;

    int sizeInt;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        switch (size)
        {
            case Size.small:
                GameObject smallHP = Instantiate(healthPacks[0].model, gameObject.transform);
                smallHP.transform.SetParent(this.transform);
                sizeInt = 0;
                break;

            case Size.medium:
                GameObject mediumHP = Instantiate(healthPacks[1].model, gameObject.transform);
                mediumHP.transform.SetParent(this.transform);
                sizeInt = 1;
                break;

            case Size.large:
                GameObject largeHP = Instantiate(healthPacks[2].model, gameObject.transform);
                sizeInt = 2;
                break;
        }

    }


    public IEnumerator Respawn()
    {
        yield return new WaitForSeconds(healthPacks[sizeInt].respawnTimer/2);
        transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(healthPacks[sizeInt].respawnTimer/2);
    }

}
