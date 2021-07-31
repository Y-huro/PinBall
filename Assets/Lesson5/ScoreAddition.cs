using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreAddition : MonoBehaviour
{
    // �ۑ� ���_��\������v���O����

    // ���_��\������e�L�X�g
    private GameObject scoreText;

    // ���_�̏�����
    private int score = 0;


    void Start()
    {
        this.scoreText = GameObject.Find("ScoreText");
        this.scoreText.GetComponent<Text>().text = "���_�F" + score.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // �Փˎ��ɌĂ΂��֐�
    void OnCollisionEnter(Collision other)
    {
        // �_�����Z
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
        this.scoreText.GetComponent<Text>().text = "���_�F" + score.ToString();
    }

}
