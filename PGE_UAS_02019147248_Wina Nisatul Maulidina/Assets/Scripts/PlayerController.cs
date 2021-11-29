using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
   

   private Rigidbody2D rig;
   CapsuleCollider2D collider;
   
    AudioSource audio;
    public AudioClip hitSound;

    GameObject panelSelesai;
    Text txPemenang;
   float originalHeight;
   public float reduceHeight;
   public float slideSpeed = 10f;
    bool isJump = true;
    bool isSlide = true;
    bool isDead = false;
        int idRun = 0;
        Animator anim;

    

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        collider = GetComponent<CapsuleCollider2D>();
         rig = GetComponent<Rigidbody2D>();
          audio = GetComponent<AudioSource>();
          panelSelesai = GameObject.Find ("Panel");
          
    }

    // Update is called once per frame
    void Update()
    {
        
    if (Input.GetKeyDown(KeyCode.LeftArrow))
    {
        MoveLeft();
    }
    if (Input.GetKeyDown(KeyCode.RightArrow))
    {
        MoveRight();
    }
    if (Input.GetKeyDown(KeyCode.Space))
    {
        Jump();
    }
    if (Input.GetKeyUp(KeyCode.RightArrow))
    {
        Idle();
    }
    if (Input.GetKeyUp(KeyCode.LeftArrow))
    {
        Idle();
    }
    if (Input.GetKeyDown(KeyCode.DownArrow))
    {
        Slide();
    }
    else if (Input.GetKeyUp(KeyCode.DownArrow))
    {
        Slide();
    }
    Move();
    Dead();
    }
    private void OnCollisionStay2D(Collision2D collision)
 {
 // Kondisi ketika menyentuh tanah
 if (isJump)
 {
 anim.ResetTrigger("jump");
 if (idRun == 0) anim.SetTrigger("idle");
 isJump = false;
 }
 }



void FixedUpdate()
{
    float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rig.AddForce (movement * 10);
}
 private void OnCollisionExit2D(Collision2D collision)
 {
 // Kondisi ketika menyentuh tanah
 anim.SetTrigger("jump");
 anim.ResetTrigger("run");
 anim.ResetTrigger("idle");
 anim.ResetTrigger("slide");
 isJump = true;
 }


 public void MoveRight()
 {
 idRun = 1;
 isSlide=true;
 }

 public void MoveLeft()
 {
 idRun = 2;
 isSlide=true;
 }

 public void Slide()
 {
   if (isSlide)
 {
 
 anim.SetTrigger("slide");
 anim.ResetTrigger("run");
 anim.ResetTrigger("idle");
 anim.ResetTrigger("jump");
    
    
 }
 
 slideSpeed = 15;
 transform.Translate(1 * Time.deltaTime * 100f, 0, 0);
 transform.Translate(-1 * Time.deltaTime * 100f, 0, 0);
    isJump = false;
    
}

 private void Move()
 {
 if (idRun == 1 && !isDead)
 {
 // Kondisi ketika bergerak ke kekanan
 if (!isJump) anim.SetTrigger("run");
 if (!isSlide) anim.SetTrigger("run");
 transform.Translate(1 * Time.deltaTime * 5f, 0, 0);
transform.localScale = new Vector3(1f, 1f, 1f);
 }
 if (idRun == 2 && !isDead)
 {
 // Kondisi ketika bergerak ke kiri
if (!isJump) anim.SetTrigger("run");
if (!isSlide) anim.SetTrigger("run");
transform.Translate(-1 * Time.deltaTime * 5f, 0, 0);
transform.localScale = new Vector3(-1f, 1f, 1f);

 }
 }

 public void Jump()
 {
 if (!isJump)
 {
 // Kondisi ketika Loncat
 gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 420f);
 }
 }

private void OnCollisionEnter2D(Collision2D collisioon)
{
if (collisioon.transform.tag.Equals("Enemy"))
{
    audio.PlayOneShot(hitSound);
    SceneManager.LoadScene("2");
    isDead = true;
}
 }

 private void OnTriggerEnter2D(Collider2D collision)
 {
 if (collision.transform.tag.Equals("Coin"))
 {
 Meta.score += 1;
 Destroy(collision.gameObject);
 }
 }

 public void Idle()
 {
 // kondisi ketika idle/diam
 if (!isJump)
 {
 anim.ResetTrigger("jump");
 anim.ResetTrigger("run");
 anim.SetTrigger("idle");
 anim.ResetTrigger("slide");
 }
 idRun = 0;
 }

 private void Dead()
 {
    if (!isDead)
    {
    if (transform.position.y < -10f)
    {
        //kondisi ketika jatuh
    isDead = true;
    //SceneManager.LoadScene("2");
    }
    }
 }
}
