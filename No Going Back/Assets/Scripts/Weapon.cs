using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Weapon : MonoBehaviour
{
    Animator anim;    

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Weapon" && Input.GetKeyDown(KeyCode.R))
        {
            PlayerFocus.barsIn = true;
            PlayerLook.freezeLook = true;
            PlayerMove.freezeMove = true;
            Destroy(other.GetComponent<Scythe>());
            transform.LookAt(new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z));
            if (Vector3.Distance(new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z), transform.position) < 2f)
            {
                transform.position -= transform.forward * 2;
            }
            other.transform.localEulerAngles = new Vector3(-89.972f, 0, 70.5f);
            transform.position = new Vector3(-216.5f, 8.8724f, 138.72f);
            transform.localEulerAngles = new Vector3(0, -79.086f, 0);
            Camera.main.transform.localEulerAngles = new Vector3(3.76f, 23.7f, 0);
            anim.SetTrigger("Reach");
            Invoke("Explosion", 3.5f);
        }
    }

    void Explosion()
    {
        SceneManager.LoadScene(3);
    }

    void PauseEditor()
    {
        Debug.Break();
    }

    void Start ()
    {
        anim = GetComponent<Animator>();
	}
	
	void Update ()
    {
		
	}
}
