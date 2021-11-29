using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
   

    public Text txSkor;
    public bool isEscapeToExit;

    public void MulaiPermainan ()
    {
    SceneManager.LoadScene ("1");
    }
    public void KembaliKeMenu ()
    {
    SceneManager.LoadScene ("0");
    }

    // Start is called before the first frame update
    void Start()
    {
        UnPause();
        txSkor.text = "Jumlah Skor: " + Meta.score;
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyUp (KeyCode.Escape)) {
            if (isEscapeToExit) {
                Application.Quit ();
            } else {
                KembaliKeMenu ();
            } 
    }    
}
public void Replay()
{
    SceneManager.LoadScene("1");
    Meta.score = 0;
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