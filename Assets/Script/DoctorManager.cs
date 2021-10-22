using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoctorManager : MonoBehaviour
{
    [SerializeField]
	public float Speed;//博士の移動速度
	public bool OnParts;//パーツに触れているかの判定
	public bool Catching;//パーツを掴んでいるかの判定
	public GameObject Hand;//手を格納する変数
	public GameObject Parts;//触れている(掴んでいる)パーツを格納する変数

	//移動量を格納する変数
	float MoveX = 0f;
	float MoveZ = 0f;

	Rigidbody rb;

	//スティック入力を格納する変数
	float Horizontal;
	float Vertical;
	Vector3 direction;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	void Update()
	{
		Horizontal = Input.GetAxis("Horizontal_Dr");
		Vertical = Input.GetAxis("Vertical_Dr");
		Move();
		Turn();
		Catch();
	}

	void FixedUpdate()
	{
		//移動量を振り当てる(実際に移動させる)処理
		rb.velocity = direction;
	}

	//移動量の計算
	void Move()
    {
		MoveX = Horizontal * Speed;
		MoveZ = Vertical * Speed;
		direction = new Vector3(MoveX, 0, MoveZ);
	}

	//向きの変更
	void Turn()
	{
		if (Horizontal != 0 || Vertical != 0)
		{
			var direction = new Vector3(Horizontal, 0, Vertical);
			transform.localRotation = Quaternion.LookRotation(direction);
		}
	}

	//パーツを掴む処理
	void Catch()
    {
		if(Input.GetButtonDown("A_Button"))
        {
			//パーツに触れてるかを取得
			OnParts = Hand.GetComponent<DoctorHand>().OnParts;
			
			//触れているけど掴んではいないとき(掴む)
			if(OnParts == true && Catching == false)
            {
				//どのパーツを持っているかを受け取る
				Parts = Hand.GetComponent<DoctorHand>().Parts;

				//パーツに掴んでいる判定を送る
				Catching = Parts.GetComponent<RobotManager>().Catching = true;
            }
			//掴んでいる時(離す)
			else if(Catching == true)
            {
				//パーツの掴んでいる判定を取り消す(離す)
				Catching = Parts.GetComponent<RobotManager>().Catching = false;

				//持ってるパーツを何もない状態にする
				Parts = null;
			}
        }
    }
}
