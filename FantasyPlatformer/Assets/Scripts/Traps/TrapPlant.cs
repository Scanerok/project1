using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapPlant : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float attackCooldown;
    private Animator anim;
   


    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
            anim.SetTrigger("activate");
            reload();
            
        }

    }

    private IEnumerator reload()
    {
        for (int i = 0; i < attackCooldown; i++)
        {
            yield return new WaitForSeconds(attackCooldown);
            anim.ResetTrigger("activate");
        }
        
     
    }
}
