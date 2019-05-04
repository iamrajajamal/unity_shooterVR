using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int health = 100;
    public GameObject bulletPrefab;

    public float shootingCooldown = 0.1f;
    private float shootingTimer;

    public float meeleeCooldown = 0.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        shootingTimer -= Time.deltaTime;

        if (GvrViewer.Instance.Triggered)
        {
            if (shootingTimer <= 0f)
            {
                shootingTimer = shootingCooldown;

                Collider[] colliders = Physics.OverlapSphere(transform.position, 1f);
                bool meeleeAttack = false;
                Enemy meeleEnemy = null;
                foreach (Collider collider in colliders)
                {
                    if (collider.GetComponent<Enemy>() != null)
                    {
                        meeleeAttack = true;
                        meeleEnemy = collider.GetComponent<Enemy>();
                        break;
                    }
                }
                if (meeleeAttack == false)
                {
                    GameObject bulletObject = Instantiate(bulletPrefab);
                    bulletObject.transform.position = this.transform.position;

                    Bullet bullet = bulletObject.GetComponent<Bullet>();
                    bullet.direction = transform.forward;
                }
                else
                {
                    shootingTimer = meeleeCooldown;
                    Destroy(meeleEnemy.gameObject);
                }
            }
        }
	}
}
