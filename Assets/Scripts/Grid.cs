using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 网格类
/// </summary>
public class Grid : MonoBehaviour
{
    /// <summary>
    /// 网格宽度
    /// </summary>
    public static int w = 8;

    /// <summary>
    /// 网格高度
    /// </summary>
    public static int h = 20;

    /// <summary>
    /// 网格二维数组
    /// </summary>
    public static Transform[,] grid = new Transform[w, h];

    /// <summary>
    /// 四舍五入转化三维向量成二维向量
    /// </summary>
    /// <param name="vector3">三维向量</param>
    /// <returns></returns>
    public static Vector2 roundVec2(Vector3 vector3)
    {
        return new Vector2(Mathf.Round(vector3.x), Mathf.Round(vector3.y));
    }

    /// <summary>
    /// 判断方块是否在边界内
    /// </summary>
    /// <param name="pos">位置</param>
    /// <returns></returns>
    public static bool insideBorder(Vector2 pos)
    {
        // 满足条件则在边框内
        return ((int)pos.x >= 0 &&
                (int)pos.x < w &&
                (int)pos.y >= 0);
    }

    #region 消除

    /// <summary>
    /// 检查一行是否填满
    /// </summary>
    /// <param name="y">行数</param>
    /// <returns></returns>
    public static bool isRowFull(int y)
    {
        // 检查某一行的每一个格子是否为空，如果有一个是空的，则说明该行还没满
        for(int x = 0; x < w; x++)
        {
            if (grid[x, y] == null)
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// 删除一行
    /// </summary>
    /// <param name="y">行数</param>
    public static void deleteRow(int y)
    {
        // 删除一行
        for(int x = 0; x < w; x++)
        {
            Destroy(grid[x, y].gameObject);

            grid[x, y] = null;
        }

        // 增加分数
        FindObjectOfType<UIManager>().IncreaseScore();
    }

    /// <summary>
    /// 移动一行
    /// </summary>
    /// <param name="y">行数</param>
    public static void decreaseRow(int y)
    {
        for(int x = 0; x < w; x++)
        {
            if (grid[x, y] != null)
            {
                grid[x, y - 1] = grid[x, y];
                grid[x, y] = null;

                grid[x, y - 1].position += new Vector3(0, -1, 0);
            }
        }
    }

    /// <summary>
    /// 移动上面的行
    /// </summary>
    /// <param name="y">行数</param>
    public static void decreaseRowAbove(int y)
    {
        for(int i = y; i < h; i++)
        {
            decreaseRow(i);
        }
    }

    /// <summary>
    /// 删除所有填满的行
    /// </summary>
    public static void deleteFullRows()
    {
        for(int y = 0; y < h; )
        {
            if (isRowFull(y))
            {
                deleteRow(y);

                decreaseRowAbove(y + 1);
            }
            else
            {
                y++;
            }
        }
    }

    #endregion
}
