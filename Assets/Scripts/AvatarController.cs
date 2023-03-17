using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarController : MonoBehaviour
{

    [SerializeField]
    float jumpForce = 100;
    [SerializeField]
    Transform groundCheker;

    [SerializeField]
    float speed = 1f;

    [SerializeField]
    LayerMask groundLayer;



    Rigidbody2D rb;
    bool hasRealesedJump = true;
    bool isGrounded = false;

    [SerializeField]


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        {

        }

    }

    void Update()
    {

        float xMove = Input.GetAxisRaw("Horizontal");
        Vector2 movement = new Vector2(xMove, 0) * speed * Time.deltaTime;
        transform.Translate(movement);

        isGrounded = Physics2D.OverlapCircle(groundCheker.position, 0.1f, groundLayer);


        if (Input.GetAxisRaw("Jump") > 0 && hasRealesedJump && isGrounded == true)
        {
            rb.AddForce(Vector2.up * jumpForce);
            hasRealesedJump = false;
        }
        else if (Input.GetAxisRaw("Jump") == 0)
        {
            hasRealesedJump = true;
        }

    }
}
