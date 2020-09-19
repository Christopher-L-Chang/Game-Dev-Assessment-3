using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    int[,] levelMap =
        {
        {1,2,2,2,2,2,2,2,2,2,2,2,2,7},
        {2,5,5,5,5,5,5,5,5,5,5,5,5,4},
        {2,5,3,4,4,3,5,3,4,4,4,3,5,4},
        {2,6,4,0,0,4,5,4,0,0,0,4,5,4},
        {2,5,3,4,4,3,5,3,4,4,4,3,5,3},
        {2,5,5,5,5,5,5,5,5,5,5,5,5,5},
        {2,5,3,4,4,3,5,3,3,5,3,4,4,4},
        {2,5,3,4,4,3,5,4,4,5,3,4,4,3},
        {2,5,5,5,5,5,5,4,4,5,5,5,5,4},
        {1,2,2,2,2,1,5,4,3,4,4,3,0,4},
        {0,0,0,0,0,2,5,4,3,4,4,3,0,3},
        {0,0,0,0,0,2,5,4,4,0,0,0,0,0},
        {0,0,0,0,0,2,5,4,4,0,3,4,4,0},
        {2,2,2,2,2,1,5,3,3,0,4,0,0,0},
        {0,0,0,0,0,0,5,0,0,0,4,0,0,0},
        };

    public GameObject empty;
    public GameObject outCorner;
    public GameObject outWall;
    public GameObject inCorner;
    public GameObject inWall;
    public GameObject pellet;
    public GameObject powerPellet;
    public GameObject tPiece;


    void Awake()
    {
        for (int i = 0; i < levelMap.GetLength(0); i++)
        {
            for (int j = 0; j < levelMap.GetLength(1); j++)
            {
                if (levelMap[i, j] == 0)
                {
                    Debug.Log(i + " " + j + " at 0");
                    Instantiate(empty, new Vector2 (j, i), Quaternion.identity);
                }
                else if (levelMap[i, j] == 1)
                {
                    Debug.Log(i + " " + j + " at 1");
                    Instantiate(empty, new Vector2(j, i), Quaternion.identity);
                }
                else if (levelMap[i, j] == 2)
                {
                    Debug.Log(i + " " + j + " at 2");
                    Instantiate(empty, new Vector2(j, i), Quaternion.identity);
                }
                else if (levelMap[i, j] == 3)
                {
                    Debug.Log(i + " " + j + " at 3");
                    Instantiate(empty, new Vector2(j, i), Quaternion.identity);
                }
                else if (levelMap[i, j] == 4)
                {
                    Debug.Log(i + " " + j + " at 4");
                    Instantiate(empty, new Vector2(j, i), Quaternion.identity);
                }
                else if (levelMap[i, j] == 5)
                {
                    Debug.Log(i + " " + j + " at 5");
                    Instantiate(empty, new Vector2(j, i), Quaternion.identity);
                }
                else if (levelMap[i, j] == 6)
                {
                    Debug.Log(i + " " + j + " at 6");
                    Instantiate(empty, new Vector2(j, i), Quaternion.identity);
                }
                else if (levelMap[i, j] == 7)
                {
                    Debug.Log(i + " " + j + " at 7");
                    Instantiate(empty, new Vector2(j, i), Quaternion.identity);
                }
            }
        }
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
