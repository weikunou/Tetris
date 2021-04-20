using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 方块类
/// </summary>
public class Block : MonoBehaviour
{
    /// <summary>
    /// 上次下落的时间
    /// </summary>
    float lastFall;

    void Start()
    {
        if(!isValidGridPos())
        {
            Debug.Log("游戏结束");

            FindObjectOfType<UIManager>().GameOver();

            Destroy(gameObject);
        }
    }

    void Update()
    {
        Move();
    }

    /// <summary>
    /// 移动方块
    /// </summary>
    void Move()
    {
        // 按键控制
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position += new Vector3(-1, 0, 0);

            if (isValidGridPos())
            {
                UpdateGrid();
            }
            else
            {
                transform.position += new Vector3(1, 0, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position += new Vector3(1, 0, 0);

            if (isValidGridPos())
            {
                UpdateGrid();
            }
            else
            {
                transform.position += new Vector3(-1, 0, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            transform.Rotate(0, 0, -90);

            if (isValidGridPos())
            {
                UpdateGrid();
            }
            else
            {
                transform.Rotate(0, 0, 90);
            }
        }
        else if (Input.GetKeyDown(KeyCode.S) || Time.time - lastFall >= 1)
        {
            transform.position += new Vector3(0, -1, 0);

            if (isValidGridPos())
            {
                UpdateGrid();
            }
            else
            {
                transform.position += new Vector3(0, 1, 0);

                // 检测满行
                Grid.deleteFullRows();

                FindObjectOfType<Spawner>().GenerateBlock();

                enabled = false;
            }

            lastFall = Time.time;
        }
    }

    /// <summary>
    /// 是否在有效的格子内
    /// </summary>
    /// <returns></returns>
    bool isValidGridPos()
    {
        foreach(Transform child in transform)
        {
            Vector2 v = Grid.roundVec2(child.position);

            if(!Grid.insideBorder(v))
            {
                return false;
            }

            // 第一个条件永远是 null 判断 false
            if (Grid.grid[(int)v.x, (int)v.y] != null && Grid.grid[(int)v.x, (int)v.y].parent != transform)
            {
                return false;
            }
        }

        // bug 永远返回 true，因为如果最后一个方块没有把生成的位置占领，那么新生成的方块都在有效格子内，然后往下移动之后不在有效格子内，
        // 就不会去更新网格，而是往回退，并且生成新的格子，进入死循环

        return true;
    }

    /// <summary>
    /// 更新网格
    /// </summary>
    void UpdateGrid()
    {
        // 清除原来的网格信息
        for(int y = 0; y < Grid.h; y++)
        {
            for(int x = 0; x < Grid.w; x++)
            {
                if (Grid.grid[x, y] != null && Grid.grid[x, y].parent == transform)
                {
                    Grid.grid[x, y] = null;
                }
            }
        }

        // 移动后的网格信息
        foreach(Transform child in transform)
        {
            Vector2 v = Grid.roundVec2(child.position);

            Grid.grid[(int)v.x, (int)v.y] = child;
        }
    }
}
