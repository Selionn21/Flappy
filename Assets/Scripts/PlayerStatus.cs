using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField] private GameObject namePanel;
    [SerializeField] private GameObject defeatext;

    public void GameResult()
    {
        Time.timeScale = 0;
        namePanel.SetActive(true);
        GameData.playerResult = "lose";
        defeatext.SetActive(true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            GameResult();
        }
    }
}
