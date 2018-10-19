﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFlash : MonoBehaviour {

    public GameObject flashholder;

    public Sprite[] flashSprites;

    public SpriteRenderer[] spriteRenderers;

    public float flashTime;
    void Start()
    {

    }


    public void Activate (){
        flashholder.SetActive(true);

        int flashSpriteIndex = Random.Range(0, flashSprites.Length);
        for (int i = 0; i < spriteRenderers.Length; i++){
            spriteRenderers[i].sprite = flashSprites[flashSpriteIndex];
        }

        Invoke("Deactivate", flashTime);

    }

    public void Deactivate() {

        flashholder.SetActive(false);

    }
}


