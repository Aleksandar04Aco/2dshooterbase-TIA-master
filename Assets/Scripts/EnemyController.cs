using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    float speed = 3f;

    int health = 1;

    [SerializeField]
    GameObject explosion;

    void Start()
    {
        float x = Random.Range(-6f, 6f);


        Vector2 position = new Vector2(x, 7);
        transform.position = position;
    }

    void Update()
    {
        Vector2 movement = new Vector2(0, -speed) * Time.deltaTime;

        transform.Translate(movement);

        if (transform.position.y < -7)
        {
            Destroy(this.gameObject);
        }
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

                GameObject bossGenerator = GameObject.Find("BossGenerator");

                bossGenerator.GetComponent<BossGenerator>().enemiesKilled++;
            }
        }
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
        }
    }

}