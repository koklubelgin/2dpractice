using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            PlayerManager.isGameOver = true;
            gameObject.SetActive(false);
        }


        if(collision.transform.tag == "Water")
        {
            PlayerManager.isGameOver = true;
            gameObject.SetActive(false);
        }
    }



}
