using TMPro;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SubmitName : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInputField;
    [SerializeField] private InsertPlayerData playerData;


    public void SaveNameToGameData()
    {
        if(nameInputField != null)
        {
            string enteredText = nameInputField.text;

            if (string.IsNullOrWhiteSpace(enteredText))
            {
                GameData.playerName = "ABC";
            }
            else
            {
                GameData.playerName = enteredText.Trim();
            }

            playerData.StartSendRequest();
            SceneManager.LoadScene("Menu");
            Time.timeScale = 1;
        }

    }
}
