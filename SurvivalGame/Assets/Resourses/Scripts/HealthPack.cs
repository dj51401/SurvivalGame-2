using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    PlayerController player;
    public HealthPacks health;
    HPSpawner hpSpawner;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        hpSpawner = gameObject.GetComponentInParent<HPSpawner>();
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (player.currentHealth < player.maxHealth)
            {
                player.TakeDamage(-health.hp);
                hpSpawner.StartCoroutine(hpSpawner.Respawn());
                gameObject.SetActive(false);
            }
        }
    }
}
