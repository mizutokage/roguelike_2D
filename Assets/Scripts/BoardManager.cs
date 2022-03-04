using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{

    public int colums = 8, rows = 8; // Player移動範囲
    public GameObject[] FloorTiles; 
    public GameObject[] OutWallTiles;

    void BoardSetup() { // FloorとWallを設置
        for (int x = -1; x < colums + 1; x++) {
            for (int y = -1; y < rows + 1; x++) {
                GameObject toInstantiate;
                if (x == -1 || x == colums || y == -1 || y == rows) {
                    toInstantiate = OutWallTiles[Random.Range(0, OutWallTiles.Length)]; // Wallを設置
                }
                else {
                    toInstantiate = FloorTiles[Random.Range(0, FloorTiles.Length)]; // Floorを設置
                }

                Instantiate(toInstantiate, new Vector3(x, y, 0), Quaternion.identity);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        BoardSetup();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
