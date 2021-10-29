using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionDirector : MonoBehaviour
{
    [SerializeField]
    private int Point = 0;//�p�[�c�i�[��

    public int Parts_No;//�S�̂̃p�[�c��
    public GameObject Generation, Doctor,Hand;//[�p�[�c�i�[�ꏊ�̔���A���m�A��]���i�[����ϐ�
    public bool Doctor_Win = false;//���m�̏����t���O

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
        //�p�[�c�̊i�[�����S�̂̃p�[�c���ɂȂ�����
        if(Point == Parts_No)
        {
            Doctor_Win = true;//���m�̏����t���O�𗧂Ă�
            Debug.Log("���m����");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //�p�[�c������ɐG�ꂽ��
        if(other.gameObject.tag == "Robot")
        {
            Point += 1;//�i�[�������Z

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

            Destroy(other.gameObject);//�p�[�c������
            Debug.Log("���m�̃|�C���g" + Point + "/" + Parts_No);
        }
    }
}
