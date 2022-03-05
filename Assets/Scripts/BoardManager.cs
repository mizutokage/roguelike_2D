using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{

    public int colums = 8, rows = 8; // Player移動範囲
    public GameObject[] floorTiles; 
    public GameObject[] outWallTiles;
    public GameObject[] wallTiles;
    public GameObject[] foodTiles;
    public GameObject exit;

    private List<Vector3> gridPositions = new List<Vector3>();

    // 壁、アイテムの数
    public int wallMinimum = 5, wallMaximum = 9, foodMinimum = 1, foodMaximum = 5;

    void BoardSetup() { // FloorとWallを設置
        for (int x = -1; x < colums + 1; x++) {
            for (int y = -1; y < rows + 1; y++) {
                GameObject toInstantiate;
                if (x == -1 || x == colums || y == -1 || y == rows) {
                    toInstantiate = outWallTiles[Random.Range(0, outWallTiles.Length)]; // Wallを設置
                }
                else {
                    toInstantiate = floorTiles[Random.Range(0, floorTiles.Length)]; // Floorを設置
                }

                Instantiate(toInstantiate, new Vector3(x, y, 0), Quaternion.identity);
            }
        }
    }

    void InitialiseList() {
        gridPositions.Clear();

        for (int x = 1; x < colums - 1; x++) {
            for (int y = 1; y < rows - 1; y++) {
                gridPositions.Add(new Vector3(x, y, 0)); // アイテムを生成するポジション
            }
        }
    }

    Vector3 RandomPosition() {
        int randomIndex = Random.Range(0, gridPositions.Count); // リストからランダムに数値を取得

        Vector3 randomPosition = gridPositions[randomIndex]; // 取得した数値のポジションをrandomPositionに代入

        gridPositions.RemoveAt(randomIndex); // 1度使ったポジションを削除、同じポジションに同じアイテムが配置されるのを防ぐ

        return randomPosition;
    }

    void LayoutobjectAtRandom(GameObject[] tileArray, int min, int max) {
        int objectCount = Random.Range(min, max + 1); // 生成するアイテムの数

        for (int i = 0; i < objectCount; i++) { 
            Vector3 randomPosition = RandomPosition();

            GameObject tileChoice = tileArray[Random.Range(0, tileArray.Length)];

            Instantiate(tileChoice, randomPosition, Quaternion.identity);
        }
    }

    public void SetupScene() {
        BoardSetup();
        InitialiseList();
        LayoutobjectAtRandom(wallTiles, wallMinimum, wallMaximum);
        LayoutobjectAtRandom(foodTiles, foodMinimum, foodMaximum);

        Instantiate(exit, new Vector3(colums-1, rows-1, 0), Quaternion.identity);
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
