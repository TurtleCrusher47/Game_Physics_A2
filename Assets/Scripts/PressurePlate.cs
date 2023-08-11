using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] private Vector3 ballPosition = new Vector3(0, 3, 0);

    private bool ballSpawned = false;
    private float spawnCooldown = 5f;
    private float spawnTimer = 0f;

    void OnTriggerEnter(Collider col)
    {
        if (!ballSpawned)
        {
            SpawnBall();

            ballSpawned = true;
        }
    }

    void FixedUpdate()
    {
        if (ballSpawned)
        {
            if (spawnTimer >= spawnCooldown)
            {
                ballSpawned = false;
                spawnTimer = 0f;
            }
            else
            {
                spawnTimer += Time.deltaTime;
            }
        }
    }

    private void SpawnBall()
    {
        GameObject ball = ObjectPool.instance.GetPooledObject();

        if (ball != null)
        {
            ball.transform.position = ballPosition;
            ball.SetActive(true);

            Debug.Log("Spawned");
        }
    }
}
