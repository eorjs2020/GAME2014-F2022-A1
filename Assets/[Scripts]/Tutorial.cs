using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public Sprite[] tutoImage;
    public GameObject mainMenuButton;
    public GameObject nextButton;
    public Image panelImage;
    private int index = 0;
    private Data data;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(index >= 2)
        {
            nextButton.SetActive(false);
            mainMenuButton.SetActive(true);            
        }
    }

    public void ChangeImage()
    {
        if (index < 3)
        {
            ++index;
            panelImage.sprite = tutoImage[index];
        }       
    }
    public void BacktoMain()
    {
        data = GameObject.FindObjectOfType<Data>();
        Destroy(data.gameObject);
        SceneManager.LoadScene("MainMenu");
    }
}
