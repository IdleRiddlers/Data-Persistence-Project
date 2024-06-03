using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartUIManager : MonoBehaviour
{

    public TMP_InputField nameInputField;

    private void Start()
    {
        if (DataManager.instance.playerName != null)
        {
            nameInputField.text = DataManager.instance.playerName;
        }
    }

    public void StartGame()
    {
        DataManager.instance.playerName = nameInputField.text;
        DataManager.instance.SaveInfo();
        SceneManager.LoadScene("main");
    }
}
