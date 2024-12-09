using UnityEngine;

public class Tile 
{
    protected bool _isWalkable;
    protected TileType _tileType;
    public TileType tileType
    {
        get
        {
            return _tileType;
        }
        set
        {
            _tileType = value;
            switch (tileType)
            {
                case TileType.Floor: _isWalkable = true; break;
                case TileType.Wall : _isWalkable = false; break;
                case TileType.Mark: _isWalkable = true; break;
                case TileType.PlacedBox: _isWalkable = false; break;
                case TileType.Box: _isWalkable = false; break;
                case TileType.Player: _isWalkable = false; break;
            }
        }
    }

    public bool IsWalkable
    {
        get
        {
            return _isWalkable;
        }
       
    }

    public void DrawTile(Sprite sprite)
    {

    }

}
public enum TileType
{
    Wall = 'W',
    Floor = ' ',
    Mark = 'X',
    Box = 'b',
    PlacedBox = 'B',
    Player = 'P'
}
