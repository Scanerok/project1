using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBomb : MonoBehaviour
{
    [SerializeField] float damage;
    [SerializeField] private float activateDelay;
    [SerializeField] private float activeTime;

    private Animator anim;
    private SpriteRenderer sprite;

    [SerializeField] private bool triggered;
    [SerializeField] private bool activate;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!triggered)
            {
                StartCoroutine(ActivateBomb());
            }
                
            
            if (activate)
            {
                collision.GetComponent<Health>().TakeDamage(damage);
            }
                
            
        }
    }

    private IEnumerator ActivateBomb()
    {
        triggered = true;
        sprite.color = Color.red;

        yield return new WaitForSeconds(activateDelay);
        activate = true;
        anim.SetBool("active", true);

        yield return new WaitForSeconds(activeTime);
        activate = false;
        gameObject.SetActive(false);
    }

   
}
