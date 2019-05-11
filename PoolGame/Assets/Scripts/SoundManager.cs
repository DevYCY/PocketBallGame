using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    public AudioClip snd, snd2;


    private void OnCollisionEnter(Collision coll)
    {
        if(coll.gameObject.tag == "ball")
        {
            AudioSource.PlayClipAtPoint(snd, transform.position);
            AudioListener.volume = 5.0F;
        }
        if (coll.gameObject.tag == "pColl")
        {
            AudioSource.PlayClipAtPoint(snd2, transform.position);
            AudioListener.volume = 30.0F;
        }

    }
}
