using System.Collections;
using System.Collections.Generic;
using UnityEngine;




    public class CoinCollect : MonoBehaviour
    {
        public AudioSource coinSound; // Coin sesini çalmak için kullanýlacak AudioSource bileþeni

        private void OnTriggerEnter2D(Collider2D other)
        {
            // Oyuncu objesiyle çarpýþma algýlandýðýnda
            if (other.CompareTag("Player"))
            {
                // Coin sesini çal
                if (coinSound != null)
                {
                    coinSound.Play();
                }

               

            }
        }

    }


