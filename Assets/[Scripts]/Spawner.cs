using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private float spawnTime;
    [SerializeField]
    private Transform[] paths;
    private List<Enemy> enemyList;

    public int wave;


    public List<Enemy> EnemyList => enemyList;
    // Start is called before the first frame update
    void Awake()
    {
        Data.Instance.waveAmount = Data.Instance.enemyAmount = wave;
        enemyList = new List<Enemy>();
        StartCoroutine("SpawnEnemy");
    }

    public void Update()
    {
        if(Data.Instance.waveAmount <= 0)
        {
            StopCoroutine("SpawnEnemy");
        }
    }

    private IEnumerator SpawnEnemy()
    {
        while(true)
        {
            GameObject clone = Instantiate(enemyPrefab);
            Enemy enemy = clone.GetComponent<Enemy>();
            enemy.Setup(this, paths);
            enemyList.Add(enemy);
            --Data.Instance.waveAmount;
            yield return new WaitForSeconds(spawnTime);
        }
    }

    public void DestroyEnemy(Enemy enemy)
    {
        enemyList.Remove(enemy);
        Destroy(enemy.gameObject);
    }
}
