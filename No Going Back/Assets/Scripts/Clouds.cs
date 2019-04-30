using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{
    public GameObject cloudPrefab;
    public int numberOfClouds;
    public float cloudHeight;
    public float minX, maxX, minZ, maxZ;

	void Start ()
    {
        GenerateClouds();
	}
	
	void Update ()
    {
		
	}

    void GenerateClouds()
    {
        for(int i=0; i<numberOfClouds; i++)
        {
            GameObject cloud = Instantiate(cloudPrefab, new Vector3(Random.Range(minX, maxX), cloudHeight, Random.Range(minZ, maxZ)), Quaternion.identity);
            cloud.transform.localScale = new Vector3(Random.Range(3,10), Random.Range(3, 5), Random.Range(3, 4));
            cloud.transform.parent = transform;
        }
    }
}
