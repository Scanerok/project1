using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Demon : Entity
{
    [SerializeField] private int lives = 3; // количество жизней
    public float speed = 1f;
    public int positionOfPatrol;
    public Transform point;
    public float stoppingDistance;

    private SpriteRenderer sprite;
    private Rigidbody2D rb;
    private Animator anim;

    private States State
    {
        get { return (States)anim.GetInteger("state"); }
        set { anim.SetInteger("state", (int)value); }
    }

    bool moveingRight = true;
    bool chill = false;
    bool angry = false;
    bool goBack = false;

    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        sprite = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Vector2.Distance(transform.position, point.position) < positionOfPatrol && angry == false)
        {
            chill = true;
        }
        if (Vector2.Distance(transform.position, player.position) < stoppingDistance)
        {
            angry = true;
            chill = false;
            goBack = false;
        }
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            goBack = true;
            angry = false;
        }

        if (chill == true)
        {
            Chill();
        }
        else if (angry == true)
        {
            Angry();
        }
        else if (goBack == true)
        {
            GoBack();
        }
        sprite.flipX = !moveingRight;
    }


    private void Chill()
    {

        if (transform.position.x > point.position.x + positionOfPatrol)
        {
            moveingRight = false;
        
        }
        else if (transform.position.x < point.position.x - positionOfPatrol)
        {
            moveingRight = true;
        
        }

        if (moveingRight)
        {
            
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
            State = States.walk;
            
        }
        else
        {

            
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
            State = States.walk;
            
        }

    }

    void Angry()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        State = States.walk;
    }

    void GoBack()
    {
        transform.position = Vector2.MoveTowards(transform.position, point.position, speed * Time.deltaTime);
        State = States.walk;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Player.Instance.gameObject)
        {
            Player.Instance.GetDamage();
        }
    }


    public void GetDamage()
    {
        lives -= 1;
        Debug.Log(lives);

        State = States.hurt;
    }


    public enum States
    {
        idle,
        walk,
        jump,
        attack,
        hurt,
        death,
    }
}