using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Another : MonoBehaviour
{
    private List<Enemy> enemies;

    public void Awake()
    {
        enemies = new List<Enemy>()
        {
            new EnemyAirplane(),
            new EnemyAirplane(),
            new EnemyAirplane(),
            new EnemyAirplane(),
            new EnemyAirplane(),
            new EnemyAirplane(),
            new EnemyTank(),
            new EnemyTank(),
            new EnemyTank(),
            new EnemyTank(),
            new EnemyTank(),
            new EnemyTank(),
            new EnemyTank(),
            new Enemy(),
            new Enemy(),
            new Enemy(),
            new Enemy(),
            new Enemy(),
            new Enemy(),
            new Enemy(),
            new EnemyTank(),
        };
        
        OurSoldier soldier = new OurSoldier();
        for (int i = 0; i < enemies.Count; i++)
        {
            soldier.PutDamage(enemies[i]);
        }
    }

    public class Enemy : MonoBehaviour
    {
        public Animator animator;
        public float HP;

        public void Walk(List<Vector3> path)
        {
            
        }
        
        public virtual void GetDamage(float damage)
        {
            HP -= damage;
            if (HP <= 0)
                Die();
        }

        public virtual void Die()
        {
            animator.Play("EnemyDie");
        }
    }

    public class EnemyTank : Enemy
    {
        public float Armor;

        public override void GetDamage(float damage)
        {
            HP -= (damage - Armor);
        }

        public override void Die()
        {
            animator.Play("TankDie");
        }
    }
    
    public class EnemyAirplane : Enemy
    {
        public float Armor;
        public float ChanceToEvadeDamage = 40f;

        public override void GetDamage(float damage)
        {
            if (Random.Range(0,100) > ChanceToEvadeDamage)
            {
                HP -= (damage - Armor);
            }
        }
    }

    public class OurSoldier
    {
        public float Damage;
        
        public void PutDamage(Enemy enemy)
        {
            enemy.GetDamage(Damage);
        }
    }
}
