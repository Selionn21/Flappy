using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class InsertPlayerData : MonoBehaviour
{
    private const string url = "http://localhost/FlappyWeen/FlappyWeen/insert_user_attributes.php";

    public void StartSendRequest()
    {
        StartCoroutine(SendRequest(GameData.playerName, GameData.playerScore, GameData.playerLevel, GameData.playerResult));
    }

    public IEnumerator SendRequest(string user_name, int user_score, int user_level, string user_result)
    {
        WWWForm form = new WWWForm();
        form.AddField("user_name", user_name);
        form.AddField("user_score", user_score);
        form.AddField("user_level", user_level);
        form.AddField("user_result", user_result);

        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Se insertó con éxito");
            }
            else
            {
                Debug.Log("Error");
            }
        }
    }
}
