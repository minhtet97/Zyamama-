using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class PlacementManager : MonoBehaviour
{
    [Header("�e�z�u�ꏊ�ƃp�[�c���i�[")]
    [SerializeField]
    public GameObject[] Generation, Parts;

    [Header("��Ƒ���i�[")]
    public GameObject Table;

    [Header("�p�[�c�̐�")]
    public int Parts_No;

    [Header("��Ƒ�̐�")]
    [SerializeField]
    int TableNo;

    [Header("�����ꏊ(���S)")]
    [SerializeField]
    Vector3 Range_L, Range_R;

    [Header("�����ꏊ(�͈�)")]
    [SerializeField]
    float Range_x, Range_z;

    private void Awake()
    {
        //�p�[�c��������Ă邩�m�F
        Parts_No = Parts.Length;
    }

    // Start is called before the first frame update
    void Start()
    {
        Parts_Create();
        Table_Create();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Parts_Create()
    {
        //�z�u�ꏊ�ƃp�[�c�̑g�ݍ��킹�������_���ɂ���
        Parts = Parts.OrderBy(a => Guid.NewGuid()).ToArray();

        //�p�[�c��z�u�ꏊ�ɐ���
        for (int i = 0; i < Parts_No; i++)
        {
            Instantiate(Parts[i], Generation[i].transform.position, Quaternion.identity);
        }
    }

    //��Ƒ䐶��
    void Table_Create()
    {
        //�����̐���
        Vector3 posL;

        posL.x = UnityEngine.Random.Range(Range_L.x + Range_x, Range_L.x + -Range_x);
        posL.z = UnityEngine.Random.Range(Range_L.z + Range_z, Range_L.z + -Range_z);
        posL.y = Table.transform.position.y;

        Instantiate(Table, posL, Quaternion.identity);

        //�E���̐���
        Vector3 posR;

        posR.x = UnityEngine.Random.Range(Range_R.x + Range_x, Range_R.x + -Range_x);
        posR.z = UnityEngine.Random.Range(Range_R.z + Range_z, Range_R.z + -Range_z);
        posR.y = Table.transform.position.y;

        Instantiate(Table, posR, Quaternion.identity);
    }
}
