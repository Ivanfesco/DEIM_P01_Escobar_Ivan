using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Aseprite;
using UnityEngine;
using Pathfinding;

public class LevelGeneratorScript : MonoBehaviour
{
    [SerializeField] private GameObject levelTile;
    [SerializeField] private GameObject[] tilesToUse;
    [SerializeField] private GameObject[] tilesEnd;
    [SerializeField] private GameObject[] tilesStart;
    [SerializeField] private List<GameObject> generatedtiles;

    [SerializeField] private GameObject ForestShop;
    int numberOfTilesToGenerate = 20;
    int tileHeight = -15;
    int tileNumber = 1;
    int tileIndex;
    int previousExit = 0;
    bool shopGenerated;
    int genAttempts;
    bool end_spawned;
    // Start is called before the first frame update
    void Start()
    {
        generatedtiles = new List<GameObject>();
        int piecesPerTile = Mathf.CeilToInt(((float)numberOfTilesToGenerate / tilesToUse.Length));

        for (int i = 0; i < tilesToUse.Length; i++)
        {
            for (int piecebagtotal = piecesPerTile; piecebagtotal > 0; piecebagtotal--)
            {
                generatedtiles.Add(tilesToUse[i]);
            }
        }


        while (tileNumber < numberOfTilesToGenerate)
        {
            if (tileNumber < 4)
            {
                Instantiate(tilesStart[0], new Vector2(0, tileNumber * tileHeight), Quaternion.identity, transform);
                tileNumber++;
            }
            else
            {
                tileIndex = UnityEngine.Random.Range(0, generatedtiles.Count);
                if (!shopGenerated)
                {
                    if (UnityEngine.Random.Range(0, 5) >= 4)
                    {
                        Instantiate(ForestShop, new Vector2(0, tileNumber * tileHeight), Quaternion.identity, transform);
                        shopGenerated = true;
                        tileNumber++;
                    }
                    else
                    {
                        generatetilesfunc();
                    }
                }
                else
                {
                    generatetilesfunc();
                }


            }
        }

        generationended();

    }
    // Update is called once per frame
    void Update()
    {
        

        if (tileNumber == numberOfTilesToGenerate)
        {
            if(!end_spawned)
            {
                Instantiate(tilesEnd[0], new Vector2(0, tileNumber * tileHeight), Quaternion.identity, transform);
                end_spawned = true;
            }
        }
        
    }

    void generatetilesfunc()
    {
        if (genAttempts < 10)
        {
            if (generatedtiles[tileIndex].GetComponent<LevelTileCriteria>().exitType != previousExit)
            {
                Instantiate(generatedtiles[tileIndex], new Vector2(0, tileNumber * tileHeight), Quaternion.identity, transform);
                if (generatedtiles[tileIndex].GetComponent<LevelTileCriteria>() != null)
                {

                    previousExit = generatedtiles[tileIndex].GetComponent<LevelTileCriteria>().exitType;
                }

                generatedtiles.RemoveAt(tileIndex);
                tileNumber++;
                genAttempts = 0;
            }
            else
            {
                genAttempts++;
            }
        }
        else
        {
            Instantiate(generatedtiles[tileIndex], new Vector2(0, tileNumber * tileHeight), Quaternion.identity, transform);
            generatedtiles.RemoveAt(tileIndex);
            tileNumber++;
        }
    }

    void generationended()
    {
        var gg = AstarPath.active.data.gridGraph;
        
        gg.RelocateNodes(center: new Vector3(0, (numberOfTilesToGenerate * tileHeight) / 2, 0), rotation: Quaternion.identity, nodeSize: 0.25f);
        gg.is2D = true;
        gg.SetDimensions(112, tileHeight * numberOfTilesToGenerate * 4, 0.25f);

        AstarPath.active.Scan();

    }
}
