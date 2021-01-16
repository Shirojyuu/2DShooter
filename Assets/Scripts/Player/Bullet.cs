using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float moveSpeed;
    public int damage;
    public AudioClip hitSound;

    private bool goingLeft;

	// Update is called once per frame
	void FixedUpdate () {
        if (goingLeft)
            transform.Translate(Vector2.left * moveSpeed * Time.fixedDeltaTime);
        else
            transform.Translate(Vector2.right * moveSpeed * Time.fixedDeltaTime);
	}

    public void SetMovingLeft()
    {
        goingLeft = true;
    }

    public void OffsetBullet(float offset)
    {
        if (goingLeft)
            transform.Translate(Vector2.left * offset);
        else
            transform.Translate(Vector2.right * offset);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            Health hp = collision.GetComponent<Health>();

            if (hp)
            {
                hp.TakeDamage(damage);
                SoundManager.PlaySound(hitSound);
            }
        }

        if (!collision.CompareTag("Player") && !collision.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }
}
