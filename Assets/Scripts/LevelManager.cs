using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [Range(1, 3)]
    public int levelNumber;
    [SerializeField] private TextMeshProUGUI levelText;

    private void Update()
    {
        levelText.text = "Nivel alcanzado: " + GameData.playerLevel.ToString();
    }
    private void Awake()
    {
        GameData.playerLevel = levelNumber;
        Debug.Log($"Cargado el Nivel: {GameData.playerLevel}");
    }





}
