using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControler : MonoBehaviour
{
 [SerializeField]
float speed = 1f;

int health =7;

[SerializeField]
GameObject explosion;
 
void Start()

{
float x = Random.Range(-2,6f);
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

                }
        }
    
 if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
        }
}
}
