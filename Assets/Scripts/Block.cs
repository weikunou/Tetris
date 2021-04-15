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

            }
            else
            {
                transform.position += new Vector3(0, 1, 0);
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

            if (Grid.grid[(int)v.x, (int)v.y] != null)
            {
                return false;
            }
        }

        return true;
    }
}
