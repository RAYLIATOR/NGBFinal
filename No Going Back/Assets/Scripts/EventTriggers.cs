using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTriggers : MonoBehaviour
{
    PlayerFocus playerFocus;
    Subtitles subtitles;
    public GameObject memoryPrefab;
    GameObject canvas;
    int memory;
    public string subtitle;
    public GameObject enemy;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (gameObject.tag == "LookAtShip")
            {
                if(canvas.tag == "1")
                {
                    subtitles.PlaySubtitle("S1TopRocks");
                }
                else if (canvas.tag == "2")
                {
                    subtitles.PlaySubtitle("S2TopRocks");
                }
                else if (canvas.tag == "3")
                {
                    subtitles.PlaySubtitle("S3TopRocks");
                }
                playerFocus.LookAtShip();
                Destroy(gameObject);
            }
            if (gameObject.tag == "LookAtEnemy" && other.gameObject.transform.position.y > 6.019f && other.gameObject.transform.position.y < 6.021f)
            {
                subtitles.PlaySubtitle("S3Demon1");
                PlayerLook.freezeLook = true;
                PlayerMove.freezeMove = true;
                playerFocus.LookAtEnemy(enemy);
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
                subtitles.PlaySubtitle(subtitle);                
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
        memory = 1;
        canvas = FindObjectOfType<Canvas>().gameObject;
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
