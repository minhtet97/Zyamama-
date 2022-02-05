using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotManager : MonoBehaviour
{
    [Header("�e�p�[�c�����Ă�")]
    [SerializeField]
    public GameObject Head, Arm_L, Arm_R, Leg_L, Leg_R;

    [Header("�Q�[���f�B���N�^�[")]
    [SerializeField]
    GameObject GameDirector;

    Animator Anim;

    // Start is called before the first frame update
    void Start()
    {
        //�ŏ��Ɋe�p�[�c���\���ɂ���
        Head.SetActive(false);
        Arm_L.SetActive(false);
        Arm_R.SetActive(false);
        Leg_L.SetActive(false);
        Leg_R.SetActive(false);

        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameDirector.GetComponent<Game_Director>().GameSet == true && GameDirector.GetComponent<Game_Director>().Doctor_Win == true)
        {
            Anim.SetTrigger("Win");
            Head.SetActive(true);
            Arm_L.SetActive(true);
            Arm_R.SetActive(true);
            Leg_L.SetActive(true);
            Leg_R.SetActive(true);

            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    //�p�[�c�����̂����鏈��
    public void CreateRobot(GameObject Parts)
    {
        //�N���[���̃I�u�W�F�N�g�Ȃ̂�(Clone)�̕������󔒂ɕς��ăp�[�c���Ɠ����ɂ���
        string chackname = Parts.name.Replace("(Clone)", "");

        switch (chackname)
        {
            case "Parts_Head":
                Head.SetActive(true);
                break;

            case "Parts_Arm_L":
                Arm_L.SetActive(true);
                break;

            case "Parts_Arm_R":
                Arm_R.SetActive(true);
                break;

            case "Parts_Leg_L":
                Leg_L.SetActive(true);
                break;

            case "Parts_Leg_R":
                Leg_R.SetActive(true);
                break;
        }

        Destroy(Parts);//��Ɏ����Ă�p�[�c������
    }
}
