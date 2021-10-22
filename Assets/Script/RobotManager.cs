using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotManager : MonoBehaviour
{
    public GameObject Hand = null;
    public bool Catching = false;

    public float PosX,PosY,PosZ = 0;

    [SerializeField]
    private float limit,High = 0;

    Rigidbody rb;
    BoxCollider bc;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        bc = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    //�ړ�����
    void Move()
    {
        //�͂܂�Ă��邩�𔻒�
        if (Catching == true)
        {
            //��̍��W(�����ȊO)���擾�A�����͌��ݒn�����̂܂ܔ��f
            PosX = Hand.transform.position.x;
            PosY = this.transform.position.y;
            PosZ = Hand.transform.position.z;

            //�������Ⴉ�����玝���グ��
            if(PosY < limit)
            {
                PosY = High;
            }
            this.transform.position = new Vector3(PosX, PosY, PosZ);

            //��]��ʒu���ꂪ�N���Ȃ��悤�Ɏ~�߂鏈��
            rb.constraints = RigidbodyConstraints.FreezeRotation
                | RigidbodyConstraints.FreezePositionY;

            //�����������ꎞ��~
            bc.isTrigger = true;
        }
        else
        {
            //�����������ĉғ�
            bc.isTrigger = false;

            //�ʒu���ꏈ�����Ē���
            rb.constraints = RigidbodyConstraints.FreezeRotation
                | RigidbodyConstraints.FreezeRotationX
                | RigidbodyConstraints.FreezeRotationZ;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //�G��Ă���̂��肾������
        if(other.gameObject.name == "Hand")
        {
            //��̏����擾
            Hand = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //���ꂽ���̂��肾������(�����ꂽ��)
        if(other.gameObject == Hand)
        {
            //��̏���j��
            Hand = null;
        }
    }
}
