﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(GenerateGUID))]
public class GridPropertiesManager : MonoSingleton<GridPropertiesManager>, ISaveable
{
    delegate bool JudgeGrid(int gridX, int gridY);

    private Transform cropParentTransform;

    private Tilemap groundDecoration1;
    private Tilemap groundDecoration2;
    /// <summary>
    /// 当前地图格子设置信息
    /// </summary>
    private Grid grid;
    /// <summary>
    /// 当前地图信息
    /// </summary>
    private Dictionary<string, GridPropertyDetails> gridPropertyDictionary;
    [SerializeField]
    private SO_GridProperties[] so_gridPropertiesArray = null;
    [SerializeField]
    private Tile[] dugGround = null;
    [SerializeField]
    private Tile[] waterGround = null;

    private string iSaveableUniqueID;
    public string ISaveableUniqueID { get => iSaveableUniqueID; set => iSaveableUniqueID = value; }

    //目前两个GridPropertiesManager和SceneItemManager分别使用了不同的GameObjectSave变量并分别存储，虽然没有问题，但造成了内存的浪费。
    private GameObjectSave gameObjectSave;
    public GameObjectSave GameObjectSave { get => gameObjectSave; set => gameObjectSave = value; }

    protected override void Awake()
    {
        base.Awake();
        ISaveableUniqueID = GetComponent<GenerateGUID>().GUID;
        GameObjectSave = new GameObjectSave();
    }

    private void OnEnable()
    {
        ISaveableRegister();
        EventCenter.Instance?.Register(EventEnum.AFTER_NEXT_SCENE_LOAD.ToString(), AfterSceneLoaded);
    }

    private void OnDisable()
    {
        ISaveableDeregister();
        EventCenter.Instance?.Unregister(EventEnum.AFTER_NEXT_SCENE_LOAD.ToString(), AfterSceneLoaded);
    }

    private void AfterSceneLoaded()
    {
        grid = GameObject.FindObjectOfType<Grid>();

        groundDecoration1 = GameObject.FindGameObjectWithTag(Tags.GroundDecoration1).GetComponent<Tilemap>();
        groundDecoration2 = GameObject.FindGameObjectWithTag(Tags.GroundDecoration2).GetComponent<Tilemap>();
    }

    public void ISaveableDeregister()
    {
        SaveLoadManager.Instance?.iSaveableObjectList.Remove(this);
    }

    public void ISaveableRegister()
    {
        SaveLoadManager.Instance?.iSaveableObjectList.Add(this);
    }

    private void Start()
    {
        InitialiseGridProperties();
    }

    private void ClearDisplayGrouondDecorations()
    {
        groundDecoration1.ClearAllTiles();
        groundDecoration2.ClearAllTiles();
    }

    private void ClearDisplayGridPropertyDetails()
    {
        ClearDisplayGrouondDecorations();
    }

    public void DisplayDugGroud(GridPropertyDetails gridPropertyDetails)
    {
        if (gridPropertyDetails.daysSinceDug > -1)
        {
            ConnectDugGround(gridPropertyDetails);
        }
    }

    public void DisplayWaterGroud(GridPropertyDetails gridPropertyDetails)
    {
        if (gridPropertyDetails.daysSinceWatered > -1)
        {
            ConnectWaterGround(gridPropertyDetails);
        }
    }

    private void ConnectDugGround(GridPropertyDetails gridPropertyDetails)
    {
        SetAdjacentGridPropertyDetails(gridPropertyDetails.gridX, gridPropertyDetails.gridY);

        SetAdjacentGridPropertyDetails(gridPropertyDetails.gridX, gridPropertyDetails.gridY + 1);
        SetAdjacentGridPropertyDetails(gridPropertyDetails.gridX, gridPropertyDetails.gridY - 1);
        SetAdjacentGridPropertyDetails(gridPropertyDetails.gridX - 1, gridPropertyDetails.gridY);
        SetAdjacentGridPropertyDetails(gridPropertyDetails.gridX + 1, gridPropertyDetails.gridY);
    }

    private void ConnectWaterGround(GridPropertyDetails gridPropertyDetails)
    {
        SetAdjacentGridPropertyWaterDetails(gridPropertyDetails.gridX, gridPropertyDetails.gridY);

        SetAdjacentGridPropertyWaterDetails(gridPropertyDetails.gridX, gridPropertyDetails.gridY + 1);
        SetAdjacentGridPropertyWaterDetails(gridPropertyDetails.gridX, gridPropertyDetails.gridY - 1);
        SetAdjacentGridPropertyWaterDetails(gridPropertyDetails.gridX - 1, gridPropertyDetails.gridY);
        SetAdjacentGridPropertyWaterDetails(gridPropertyDetails.gridX + 1, gridPropertyDetails.gridY);
    }

    private GridPropertyDetails SetAdjacentGridPropertyDetails(int gridX, int gridY)
    {
        GridPropertyDetails adjacentGridPropertyDetails = GetGridPropertyDetails(gridX, gridY);
        if (adjacentGridPropertyDetails != null && adjacentGridPropertyDetails.daysSinceDug > -1)
        {
            Tile dugTile = SetTile(gridX, gridY, dugGround, IsGridDug);
            groundDecoration1.SetTile(new Vector3Int(gridX, gridY, 0), dugTile);
        }

        return adjacentGridPropertyDetails;
    }

    private GridPropertyDetails SetAdjacentGridPropertyWaterDetails(int gridX, int gridY)
    {
        GridPropertyDetails adjacentGridPropertyDetails;
        adjacentGridPropertyDetails = GetGridPropertyDetails(gridX, gridY);
        if (adjacentGridPropertyDetails != null && adjacentGridPropertyDetails.daysSinceWatered > -1)
        {
            Tile waterTile = SetTile(gridX, gridY, waterGround, IsGridWatered);
            groundDecoration2.SetTile(new Vector3Int(gridX, gridY, 0), waterTile);
        }

        return adjacentGridPropertyDetails;
    }

    private Tile SetTile(int gridX, int gridY, Tile[] tiles, JudgeGrid judgeGridFunc)
    {
        bool upDug = judgeGridFunc(gridX, gridY + 1);
        bool downDug = judgeGridFunc(gridX, gridY - 1);
        bool leftDug = judgeGridFunc(gridX - 1, gridY);
        bool rightDug = judgeGridFunc(gridX + 1, gridY);

        if (!upDug && !downDug && !rightDug && !leftDug)
        {
            return tiles[0];
        }
        else if (!upDug && downDug && rightDug && !leftDug)
        {
            return tiles[1];
        }
        else if (!upDug && downDug && rightDug && leftDug)
        {
            return tiles[2];
        }
        else if (!upDug && downDug && !rightDug && leftDug)
        {
            return tiles[3];
        }
        else if (!upDug && downDug && !rightDug && !leftDug)
        {
            return tiles[4];
        }
        else if (upDug && downDug && rightDug && !leftDug)
        {
            return tiles[5];
        }
        else if (upDug && downDug && rightDug && leftDug)
        {
            return tiles[6];
        }
        else if (upDug && downDug && !rightDug && leftDug)
        {
            return tiles[7];
        }
        else if (upDug && downDug && !rightDug && !leftDug)
        {
            return tiles[8];
        }
        else if (upDug && !downDug && rightDug && !leftDug)
        {
            return tiles[9];
        }
        else if (upDug && !downDug && rightDug && leftDug)
        {
            return tiles[10];
        }
        else if (upDug && !downDug && !rightDug && leftDug)
        {
            return tiles[11];
        }
        else if (upDug && !downDug && !rightDug && !leftDug)
        {
            return tiles[12];
        }
        else if (!upDug && !downDug && rightDug && !leftDug)
        {
            return tiles[13];
        }
        else if (!upDug && !downDug && rightDug && leftDug)
        {
            return tiles[14];
        }
        else if (!upDug && !downDug && !rightDug && leftDug)
        {
            return tiles[15];
        }
        return null;
    }

    private void DisplayGridPropertyDetails()
    {
        foreach (var item in gridPropertyDictionary)
        {
            GridPropertyDetails gridPropertyDetails = item.Value;
            DisplayDugGroud(gridPropertyDetails);
            DisplayWaterGroud(gridPropertyDetails);
        }
    }

    private bool IsGridDug(int gridX, int gridY)
    {
        GridPropertyDetails gridPropertyDetails = GetGridPropertyDetails(gridX, gridY);
        if (gridPropertyDetails == null)
        {
            return false;
        }
        else if (gridPropertyDetails.daysSinceDug > -1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool IsGridWatered(int gridX, int gridY)
    {
        GridPropertyDetails gridPropertyDetails = GetGridPropertyDetails(gridX, gridY);
        if (gridPropertyDetails == null)
        {
            return false;
        }
        return (gridPropertyDetails.daysSinceWatered > -1);
    }

    private void InitialiseGridProperties()
    {
        foreach (var so_GridProperties in so_gridPropertiesArray)
        {
            Dictionary<string, GridPropertyDetails> gridPropertyDictionary = new Dictionary<string, GridPropertyDetails>();

            foreach (var gridProperty in so_GridProperties.gridPropertyList)
            {
                GridPropertyDetails gridPropertyDetails = GetGridPropertyDetails(gridProperty.gridCoordinate.x, gridProperty.gridCoordinate.y, gridPropertyDictionary);
                if (gridPropertyDetails == null)
                {
                    gridPropertyDetails = new GridPropertyDetails();
                }

                switch (gridProperty.gridBoolProperty)
                {
                    case GridBoolProperty.diggable:
                        gridPropertyDetails.isDiggable = gridProperty.gridBoolValue;
                        break;
                    case GridBoolProperty.canDropItem:
                        gridPropertyDetails.canDropItem = gridProperty.gridBoolValue;
                        break;
                    case GridBoolProperty.canPlaceFurniture:
                        gridPropertyDetails.canPlaceFurniture = gridProperty.gridBoolValue;
                        break;
                    case GridBoolProperty.isPath:
                        gridPropertyDetails.isPath = gridProperty.gridBoolValue;
                        break;
                    case GridBoolProperty.isNPCObstacle:
                        gridPropertyDetails.isNPCObstacle = gridProperty.gridBoolValue;
                        break;
                    default:
                        break;
                }

                SetGridPropertyDetails(gridProperty.gridCoordinate.x, gridProperty.gridCoordinate.y, gridPropertyDetails, gridPropertyDictionary);
            }

            SceneSave sceneSave = new SceneSave();
            sceneSave.gridPropertyDetailsDictionary = gridPropertyDictionary;
            if (so_GridProperties.sceneName == SceneControllerManager.Instance.startingSceneName)
            {
                this.gridPropertyDictionary = gridPropertyDictionary;
            }
            GameObjectSave.sceneData.Add(so_GridProperties.sceneName.ToString(), sceneSave);
        }
    }

    private void SetGridPropertyDetails(int x, int y, GridPropertyDetails gridPropertyDetails, Dictionary<string, GridPropertyDetails> gridPropertyDictionary)
    {
        string key = $"x{x}y{y}";
        gridPropertyDetails.gridX = x;
        gridPropertyDetails.gridY = y;

        gridPropertyDictionary[key] = gridPropertyDetails;
    }

    public void SetGridPropertyDetails(int x, int y, GridPropertyDetails gridPropertyDetails)
    {
        string key = $"x{x}y{y}";
        gridPropertyDetails.gridX = x;
        gridPropertyDetails.gridY = y;

        gridPropertyDictionary[key] = gridPropertyDetails;
    }

    private GridPropertyDetails GetGridPropertyDetails(int x, int y, Dictionary<string, GridPropertyDetails> gridPropertyDictionary)
    {
        string key = $"x{x}y{y}";
        GridPropertyDetails propertyDetails;
        if (!gridPropertyDictionary.TryGetValue(key, out propertyDetails))
        {
            return null;
        }
        else
        {
            return propertyDetails;
        }
    }

    public GridPropertyDetails GetGridPropertyDetails(int x, int y)
    {
        return GetGridPropertyDetails(x, y, gridPropertyDictionary);
    }

    public void ISaveableRestoreScene(string sceneName)
    {
        if (GameObjectSave.sceneData.TryGetValue(sceneName, out SceneSave sceneSave))
        {
            if (sceneSave.gridPropertyDetailsDictionary != null)
            {
                gridPropertyDictionary = sceneSave.gridPropertyDetailsDictionary;
            }

            if (gridPropertyDictionary.Count > 0)
            {
                ClearDisplayGridPropertyDetails();
                DisplayGridPropertyDetails();
            }
        }
    }

    public void ISaveableStoreScene(string sceneName)
    {
        GameObjectSave.sceneData.Remove(sceneName);
        SceneSave sceneSave = new SceneSave();
        sceneSave.gridPropertyDetailsDictionary = gridPropertyDictionary;
        GameObjectSave.sceneData.Add(sceneName, sceneSave);
    }
}
