using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    public BoxCollider2D collide;
    public Rigidbody2D rigid;
    public float scrollSpeed = -3f;
    private float screenCount;


    void Start()
    {
        collide = GetComponent<BoxCollider2D>();
        rigid = GetComponent<Rigidbody2D>();

        screenCount = collide.size.x;
        collide.enabled = false;

        rigid.velocity = new Vector2(scrollSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -screenCount)
        {
            Vector2 reset = new Vector2(screenCount * 3f, 0);
            transform.position = (Vector2)transform.position + reset;
        }
    }
}
