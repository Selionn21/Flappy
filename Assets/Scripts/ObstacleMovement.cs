using Unity.VisualScripting;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    [SerializeField] private float obstacleSpd;
    


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * obstacleSpd * Time.deltaTime);
    }
}
