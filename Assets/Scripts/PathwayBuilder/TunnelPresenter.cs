using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class TunnelPresenter : MonoBehaviour
{
    public InputActionAsset inputActions;
    public TunnelView view;
    public TileBase wallTile;
    public TileBase resourceTile;
    public int initialCost = 7;

    private TunnelModel model;
    private InputAction clickAction;
    private InputAction positionAction;
    private Camera mainCamera;
    private bool isDragging = false;

    void Awake()
    {
        model = new TunnelModel(initialCost);
    }

    void OnEnable()
    {
        var tilemapControls = inputActions.FindActionMap("TilemapControls");
        clickAction = tilemapControls.FindAction("Click");
        positionAction = tilemapControls.FindAction("Position");

        clickAction.Enable();
        positionAction.Enable();

        clickAction.started += OnClickStarted;
        clickAction.canceled += OnClickCanceled;

        mainCamera = Camera.main;
    }

    void OnDisable()
    {
        clickAction.Disable();
        positionAction.Disable();
    }

    private void OnClickStarted(InputAction.CallbackContext context)
    {
        isDragging = true;
        model.ResetPreview();
    }

    private void OnClickCanceled(InputAction.CallbackContext context)
    {
        isDragging = false;
        foreach (var position in model.PreviewTiles)
        {
            view.DigTile(position);
        }
        foreach (var position in model.PreviewTiles)
        {
            view.ClearTilePreview(position);
        }
        model.ResetPreview();
    }

    void Update()
    {
        if (isDragging)
        {
            Vector2 mousePosition = Mouse.current.position.ReadValue();
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
            worldPosition.z = 0;
            Vector3Int tilePosition = view.tilemap.WorldToCell(worldPosition);

            if (model.CanDig(tilePosition) && view.tilemap.HasTile(tilePosition))
            {
                TileBase currentTile = view.tilemap.GetTile(tilePosition);
                if (currentTile != wallTile && currentTile != resourceTile)
                {
                    model.DigTile(tilePosition);
                    view.SetTilePreview(tilePosition);
                }
            }
        }
    }
}