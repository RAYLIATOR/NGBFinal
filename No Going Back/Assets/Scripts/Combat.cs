using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Combat : MonoBehaviour
{
    public bool encountered;
    float health;
    public GameObject closestEnemy;
    float attackTime;
    float attackCooldown;
    Animator anim;
    
    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Enemy" && Input.GetKeyDown(KeyCode.Mouse0))
        {
            other.GetComponent<Enemy>().TakeDamage();
            anim.SetTrigger("Attack");
            attackTime = Time.time + attackCooldown;
        }
    }

    void Start ()
    {
        attackTime = 0;
        attackCooldown = 2.5f;
        anim = GetComponent<Animator>();
        health = 100f;
	}

    void Update()
    {
        //Attack();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health<=0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void Attack()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && Time.time >= attackTime)
        {
            anim.SetTrigger("Attack");
            attackTime = Time.time + attackCooldown;
        }
    }

}
