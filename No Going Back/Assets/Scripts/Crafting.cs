using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Crafting : MonoBehaviour
{
    Tutorial tutorial;
    Animator anim;
    Camera cam;
    GameObject axe;
    public GameObject hand;
    public GameObject logPrefab;
    Vector3 logPosition;
    Vector3 treePosition;
    public GameObject woodEffect1;
    public bool inZone;
    public GameObject xMark;
    public GameObject xInstruction;
    bool marked;
    int logsPlaced;
    int logs;
    bool hasAxe;
    public GameObject currentLog;
    public GameObject[] placedLogs;
    public GameObject transitionEffect;
    Subtitles subtitles;

	void Start ()
    {
        tutorial = FindObjectOfType<Tutorial>();
        subtitles = FindObjectOfType<Subtitles>();
        anim = GetComponent<Animator>();
        cam = Camera.main;
        logPosition = new Vector3(3.5f,2.61f,-8.05f);
        logsPlaced = 0;
        logs = 0;
	}

    void Update()
    {
        if (inZone && Input.GetKeyDown(KeyCode.E) && !marked)
        {
            xInstruction.SetActive(false);
            xMark.SetActive(true);
            marked = true;
        }
        if (inZone && Input.GetKeyDown(KeyCode.E) && marked && logs>0)
        {
            Destroy(currentLog);
            placedLogs[logsPlaced].SetActive(true);
            logsPlaced += 1;
            if(logsPlaced == 1)
            {
                subtitles.PlaySubtitle("S1OneDown");
            }
            if(logsPlaced == 4)
            {
                subtitles.PlaySubtitle("S1FourDown");
            }
            logs -= 1;
            if(logsPlaced >= 7)
            {
                Stage2Transition();
            }
        }
    }

    void Stage2Transition()
    {
        subtitles.PlaySubtitle("Stage2Transition");
        transitionEffect.SetActive(true);
        Invoke("LoadStage2", 7.15f);
    }

    void LoadStage2()
    {
        SceneManager.LoadScene(2);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Tree")
        {
            print("Tree");
        }
        if (other.tag == "Tree" && Input.GetKeyDown(KeyCode.E) && hasAxe && logs == 0)
        {
            logs += 1;
            PlayerFocus.barsIn = true;
            PlayerLook.freezeLook = true;
            PlayerMove.freezeMove = true;
            transform.LookAt(new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z));
            if(Vector3.Distance(new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z), transform.position) < 2f)
            {
                transform.position -= transform.forward * 2;
            }
            treePosition = other.transform.position;
            cam.transform.localEulerAngles = new Vector3(50f, 0, 0);
            anim.SetTrigger("Chop");
            Destroy(other.gameObject, 4.8f);
            Invoke("UnPause", 4.8f);
            Invoke("PickUpLog", 4.8f);
        }
        if (other.tag == "Axe" && Input.GetKeyDown(KeyCode.E))
        {
            PlayerFocus.barsIn = true;
            PlayerLook.freezeLook = true;
            PlayerMove.freezeMove = true;
            transform.position = new Vector3(92.88f, 11.672f, 76.26f);
            transform.localEulerAngles = new Vector3(0, 297, 0);
            cam.transform.localEulerAngles = new Vector3(12f, 0, 0);
            anim.SetTrigger("Pick");
            axe = other.gameObject;
            Invoke("PickUpAxe", 2.17f);
            Invoke("UnPause", 7f);
            //Invoke("PauseEditor", 7.43f);
            Destroy(axe.GetComponent<Rigidbody>());
            Destroy(axe.GetComponent<BoxCollider>());
        }
    }

    void LogInstruction()
    {
        tutorial.ShowTutorial("Press E to place log on marked spot");
    }

    void Axe()
    {

    }

    void PauseEditor()
    {
        Debug.Break();
    }

    void PickUpLog()
    {
        GameObject log = Instantiate(logPrefab, transform.position, Quaternion.identity);
        log.transform.parent = transform;
        log.transform.localPosition = logPosition;
        log.transform.localEulerAngles = Vector3.zero;
        currentLog = log;
        Invoke("WoodEffect1", 0);
        if (logsPlaced == 0)
        {
            subtitles.PlaySubtitle("S1Log");
            Invoke("LogInstruction", 3);
        }
    }

    void WoodEffect1()
    {
        Instantiate(woodEffect1, treePosition, Quaternion.Euler(-90,0,0));
    }

    void PickUpAxe()
    {
        hasAxe = true;
        axe.transform.parent = hand.transform;
        axe.transform.localPosition = new Vector3(0.399f, -0.661f, -0.857f);
    }

    void UnPause()
    {
        PlayerLook.freezeLook = false;
        PlayerMove.freezeMove = false;
        PlayerFocus.barsOut = true;
    }
}
