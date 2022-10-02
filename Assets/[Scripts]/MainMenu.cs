using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Text State;
   
    private void Start()
    {
        if (Data.Instance.health > 0)
        {
            State.text = "Win";
           
        }
        else
        {
            State.text = "Loss";
            
        }
    }

    public void GameStart()
    {
        Debug.Log("a");
        SceneManager.LoadScene("Level1");
    }
  
}
