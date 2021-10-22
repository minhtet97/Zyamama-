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

    //移動処理
    void Move()
    {
        //掴まれているかを判定
        if (Catching == true)
        {
            //手の座標(高さ以外)を取得、高さは現在地をそのまま反映
            PosX = Hand.transform.position.x;
            PosY = this.transform.position.y;
            PosZ = Hand.transform.position.z;

            //高さが低かったら持ち上げる
            if(PosY < limit)
            {
                PosY = High;
            }
            this.transform.position = new Vector3(PosX, PosY, PosZ);

            //回転や位置ずれが起きないように止める処理
            rb.constraints = RigidbodyConstraints.FreezeRotation
                | RigidbodyConstraints.FreezePositionY;

            //物理処理を一時停止
            bc.isTrigger = true;
        }
        else
        {
            //物理処理を再稼働
            bc.isTrigger = false;

            //位置ずれ処理を再調整
            rb.constraints = RigidbodyConstraints.FreezeRotation
                | RigidbodyConstraints.FreezeRotationX
                | RigidbodyConstraints.FreezeRotationZ;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //触れているのが手だったら
        if(other.gameObject.name == "Hand")
        {
            //手の情報を取得
            Hand = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //離れたものが手だったら(離されたら)
        if(other.gameObject == Hand)
        {
            //手の情報を破棄
            Hand = null;
        }
    }
}
