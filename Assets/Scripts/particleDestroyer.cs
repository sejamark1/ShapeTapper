using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyDeathParticle()); 
    }

    IEnumerator DestroyDeathParticle()
    {
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);       
    }

}
