using UnityEngine;

public class MapParser
{
    public void Parse(string filePath)
    {

        var content = Resources.Load<TextAsset>(filePath).text;

        int height = content.Split('\n').Length;
        int width = content.Split('\n')[0].Length;
        string[] strings = content.Split("\n");
        Tile[,] _tile = new Tile[width, height];
        int box = 0;
        int marks = 0;
        int placedBox = 0;
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                char tileType = strings[y][x];
                Tile tile = new Tile();
                tile.tileType = (TileType)tileType;
                switch (tile.tileType)
                {
                    case TileType.Player: GameMap.Player = new Coordinate(x, y); break;
                    case TileType.Box: box++; break;
                    case TileType.Mark: marks++; break;
                    case TileType.PlacedBox: marks++; box++; placedBox++; break;
                    default: break;
                }
                _tile[x, y] = tile;
            }
        }
        GameMap.tile = _tile;
        GameMap.Width = width;
        GameMap.Height = height;
        GameMap.Boxes = box;
        GameMap.Marks = marks;
        GameMap.PlacedBoxes = placedBox;
    }
}
