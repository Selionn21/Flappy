using UnityEngine;
using TMPro;

public class PointsManager : MonoBehaviour
{
    [SerializeField] private int currentFib = 1;
    [SerializeField] private int previousFib = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI finalScore;

    private void Update()
    {
        scoreText.text = "Score: " + GameData.playerScore.ToString();
        finalScore.text = "Final score: " + GameData.playerScore.ToString();
    }

    public void AddFibonacciScore()
    {
        int pointsToAdd = currentFib;
        GameData.playerScore += pointsToAdd;

        int nextFib = currentFib + previousFib;
        previousFib = currentFib;
        currentFib = nextFib;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            AddFibonacciScore();
        }
    }
}
