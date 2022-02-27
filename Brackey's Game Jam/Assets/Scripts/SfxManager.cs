using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxManager : MonoBehaviour
{
    //audio source and clips
    public AudioSource Audio;
    public AudioClip Rock;
    public AudioClip Jump;
    public AudioClip PickUp;
    public AudioClip Hit;
    public static SfxManager SfxInstance;

    private void Awake()
    {
        if (SfxInstance != null && SfxInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        SfxInstance = this;
        DontDestroyOnLoad(this);
    }
}
