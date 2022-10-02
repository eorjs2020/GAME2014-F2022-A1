using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private bool collideMonster = false;

    [SerializeField]
    private int level;

    private Enemy target;
    private Turrets parent;
    private Animator myAnimator;    

    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        MoveToTarget();
    }

    public void Initialize(Turrets parent)
    {
        this.parent = parent;
        target = parent.CurrentEnemyTarget;
        
        collideMonster = false;
    }

    void MoveToTarget()
    {
        if (target != null && target.gameObject.activeSelf)
        {
            
            Vector2 dir = target.transform.position - transform.position;
           
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * parent.projectileSpeed);

            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            
        }
        else {
            Destroy(gameObject);
        }
        if (collideMonster)
            transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (target.gameObject.Equals(collision.gameObject))
            {
                collideMonster = true;
                target.TakeDamage(2);
                Destroy(gameObject);
                
            }
        }
    }
}
