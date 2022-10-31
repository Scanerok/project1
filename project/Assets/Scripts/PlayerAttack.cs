using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    private GameObject[] fireballs;

    private Animator anim;
    private Player playerMovement;
    private float cooldownTimer = Mathf.Infinity;

    private States State
    {
        get { return (States)anim.GetInteger("state"); }
        set { anim.SetInteger("state", (int)value); }
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<Player>();
       
    }

    private void Start()
    {
        fireballs = GameObject.FindGameObjectsWithTag("Fireballs");
    }

    private void Update()
    {
        
        if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown)
            Attack();

        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        State = States.attack;
        cooldownTimer = 0;

        fireballs[0].transform.position = firePoint.position;
        fireballs[0].GetComponent<Fireball>().SetDirection(Mathf.Sign(transform.localScale.x));
    }
}
