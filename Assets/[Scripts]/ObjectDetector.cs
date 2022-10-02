using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ObjectDetector : MonoBehaviour
{
    [SerializeField]
    private TowerSpawner towerSpawner;

    private Camera cam;
    private Ray ray;
    private RaycastHit hit;

   
    public Text Health;
    public Text Currency;    
    


    private GameObject currentTower;
    public GameObject towerUI;
    private void Awake()
    {
        Data.Instance.health = 10;
        Data.Instance.score = 0;
        Data.Instance.currency = 140;
        cam = Camera.main;        
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetMouseButton(0))
        foreach (var touch in Input.touches)
        {
            ray = cam.ScreenPointToRay(touch.position);


            if(Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                Tile tile = hit.transform.gameObject.GetComponent<Tile>();

                if (hit.transform.CompareTag("SpawnTile")&& !(tile.isBuildTower))
                {                    
                    towerUI.SetActive(true);
                    towerUI.transform.position = hit.transform.position;

                    currentTower = hit.transform.gameObject;
                }
            }
        }

        
        Health.text = Data.Instance.health.ToString();
        Currency.text = Data.Instance.currency.ToString();
        

        if (Data.Instance.health <= 0 || Data.Instance.enemyAmount <= 0)
        {
            EndState();
        }
    }

    public void TowerSpawn(int towerIndex)
    {        
        towerUI.SetActive(false);
        towerSpawner.SpawnTower(currentTower.transform, towerIndex);        
    }

    public void EndState()
    {
        Debug.Log("done");
        SceneManager.LoadScene("EndState");
    }
}
