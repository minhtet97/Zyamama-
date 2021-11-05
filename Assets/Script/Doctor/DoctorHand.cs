using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoctorHand : MonoBehaviour
{
    [SerializeField]
    public bool OnParts = false;//�p�[�c�ɐG��Ă��邩�̔���
    public GameObject Parts;//�G��Ă���p�[�c���i�[����ϐ�
    public string SkillName;

    Rigidbody Rb;

    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //�p�[�c�������Ă��Ȃ����͎����Ă��Ȃ�����ɂ���
        if(Parts == null)
        {
            OnParts = false;
        }
    }

    //�p�[�c�ɐG��Ă��鎞�A�ǂ̃p�[�c�ɐG��Ă��邩
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Robot")
        {
            //�G��Ă��锻��ɐ؂�ւ���
            OnParts = true;

            //�G��Ă���p�[�c���i�[
            Parts = other.gameObject;

            SkillName = other.gameObject.GetComponent<RobotManager>().SkillName;
        }
    }

    //�p�[�c�𗣂�����
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Robot")
        {
            //�擾�p�[�c����(���������Ă��Ȃ����)�ɂ���
            Parts = null;
        }
    }
}
