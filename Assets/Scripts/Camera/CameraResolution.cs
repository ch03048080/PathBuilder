using UnityEngine;
// 카메라 관리
public class CameraResolution : MonoBehaviour
{
    [SerializeField] private float targetAspectWidth = 16f;
    [SerializeField] private float targetAspectHeight = 9f;

    private void Awake()
    {
        Camera cam = GetComponent<Camera>();
        Rect viewportRect = cam.rect;
        //Debug.Log($"Screen.width: {Screen.width}, Screen.height: {Screen.height}");
        //Debug.Log($"Camera.pixelWidth: {cam.pixelWidth}, Camera.pixelHeight: {cam.pixelHeight}");
        //Debug.Log($"Camera.rect: {cam.rect}");

        float screenAspectRatio = (float)Screen.width / Screen.height;
        float targetAspectRatio = targetAspectWidth / targetAspectHeight;

        if (screenAspectRatio < targetAspectRatio)
        {
            viewportRect.height = screenAspectRatio / targetAspectRatio;
            viewportRect.y = (1f - viewportRect.height) / 2f;
        }
        else
        {
            viewportRect.width = targetAspectRatio / screenAspectRatio;
            viewportRect.x = (1f - viewportRect.width) / 2f;
        }

        cam.rect = viewportRect;
    }
}
