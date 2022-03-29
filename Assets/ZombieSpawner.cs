using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ZombieSpawner : MonoBehaviour
{
    bool spawning = false;
    float timer = 0.0f;
    float spawningTimer = 0.0f;
    [SerializeField] float peacefulStageInterval = 5.0f;
    [SerializeField] float spawningStateInterval = 5.0f;
    public UnityEvent onZombieSpawned;
    void Start()
    {
    }
    public void SpawnZombie()
    {
        onZombieSpawned.Invoke();
        Debug.Log("Zombie Spawned");
    }

    public void StopSpawning()
    {
        CancelInvoke("SpawnZombie");
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > peacefulStageInterval && !spawning)
        {
            spawningTimer = 0;
            spawning = true;
            InvokeRepeating("SpawnZombie", 0f, 0.5f);
        }

        if (spawning)
        {
            spawningTimer += Time.deltaTime;
            if (spawningTimer >= spawningStateInterval)
            {
                timer = 0;
                spawning = false;
                StopSpawning();

            }
        }
    }
}
