using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opossum : Entity
{
    [SerializeField] private int lives = 3;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Player.Instance.gameObject)
        {
            Player.Instance.GetDamage();
            lives--;
            Debug.Log("Обоссум " + lives);
        }
        if (lives < 1)
            Die();
    }   


}

