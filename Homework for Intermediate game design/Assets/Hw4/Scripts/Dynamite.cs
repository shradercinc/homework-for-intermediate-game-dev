using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dynamite : MonoBehaviour
{
    public static float detT = 0;
    public static float detM = 4 * 50;
    private float expT = 0;
    public Transform P1;
    public Sprite sprNew;
    public Sprite sprOld;
    public PhysicsMaterial2D bounce;
    private SpriteRenderer ren;
    private Transform pos;
    private Rigidbody2D rb;
    bool exploded = false;
    private float scalex = 0;
    private float scaley = 0;

    private AudioSource AS;
    //public AudioClip explode;
    //private bool expAudio = false;


    // Start is called before the first frame update
    void Start()
    {
        ren = GetComponent<SpriteRenderer>();
        pos = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        ren.color = new Color(0.6f, 0.6f, 0.6f);
        expT = 0;
        AS = GetComponent<AudioSource>();
        Dynamite.detT = 0;
        Player.numBoom = 1;
    }

    private void FixedUpdate()
    {
        detT++;
        if (exploded == true)
        {
            expT++;
            scalex += 0.7f;
            scaley += 0.7f;
        }
    }

    void Update()
    {
        if (detT > (1 * 50) && detT < (2 * 50)) 
        {
            ren.color = new Color(0.78f,0.78f,0.78f);
        }
        if (detT > (2 * 50) && detT < (3 * 50))
        {
            ren.color = new Color(0.84f, 0.84f, 0.84f);
        }
        if (detT > (3 * 50) && detT < (detM))
        {
            ren.color = new Color(1, 1, 1);
        }

        if (detT > (detM))
        {
            rb.mass = 100000000;
            pos.transform.localScale = new Vector3(0, 0, 1);
            ren.sprite = sprNew;
            ren.color = new Color(1, 0.5f, 0, 0.2f);
            exploded = true;
            rb.sharedMaterial = bounce;
        }

        if (exploded == true)
        {
            pos.transform.localScale = new Vector3(scalex, scaley, 1);
            /*
            if (expAudio == false)
            {
                expAudio = true;
                AS.PlayOneShot(explode);
            }
            */
        }

        if (expT > 0.4 * 50)
        {
            ren.enabled = false;

        }
        if (expT > 0.75 * 50)
        {
            Player.numBoom = 0;
            Destroy(gameObject);
        }

    }
}
