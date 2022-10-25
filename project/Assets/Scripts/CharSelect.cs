using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class CharSelect : MonoBehaviour
{
   
    public void SetPlayer(int index)
    {

        PlayerPrefs.SetInt("Player", index);          
        
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
    }

    
}
