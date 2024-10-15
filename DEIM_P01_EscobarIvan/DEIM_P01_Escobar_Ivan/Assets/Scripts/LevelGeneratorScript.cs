using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class LevelGeneratorScript : MonoBehaviour
{
    [SerializeField] private GameObject levelTile;
    [SerializeField] private GameObject[] tilesToUse;
    [SerializeField] private GameObject[] tilesEnd;
    [SerializeField] private GameObject[] tilesStart;
    [SerializeField] private List<GameObject> generatedtiles;
    int numberOfTilesToGenerate = 20;
    int tileHeight = -15;
    int tileNumber = 1;
    int tileIndex;
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
        Instantiate(tilesStart[UnityEngine.Random.Range(0, 1)], new Vector2(0, 0), Quaternion.identity, transform);

        while (tileNumber < numberOfTilesToGenerate)
        {
            tileIndex = UnityEngine.Random.Range(0, generatedtiles.Count);
            Instantiate(generatedtiles[tileIndex], new Vector2(0, tileNumber * tileHeight), Quaternion.identity, transform);
            generatedtiles.RemoveAt(tileIndex);
            tileNumber++;
        }
        Instantiate(tilesEnd[UnityEngine.Random.Range(0, 1)], new Vector2(0, tileNumber*tileHeight), Quaternion.identity, transform);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
