using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// UI 管理器类
/// </summary>
public class UIManager : MonoBehaviour
{
    /// <summary>
    /// 计时器
    /// </summary>
    float time;

    /// <summary>
    /// 开始时间
    /// </summary>
    float startTime;

    /// <summary>
    /// 计时器文本
    /// </summary>
    public Text timer;

    void Start()
    {
        // 游戏开始时的时间
        startTime = Time.time;
    }

    void Update()
    {
        // 游戏运行的时间
        time = Time.time - startTime;

        // 计算秒钟和分钟
        int seconds = (int)(time % 60);
        int minutes = (int)(time / 60);

        // 格式化字符串
        string strTime = string.Format("{0:00} : {1:00}", minutes, seconds);

        timer.text = strTime;
    }
}
