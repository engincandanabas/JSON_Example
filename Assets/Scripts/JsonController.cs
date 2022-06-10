using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.UI;

public class JsonController : MonoBehaviour
{
    private CharacterStats charachter;
    // Save Variables
    [Header("Save Variables")]
    [Space(10)]
    [SerializeField] private TMP_InputField usernameInput;
    [SerializeField] private TMP_InputField levelInput;
    [SerializeField] private TMP_InputField highScoreInput;
    [SerializeField] private TMP_InputField moneyCountInput;
    [SerializeField] private TextMeshProUGUI statusText;
    [SerializeField] private Button saveButton, loadButton,clearButton;
    // Load Variables
    [Header("Load Variables")]
    [Space(10)]
    [SerializeField] private TextMeshProUGUI usernameText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private TextMeshProUGUI moneyCountText;
    public void JsonSave()
    {
        // Control
        if (usernameInput.text is null || levelInput.text is null || highScoreInput.text is null ||
            moneyCountInput.text is null)
        {
            Debug.LogWarning("Inputs must be filled");
            statusText.text = "Inputs must be filled";
            return;;
        }
        try
        {
            charachter= new CharacterStats(usernameInput.text, int.Parse(levelInput.text), int.Parse(highScoreInput.text), int.Parse(moneyCountInput.text));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            statusText.text = e.ToString();
            throw;
        }
        string jsonString = JsonUtility.ToJson(charachter);
        Debug.Log(jsonString);
        statusText.text = jsonString.ToString();
        File.WriteAllText(Application.dataPath+"/Saves/userStats.json",jsonString);
    }

    public void JsonLoad()
    {
        string path = Application.dataPath + "/Saves/userStats.json";
        if (File.Exists(path))
        {
            string jsonFile = File.ReadAllText(path);
            charachter = JsonUtility.FromJson<CharacterStats>(jsonFile);
            usernameText.text = charachter.username;
            levelText.text = charachter.userLevel.ToString();
            highScoreText.text = charachter.highScore.ToString();
            moneyCountText.text = charachter.moneyCount.ToString();

        }
        else
        {
            Debug.LogError("Path Not Found");
            statusText.text = "Path Not Found";
        }

    }

    public void ClearAllText()
    {
        usernameInput.text = "";
        moneyCountInput.text = "";
        levelInput.text = "";
        highScoreInput.text = "";
        highScoreText.text = "-------------------";
        usernameText.text = "-------------------";
        levelText.text = "-------------------";
        moneyCountText.text = "-------------------";
        statusText.text = "-----------------------------------";
    }

    #region Unity
    private void Start()
    {
        saveButton.onClick.AddListener(() => JsonSave());
        loadButton.onClick.AddListener(() => JsonLoad());
        clearButton.onClick.AddListener(()=>ClearAllText());
    }
    #endregion
}
