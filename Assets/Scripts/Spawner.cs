using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 方块生成器类
/// </summary>
public class Spawner : MonoBehaviour
{
    /// <summary>
    /// 方块预制体
    /// </summary>
    public GameObject[] blocks;


    void Start()
    {
        GenerateBlock();
    }

    
    void Update()
    {
        
    }

    /// <summary>
    /// 生成方块
    /// </summary>
    void GenerateBlock()
    {
        int i = Random.Range(0, blocks.Length);

        Instantiate(blocks[i], transform.position, Quaternion.identity);
    }
}
