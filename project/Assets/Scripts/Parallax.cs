using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private Transform target;

    Material material;

    [SerializeField] float scale = 1.0f;

    Vector2 offset = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        target = target.transform;
        material = GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        offset = new Vector2(target.position.x / 100f/scale, 0f);
        material.mainTextureOffset = offset;

    }
}
