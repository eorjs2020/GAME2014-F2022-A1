using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform[] path;    
    private Movements movements;
    private int currentIndex = 0;
    private int pathCount;
    
    // Start is called before the first frame update
    public void Setup(Transform[] paths)
    {
        movements = GetComponent<Movements>();

        pathCount = paths.Length;
        this.path = new Transform[pathCount];
        this.path = paths;

        transform.position = path[currentIndex].position;

        StartCoroutine("OnMove");

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
            Destroy(gameObject);
        }
    }
}
