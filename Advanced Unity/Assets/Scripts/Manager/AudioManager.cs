using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    AudioSource AS;
    // Start is called before the first frame update
    void Start()
    {
        AS = GetComponent<AudioSource>();
    }

    public void PlayClipOnce(SoundEffect se, GameObject obj)
    {
        AudioSource objAS = obj.GetComponent<AudioSource>();

        if (objAS != null)
        {
            objAS = obj.AddComponent<AudioSource>();
        }
        AudioClip clip = se.GetClip();

        if (clip == null)
            return;

        objAS.volume = se.Volume;
        objAS.spatialBlend = se.SpatialBlend;
        objAS.PlayOneShot(clip);
    }

    internal void PlayClipOnce(SoundEffect onTakeDamageSE)
    {
        throw new NotImplementedException();
    }

    public void PlayClipOnce(SoundEffect se, AudioSource aS)
    {
        PlayClipOnce(se, this.gameObject);
    }

    /*
    public void OnInteract()
    {
        interactEvt.Invoke();
        AudioManager.Instance.PlayClipOnce();
    }
    */
}

