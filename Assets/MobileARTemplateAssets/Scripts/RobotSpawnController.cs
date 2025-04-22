using UnityEngine;

public class RobotSpawnController : MonoBehaviour
{
    public GameObject robotPrefab;
    public Score score;
    public float spawnInterval = 2f;
    public float spawnDistance = 10f;
    void Start()
    {
        InvokeRepeating("SpawnRobot", 2f, spawnInterval);
    }
    void SpawnRobot()
    {
        Vector3 spawnDirection = Random.onUnitSphere;
        spawnDirection.y = Mathf.Clamp(spawnDirection.y, -0.5f, 0.5f);
        Vector3 spawnPosition = transform.position + spawnDirection *
            spawnDistance;
        spawnPosition = new Vector3(spawnPosition.x, transform.position.y, spawnPosition.z);
        GameObject robot = Instantiate(robotPrefab, spawnPosition,
            Quaternion.identity);
        robot.GetComponent<BulletCollision>().Score = score;
        
    }
}
