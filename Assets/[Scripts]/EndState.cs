using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndState : MonoBehaviour
{
    public Text State;
    public Text Score;
    private void Start()
    {
      /*  if (Data.Instance.health > 0)
        {
            State.text = "Win";
            Score.text = Data.Instance.score.ToString();
        }
        else
        {
            State.text = "Loss";
            Score.text = "";
        }*/
    }

    public void BacktoMain()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
