using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerDestroyer : MonoBehaviour
{



    private void OnTriggerEnter(UnityEngine.Collider other)
    {

        if (other.gameObject.tag.ToString() == "Untagged")
        {
            Destroy(other.gameObject);
        }


    }



}
