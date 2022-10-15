using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{
    private SpriteRenderer sprite;
    private float speed = 1f;

    private void Awake()
    {
        
        sprite = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (Input.GetButton("Horizontal"))
            Run();
    }

    private void Run()
    {
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        
        sprite.flipX = dir.x < 0.0f;
    }



}