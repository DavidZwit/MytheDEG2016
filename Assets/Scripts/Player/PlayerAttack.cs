﻿using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

    GameObject throwableObj;
    EventHandeler handeler;
    Projectile projectile;
    bool attacking;
    bool canThrow = false;
    int hitRange = 9;

	void Awake()
    {
        handeler = GameObject.Find("Handeler").GetComponent<EventHandeler>();
        projectile = GameObject.Find("Handeler").GetComponent<Projectile>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            RaycastHit hit;
            if (!canThrow) {
                Debug.DrawRay(transform.position, transform.forward);
                if (Physics.Raycast(new Ray(new Vector3(transform.position.x, transform.position.y - 5f, transform.position.z), transform.forward), out hit, hitRange) ||
                    Physics.Raycast(new Ray(new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), transform.forward), out hit, hitRange)) {
                    if (hit.collider.gameObject.tag == "Throwable") {
                        canThrow = true;
                        throwableObj = hit.collider.gameObject;
                        projectile.PickupProjectile(throwableObj);
                    }
                }
            }
            else {
                projectile.ShootProjectile(throwableObj);
                canThrow = false;
            }
        }
    }
}
