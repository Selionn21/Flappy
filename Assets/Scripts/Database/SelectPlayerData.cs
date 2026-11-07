using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

[Serializable]
public class UserModel
{
    public int user_id;
    public string user_name;
    public int user_score;
    public int user_level;
    public string user_result;
}

[Serializable]
public class UserArrayModel
{
    public UserModel[] data;
}

public class SelectPlayerData : MonoBehaviour
{
    [SerializeField] private GameObject rowPrefab;
    [SerializeField] private GameObject ranking;
    [SerializeField] private Transform contentTransform;
    
    private const string url = "http://localhost/FlappyWeen/FlappyWeen/select_ranking.php";
    [SerializeField] private UserArrayModel userArrayModel;

    public void OpenRanking()
    {
        RefreshLeaderBoard();
        ranking.SetActive(true);

    }

    void RefreshLeaderBoard()
    {
        StartCoroutine(GetLeaderBoard());
    }

    IEnumerator GetLeaderBoard()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                userArrayModel = JsonUtility.FromJson<UserArrayModel>(www.downloadHandler.text);

                Array.Sort(userArrayModel.data, (a, b) => b.user_score.CompareTo(a.user_score));
                BuildRankingUI();
            }
            else
            {
                Debug.Log("Error");
            }
        }
    }

    void BuildRankingUI()
    {
        foreach (Transform child in contentTransform)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < userArrayModel.data.Length; i++)
        {
            UserModel user = userArrayModel.data[i];

            GameObject newRow = Instantiate(rowPrefab, contentTransform);
            TextMeshProUGUI[] texts = newRow.GetComponentsInChildren<TextMeshProUGUI>();

            if (texts.Length >= 3)
            {
                texts[0].text = user.user_name;
                texts[1].text = user.user_score.ToString();
                texts[2].text = user.user_level.ToString();
                texts[3].text = user.user_result;
            }
        }
    }
}


