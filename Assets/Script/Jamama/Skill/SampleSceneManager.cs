using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SampleSceneManager : MonoBehaviour
{
    //  ���ɗp�ӂ����V�����_�[�I�u�W�F�N�g
    [Serializable]
    private class LinePack
    {
        public List<GameObject> PackCylinder = new List<GameObject>();
    }
    //  �V�����_�[�񃊃X�g
    [SerializeField]
    private List<LinePack> _linePack = new List<LinePack>();

    //[SerializeField]
    //private Button _button;

    private void Start()
    {
        //  �{�^���Ή�
        RandomObjectSet();
    }

    /// <summary>
    /// �{�^�����������烉���_���ɃZ�b�g����
    /// </summary>
    private void RandomObjectSet()
    {
        //  �e��ɑ΂��ĂP�����A�C�e����ݒ�
        _linePack.ForEach(packLines => {
            //  ��U���g���N���A����
            packLines.PackCylinder.ForEach(pack => pack.GetComponent<CylinderUseCase>().ClearItem());
            //  �O�`�T�܂ł̗����擾
            var rndIndex = UnityEngine.Random.Range(0, packLines.PackCylinder.Count);
            //  �Ώۂ̃V�����_�[�ɃI�u�W�F�N�g��ݒ�
            packLines.PackCylinder[rndIndex].GetComponent<CylinderUseCase>().SetRandomItem();
        });
    }

}