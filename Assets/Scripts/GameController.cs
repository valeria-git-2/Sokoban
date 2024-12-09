using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private int level, box, marks, checkedBoxes;
    MapView mapView;

    void Awake()
    {
        mapView = FindObjectOfType<MapView>();
        StartLevel();

    }
    private void Update()
    {
        box = GameMap.Boxes;
        marks = GameMap.Marks;
        checkedBoxes = GameMap.PlacedBoxes;
        if (box == checkedBoxes||marks == checkedBoxes){
            SetWin();
        }
    }

    private void StartLevel()
    {
        level = PlayerPrefs.GetInt("level", 1);
        if (level > 2) { level = 2; }
        GameMap.SetGameMap(level);
        GameMap.SetGameMapView(mapView);
        mapView.DrawMap(GameMap.Width, GameMap.Height, GameMap.tile);
    }
    private void SetWin()
    {
        mapView.ClearMap();
        PlayerPrefs.SetInt("level", level+1);
        StartLevel();
    }
}
