using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionDirector : MonoBehaviour
{
    [SerializeField]
    private int Point = 0;

    public int Parts_No;
    public GameObject Generation, Doctor,Hand;
    public bool Doctor_Win = false;

    // Start is called before the first frame update
    void Start()
    {
        Generation = GameObject.Find("Generation");
        Hand = Doctor.GetComponent<DoctorManager>().Hand;
        Parts_No = Generation.GetComponent<PlacementManager>().Parts_No;//�p�[�c�����擾
    }

    // Update is called once per frame
    void Update()
    {
        if(Point == Parts_No)
        {
            Doctor_Win = true;
            Debug.Log("���m����");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Robot")
        {
            Point += 1;

            //�t���O�⎝���������Ƀ��Z�b�g
            Doctor.GetComponent<DoctorManager>().Parts
                = Hand.GetComponent<DoctorHand>().Parts
                = null;
            Doctor.GetComponent<DoctorManager>().Catching
                = false;
            Hand.GetComponent<DoctorHand>().OnParts
                = false;

            Destroy(other.gameObject);
        }
    }
}
