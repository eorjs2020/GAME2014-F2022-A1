using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponState
{ SearchTarget = 0, AttactToTarget = 1} 

public class Turrets : MonoBehaviour
{
    public List<Enemy> _enemies;
    public Enemy CurrentEnemyTarget;
    public GameObject projectile;
    
    bool canAttack;
    float attackTimer = 0;
    public float projectileSpeed, attackCooldown;

    // Start is called before the first frame update
    void Start()
    {
        canAttack = true;
    }

    // Update is called once per frame
    void Update()
    {
        GetCurrentEnemyTarget();
        Attack();
    }
    
    private void Attack()
    {
        if (!canAttack)
        {
            attackTimer += Time.deltaTime;
            if (attackTimer >= attackCooldown)
            {
                canAttack = true;
                attackTimer = 0;
            }
        }
        if (CurrentEnemyTarget != null)
        {
            if (canAttack)
            {
                Shoot();
                canAttack = false;
            }
        }
    }

    private void Shoot()
    {        
        Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Projectile>().Initialize(this);        
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
