using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private LayerMask groundLayer;
    
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(Input.GetAxis("Horizontal")* speed, body.velocity.y);

        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(2, 2, 0);
        if(horizontalInput < -0.01f)
            transform.localScale = new Vector3(-2, 2, 0);

        if (Input.GetKey(KeyCode.Space) && isGrounded())
            Jump();

        anim.SetBool("walk", horizontalInput != 0);
        anim.SetBool("grounded", isGrounded());
        anim.SetBool("push", canMoving());
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jumpPower);
        anim.SetTrigger("jump");
        
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    private bool canMoving()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    public bool canAttack()
    {
        return isGrounded();
    }
}
