using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 3f; // скорость движения
	[SerializeField] private int lives = 5; // количество жизней
	[SerializeField] private float jumpForce = 15f; // Сила прыжка
		
		
	private Rigidbody2D rb;
	private SpriteRenderer sprite;
	
	
	
	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		sprite = GetComponentInChildren<SpriteRenderer>();		
		
	}
	
		
	private void Update()
	{
		 if (Input.GetButton("Horizontal"))
			 Run();
		 if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) <0.05f) 
			 Jump();
	}
	
	private void Run()
	{
		Vector3 dir = transform.right * Input.GetAxis("Horizontal");
		
		transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
		
		sprite.flipX = dir.x < 0.0f;
	}
	
	private void Jump()
	{
		rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
	}
	
	
	
}
