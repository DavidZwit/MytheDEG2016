﻿using UnityEngine;
using System.Collections;
//using UnityEngine.SceneManagement;

public class EventHandeler : MonoBehaviour {
<<<<<<< HEAD
    
=======
	
>>>>>>> 6ebfdbb8244ef058cea9cf79b23103e60811d40f
    RandomShake screenShake;

    private Transform player;
    public delegate void ReachedObjective();
    public static event ReachedObjective _ObjectiveReached;

	AdrenalineBar adrenalineBar;
    AddScore scoreAdd;
    [SerializeField] [Range(0, 100)]
    int perCentWonCodition;
    float brokenObjectsNeededLeft, breakableObjects = 0;

    void Awake()
    {
		adrenalineBar = GameObject.Find("Image").GetComponent<AdrenalineBar> (); 
        scoreAdd = GetComponent<AddScore>();
        screenShake = GameObject.Find("Camera").GetComponent<RandomShake>();
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    void Start()
    {
		InvokeRepeating ("AdrenalineBarDecreasing" ,1 ,2);
        brokenObjectsNeededLeft = (breakableObjects / 100) * Mathf.Abs(perCentWonCodition - 100);
    }

    public float BreakableObjects
    {
        get { return breakableObjects; }
        set { breakableObjects = value;
            if (breakableObjects < brokenObjectsNeededLeft) _ObjectiveReached();
        }
    }

	public void SomethingBroke(GameObject coll)
    {
        scoreAdd.IncreaseScore(100);
        screenShake.Shake(new Vector2(0.5f, 0.3f), 0.8f, 0.01f);
        coll.gameObject.GetComponent<ChangeToBrokenModelOnCollisionWith>().Break();

		//Adds Adrenaline
		adrenalineBar.Adrenaline++;

        if (coll.gameObject.name == "kasteel_model")
            Application.LoadLevel(0);
    }

    public void BulletHitSomething(Collision coll)
    {
        if (coll.gameObject.tag == "Breakable")
        {
            coll.gameObject.GetComponent<ChangeToBrokenModelOnCollisionWith>().Break();
        }
        else if (coll.gameObject.tag == "Player")
        {
<<<<<<< HEAD
            scoreAdd.DecreaseScore(100);
            //remove adrealine
        }
    }

    public void PickupProjectile(GameObject coll)
    {
        Rigidbody rb = coll.GetComponent<Rigidbody>();
        coll.transform.parent = player;
        rb.isKinematic = true;
        rb.useGravity = false;
        rb.position = new Vector3(player.position.x, player.position.y + 3, player.position.z);
    }

    public void ShootProjectile(GameObject coll)
    {
        Rigidbody rb = coll.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.useGravity = true;
        coll.transform.parent = null;
        rb.AddForce(transform.forward * 2500);
    }
=======
			scoreAdd.DecreaseScore(100);
			//Decreases Adrenaline when hit.
			adrenalineBar.Adrenaline -= 5f;
         
        }
    }

	void AdrenalineBarDecreasing()
	{
		//Decreases the adrenalineBar every few seconds.
		adrenalineBar.Adrenaline -= 5f;

		if(adrenalineBar.Adrenaline <= 0f)
		{
			//SceneManager.LoadScene ("StartMenu");
		}

	}
>>>>>>> 6ebfdbb8244ef058cea9cf79b23103e60811d40f
}
