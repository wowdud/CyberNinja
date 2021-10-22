using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScroller : MonoBehaviour
{
    public BoxCollider2D collide;
    public Rigidbody2D rigid;
    public float scrollSpeed = -3f;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        collide = GetComponent<BoxCollider2D>();

        rigid.velocity = new Vector2(scrollSpeed, 0);   
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -12)
        {
            Destroy(gameObject);
        }
    }
}
