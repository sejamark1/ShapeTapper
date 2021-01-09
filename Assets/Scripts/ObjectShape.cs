using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class ObjectShape : MonoBehaviour
{

    // Note: 
    // Angular Drag for object -(speed up) + (slow donw) 
    public float speed;   
    private float colourChangeEvery = 0.1f;
    private float XTransform;
    private float YTransform;
    private float ZTransform;
    private string whatDestroyed = "None"; 


    private ParticleSystem destroyerParticle;
    private spawnRandomShape srShape; 
    private Rigidbody rb;
    private Vector3 positionX;
    private Ray ray;
    private GameObject instantiateAudio = null; 


    public GameObject touchDestroyer; 

    [Header("Extras")]
    public scoreBoard scoreboard;
    public ParticleSystem deathParticle;

    [Header("Change Material")]
    public Material[] changeMaterial;
    public Renderer rend;

    [Header("Audio")]
    public GameObject audioObject;
    private audioScript audioS; 


    void Awake()
    {
        scoreboard = GameObject.FindObjectOfType<scoreBoard>();
        srShape = GameObject.FindObjectOfType<spawnRandomShape>();

        rend = GetComponent<Renderer>();
        rend.enabled = true; 


            
    }


    void Start()
    {

        rb = GetComponent<Rigidbody>();

        XTransform = Random.Range(1f, 30f);
        YTransform = Random.Range(1f, 30f);
        ZTransform = Random.Range(1f, 20f);

        audioS = audioObject.GetComponent<audioScript>();
    }

    // Update is called once per frame
    void Update()
    {
        speed = srShape.returnSpeed(); 
        this.transform.Rotate(new Vector3(XTransform, YTransform, ZTransform) * Time.deltaTime);
        this.transform.position += new Vector3(0f, 1f, 0f) * -speed * Time.deltaTime;
        if (colourChangeEvery <= 0)
        {
            rend.sharedMaterial = changeMaterial[Random.Range(0, (changeMaterial.Length - 1))];
            colourChangeEvery = Random.Range(0.1f, 1f); 
        }
        else
        {
            colourChangeEvery -= Time.deltaTime; 
        }



        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0f;
            GameObject destroyer = Instantiate(touchDestroyer, touchPosition, Quaternion.identity);
            Instantiate(touchDestroyer, touchPosition, Quaternion.identity); 



        }





    }

    private void OnTriggerEnter(UnityEngine.Collider other)
    {
        if (other.gameObject.tag == "BottomColliderDestroyer" | other.gameObject.tag == "ShapeDestroyer")
        {
            Destroy(this.gameObject);
        }else if(!(other.tag == "BottomShape" | this.tag == "BottomShape"))
        {
            Instantiate(deathParticle, this.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
        }
        whatDestroyed = other.tag; 
    }

    private void whenObjectPressed()
    {
        if (this.gameObject.tag != "BottomShape")
        {
            if (this.tag != srShape.returnThisTag())
            {
                audioS.changeIndex(1);
            }
            else
            {
                audioS.changeIndex(0);
            }
            Instantiate(deathParticle, this.transform.position, Quaternion.identity);
            Instantiate(audioObject, this.transform.position, Quaternion.identity);
/*            Destroy(this.gameObject);*/
        }
        if (this.tag == srShape.returnThisTag())
        {
            scoreboard.addScore();
        }
        else
        {
            scoreboard.damageCount();

        }

    }
    private void OnDestroy()
    {
        if(whatDestroyed == "ShapeDestroyer")
        {
            whenObjectPressed(); 
        }
    }


}
