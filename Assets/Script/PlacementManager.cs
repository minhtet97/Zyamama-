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
    
    public GameObject Table;
    Vector3 TableSize;
    [SerializeField]
    int TableNo;

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

    void Table_Create()
    {
        //��Ƒ�̔��a����
        TableSize = Table.transform.localScale / 2;

        //��Ƒ�𐶐�
        for (int i = 0; i < TableNo; i++)
        {
            Vector3 pos = UnityEngine.Random.insideUnitCircle * 6;
            pos.z = pos.y;
            pos.y = TableSize.y;

            if (!Physics.CheckBox(pos, TableSize, Quaternion.identity, 1 << 12))
            {
                Instantiate(Table, pos, Quaternion.identity);
                break;
            }
        }
    }
}
