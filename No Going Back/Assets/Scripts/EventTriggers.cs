using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTriggers : MonoBehaviour
{
    PlayerFocus playerFocus;
    Subtitles subtitles;
    public GameObject memoryPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (gameObject.tag == "LookAtShip")
            {
                subtitles.PlaySubtitle("S1TopRocks");
                playerFocus.LookAtShip();
                Destroy(gameObject);
            }
            if (gameObject.tag == "LookAtEnemy")
            {
                PlayerLook.freezeLook = true;
                PlayerMove.freezeMove = true;
                playerFocus.LookAtEnemy();
                Destroy(gameObject);
            }
            if (gameObject.tag == "LookAtBoss")
            {
                PlayerLook.freezeLook = true;
                PlayerMove.freezeMove = true;
                playerFocus.LookAtBoss();
                Destroy(gameObject);
            }
            if (gameObject.tag == "MemoryTrigger")
            {
                PlayerLook.freezeLook = true;
                PlayerMove.freezeMove = true;
                PlayerFocus.barsIn = true;
                other.transform.LookAt(transform);
                Camera.main.transform.localEulerAngles = new Vector3(14, 0, 0);
                Memory();
                Destroy(gameObject);
            }
            if (gameObject.tag == "Zone")
            {
                other.GetComponent<Crafting>().inZone = true;
            }
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (gameObject.tag == "Zone")
            {
                other.GetComponent<Crafting>().inZone = false;
            }
        }
    }

    void Start ()
    {
        subtitles = FindObjectOfType<Subtitles>();
        playerFocus = FindObjectOfType<PlayerFocus>();
    }
	
	void Update ()
    {
		
	}

    void Memory()
    {
        GameObject memory = Instantiate(memoryPrefab, transform.position, Quaternion.identity);
    }
}
