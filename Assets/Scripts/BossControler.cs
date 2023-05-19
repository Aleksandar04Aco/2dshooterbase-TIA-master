using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BossControler : MonoBehaviour
{
 [SerializeField]
float speed = 1f;

int health =7;

[SerializeField]
GameObject explosion;
 
void Start()

{
float x = Random.Range(3,3f);
}

private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "shot")
        {
            health--;

            if (health == 0)
            {

            Destroy(this.gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
            SceneManager.LoadScene(3);
            ShipController.score += 175;
            
           }
        }
    
 if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
        }
}
}
