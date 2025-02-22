﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [Header("ボールの速度を変更できるよ")]
    public float movespeed;

    //リジッドボディ
    private Rigidbody rb;

    public bool istrue;

    [Header("ボールのプレハブを入れる変数")]
    public GameObject ballOriginal;

    [Header("ジャママーが入る変数")]
    public GameObject Zyamama;

    //移動ベクトルを保存する変数
    private Vector3 pos;

    //ボールが当たった物体の法線ベクトル
    private Vector3 objNomalVector = Vector3.zero;

    // 跳ね返った後のverocity
    [HideInInspector] public Vector3 afterReflectVero = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        //float randomValue = Random.Range(-100f, 10f);
        //int xComponent = (int)Mathf.Sign(randomValue);
        pos = new Vector3(movespeed, 0, movespeed);
        afterReflectVero = rb.velocity;
        rb.velocity = pos;
        afterReflectVero = rb.velocity;
    }
     void Update()
    {
        if (istrue == true)
        {
            Instantiate(this.gameObject, transform.position, Quaternion.identity);
            istrue = false;
        }
    }

    void FixedUpdate()
    {
    }

    // Update is called once per frame


    /*void MyInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            speed= 0;
        }
        else if(Input.GetKeyUp(KeyCode.Space))
        {
            speed = 3;
        }
    }*/


    private void OnCollisionEnter(Collision hit)
    {
        switch(hit.gameObject.tag)
        {
            case  "SpeedBoost":
                movespeed = 20f;
                rb.AddForce((transform.forward + transform.right) * movespeed, ForceMode.VelocityChange);
                break;

            case "Capsule"://当たったものがカプセル(ブロック)の時
                Destroy(hit.gameObject);//カプセルを消す
                break;
        }

        switch(hit.gameObject.name)
        {
            //当たったのが博士の時
            case "Doctor"://博士のスキルが発動してなければ消去
                if (hit.gameObject.GetComponent<DoctorManager>().SkillOn == false)
                {
                    Debug.Log("博士が被弾したよ");

                    //博士にダメージ
                    hit.gameObject.GetComponent<DoctorManager>().Life_Doctor -= 1;

                    //ジャママーの射撃中判定をリセット
                    Zyamama.gameObject.GetComponent<Jamma>().Shot = false;
                    
                    Destroy(this.gameObject);
                }
                else
                {
                    if(hit.gameObject.GetComponent<DoctorManager>().SkillName == "Blue")
                    {
                        //break;
                    }
                }
                break;

            case "DestroyZONE":
                Debug.Log("ジャママーが返せなかったよ");

                //ジャママーの射撃中判定をリセット
                Zyamama.gameObject.GetComponent<Jamma>().Shot = false;

                //ジャママーのライフを削る処理
                Zyamama.GetComponent<Jamma>().Life_Zyama -= 1;

                Destroy(this.gameObject);
                break;
        }

        //反射の計算
        objNomalVector = hit.contacts[0].normal;
        Vector3 reflectVec = Vector3.Reflect(afterReflectVero, objNomalVector);
        rb.velocity = reflectVec;

        // 計算した反射ベクトルを保存
        afterReflectVero = rb.velocity;
    }

    /* void OnTriggerEnter(Collider other)
     {
         if (other.gameObject.tag.Equals("BallDes"))
         {
            Destroy(GetComponent<Collider>().gameObject);
         }
     }*/
}
