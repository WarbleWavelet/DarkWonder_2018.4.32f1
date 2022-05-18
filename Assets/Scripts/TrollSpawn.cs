using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrollSpawn : MonoBehaviour
{
    //生成时间
    public float timer = 0f;
    public float spawnTime = 3f;

    public GameObject trollPrefab;
    //生成数量
    public int count = 0;
    public int maxCount = 2;


    void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawnTime && count<maxCount)
        {
            timer = 0f;
            Instantiate(trollPrefab, transform.position, Quaternion.identity);
            count ++;
        }
    }
}
