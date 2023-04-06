using System;
using UnityEngine;
using UniVRM10; //VRM1�n���������߂̖��O���
public class VRMLoader : MonoBehaviour
{
    [SerializeField] string _vrmName; //VRM�t�@�C����
    private void Start()
    { //StreamingAssets�t�H���_����VRM�t�@�C����ǂݍ���
        string _vrmPath = $"{Application.streamingAssetsPath}/{_vrmName}.vrm";
        VRMLoadAsync(_vrmPath);
    }
    private async void VRMLoadAsync(string path)
    {
        try
        { //VRM1.0�t�@�C���̔񓯊��ǂݍ���(���s���������l��)
            await Vrm10.LoadPathAsync(path);
        }
        catch (Exception e)
        { //�ǂݍ��݂Ɏ��s�����ꍇ�̗�O����
            Debug.LogError("Failed to load");
            Debug.LogException(e);
            throw;
        }
    }
}
