using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject target;
    Animator anim;
    float distanceToTarget;
    float chaseRange;
    float attackRange;
    float attackRate;
    float attackTime;
    float damage;
    float health;
    Subtitles subtitles;

	void Start ()
    {
        subtitles = FindObjectOfType<Subtitles>();
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player");
        chaseRange = 30f;
        attackRange = 6f;
        attackTime = 0;
        attackRate = 1.5f;
        damage = 10;
        health = 100f;
	}
	
	void Update ()
    {
        distanceToTarget = Vector3.Distance(transform.position, target.transform.position);
        //print(distanceToTarget);
        if(distanceToTarget <= chaseRange)
        {
            Chase();
        }
        else
        {
            anim.SetBool("Chase", false);
            //anim.SetBool("Idle", true);
        }
	}

    void Chase()
    {
        if (distanceToTarget <= attackRange)
        {
            target.GetComponent<Combat>().closestEnemy = gameObject;
            if (Time.time >= attackTime)
            {
                Attack();
            }
            else
            {
                anim.SetBool("Chase", false);
            }
        }
        else
        {
            anim.SetBool("Chase", true);
            transform.LookAt(new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z));
            transform.position += transform.forward * 0.1f;
        }
    }

    void Attack()
    {
        anim.SetTrigger("Attack");
        Invoke("DealDamage", 0.6f);
        attackTime = Time.time + attackRate;
    }

    void DealDamage()
    {
        target.GetComponent<Combat>().TakeDamage(damage);
    }

    public void TakeDamage()
    {
        health -= 20f;
        if(health<=0)
        {
            Fall();
        }
    }

    public void Roar()
    {
        anim.SetTrigger("Roar");
    }

    void Fall()
    {
        if (Subtitles.enemies == 2)
        {
            subtitles.PlaySubtitle("S3Demon1D");
        }
        else if (Subtitles.enemies == 3)
        {
            subtitles.PlaySubtitle("S3Demon2D");
        }
        else if (Subtitles.enemies == 4)
        {
            subtitles.PlaySubtitle("S3Demon3D");
        }
        else if (Subtitles.enemies == 5)
        {
            subtitles.PlaySubtitle("S3Demon4D");
        }
        else if (Subtitles.enemies == 6)
        {
            subtitles.PlaySubtitle("S3Demon5D");
        }
        anim.SetTrigger("Fall");
        Destroy(gameObject, 1.5f);
    }
}
