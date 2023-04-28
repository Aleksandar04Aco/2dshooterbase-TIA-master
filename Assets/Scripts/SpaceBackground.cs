using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceBackground : MonoBehaviour
{
    [SerializeField]
float speed = 2f;
    void Start()
    {
        
    }

    void Update()
    {
        Vector2 movement = new Vector2(0, -speed) * Time.deltaTime;

        transform.Translate(movement);

        if (transform.position.y < -20) 
        {
            movement = new Vector3(0, 50);
            transform.Translate(movement);

        }
    }


}

