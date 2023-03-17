using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Skjutande
 * Hindra att man åker utanför
 * Fiender
 - (Diagonal förflyttning)
 - Musik
 - Livräkning & gameover
 - Highscore 
 - Powerups (speed, vapen)

 SKOTT:
 x Åka uppåt
 x Ta bort när ovanför skärmen
 x Skapa där skeppet är
 x Inte skjuta varje frame
 - Skada fiender + ta bort
*/

public class ShipController : MonoBehaviour
{
    [SerializeField]
    int health = 5;

    [SerializeField]
    Slider healthMeter;

    [SerializeField]
    float speed = 2f;

    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    Transform gunTransform;

    float shootTimer = 0;

    [SerializeField]
    float timeBetweenShots = 0.5f;

    void Start()
    {
        healthMeter.maxValue = health;
        healthMeter.value = health;

    }

    void Update()
    {
        float xMove = Input.GetAxisRaw("Horizontal");
        float yMove = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(xMove, yMove) * speed * Time.deltaTime;

        transform.Translate(movement);

        shootTimer += Time.deltaTime;

        if (Input.GetAxisRaw("Fire1") > 0 && shootTimer > timeBetweenShots)
        {
            Instantiate(bulletPrefab, gunTransform.position, Quaternion.identity);
            shootTimer = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "enemy")
        {
            health--;
            healthMeter.value = health;
        }
    }
}
