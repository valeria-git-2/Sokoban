using UnityEngine;

public class MapView : MonoBehaviour
{
    [SerializeField] GameObject TilePrefab;
    [SerializeField] GameObject PlayerPrefab;
    private TileView[,] map;
    GameObject Player;
    
    public void DrawMap(int width, int height, Tile[,] tile)
    {
        map = new TileView[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                GameObject tileView = Instantiate(TilePrefab, gameObject.transform);
                tileView.transform.localPosition = new Vector2(x * 1.3f, y * 1.3f);
                if (tile[x, y].tileType == TileType.Player)
                {
                    Player = Instantiate(PlayerPrefab, gameObject.transform);
                    Player.transform.localPosition = new Vector2(x * 1.3f, y * 1.3f);
                }
                tileView.GetComponent<TileView>().SetImage(tile[x, y].tileType);
                map[x, y] = tileView.GetComponent<TileView>();
            }
        }

    }

    public void ChangeMap(Coordinate coord, Tile tile)
    {
        map[coord.x, coord.y].GetComponent<TileView>().SetImage(tile.tileType);

    }
    public void MovePlayer(Coordinate coord)
    {
        Player.transform.localPosition = new Vector2(coord.x * 1.3f, coord.y * 1.3f);

    }

    internal void ClearMap()
    {
        map = null;
        RemoveAllChildren();
    }
    void RemoveAllChildren()
    {
        while (transform.childCount > 0)
        {
            DestroyImmediate(transform.GetChild(0).gameObject);
        }
    }
}
