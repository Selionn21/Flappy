using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacles; 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateObstacles()
    {
        int randomIndex = Random.Range(0, obstacles.Length);
        Instantiate(obstacles[randomIndex], transform.position, Quaternion.identity, transform);
    }
}
