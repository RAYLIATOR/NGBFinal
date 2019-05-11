using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTriggers : MonoBehaviour
{
    Tutorial tutorial;
    PlayerFocus playerFocus;
    Subtitles subtitles;
    public GameObject memoryPrefab;
    GameObject canvas;
    int memory;
    public string subtitle;
    public GameObject enemy;
    public string instruction;

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
                if (Subtitles.enemies == 1)
                {
                    subtitles.PlaySubtitle("S3Demon1E");
                    Subtitles.enemies += 1;
                    playerFocus.LookAtEnemy(enemy);
                }
                else if (Subtitles.enemies == 2)
                {
                    subtitles.PlaySubtitle("S3Demon2E");
                    Subtitles.enemies += 1;
                    playerFocus.LookAtEnemy(enemy);
                }
                else if (Subtitles.enemies == 3)
                {
                    subtitles.PlaySubtitle("S3Demon3E");
                    Subtitles.enemies += 1;
                    playerFocus.LookAtEnemy(enemy);
                }
                else if (Subtitles.enemies == 4)
                {
                    subtitles.PlaySubtitle("S3Demon4E");
                    Subtitles.enemies += 1;
                    playerFocus.LookAtEnemy(enemy);
                }
                else if (Subtitles.enemies == 5)
                {
                    subtitles.PlaySubtitle("S3Demon5E");
                    Subtitles.enemies += 1;
                    playerFocus.LookAtEnemy(enemy);
                }
                PlayerLook.freezeLook = true;
                PlayerMove.freezeMove = true;
                Destroy(gameObject);
            }
            if (gameObject.tag == "LookAtBoss")
            {
                subtitles.PlaySubtitle("S3Boss");
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
            if (gameObject.tag == "Instruction")
            {
                tutorial.ShowTutorial(instruction);
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
        tutorial = FindObjectOfType<Tutorial>();
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
