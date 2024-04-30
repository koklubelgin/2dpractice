using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class CheckPoint : MonoBehaviour
{
    public AudioSource checkpointSound; // Checkpoint sesini �almak i�in kullan�lacak AudioSource bile�eni

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerManager.lastCheckPointPos = transform.position;
            GetComponent<SpriteRenderer>().color = Color.white;

            // Checkpoint sesini �al
            if (checkpointSound != null)
            {
                checkpointSound.Play();
            }
        }
    }
}