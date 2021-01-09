using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerEnumerator : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(DestroyerSpawn());
    }

    IEnumerator DestroyerSpawn()
    {
        this.transform.position += new Vector3(0.1f, 0f, 0f);
        yield return new WaitForSeconds(0.01f);
        Destroy(this.gameObject);

    }

}
