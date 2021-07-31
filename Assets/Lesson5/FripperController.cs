using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour
{

    // HingeJoint�R���|�[�l���g������
    private HingeJoint myHingeJoint;

    // �����̌X��
    private float defaultAngle = 20;
    // �e�������̌X��
    private float flickAngle = -20;

    void Start()
    {
        // HingeJoint�R���|�[�l���g�擾
        this.myHingeJoint = GetComponent<HingeJoint>();
        
        // �t���b�p�[�̌X����ݒ�
        SetAngle(this.defaultAngle);
    }

    // Update is called once per frame
    void Update()
    {
        // ���W�ۑ� 
        // A�L�[�܂���S�L�[�܂��͉����L�[�����������ɍ��t���b�p�[�𓮂��悤�ɂ���
        // D�L�[�܂���S�L�[�܂��͉����L�[�����������ɉE�t���b�p�[�𓮂��悤�ɂ���

        // �����L�[�������������t���b�p�[�𓮂���
        if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        // �E���L�[�����������E�t���b�p�[�𓮂���
        if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        // ���L�[�����ꂽ���t���b�p�[�����ɖ߂�
        if ((Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow)) && tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
        if ((Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow)) && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }

        // ���W�ۑ� �X�}�[�g�t�H���̃}���`�^�b�`�Ή�
        if(Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                // �^�b�`���̃R�s�[
                Touch touch = Input.GetTouch(i);
                if (touch.phase == TouchPhase.Began)
                {
                    // �E���ʂ����������E�t���b�p�[�𓮂���
                    if (touch.position.x >= Screen.width / 2 && tag == "RightFripperTag")
                    {
                        SetAngle(this.flickAngle);
                    }
                    // �����ʂ������������t���b�p�[�𓮂���
                    if (touch.position.x < Screen.width / 2 && tag == "LeftFripperTag")
                    {
                        SetAngle(this.flickAngle);
                    }
                }
                if (touch.phase == TouchPhase.Ended)
                {
                    // �E���ʗ��������E�t���b�p�[�����ɖ߂�
                    if (touch.position.x >= Screen.width / 2 && tag == "RightFripperTag")
                    {
                        SetAngle(this.defaultAngle);
                    }
                    // �����ʗ����������t���b�p�[�����ɖ߂�
                    if (touch.position.x < Screen.width / 2 && tag == "LeftFripperTag")
                    {
                        SetAngle(this.defaultAngle);
                    }
                }
            }
        }

    }

    // �t���b�p�[�̌X����ݒ�
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}
