using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrets : MonoBehaviour
{
    public List<Enemy> _enemies;
    Enemy CurrentEnemyTarget;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetCurrentEnemyTarget();
    }

    private void GetCurrentEnemyTarget()
    {
        if(_enemies.Count <= 0)
        {
            CurrentEnemyTarget = null;
            return;
        }

        CurrentEnemyTarget = _enemies[0];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("aa");
        if (collision.CompareTag("Enemy"))
        {
           
            Enemy newenemy = collision.GetComponent<Enemy>();
            _enemies.Add(newenemy);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemy newenemy = collision.GetComponent<Enemy>();
            _enemies.Remove(newenemy);
        }
    }
}
