using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public List<GameObject> shapeObject = new List<GameObject>();

    private int objectChoose;
    private float minSpawnTime; 
    private float maxSpawnTime; 
    private float instantiateEvery;
    public scoreBoard scoreboard; 


    private void Awake()
    {
        scoreboard = FindObjectOfType<scoreBoard>(); 
    }

    void Start()
    {
        minSpawnTime = 0.3f;
        maxSpawnTime = 3f;
        instantiateEvery = 3f; // Instantiate after 3 second soon as the game starts. 
    }

    // Update is called once per frame
    void Update()
    {
        if (instantiateEvery <= 0)
        {
            instantiateObject();
            instantiateEvery = Random.Range(minSpawnTime, maxSpawnTime);
        }
        else
        {
            instantiateEvery -= Time.deltaTime;
        }


        // in objectShape.cs speed has effect on spawn time.
        if(scoreboard.returnScore() >= 0)
        {
            maxSpawnTime = 2.5f; 
        }
        else if(scoreboard.returnScore() >= 50)
        {
            maxSpawnTime = 2f; 
        }else if(scoreboard.returnScore() >= 150)
        {
            maxSpawnTime = 1.5f;
        }else if(scoreboard.returnScore() >= 250)
        {
            maxSpawnTime = 1.2f;
        }
        else
        {
            maxSpawnTime = 1f; 
        }

    }

    private void instantiateObject()
    { 
        objectChoose = Random.Range(0, shapeObject.Count);
        this.shapeObject[objectChoose].GetComponent<ObjectShape>().enabled = true;
        this.shapeObject[objectChoose].GetComponent<MeshCollider>().convex = true;
        this.shapeObject[objectChoose].GetComponent<MeshCollider>().isTrigger = true;
        Instantiate(shapeObject[objectChoose], this.transform.position, Quaternion.identity);

    }




    //s[10f, 15f][0.5f, 3f] very slow 
    //s[15f, 20f][0.5f, 3f] slow 
    //s[20f, 25f][0.5f, 3f] slow + 
    //s[20f, 25f][0.5f, 2f] slow ++
    //s[25f, 30f][0.5f, 2f] mid
    //s[25f, 30f][0.5f, 1f] mid fast 
    //s[40, 50f][0.5f, 1f] fast
    //s[90f, 100f][0.3f, 0.5f] = ultimate fast


}
