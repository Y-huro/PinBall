using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreAddition : MonoBehaviour
{
    // 課題 得点を表示するプログラム

    // 得点を表示するテキスト
    private GameObject scoreText;

    // 得点の初期化
    private int score = 0;


    void Start()
    {
        this.scoreText = GameObject.Find("ScoreText");
        this.scoreText.GetComponent<Text>().text = "得点：" + score.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 衝突時に呼ばれる関数
    void OnCollisionEnter(Collision other)
    {
        // 点数加算
        if (other.gameObject.tag == "SmallStarTag")
        {
            score += 10;
        }
        else if (other.gameObject.tag == "LargeStarTag")
        {
            score += 30;
        }
        else if (other.gameObject.tag == "SmallCloudTag")
        {
            score += 20;
        }
        else if (other.gameObject.tag == "LargeCloudTag")
        {
            score += 50;
        }
        this.scoreText.GetComponent<Text>().text = "得点：" + score.ToString();
    }

}
