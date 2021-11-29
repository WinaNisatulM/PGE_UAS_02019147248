using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public bool isGrounded = false; 
    public bool isFacingRight = false;
    public Transform b1; 
    public Transform b2;
    CapsuleCollider2D collider;
    float speed = 2;
    Rigidbody2D rigid;
    Animator anim;
    public int HP = 1;
    
    public static int EnemyKilled = 0;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        {
        if (isFacingRight)
            MoveRight ();
        else
            MoveLeft ();

        if (transform.position.x >= b2.position.x && isFacingRight)
            Flip ();
        else if (transform.position.x <= b1.position.x && !isFacingRight)
            Flip ();
        }
    }
    void MoveRight()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        
        if (!isFacingRight)
        {
        Flip();
        }
    }
    void MoveLeft()
    {
        Vector3 pos = transform.position;
        pos.x -= speed * Time.deltaTime;
       
        if (isFacingRight)
        {
        Flip();
        }
    }
    void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        
        isFacingRight = !isFacingRight;
    }
    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.CompareTag("Tanah"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionStay2D (Collision2D col)
    {
        if (col.gameObject.CompareTag("Tanah"))
        {
            isGrounded = true;
        }    
    }

    void OnCollisionExit2D (Collision2D col)
    {
        if (col.gameObject.CompareTag("Tanah"))
        {
            isGrounded = false;
        }
    }

    

}