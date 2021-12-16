using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Director : MonoBehaviour
{
    [Header("�������Ԃ�ύX�ł����")]
    [SerializeField]
    private float Timmer;

    [Header("�p�[�c�i�[��")]
    [SerializeField]
    private int Point = 0;

    [Header("�S�̂̃p�[�c��")]
    public int Parts_No;

    [Header("���m�̏����t���O")]
    public bool Doctor_Win = false;

    [Header("�W���}�}�[�̏����t���O")]
    public bool Zyama_Win = false;

    [Header("���C�t")]
    [SerializeField]
    private int Life_Doctor, Life_Zyama;

    [Header("Life�摜")]
    [SerializeField]
    Image[] Lifeimage_D,Lifeimage_Z;

    [Header("���������p�̕ϐ�")]
    [SerializeField]
    private GameObject Generation, Doctor, Hand, Zyama, Robots;
    [SerializeField]
    private Text Count_Text;
    public bool BlockBreake;//�W���}�}�[�̃u���b�N�j�󉹂�炷�t���O

    // Start is called before the first frame update
    void Start()
    {
        Generation = GameObject.Find("Generation");//�p�[�c�i�[������擾
        Hand = Doctor.GetComponent<DoctorManager>().Hand;//����擾
        Parts_No = Generation.GetComponent<PlacementManager>().Parts_No;//�S�̂̃p�[�c�����擾
    }

    // Update is called once per frame
    void Update()
    {
        //�J�E���g���I����Ă��Ȃ���
        if(Timmer >= 0)
        {
            //�J�E���g��i�߂�
            Timmer -= Time.deltaTime;
        }
        //�J�E���g���I�������
        else
        {
            //�W���}�}�[�̏����ɂ���
            Zyama_Win = true;
        }

        //���ꂼ��̃��C�t���擾(�X�V)
        Life_Doctor = Doctor.GetComponent<DoctorManager>().Life_Doctor;
        Life_Zyama = Zyama.GetComponent<Jamma>().Life_Zyama;

        //�p�[�c�̊i�[�����S�̂̃p�[�c���ɂȂ�����
        if(Point == Parts_No)
        {
            Doctor_Win = true;//���m�̏����t���O�𗧂Ă�
        }

        //���m�̃��C�t��0�ɂȂ�����
        if(Life_Doctor <= 0)
        {
            Zyama_Win = true;
        }

        //�W���}�}�[�̃��C�t��0�ɂȂ�����
        if(Life_Zyama <= 0)
        {
            Doctor_Win = true;
        }

        //�I�u�W�F�N�g��������Ɖ���点�Ȃ��̂ő���Ƀu���b�N�j�󉹂�炷
        if (BlockBreake == true)
        {
            Sound_Manager.Instance.PlaySE(SE.Break_1,0.6f,0);
            Sound_Manager.Instance.PlaySE(SE.Break_2,0.6f,0);
            BlockBreake = false;
        }
    }

    private void FixedUpdate()
    {
        if(Timmer >= 0)
        {
            //�^�C�}�[�̍X�V
            Count_Text.text = Timmer.ToString("F0");
        }
        else
        {
            if(Doctor_Win == true)
            {
                Count_Text.text = "���m�̏����I";
            }
            else if(Zyama_Win == true)
            {
                Count_Text.text = "�W���}�}�[�̏����I";
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //�p�[�c������ɐG�ꂽ��
        if(other.gameObject.tag == "Robot")
        {
            Point += 1;//�i�[�������Z

            Robots.GetComponent<RobotManager>().CreateRobot(other.gameObject);//���̃p�[�c�ƍ��̂�����

            //���m����������̃X�L���������Ă����ꍇ�X�L����������炷
            if (Doctor.GetComponent<DoctorManager>().SkillName != null && Doctor.GetComponent<DoctorManager>().SkillOn == false)
            {
                Sound_Manager.Instance.PlaySE(SE.SkillGet_D,1,0);
            }

            //���m�B�̃t���O�⎝���������Ƀ��Z�b�g
            Doctor.GetComponent<DoctorManager>().Parts
                = Hand.GetComponent<DoctorHand>().Parts
                = null;
            Doctor.GetComponent<DoctorManager>().Catching
                = false;
            Hand.GetComponent<DoctorHand>().OnParts
                = false;

            Doctor.GetComponent<DoctorManager>().SkillOn = true;//���m�̃X�L���𔭓�������
            Doctor.GetComponent<DoctorManager>().Skill_Keep = false;//���m�̉��H��p�[�c�擾������Z�b�g

            Debug.Log("���m�̃|�C���g" + Point + "/" + Parts_No);
        }
    }
}
