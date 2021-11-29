using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Ket : MonoBehaviour
{
    public GameObject Panel;
 
    AudioSource audio;
    public AudioClip hitSound;
   
    // Start is called before the first frame update
    void Start()
    {
         Panel.SetActive(false);
        //this.gameObject.SetActive(false);
         audio = GetComponent<AudioSource>();
         UnPause();
        
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyUp(KeyCode.Escape))
        {
        Application.Quit();
        }

       if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene("1");
        }
         if (Input.GetKeyDown("h"))
        {
            SceneManager.LoadScene("0");
        }
        
        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
         audio.PlayOneShot(hitSound);
    if (collision.tag.Equals("Player"))
    {   
        this.gameObject.SetActive(true);
       Panel.SetActive(true);
        Pause();
        Meta.score = 0;
       //SceneManager.LoadScene("2");
    }
   
    }
    public void Replay()
    {
    Meta.score = 0;
    EnemyController.EnemyKilled = 0;
    SceneManager.LoadScene("1");
    }
    private void Pause()
    {
        Time.timeScale = 0f;
    }
    
    private void UnPause()
    {
        Time.timeScale = 1f;
    }
}
