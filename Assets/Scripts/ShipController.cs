using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

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

    [Header("Score")]
    [SerializeField]
    TMP_Text scoreLabel;

    public static int score = 0;


    void Start()
    {
        healthMeter.maxValue = health;
        healthMeter.value = health;

    }

    void Update()
    {
        scoreLabel.SetText("Score: " + score);

        if (health == 0)
        {
         print("GAMEOVER");
            SceneManager.LoadScene(2);
        }

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
        if (other.gameObject.tag == "boss")
        {
            print("GAMEOVER");
            SceneManager.LoadScene(2);
        }


        if (other.gameObject.tag == "enemy")
        {
            health--;
            healthMeter.value = health;
        }
    }
}
