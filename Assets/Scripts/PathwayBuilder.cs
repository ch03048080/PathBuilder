using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.InputSystem;
public class PathwayBuilder : MonoBehaviour
{

    public InputActionAsset inputActions; // Input Action Asset 연결
    public Tilemap tilemap; // 타일맵 참조
    public TileBase wallTile; // Wall 타일
    public TileBase resourceTile; // Resource 타일
    public TileBase emptyTile; // 굴 파기 후 사용할 빈 타일 (null로 설정 가능)
    public Color previewColor = new Color(1f, 1f, 1f, 0.5f); // 미리보기 색상

    private InputAction clickAction;
    private InputAction positionAction;
    private Camera mainCamera;

    private HashSet<Vector3Int> previewTiles = new HashSet<Vector3Int>(); // 미리보기 타일 좌표
    private bool isDragging = false;
    void OnEnable()
    {
        // Action Map과 Action 가져오기
        var tilemapControls = inputActions.FindActionMap("TilemapControls");
        clickAction = tilemapControls.FindAction("Click");
        positionAction = tilemapControls.FindAction("Position"); // 마우스 위치 추적용

        // Action 활성화
        clickAction.Enable();
        positionAction.Enable();

        // Action에 콜백 연결
        clickAction.started += OnClickStarted;
        clickAction.canceled += OnClickCanceled;

        // 카메라 참조
        mainCamera = Camera.main;
    }

    void OnDisable()
    {
        // Action 비활성화
        clickAction.Disable();
        positionAction.Disable();
    }

    private void OnClickStarted(InputAction.CallbackContext context)
    {
        isDragging = true;
        previewTiles.Clear(); // 이전 경로 초기화
    }

    private void OnClickCanceled(InputAction.CallbackContext context)
    {
        isDragging = false;

        // 드래그한 경로를 굴로 변환
        foreach (var tilePosition in previewTiles)
        {
            if (tilemap.HasTile(tilePosition))
            {
                tilemap.SetTile(tilePosition, emptyTile); // 빈 타일로 설정
            }
        }
        // 미리보기 타일 초기화
        ClearPreviewTiles();
    }

    void Update()
    {
        if (isDragging)
        {
            // 마우스 위치 가져오기
            Vector2 mousePosition = Mouse.current.position.ReadValue();
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
            worldPosition.z = 0;

            // 클릭한 위치의 타일 좌표 가져오기
            Vector3Int tilePosition = tilemap.WorldToCell(worldPosition);

            // 타일이 Wall 또는 Resource 타일이 아니고, 이미 미리보기된 타일이 아니면 추가
            if (!previewTiles.Contains(tilePosition) && tilemap.HasTile(tilePosition))
            {
                TileBase currentTile = tilemap.GetTile(tilePosition);
                if (currentTile != wallTile && currentTile != resourceTile)
                {
                    previewTiles.Add(tilePosition);
                    SetTilePreview(tilePosition);
                }
            }
        }
    }

    private void SetTilePreview(Vector3Int tilePosition)
    {
        // 타일맵의 색상을 변경하여 미리보기 표시
        tilemap.SetTileFlags(tilePosition, TileFlags.None); // 타일 플래그 초기화
        tilemap.SetColor(tilePosition, previewColor); // 미리보기 색상 적용
    }

    private void ClearPreviewTiles()
    {
        // 미리보기로 설정된 타일 색상 초기화
        foreach (var tilePosition in previewTiles)
        {
            if (tilemap.HasTile(tilePosition))
            {
                tilemap.SetTileFlags(tilePosition, TileFlags.None); // 타일 플래그 초기화
                tilemap.SetColor(tilePosition, Color.white); // 원래 색상으로 복원
            }
        }

        previewTiles.Clear();
    }
}
