using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform playerPos;
    public GameObject[] players;
    private Player player;

    // Start is called before the first frame update
    void Awake()
    {
     player = Instantiate(players[PlayerPrefs.GetInt("Player")], playerPos.position, Quaternion.identity).GetComponent<Player>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
