using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody2D rigid;
    public Animator animator;
    public float speed = 5;
    public bool isGrounded;
    public bool fallingFlag = false;
    public bool isGameOver = false;
    public AudioSource jumpSFX;
    public static float gameTime;


    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        gameTime = 0;
    }

    
    void Update()
    {
        if (!isGameOver)
        {
            if (isGrounded)
            {
                fallingFlag = false;
                animator.SetBool("isGrounded", true);
                animator.SetBool("isFalling", false);
                if (Input.GetKey(KeyCode.W))
                {
                    float moveDirection = Input.GetAxisRaw("Vertical");
                    rigid.velocity = new Vector2(0, moveDirection * speed);
                    animator.SetBool("isGrounded", false);
                    animator.SetBool("isFalling", false);
                    jumpSFX.Play();
                }
            }
            if (Input.GetKeyUp(KeyCode.W) && fallingFlag == false)
            {
                fallingFlag = true;
                float moveDirection = Input.GetAxisRaw("Vertical");
                rigid.velocity = new Vector2(0, -moveDirection * speed);
                animator.SetBool("isFalling", true);
            }
        }
        if (isGameOver)
        {
            gameTime = SpawnScript.timer;
            Invoke("GameOver", 2.5f);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.transform.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
            print(other.tag);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            isGrounded = false;
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Obstacle"))
        {
            isGameOver = true;
            animator.SetTrigger("isDead");
        }
    }

    void GameOver()
    {
        SceneManager.LoadScene(2);
    }

}
