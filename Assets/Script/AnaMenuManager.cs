using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnaMenuManager : MonoBehaviour
{
    void Start()
    {
        if (PlayerPrefs.HasKey("level"))
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("level"));
        }
        else
        {
            PlayerPrefs.SetInt("level", 1);
            SceneManager.LoadScene(PlayerPrefs.GetInt("level"));
        }
    }
}
