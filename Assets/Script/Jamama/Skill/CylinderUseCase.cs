using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderUseCase : MonoBehaviour
{
    //  �����I�u�W�F�N�g���X�g
    [SerializeField]
    private List<GameObject> _itemObject = new List<GameObject>();

    //  �I�u�W�F�N�g�����݂��邩�ǂ����̃`�F�b�N
    public bool IsSetting { get; private set; } = false;
    //  �I�������I�u�W�F�N�g�ԍ���Ԃ�
    public int SelectIndex { get; private set; } = -1;

    /// <summary>
    /// �����_���ɃA�C�e����ݒ肷��
    /// </summary>
    public void SetRandomItem()
    {
        //  �����ŗ\�肵�Ă���I�u�W�F�N�g�̐����痐�����擾
        SelectIndex = Random.Range(0, _itemObject.Count);
        //  �Ώۂ̃I�u�W�F�N�g��\������
        _itemObject[SelectIndex].SetActive(true);
        //  �\������Ă���t���O��ݒ�
        IsSetting = true;
    }

    /// <summary>
    /// �A�C�e���������i�\���j
    /// </summary>
    public void ClearItem()
    {
        _itemObject.ForEach(item => item.SetActive(false));
    }
}