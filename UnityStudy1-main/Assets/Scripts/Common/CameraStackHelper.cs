using UnityEngine;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(Camera))] // ĳ���� - ī�޶�, ������ٵ�, �ݶ��̴�
public class CameraStackHelper : MonoBehaviour
{
   
    void Start()
    {
        Camera mainCamera = Camera.main;
        var mainCameraData = mainCamera.GetUniversalAdditionalCameraData();
        mainCameraData.renderType = CameraRenderType.Base; // ������ = ���� �� ����

        Camera uICamera = GetComponent<Camera>(); // UICamera ��������
        var uICameraData = uICamera.GetUniversalAdditionalCameraData();
        uICameraData.renderType = CameraRenderType.Overlay;
        mainCameraData.cameraStack.Add(uICamera);

        var uiManagerCamera = UIManager.Instance.UICamera;
        var uiManagerCameraData = uiManagerCamera.GetUniversalAdditionalCameraData();
        uiManagerCameraData.renderType = CameraRenderType.Overlay;
        mainCameraData.cameraStack.Add(uiManagerCamera);
    }

}
