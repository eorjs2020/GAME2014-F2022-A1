using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    public GameObject[] tower;

    public void SpawnTower(Transform towerTransform, int Index)
    {
        Tile tile = towerTransform.GetComponent<Tile>();

        if (tile.isBuildTower == true || Data.Instance.currency < 70)
        {
            return;
        }
        else
        {
            Data.Instance.currency -= 70;
            tile.isBuildTower = true;
            Instantiate(tower[Index], towerTransform.position, Quaternion.identity);
        }
        
    }
       
}
