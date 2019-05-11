using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFocus : MonoBehaviour
{
    bool lookAtShip;
    Quaternion shipQuaternion;
    //Quaternion enemyQuaternion;
    Transform target;
    Vector3 shipViewPosition;
    int shipZoom;
    int enemyZoom;
    bool zoomIn;
    bool zoomOut;
    int fov;
    public Image topBar;
    public Image bottomBar;
    public static bool barsIn, barsOut;
    float barsRate;
    bool lookAtEnemy;
    bool lookAtBoss;
    GameObject enemy;
    bool roar;
    GameObject boss;
    Tutorial tutorial;
    int enemyLook;

    void Start ()
    {
        enemyLook = 0;
        tutorial = FindObjectOfType<Tutorial>();
        barsRate = 0.03f;
        target = GameObject.FindGameObjectWithTag("Ship").transform;
        shipQuaternion = new Quaternion(0.0f, -0.5f, 0.0f, 0.9f);
        //enemyQuaternion = new Quaternion(0.0f, 1.0f, 0.0f, 0.1f);
        shipZoom = 10;
        enemyZoom = 15;
        fov = 60;
        shipViewPosition = new Vector3(197, 23, 80);
    }
	
	void Update ()
    {
        //print(transform.rotation);
        if(barsIn)
        {
            topBar.fillAmount += barsRate;
            bottomBar.fillAmount += barsRate;
            if (topBar.fillAmount >= 1f && bottomBar.fillAmount >= 1f)
            {
                barsIn = false;
            }
        }
        if (barsOut)
        {
            topBar.fillAmount -= barsRate;
            bottomBar.fillAmount -= barsRate;
            if (topBar.fillAmount <= 0 && bottomBar.fillAmount <= 0)
            {
                barsOut = false;
            }
        }
        if (lookAtShip)
        {
            Vector3 targetDir = target.position - transform.position;

            // The step size is equal to speed times frame time.
            float step = 1 * Time.deltaTime;

            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
            Debug.DrawRay(transform.position, newDir, Color.red);

            // Move our position a step closer to the target.
            transform.rotation = Quaternion.LookRotation(newDir);

            Camera.main.transform.localPosition = Vector3.zero;
            Camera.main.transform.localEulerAngles = new Vector3(-2f, 0, 0);

            //transform.localPosition = shipViewPosition;

            if(transform.rotation == shipQuaternion && !zoomOut)
            {
                zoomIn = true;
            }

            if(zoomIn)
            {
                if(Camera.main.fieldOfView<=shipZoom)
                {
                    zoomIn = false;
                    Invoke("ZoomOut", 3);
                }
                else
                {
                    Camera.main.fieldOfView -= 0.3f;
                }
            }

            if(zoomOut)
            {
                if(Camera.main.fieldOfView >= fov)
                {
                    BarsOut();
                    zoomOut = false;
                    lookAtShip = false;
                    PlayerLook.freezeLook = false;
                    PlayerMove.freezeMove = false;
                }
                else
                {
                    Camera.main.fieldOfView += 0.3f;
                }
            }
            //print(transform.rotation);
        }
        if (lookAtEnemy)
        {
            Vector3 targetDir = enemy.transform.position - transform.position;

            // The step size is equal to speed times frame time.
            float step = 1 * Time.deltaTime;

            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
            Debug.DrawRay(transform.position, newDir, Color.red);

            // Move our position a step closer to the target.
            transform.rotation = Quaternion.LookRotation(newDir);

            Camera.main.transform.localPosition = Vector3.zero;
            Camera.main.transform.localEulerAngles = new Vector3(-5.86f, 0, 0);

            //transform.localPosition = shipViewPosition;

            if (!zoomOut && !roar)
            {
                //Debug.Break();
                //print("lol");
                zoomIn = true;
            }

            if (zoomIn)
            {
                if (Camera.main.fieldOfView <= enemyZoom)
                {
                    zoomIn = false;
                    if (!roar)
                    {
                        enemy.GetComponent<Enemy>().Roar();
                        roar = true;
                    }
                    Invoke("ZoomOut", 3);
                    //Camera.main.fieldOfView = shipZoom + 1;
                }
                else
                {
                    Camera.main.fieldOfView -= 0.3f;
                }
            }

            if (zoomOut)
            {
                if (Camera.main.fieldOfView >= fov)
                {
                    BarsOut();
                    //Debug.Break();
                    zoomOut = false;
                    print("ZoomOut is False");
                    lookAtEnemy = false;
                    PlayerLook.freezeLook = false;
                    PlayerMove.freezeMove = false;
                    roar = false;
                    if(enemyLook == 1)
                    {
                        tutorial.ShowTutorial("Press Left mouse button to Attack");
                    }
                }
                else
                {
                    Camera.main.fieldOfView += 0.3f;
                }
            }
            //print(transform.rotation);
        }

        if(lookAtBoss)
        {
        }
    }

    void ZoomOut()
    {
        zoomOut = true;
    }

    public void LookAtShip()
    {
        lookAtShip = true;
        BarsIn();
    }

    public void LookAtEnemy(GameObject e)
    {
        enemyLook += 1;
        enemy = e;
        lookAtEnemy = true;
        BarsIn();
    }

    public void LookAtBoss()
    {
        boss = GameObject.FindGameObjectWithTag("Boss");
        boss.GetComponent<Boss>().BossSequence();
        transform.position = new Vector3(-213f, 9.5f, 123f);
        transform.localEulerAngles = new Vector3(0, -38f, 0);
        Camera.main.transform.localEulerAngles = new Vector3(-11f, 0, 0);
        //Camera.main.transform.localEulerAngles = new Vector3(7f, 0, 0);
        lookAtBoss = true;
        BarsIn();
    }

    void BarsIn()
    {
        barsIn = true;
    }

    void BarsOut()
    {
        barsOut = true;
    }
}
