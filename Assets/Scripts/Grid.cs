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
}
