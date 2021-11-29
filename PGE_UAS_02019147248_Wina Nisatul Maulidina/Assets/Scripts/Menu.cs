using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject MenuImage;
    public GameObject HTPPanel;
    public static bool IsInputEnabled = true;

    // Start is called before the first frame update
    void Start()
    {
        MenuImage.SetActive(true);
        HTPPanel.SetActive(false);
         if(Input.GetKeyDown("l"))
 {
        Menu.IsInputEnabled = false; 
 }
    }


public void MulaiButtonClicked()
{
    MenuImage.SetActive(false);
    HTPPanel.SetActive(true);
    

}

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("l"))
        {
            SceneManager.LoadScene("1");
        }
    
        
    }



 public void Exit_Clicked()
    {
        Application.Quit();
    }


}
