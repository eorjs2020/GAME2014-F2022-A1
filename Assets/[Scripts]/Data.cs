using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : Singleton<Data>
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public int health { get; set; }
    public int score { get; set; }
    public int currency { get; set; }
    public int waveAmount { get; set; }
    public int enemyAmount { get; set; }
}
