﻿using UnityEngine;
using System;
using System.Collections;

public class MapGenerator1 : MonoBehaviour {
    public int width;
    public int height;

    public string seed;
    public bool useRandomSeed;

    [Range(0,100)]
    public int randomFillPercent;

    int[,] map;

    void Start() {
        GenerateMap();

    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GenerateMap();
        }
    }

    void GenerateMap()
    {
        map = new int[width, height];
        RandomFillMap();

        for(int i = 0 ; i < 5 ;i++)
        {
            SmoothMap();
        }
        
    }

    void RandomFillMap()
    {
        if (useRandomSeed)
           seed = Time.time.ToString();

        System.Random pseudoDoRandom = new System.Random(seed.GetHashCode());

        for(int x = 0; x < width; x ++)
        {
            for (int y = 0; y < height; y ++)
            {
                if (x == 0 || x == width - 1 || y == 0 || y == height - 1)
                {
                    map[x, y] = 1;
                }
                else
                {
                    map[x, y] = (pseudoDoRandom.Next(0, 100) < randomFillPercent) ? 1 : 0;
                }
            }
        }

    }

    //Гладкость карты  neighbourTiles < 4  до 7
    public int SmoothMapNum_1 = 4;
    public int SmoothMapNum_2 = 4;
    void SmoothMap()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                int neighbourTiles = GetSurroundingWallCount(x,y);

                if (neighbourTiles > SmoothMapNum_1 )
                    map[x, y] = 1;
                else if (neighbourTiles < SmoothMapNum_2 )
                    map[x, y] = 0;
            }
        }
    }

    int GetSurroundingWallCount(int gridX, int gridY)
    {
        int wallCount = 0;
        for (int neightbourX = gridX - 1; neightbourX <= gridX + 1; neightbourX++)
        {
            for (int neightbourY = gridY - 1; neightbourY <= gridY + 1; neightbourY++)
            {
                if (neightbourX >= 0 && neightbourX < width && neightbourY >= 0 && neightbourY < height)
                {
                    if (neightbourX != gridX || neightbourY != gridY)
                    {
                        wallCount += map[neightbourX, neightbourY];
                    }
                }
                else
                {
                    wallCount++;
                }
            }
        }

        return wallCount;
    }

    void OnDrawGizmos()
    {
        if( map != null)
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Gizmos.color = (map[x, y] == 1) ? Color.black : Color.white;
                    Vector3 pos = new Vector3(-width / 2 + x + .5f, 0, -height / 2 + y + .5f);
                    Gizmos.DrawCube(pos, Vector3.one);
                }
            }
        }
    }
}