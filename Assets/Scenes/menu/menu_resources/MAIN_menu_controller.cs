using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class MAIN_menu_controller : MonoBehaviour
{
    [Header("Levels to load")]
    public string _newGameLevel1;
    private string LevelToLoad;
    [SerializeField] private GameObject noSavedGameDialog = null;


    public void NewGameDialogYes()
    {
        SceneManager.LoadScene(_newGameLevel1);
    }



    public void LoadGameDialogYes()
    {
        if (PlayerPrefs.HasKey("SavedLevel"))
        {
            LevelToLoad = PlayerPrefs.GetString("SavedLevel");
            SceneManager.LoadScene(LevelToLoad);
        }
        else
        {
            noSavedGameDialog.SetActive(true);
        }
    }
    public void ExitButton()
    {
        Debug.Log("Пидарас, взял ВЫШЕЛ");
        Application.Quit();
    }
}




