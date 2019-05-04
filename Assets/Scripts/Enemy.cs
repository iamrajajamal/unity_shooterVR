using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public Player player;
    public Vector3 direction;

    [SerializeField]
    private float speed = 3.5f;
    public float distanceToStop = 1f;
    public int damage = 3;
    public float eatingInterval = 0.5f;
    private float eatingTimer = 0f;

    public bool chasingPlayer = true;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(transform.position, player.transform.position) < distanceToStop)
        {
            chasingPlayer = false;
        }

        if (chasingPlayer)
        {
            transform.position += direction * speed * Time.deltaTime;
        }
        else
        {
            eatingTimer -= Time.deltaTime;
            if (eatingTimer <= 0f)
            {
                eatingTimer = eatingInterval;
                player.health -= damage;
            }
        }

        
	}
}
