using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform target;
    float speed = 3f;

        
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
    }

 

    // Update is called once per frame
    private void Update()
    {
        Vector3 position = target.position;
        position.z = transform.position.z;
        position.y = 2f;
        transform.position = Vector3.Lerp(transform.position, position, speed * Time.deltaTime);
    }
}
