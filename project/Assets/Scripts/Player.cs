using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 3f; // скорость движения
	[SerializeField] private int lives = 5; // количество жизней
	[SerializeField] private float jumpForce = 2f; // Сила прыжка
		
		
	private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;
    private bool isGrounded = false;
	
    public static Player Instance { get; set; }
    

	private States State
    {
        get { return (States)anim.GetInteger("state"); }
        set { anim.SetInteger("state", (int)value); }
    }
	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponent<Animator>();
        Instance = this;
	}
    private void FixedUpdate()
    {
        CheckGround();
    }

    private void Update()
	{
         if (isGrounded) State = States.idle;

		 if (Input.GetButton("Horizontal"))
			 Walk();
		 if (Input.GetButtonDown("Jump") && isGrounded) 
			 Jump();
	}

    private void Walk ()
	{
        if (isGrounded) State = States.walk;

		Vector3 dir = transform.right * Input.GetAxis("Horizontal");
		transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
        sprite.flipX = dir.x < 0.0f;
	}
	
	private void Jump()
	{
        
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
	}
	
	private void CheckGround()
    {
        isGrounded = Mathf.Abs(rb.velocity.y) < 0.05f;

        if (!isGrounded) State = States.jump;
    }
	
    public void GetDamage()
    {
        lives -= 1;
        Debug.Log(lives); 
    }
}
    

public enum States
{
    idle,
    walk,
    jump,
    attack,
}