using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotManager : MonoBehaviour
{
    public GameObject Hand = null;//触れた手を格納する変数
    public bool Catching = false;//掴まれているかを判定する変数

    public float PosX,PosY,PosZ = 0;//手の座標を格納する変数

    [SerializeField]
    private float High = 0;//持ち上げる高さ
    public string SkillName;//スキルの種類を格納する変数

    Rigidbody rb;
    BoxCollider bc;
    Vector3 FarstPos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        bc = GetComponent<BoxCollider>();
        FarstPos = this.transform.position;//初期位置を記憶
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
            //持ち上げる処理
            PosY = High;
            
            //座標を反映
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

    private void OnCollisionEnter(Collision collision)
    {
        //触れたのが地面だったら(落とされたら)
        if (collision.gameObject.tag == "Ground")
        {
            //初期位置に戻す
            this.transform.position = FarstPos;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Catching == true)
        {
            //触れたのが作業台だったら
            if (other.gameObject.tag == "CreateTable")
            {
                //発動できるスキルの種類を記憶
                SkillName = other.gameObject.GetComponent<TableManager>().SkillName;
            }
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

        if (other.gameObject.tag == "CreateTable")
        {
            SkillName = null;
        }
    }
}
