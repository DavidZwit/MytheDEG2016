﻿using UnityEngine;
using System.Collections;

public class AddChildsToContainer : MonoBehaviour {
    [SerializeField] //Booleans to togle the modes
    bool removeOnFPS, removeOverTime, fadeBeforeDelete, 
        turnOffCollidionInChildren;
    [SerializeField] //Floats to tweak the speeds
    float lifeTime = 5, fadeTime = 3, fadeSmoothness = 0.1f;

    //VAriables for fading
    float startTime;
    float timeFadingLeft;
    MeshRenderer[] childranAlpha;

    void Awake() {
        //Put the chards in the chard dump to be deleted if needed
        if (removeOnFPS) {
            PreformanceHandeler chardDump = GameObject.Find("Handeler").GetComponent<PreformanceHandeler>();

            foreach (Transform child in transform) {
                chardDump.BrokenPeases.Add(child.gameObject);
            }
        } 
        //Delete de chards in X seconds
        if (removeOverTime || turnOffCollidionInChildren) {
            Invoke("DestroyThis", lifeTime);
        }
        //Fade the chards out before deleting
        if (fadeBeforeDelete) {
            //Finding the cilds to fade and preping variables
            childranAlpha = transform.GetComponentsInChildren<MeshRenderer>();
            startTime = Time.time + lifeTime;
            timeFadingLeft = fadeTime;
            //Starting the fade loop
            InvokeRepeating("Fade", lifeTime - fadeTime, fadeSmoothness);
        }
    }

    void DestroyThis() {
        //If it is not going to delete it and the turn rigidbody option is on turn collidion off
        if (!fadeBeforeDelete && !removeOverTime && turnOffCollidionInChildren) {
            MeshCollider[] childColliders = transform.GetComponentsInChildren<MeshCollider>();
            Rigidbody[] childRigidbodies = transform.GetComponentsInChildren<Rigidbody>();
            foreach (MeshCollider collider in childColliders)
                Destroy(collider);
            foreach (Rigidbody rigidbody in childRigidbodies)
                Destroy(rigidbody);
        } else Destroy(gameObject);
        //else just delete it
    }

    void Fade() {
        //Calculating how long buissy fading
        float timeFading = startTime - Time.time;
        //Calculating how much time is left
        timeFadingLeft = timeFading / fadeTime;
        //If fading is over stop fading
        if (timeFading > fadeTime) {
            DestroyThis();
        } //Change alpha to timeFading
        foreach (MeshRenderer renderer in childranAlpha) {
            if (renderer != null) {
                Color newColor = renderer.materials[0].color;
                newColor.a = timeFadingLeft;

                renderer.materials[0].color = newColor;
            }
        }
    }
}
