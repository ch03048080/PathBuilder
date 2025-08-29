using UnityEngine;
// 카메라 관리
public class CameraResolution : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   private void Awake()
    {
   
        Camera cam = GetComponent<Camera>();

  
        Rect viewportRect = cam.rect;

        // 원하는 가로 세로 비율을 계산
        float screenAspectRatio = (float)Screen.width / Screen.height;
        float targetAspectRatio = 16f / 9f;

        // 화면 가로 세로 비율에 따라 뷰포트 영역 조정
        if (screenAspectRatio < targetAspectRatio)
        {
            //세로가 더 길다면, 세로를 조절
            viewportRect.height = screenAspectRatio / targetAspectRatio;
            viewportRect.y = (1f - viewportRect.height) / 2f;
        }
        else
        {
            //가로가 더 길다면, 가로를 조절
            viewportRect.width = targetAspectRatio / screenAspectRatio;
            viewportRect.x = (1f - viewportRect.width) / 2f;
        }

        // 조정된 뷰포트 영역을 카메라에 설정
        cam.rect = viewportRect;
    }
}
