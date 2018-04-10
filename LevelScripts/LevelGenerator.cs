using UnityEngine;
using System;
using System.Collections.Generic;   
using Random = UnityEngine.Random;




public class LevelGenerator : MonoBehaviour {
    private struct CellUnit
    {
        public Vector3 position;
        public bool isFloor;

        public CellUnit(Vector3 location, bool floor) {
            position = location;
            isFloor = floor;
        }
    }



    private CellUnit[,] level;
    public GameObject[] wallTiles;                                  //Array of wall prefabs.
    public GameObject[] floorTiles;                                  //Array of food prefabs.
    public GameObject player;
    public GameObject[] enemy;
    private Transform boardList;
    private Transform enemyList;
    private List<HashSet<CellUnit>> caverns;

    //Clears Initialises a new level                                                              
    public void InitialiseLevel(int x, int y) { 
        //Clear our list gridPositions.
        level = new CellUnit[x, y];
        //Build the Array with CellUnits
        InitializeArray();
        //Play the Game of Life
        for(int i = 0; i < 7; i++)
        {
            TheGameofLife();
        }
        buildLevel();
    }

    private void buildLevel() {
        {
            //Instantiate Board and set boardHolder to its transform.
            boardList = new GameObject("Board").transform;
            enemyList = new GameObject("Enemies").transform;

            bool flag = true;
            int enemyCount = 1;
            for (int i = 0; i < level.GetLength(0); i++)
            {
                for (int j = 0; j < level.GetLength(1); j++)
                {
                    //Choose a random tile from our array of floor tile prefabs and prepare to instantiate it.
                    GameObject toInstantiate = (level[i, j].isFloor) ? 
                        floorTiles[Random.Range(0, floorTiles.Length)] : wallTiles[Random.Range(0, wallTiles.Length)];

                    //Insert the player
                    if (flag && i > 3 && level[i, j].isFloor) {
                        player = (GameObject)Instantiate(player, new Vector3(i, j, 0f), Quaternion.identity);
                        flag = false;
                    }//Insert the enemies
                    else if (probability(3) && level[i, j].isFloor)
                    {
                        GameObject enemyInstance = (GameObject)Instantiate(enemy[0], new Vector3(i, j, 0f), Quaternion.identity);
                        enemyInstance.transform.SetParent(enemyList);
                    }
                    //Instantiate the GameObject, cast it to GameObject.
                    GameObject boardInstance = (GameObject)Instantiate(toInstantiate, new Vector3(i, j, 0f), Quaternion.identity);
                    //This is just organizational to avoid cluttering hierarchy.
                    boardInstance.transform.SetParent(boardList); 
                }
            }
        }
    }

    //Plays the Game of life i.e. we generate new level patterns
    private void TheGameofLife() {
        for (int i = 1; i < level.GetLength(0) - 1; i++)
        {
            for (int j = 1; j < level.GetLength(1) - 1; j++)
            {
                    level[i, j].isFloor = GetNeighbors(i, j);
            }
        }
    }

    //Game of life rules, 4-5 algorithm, returns true if tile should stay a floor, false if it should become a wall
    private bool GetNeighbors(int x, int y) {
        int wallCount = 0;
        for (int i = x - 1; i < x + 2; i++) {
            for (int j = y - 1; j < y + 2; j++)
            {
                wallCount += (level[i,j].isFloor) ? 0 : 1;
            }
        }
        return (level[x, y].isFloor) ? (wallCount < 5) : (wallCount < 4);
    }

    //Initializes the level array
    private void InitializeArray()
    {
        for (int i = 0; i < level.GetLength(0); i++)
        {
            for (int j = 0; j < level.GetLength(1); j++)
            {
                if (i == 0 || i == level.GetLength(0) - 1|| j == 0 || j == level.GetLength(1) - 1) {
                    level[i, j] = new CellUnit(new Vector3(i, j, 0f), false);
                }
                else {
                    level[i, j] = new CellUnit(new Vector3(i, j, 0f), probability(62.0));
                }
            }
        }
    }

    //Create give a proportional chance for something to occur
    private static bool probability(double percentage) {
        return (percentage/100.0 >= Random.value);
    }
};
