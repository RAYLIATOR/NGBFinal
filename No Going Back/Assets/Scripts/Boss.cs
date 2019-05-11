using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    bool rise;
    Animator anim;
    public GameObject fire;

    void Start ()
    {
        anim = GetComponent<Animator>();
	}
	
	void Update ()
    {
		if(rise)
        {
            if (transform.position.y >= -41.5f)
            {
                rise = false;
                Invoke("Smash", 3);
            }
            else
            {
                transform.position += Vector3.up * 0.1f;
            }
        }
        if(Input.GetKeyDown(KeyCode.G))
        {
            Smash();
        }
	}

    public void BossSequence()
    {
        rise = true;
    }

    public void Smash()
    {
        anim.SetTrigger("Smash");
        Invoke("Fire", 2.7f);
    }

    void Fire()
    {
        fire.SetActive(true);
        Invoke("GameEnd", 2.7f);
    }

    void GameEnd()
    {
        SceneManager.LoadScene(4);
    }
}
