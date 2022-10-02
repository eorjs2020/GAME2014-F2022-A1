using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform[] path;    
    private Movements movements;
    private int currentIndex = 0;
    private int pathCount;
    private Spawner spawner;
    private AudioSource damagesound;
    private float health = 10;
    // Start is called before the first frame update
    public void Setup(Spawner spawner, Transform[] paths)
    {
        movements = GetComponent<Movements>();
        this.spawner = spawner;
        pathCount = paths.Length;
        this.path = new Transform[pathCount];
        this.path = paths;

        transform.position = path[currentIndex].position;

        StartCoroutine("OnMove");
        damagesound = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    private IEnumerator OnMove()
    {
        NextMoveTo();

        while (true)
        {
            

            if (Vector3.Distance(transform.position, path[currentIndex].position) < 0.02f * movements.MoveSpeed)
            {
                NextMoveTo();
            }

            yield return null;
        }
    }

    private void NextMoveTo()
    {
        if(currentIndex < pathCount - 1)
        {
            transform.position = path[currentIndex].position;
            currentIndex++;
            Vector3 direction = (path[currentIndex].position - transform.position).normalized;
            movements.MoveTo(direction);
        }
        else
        {
            Data.Instance.health -= 1;
            Dead();
        }
    }

    public void TakeDamage(float damage)
    {
        damagesound.Play();
        health -= damage;

        //Monster Die
        if (health <= 0)
        {
            health = 0;
            Data.Instance.score += 100;
            Data.Instance.enemyAmount -= 1;
            Data.Instance.currency += 35;
            Dead();
        }
       
    }

    public void Dead()
    {
        spawner.DestroyEnemy(this);
    }
}
