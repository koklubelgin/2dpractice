using System.Collections;
using System.Collections.Generic;
using UnityEngine;




    public class CoinCollect : MonoBehaviour
    {
        public AudioSource coinSound; // Coin sesini �almak i�in kullan�lacak AudioSource bile�eni

        private void OnTriggerEnter2D(Collider2D other)
        {
            // Oyuncu objesiyle �arp��ma alg�land���nda
            if (other.CompareTag("Player"))
            {
                // Coin sesini �al
                if (coinSound != null)
                {
                    coinSound.Play();
                }

               

            }
        }

    }


