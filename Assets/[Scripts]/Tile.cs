using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool isBuildTower = false;

    private void Awake()
    {
        isBuildTower = false;
    }
}
