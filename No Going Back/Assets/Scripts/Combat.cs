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
    public GameObject fire;
    
    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Enemy" && Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack(other.gameObject);
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
        if (transform.position.y <= 0.5f)
        {
            PlayerMove.freezeMove = true;
            PlayerLook.freezeLook = true;
            PlayerFocus.barsIn = true;
            fire.SetActive(true);
            Invoke("ReloadScene", 3);
        }
        if(health<100 && closestEnemy == null)
        {
            health += 0.1f;
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health<=0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void Attack(GameObject other)
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && Time.time >= attackTime)
        {
            other.GetComponent<Enemy>().TakeDamage();
            anim.SetTrigger("Attack");
            attackTime = Time.time + attackCooldown;
        }
    }

}
