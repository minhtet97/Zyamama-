using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoctorManager : MonoBehaviour
{
    [SerializeField]
	public float Speed;//���m�̈ړ����x
	public bool OnParts;//�p�[�c�ɐG��Ă��邩�̔���
	public bool Catching;//�p�[�c��͂�ł��邩�̔���
	public GameObject Hand;//����i�[����ϐ�
	public GameObject Parts;//�G��Ă���(�͂�ł���)�p�[�c���i�[����ϐ�

	//�ړ��ʂ��i�[����ϐ�
	float MoveX = 0f;
	float MoveZ = 0f;

	Rigidbody rb;

	//�X�e�B�b�N���͂��i�[����ϐ�
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

		//�p�[�c�ɐG��Ă邩���擾
		OnParts = Hand.GetComponent<DoctorHand>().OnParts;
	}

	void FixedUpdate()
	{
		//�ړ��ʂ�U�蓖�Ă�(���ۂɈړ�������)����
		rb.velocity = direction;
	}

	//�ړ��ʂ̌v�Z
	void Move()
    {
		MoveX = Horizontal * Speed;
		MoveZ = Vertical * Speed;
		direction = new Vector3(MoveX, 0, MoveZ);
	}

	//�����̕ύX
	void Turn()
	{
		if (Horizontal != 0 || Vertical != 0)
		{
			var direction = new Vector3(Horizontal, 0, Vertical);
			transform.localRotation = Quaternion.LookRotation(direction);
		}
	}

	//�p�[�c��͂ޏ���
	void Catch()
    {
		if(Input.GetButtonDown("A_Button"))
        {
			//�G��Ă��邯�ǒ͂�ł͂��Ȃ��Ƃ�(�͂�)
			if(OnParts == true && Catching == false)
            {
				//�ǂ̃p�[�c�������Ă��邩���󂯎��
				Parts = Hand.GetComponent<DoctorHand>().Parts;

				//�p�[�c�ɒ͂�ł��锻��𑗂�
				Catching = Parts.GetComponent<RobotManager>().Catching = true;
            }
			//�͂�ł��鎞(����)
			else if(Catching == true)
            {
				//�p�[�c�̒͂�ł��锻���������(����)
				Catching = Parts.GetComponent<RobotManager>().Catching = false;

				//�����Ă�p�[�c�������Ȃ���Ԃɂ���
				Parts = null;
			}
        }
    }
}
