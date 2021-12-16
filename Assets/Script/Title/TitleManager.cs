using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    [Header("���b�Z�[�W��text������")]
    [SerializeField]
    Text Message;

    [Header("�����̓_�ő��x")]
    [SerializeField]
    float TextSpeed;

    [Header("��ʂ��Ó]������p�l��")]
    [SerializeField]
    Image BlackImage;

    [Header("�����Ă���V�[�����ړ�������Ó]�܂ł̑��x")]
    [SerializeField]
    float ChangeTime;

    float Alpha,Alpha_2;
    bool A_judge;
    bool Change_Scene;

    // Start is called before the first frame update
    void Start()
    {
        Alpha = Message.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        if(Change_Scene == false)
        {
            A_Change();
        }
        else
        {
            Alpha_2 += ChangeTime;
            
            BlackImage.color = BlackImage.color = new Color(BlackImage.color.r, BlackImage.color.g, BlackImage.color.b, Alpha_2);

            if(Alpha_2 >= 1)
            {
                SceneManager.LoadScene("GameScene");
            }
        }

        if(Input.GetButtonDown("��_Button"))
        {
            Change_Scene = true;
        }
    }

    void A_Change()
    {
        Message.color = new Color(Message.color.r, Message.color.g, Message.color.b, Alpha);

        if (Alpha >= 1)
        {
            A_judge = true;
        }
        else if (Alpha <= 0)
        {
            A_judge = false;
        }

        if (A_judge == true)
        {
            Alpha -= TextSpeed;
        }
        else
        {
            Alpha += TextSpeed;
        }
    }
}
