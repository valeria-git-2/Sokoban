public static class GameMap
{
    private static int _width, _height;
    private static Tile[,] _tile;
    private static MapView _mapView;
    public static int Width
    {
        get { return _width; }
        set
        {
            if (value <= 1) _width = 2;
            else _width = value;
        }
    }
    public static int Height
    {
        get { return _height; }
        set
        {
            if (value <= 1) _height = 2;
            else _height = value;
        }
    }

    public static Tile[,] tile
    {
        get { return _tile; }
        set
        {
            _tile = new Tile[_width, _height];
            _tile = value;
        }
    }
    private static Coordinate _player;
    private static int _box;
    private static int _marks;
    private static int _placedBoxes;
    public static Coordinate Player
    {
        get { return _player; }
        set
        {
            _player = new Coordinate(0, 0);
            _player.x = value.x;
            _player.y = value.y;
        }
    }
    public static int Boxes
    {
        get { return _box; }
        set
        {
            if (value > 0) _box = value;
        }
    }
    public static int PlacedBoxes
    {
        get { return _placedBoxes; }
        set
        {
            if (value > 0) _placedBoxes = value;
        }
    }
    public static int Marks
    {
        get { return _marks; }
        set
        {
            if (value > 0) _marks = value;
        }
    }

    public static void SetGameMap(int level)
    {

        string levelPath = "Levels/Level" + level.ToString();
        MapParser parser = new MapParser();
        parser.Parse(levelPath);
    }
    public static void SetGameMapView(MapView mapView)
    {
        _mapView = mapView;
    }
    public static void ChangeMovable(int deltaX = 0, int deltaY = 0)
    {
        if (!CheckBounds(_player.x + deltaX, _player.y + deltaY)) return;
        if (CheckBox(_player.x + deltaX, _player.y + deltaY))
        {
            if (CheckWalkable(_player.x + deltaX * 2, _player.y + deltaY * 2))
            {
                var tempTile = _tile[_player.x + deltaX * 2, _player.y + deltaY * 2];
                if (CheckMark(_player.x + deltaX * 2, _player.y + deltaY * 2))
                {
                    tempTile.tileType = TileType.PlacedBox;
                    _placedBoxes++;
                }
                else tempTile.tileType = TileType.Box;
                _mapView.ChangeMap(new Coordinate(_player.x + deltaX * 2, _player.y + deltaY * 2), tempTile);
                tempTile = _tile[_player.x + deltaX, _player.y + deltaY];
                tempTile.tileType = TileType.Floor;
                _mapView.ChangeMap(new Coordinate(_player.x + deltaX, _player.y + deltaY), tempTile);
                _player.x += deltaX;
                _player.y += deltaY;
                _mapView.MovePlayer(_player);
            }
        }
        else if (CheckPlacedBox(_player.x + deltaX, _player.y + deltaY))
        {
            if (CheckWalkable(_player.x + deltaX * 2, _player.y + deltaY * 2))
            {
                var tempTile = _tile[_player.x + deltaX * 2, _player.y + deltaY * 2];
                tempTile.tileType = TileType.Box;
                _mapView.ChangeMap(new Coordinate(_player.x + deltaX * 2, _player.y + deltaY * 2), tempTile);
                tempTile = _tile[_player.x + deltaX, _player.y + deltaY];
                tempTile.tileType = TileType.Mark;
                _placedBoxes--;
                _mapView.ChangeMap(new Coordinate(_player.x + deltaX, _player.y + deltaY), tempTile);
                _player.x += deltaX;
                _player.y += deltaY;
                _mapView.MovePlayer(_player);
            }
        }
        else if (CheckWalkable(_player.x + deltaX, _player.y + deltaY))
        {
            _player.x += deltaX;
            _player.y += deltaY;
            _mapView.MovePlayer(_player);
        }

    }

    private static bool CheckBox(int x, int y)
    {
        return _tile[x, y].tileType == TileType.Box;

    }
    private static bool CheckPlacedBox(int x, int y)
    {
        return _tile[x, y].tileType == TileType.PlacedBox;

    }

    private static bool CheckMark(int x, int y)
    {
        return _tile[x, y].tileType == TileType.Mark;

    }
    private static bool CheckWalkable(int x, int y)
    {
        return _tile[x, y].IsWalkable;
    }

    private static bool CheckBounds(int x, int y)
    {
        return (x < _width || x >= 0 || y < _height || y >= 0);
    }
}

public class Coordinate
{
    public int x, y;
    public Coordinate(int x, int y) { this.x = x; this.y = y; }
}