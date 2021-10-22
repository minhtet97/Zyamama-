using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class PlacementManager : MonoBehaviour
{
    [SerializeField]
    public GameObject[] Generation, Parts;//�e�z�u�ꏊ�ƃp�[�c���i�[

    public int Parts_No;//�p�[�c�̐�

    private void Awake()
    {
        //�p�[�c��������Ă邩�m�F
        Parts_No = Parts.Length;
    }

    // Start is called before the first frame update
    void Start()
    {
        //�z�u�ꏊ�ƃp�[�c�̑g�ݍ��킹�������_���ɂ���
        Parts = Parts.OrderBy(a => Guid.NewGuid()).ToArray();

        //�p�[�c��z�u�ꏊ�ɐ���
        for (int i = 0; i < Parts_No ; i++)
        {
            Instantiate(Parts[i],Generation[i].transform.position,Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
