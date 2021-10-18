using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D bc;
    private Transform PlPos;

    public static int lives = 5;

    public GameObject dynamite;

    public float speed = 5.0f;
    float moveX = 1.0f;
    public float jumpSpeed = 8.5f;

    bool canJump = false;
    private float DeathTimer = 0.0f;
    public static bool canExp = true;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        PlPos = GetComponent<Transform>();

    }
    void Start()
    {


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.CompareTag("Floor") || collision.gameObject.CompareTag("Box")) && PlPos.transform.position.y > (collision.gameObject.transform.position.y + collision.gameObject.transform.localScale.y - 0.5))
        {
            canJump = true;
        }
        if (collision.gameObject.CompareTag("Wheel"))
        {
            canJump = true;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveX * speed, rb.velocity.y);
        if (lives <= 0)
        {
            DeathTimer++;
        }
        if (DeathTimer >= 1.5 * 50)
        {
            SceneManager.LoadScene("Homework4Scene0");
        }
    }

    void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump == true)
        {
            canJump = false;
            rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
        }
    }

    void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        jump();
        if (canExp == true)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Object.Instantiate(dynamite, new Vector3(PlPos.transform.position.x, PlPos.transform.position.y, -2), dynamite.transform.rotation);
            }
        }
  
    }
}
