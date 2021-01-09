using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class audioScript : MonoBehaviour
{

    private static int index = 0; 
    public AudioClip[] clip;
    private AudioSource audioClip; 
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(destroySound()); 

    }

    IEnumerator destroySound()
    {
        audioClip = this.GetComponent<AudioSource>();
        audioClip.clip = this.clip[index];
        audioClip.Play();
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject); 
    }

    public void changeIndex(int i)
    {
        index = i; 
    }


}
