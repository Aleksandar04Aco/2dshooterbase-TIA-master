using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject Bossprefab;
    public int enemiesKilled = 0;
    
    bool bossHasSpawned = false;
    
    void Start()
    {

    }

    void Update()
    {
        if (enemiesKilled >= 20 && bossHasSpawned == false)
        {
            Instantiate(Bossprefab);
            bossHasSpawned = true;

            GameObject generator = GameObject.Find("EnemyGenerator");
            generator.SetActive(false);
        }
    }
}
