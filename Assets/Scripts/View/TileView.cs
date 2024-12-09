using UnityEngine;

public class TileView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite Wall;
    [SerializeField] private Sprite Floor;
    [SerializeField] private Sprite Box;
    [SerializeField] private Sprite PlacedBox;

    bool isMark;
    public void SetImage(TileType tileType)
    {
        transform.GetChild(0).gameObject.SetActive(false);
        if (spriteRenderer == null) spriteRenderer = gameObject.AddComponent<SpriteRenderer>();

        switch (tileType)
        {
            case TileType.Floor: spriteRenderer.sprite = Floor; break;
            case TileType.Wall: spriteRenderer.sprite = Wall; break;
            case TileType.Mark:
                spriteRenderer.sprite = Floor;
                transform.GetChild(0).gameObject.SetActive(true);
                break;
            case TileType.Box: spriteRenderer.sprite = Box; break;
            case TileType.PlacedBox: spriteRenderer.sprite = PlacedBox; break;
            default: spriteRenderer.sprite = Floor; break;
        }
    }
}
