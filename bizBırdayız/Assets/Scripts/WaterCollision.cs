using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    public class WaterCollision : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                // PlayerManager scriptine eriþerek ReplayLevel fonksiyonunu çaðýr
                PlayerManager playerManager = FindObjectOfType<PlayerManager>();
                if (playerManager != null)
                {
                    playerManager.ReplayLevel();
                }
            }
     
    
         }

            
    }

