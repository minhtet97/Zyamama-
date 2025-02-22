using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Director : MonoBehaviour
{
    [Header("制限時間を変更できるよ")]
    [SerializeField]
    private float Timmer;

    [Header("パーツ格納数")]
    [SerializeField]
    private int Point = 0;

    [Header("全体のパーツ数")]
    public int Parts_No;

    [Header("博士の勝利フラグ")]
    public bool Doctor_Win = false;

    [Header("ジャママーの勝利フラグ")]
    public bool Zyama_Win = false;

    [Header("ライフ")]
    [SerializeField]
    private int Life_Doctor, Life_Zyama;

    [Header("内部処理用の変数")]
    [SerializeField]
    private GameObject Generation, Doctor, Hand, Zyama;
    [SerializeField]
    private Text Count_Text;

    // Start is called before the first frame update
    void Start()
    {
        Generation = GameObject.Find("Generation");//パーツ格納判定を取得
        Hand = Doctor.GetComponent<DoctorManager>().Hand;//手を取得
        Parts_No = Generation.GetComponent<PlacementManager>().Parts_No;//全体のパーツ数を取得
    }

    // Update is called once per frame
    void Update()
    {
        Timmer -= Time.deltaTime;

        //それぞれのライフを取得(更新)
        Life_Doctor = Doctor.GetComponent<DoctorManager>().Life_Doctor;
        Life_Zyama = Zyama.GetComponent<Jamma>().Life_Zyama;

        //パーツの格納数が全体のパーツ数になった時
        if(Point == Parts_No)
        {
            Doctor_Win = true;//博士の勝利フラグを立てる
            Debug.Log("博士勝ち");
        }

        //博士のライフが0になったら
        if(Life_Doctor <= 0)
        {
            Zyama_Win = true;
            Debug.Log("ジャママーの勝ち");
        }

        //ジャママーのライフが0になったら
        if(Life_Zyama <= 0)
        {
            Doctor_Win = true;
            Debug.Log("博士の勝ち");
        }
    }

    private void FixedUpdate()
    {
        //タイマーの更新
        Count_Text.text = "残り時間 " + Timmer.ToString("F2");
    }

    private void OnTriggerEnter(Collider other)
    {
        //パーツが判定に触れた時
        if(other.gameObject.tag == "Robot")
        {
            Point += 1;//格納数を加算

            //博士達のフラグや持ち物を代わりにリセット
            Doctor.GetComponent<DoctorManager>().Parts
                = Hand.GetComponent<DoctorHand>().Parts
                = null;
            Doctor.GetComponent<DoctorManager>().Catching
                = false;
            Hand.GetComponent<DoctorHand>().OnParts
                = false;

            Doctor.GetComponent<DoctorManager>().SkillOn = true;//博士のスキルを発動させる
            Doctor.GetComponent<DoctorManager>().Skill_Keep = false;//博士の加工後パーツ取得状をリセット

            Destroy(other.gameObject);//パーツを消去
            Debug.Log("博士のポイント" + Point + "/" + Parts_No);
        }
    }
}
