using UnityEngine;

public class ObstacleDetection : MonoBehaviour
{
    public CapsuleMove movement;

    void OnCollisionEnter(Collision collisionInfo)
    {
        if(collisionInfo.collider.tag == "Obstacle")
        {
            movement.enabled = false;
            FindObjectOfType<GameManagers>().EndGame();
        }
    }
}
