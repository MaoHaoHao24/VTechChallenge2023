using System;
using UnityEngine;
using UniVRM10;  //VRM1�n���������߂̖��O���
using Cinemachine;�@//Unity�̃J�����𑀍삷�郂�W���[��
public class VRMLoaderAddScript : MonoBehaviour
{
    [SerializeField] string _vrmName; //VRM�t�@�C����
    [SerializeField] CinemachineVirtualCamera _vcam; //�J�����Ǐ]�悤�Ɏg��VirtualCamera�B�g�p����VirtualCamera���Z�b�g����
    private void Start()
    { //StreamingAssets�t�H���_����VRM�t�@�C����ǂݍ���
        string vrmPath = $"{Application.streamingAssetsPath}/{_vrmName}.vrm";
        VRMLoadAsync(vrmPath);
    }
    private async void VRMLoadAsync(string path)
    {
        try
        { //VRM1.0�t�@�C���̔񓯊��ǂݍ���
            var vrm10Instance = await Vrm10.LoadPathAsync(path);
            GameObject vrm = vrm10Instance.gameObject; //VRM�A�o�^�[���I�u�W�F�N�g�Ƃ��Ď擾
            VRMAttach(vrm); //VRMAttach�֐��̎��s
        }
        catch (Exception e)
        { //�ǂݍ��݂Ɏ��s�����ꍇ�̗�O����
            Debug.LogError("Failed to load");
            Debug.LogException(e);
            throw;
        }
    }
    private void VRMAttach(GameObject vrm)
    {
        //VRM�A�o�^�[�ɃA�j���[�V�����R���g���[���t�@�C���AController.cs���A�^�b�`�A�J������Ǐ]
        Animator animator = vrm.GetComponent<Animator>(); //�A�j���[�V�����R���g���[���t�@�C�����擾
        animator.runtimeAnimatorController = (RuntimeAnimatorController)
            RuntimeAnimatorController.Instantiate(Resources.Load("VRMAnimations"));
        vrm.AddComponent<Controller>(); //Controller.cs�̒ǉ�
        Transform vcamPos = vrm.transform; //virtualcamera�̒Ǐ]
        _vcam.Follow = vcamPos;
        _vcam.LookAt = vcamPos;
    }
}
