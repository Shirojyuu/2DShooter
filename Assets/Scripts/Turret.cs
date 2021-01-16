using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {
    public GameObject objectToFire;
    public float shotDelay;

    private float shotDelayTimer;
	
	// Update is called once per frame
	void Update () {
        if (shotDelayTimer > 0.0f)
            shotDelayTimer -= Time.deltaTime;
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(shotDelayTimer <= 0.0f && collision.CompareTag("Player"))
        {
            GameObject newBullet = Instantiate(objectToFire, transform.position, Quaternion.identity);
            newBullet.GetComponent<EnemyBullet>().SetDirection((collision.transform.position - transform.position).normalized);
            newBullet.GetComponent<EnemyBullet>().OffsetBullet(1.0f);
            shotDelayTimer = shotDelay;
        }
    }
}
