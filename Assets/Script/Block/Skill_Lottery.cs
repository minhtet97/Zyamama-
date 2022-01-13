using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Lottery : MonoBehaviour
{
    [Header("�{�[���̉����X�L���𒊑I")]
    [SerializeField]
    GameObject[] Block_1;

    [Header("�{�[���̕��g�X�L���𒊑I")]
    [SerializeField]
    GameObject[] Block_2;

    [Header("�������ԃX�L���𒊑I")]
    [SerializeField]
    GameObject[] Block_3;

    //�e���I�@�ɂ����u���b�N�������Ă邩��ۑ�����ϐ�
    private int Count1, Count2, Count3;
    void Awake()
    {
        //�e�X�L���ɂ����u���b�N������̂���ۑ�
        Count1 = Block_1.Length;
        Count2 = Block_2.Length;
        Count3 = Block_3.Length;

        //���I�����ԍ���ۑ�
        int PickUp1 = Random.Range(0, Count1);
        int PickUp2 = Random.Range(0, Count2);
        int PickUp3 = Random.Range(0, Count3);
        
        Block_1[PickUp1].GetComponent<BlockManager>().Skill_Number = 1;
        Block_2[PickUp2].GetComponent<BlockManager>().Skill_Number = 2;
        Block_3[PickUp3].GetComponent<BlockManager>().Skill_Number = 3;
    }
}
