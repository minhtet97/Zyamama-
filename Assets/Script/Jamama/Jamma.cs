﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jamma : MonoBehaviour
{
    /*public float speed = 1f; // to adjust player movement speed in unity
    
    void Update()
    {
        float xDirection = Input.GetAxis("Horizontal"); // A/S Keyword
        
        Vector3 moveDirection = new Vector3(xDirection, 0.0f); //to move X direction 

        transform.position += moveDirection * speed; // add speed 
    }*/

    [Header("ライフが変更できるよ")]
    public int Life_Zyama;

    [Header("移動速度が変更できるよ")]
    public float speed;

    private Rigidbody rb;//リジッドボディ

    [Header("ボールのプレハブを代入する変数")]
    public GameObject ball;

    //スティック入力を格納する変数
    float Horizontal;

    Vector3 direction;//移動量を格納する変数

    public bool Frieze = false;//操作を停止させるフラグ(ポーズ等)

    public bool Shot = false;//玉を射出しているかの判定

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //ポーズ中は操作不可
        if (Frieze == false)
        {
            //入力受付
            Horizontal = Input.GetAxis("Horizontal_Ja");

            //移動量計算
            direction = new Vector3(Horizontal, 0, 0).normalized * speed;

            //発射処理
            if (Input.GetButtonDown("X_Button_2"))
            {
                if (Shot == false)
                {
                    Vector3 tmp = this.gameObject.transform.position;
                    Instantiate(ball, tmp, Quaternion.identity);
                    ball.GetComponent<Ball>().Zyamama = this.gameObject;
                    Shot = true;
                }
            }
        }
    }

    void FixedUpdate()
    {
        //移動量を振り当てる(実際に移動させる)処理
        rb.velocity = direction;
    }
}
