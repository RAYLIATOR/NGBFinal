using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObjects : MonoBehaviour
{
    public GameObject newTree;

	void Start ()
    {
        ReplaceObjects("Tree");
        //RandomRotate("Tree");
	}
	
	void Update ()
    {
		
	}

    void ResizeObjects(string tag)
    {
        List<GameObject> objects = new List<GameObject>();
        objects.AddRange(GameObject.FindGameObjectsWithTag(tag));
        for (int i = 0; i < objects.Count; i++)
        {
            objects[i].transform.localScale = new Vector3(objects[i].transform.localScale.x, Random.Range(1f, 1.5f), objects[i].transform.localScale.z);
        }
    }

    void ReplaceObjects(string tag)
    {
        List<GameObject> objects = new List<GameObject>();
        objects.AddRange(GameObject.FindGameObjectsWithTag(tag));
        for (int i = 0; i < objects.Count; i++)
        {
            GameObject nTree = Instantiate(newTree, objects[i].transform.position, objects[i].transform.rotation);
            nTree.transform.parent = transform; 
            nTree.transform.Rotate(-90, 0, Random.Range(0f, 360f));
            nTree.transform.localScale = new Vector3(nTree.transform.localScale.x, nTree.transform.localScale.y, Random.Range(141, 165));
            Destroy(objects[i]);
        }
    }

    void RandomRotate(string tag)
    {
        List<GameObject> objects = new List<GameObject>();
        objects.AddRange(GameObject.FindGameObjectsWithTag(tag));
        for (int i = 0; i < objects.Count; i++)
        {
            objects[i].transform.Rotate(0, Random.Range(0f,360f), 0);
            objects[i].transform.localScale = new Vector3(objects[i].transform.localScale.x, Random.Range(1f, 1.5f), objects[i].transform.localScale.z);
        }
    }
}
