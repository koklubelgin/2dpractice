using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class CheckPoint : MonoBehaviour
{
    public AudioSource checkpointSound; // Checkpoint sesini çalmak için kullanýlacak AudioSource bileþeni

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerManager.lastCheckPointPos = transform.position;
            GetComponent<SpriteRenderer>().color = Color.white;

            // Checkpoint sesini çal
            if (checkpointSound != null)
            {
                checkpointSound.Play();
            }
        }
    }
}