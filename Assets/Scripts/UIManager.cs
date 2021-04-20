using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    /// <summary>
    /// 分数文本
    /// </summary>
    public Text scoreText;

    /// <summary>
    /// 游戏结束窗口
    /// </summary>
    public GameObject gameover;

    /// <summary>
    /// 游戏是否结束
    /// </summary>
    bool isEnd = false;

    /// <summary>
    /// 分数
    /// </summary>
    public int score;

    void Start()
    {
        // 游戏开始时的时间
        startTime = Time.time;
    }

    void Update()
    {
        if (isEnd)
        {
            return;
        }

        // 游戏运行的时间
        time = Time.time - startTime;

        // 计算秒钟和分钟
        int seconds = (int)(time % 60);
        int minutes = (int)(time / 60);

        // 格式化字符串
        string strTime = string.Format("{0:00} : {1:00}", minutes, seconds);

        timer.text = strTime;
    }

    /// <summary>
    /// 增加分数
    /// </summary>
    public void IncreaseScore()
    {
        score++;

        if(score < 10)
        {
            scoreText.text = string.Format("000{0}", score);
        }
        else if (score < 100)
        {
            scoreText.text = string.Format("00{0}", score);
        }
        else if (score < 1000)
        {
            scoreText.text = string.Format("0{0}", score);
        }
        else
        {
            scoreText.text = string.Format("{0}", score);
        }
    }

    /// <summary>
    /// 游戏结束
    /// </summary>
    public void GameOver()
    {
        gameover.SetActive(true);

        isEnd = true;
    }

    /// <summary>
    /// 重新开始游戏
    /// </summary>
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
