using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnRandomShape : MonoBehaviour
{

    /// <summary>
    /// Wait for few seconds before spawn object that user need to look for and click
    /// 
    /// </summary>
    private float XTransform;
    private float YTransform;
    private float ZTransform;
    
    public GameObject[] shapes;
    private int objectChoose;
    private GameObject spawnedObject;
    private GameObject audioObj;
    private scoreBoard scoreabord;
    private float minSpeed = 1f ;
    private float maxSpeed = 5f; 
    

    int counter = 2;
    private float waitTime = 0f;
    int value = 25; // change this value to change the exchange time [higher = long time for max range to change]
    float maxRange = 50f; // [CHANGE]

    


    void Start()
    {
        scoreabord = FindObjectOfType<scoreBoard>();
    }

    // Update is called once per frame
    void Update()
    {
        // Time before choosing different obj at the bottom 
        if (waitTime <= 0)
        {
            Destroy(spawnedObject);
            objectChoose = Random.Range(0, 4);
            //Warning audio: Instantiate before Spawning object at the bottom 
            this.GetComponent<AudioSource>().Play();
            // Spawn randomly choosen gameobject 
            spawnedObject = Instantiate(shapes[objectChoose], this.transform.position, Quaternion.identity) as GameObject;
            spawnedObject.GetComponent<ObjectShape>().enabled = false;
            spawnedObject.GetComponent<MeshCollider>().isTrigger = false;
            spawnedObject.GetComponent<MeshCollider>().convex = false;
            //[2f, 40f] 
            waitTime = returnWaitTime();



        }
        else
        {
            waitTime -= Time.deltaTime;
        }

        XTransform = Random.Range(1f, 30f);
        YTransform = Random.Range(1f, 30f);
        ZTransform = Random.Range(1f, 20f);

        spawnedObject.transform.Rotate(new Vector3(XTransform, YTransform, ZTransform) * Time.deltaTime);
/*        print(minSpeed);
        print(maxSpeed); */
    }


    public string returnThisTag()
    {
        return this.shapes[objectChoose].tag;
    }
    private float returnWaitTime() {
        if (scoreabord.returnScore() >= value)
        {
            value = value * counter;
            counter++;
            minSpeed += 1f;
            maxSpeed += 1f; 
            if (maxRange >= 10f)
            {
                maxRange = maxRange / (counter / 2);
            }
            else
            {
                maxRange = 10f;
            }
        }
        return Random.Range(2f, maxRange); 
    }
    public int returnCounter()
    {
        return this.counter; 
    }
    public float returnSpeed()
    {
        return Random.Range(this.minSpeed, this.maxSpeed); 
    }
}

