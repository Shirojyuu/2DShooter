using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float jumpForce;
    public GameObject bullet;
    public AudioClip landSound, shootSound;
    
    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 velocity, size;
    private float xScale;
    private bool facingLeft;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        size.x = GetComponent<Collider2D>().bounds.extents.x * 2.0f;
        size.y = GetComponent<Collider2D>().bounds.extents.y * 2.0f;
        xScale = transform.localScale.x;
	}
	
	public void ProcessInput(float move, bool jumpKeyPressed, bool shootKeyPressed)
    {
        //move
        velocity = rb.velocity;
        velocity.x = move * moveSpeed;

        //jump
        if (jumpKeyPressed && CanJump())
        {
            velocity.y = jumpForce;
            anim.SetTrigger("jump");
            anim.SetBool("land", false);
        }

        //shoot
        if (shootKeyPressed)
        {
            Shoot();
        }

        rb.velocity = velocity;
        anim.SetBool("moving", Mathf.Abs(velocity.x) > 0.0f);

        if (velocity.x > 0.0f)
        {
            transform.localScale = new Vector3(xScale, transform.localScale.y, transform.localScale.z);
            facingLeft = false;
        }
        else if (velocity.x < 0.0f)
        {
            transform.localScale = new Vector3(-xScale, transform.localScale.y, transform.localScale.z);
            facingLeft = true;
        }
    }

    private void Shoot()
    {
        anim.SetTrigger("shoot");
        GameObject temp = Instantiate(bullet, transform.position, Quaternion.identity);
        if (facingLeft)
            temp.GetComponent<Bullet>().SetMovingLeft();
        temp.GetComponent<Bullet>().OffsetBullet(size.x);
        SoundManager.PlaySound(shootSound);
    }

    private bool CanJump()
    {
        if (Physics2D.BoxCast(transform.position, size, 0.0f, Vector2.down, 0.1f))
        {
            return true;
        }
        return false;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            anim.SetBool("land", true);
            SoundManager.PlaySound(landSound);
        }
    }
}
