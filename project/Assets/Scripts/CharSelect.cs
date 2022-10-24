using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CharSelect : MonoBehaviour
{
    public Button[] levels;

    // Start is called before the first frame update
    void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        for (int i = 0; i < levels.Length; i++)
            if (i + 1 > levelReached)
                levels[i].interactable = false;
    }

    // Update is called once per frame
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    public void SetPlayer(int index)
    {
        PlayerPrefs.SetInt("player", index);
    }


}
