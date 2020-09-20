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
        float left = 90;
        float right = -90;
        float flip = 180;


        for (int i = 0; i < levelMap.GetLength(0); i++)
        {
            for (int j = 0; j < levelMap.GetLength(1); j++)
            {
                if (levelMap[i, j] == 0)
                {
                    Debug.Log(j + " " + i + " at 0");
                    Instantiate(empty, new Vector2 (j, i), Quaternion.identity);
                }
                else if (levelMap[i, j] == 1)
                {
                    Debug.Log(j + " " + i + " at 1");
                    if (i - 1 >= 0)
                    {
                        if (levelMap[i - 1, j] == 2)
                        {
                            if (j - 1 >= 0)
                            {
                                if (levelMap[i, j - 1] == 2)
                                {
                                    Instantiate(outCorner, new Vector2(j, i), Quaternion.Euler(0, 0, right));
                                }
                                else
                                {
                                    Instantiate(outCorner, new Vector2(j, i), Quaternion.Euler(0, 0, flip));
                                }
                            }
                            else
                            {
                                Instantiate(outCorner, new Vector2(j, i), Quaternion.identity);
                            }
                        } 
                        else
                        {
                            if (j - 1 >= 0)
                            {
                                if (levelMap[i, j - 1] == 2)
                                {
                                    Instantiate(outCorner, new Vector2(j, i), Quaternion.Euler(0, 0, flip));
                                }
                                else
                                {
                                    Instantiate(outCorner, new Vector2(j, i), Quaternion.Euler(0, 0, left));
                                }
                            }
                            else
                            {
                                Instantiate(outCorner, new Vector2(j, i), Quaternion.identity);
                            }
                        }
                    }
                    else
                    {
                        if (j-1 < 0)
                        {
                            Instantiate(outCorner, new Vector2(j, i), Quaternion.Euler(0, 0, left));
                        }
                        else
                        {
                            Instantiate(outCorner, new Vector2(j, i), Quaternion.identity);
                        }
                    }
                }
                else if (levelMap[i, j] == 2)
                {
                    Debug.Log(j + " " + i + " at 2");

                    if (i - 1 >= 0)
                    {
                        if (levelMap[i - 1, j] == 1 || levelMap[i - 1, j] == 2)
                        {
                            Instantiate(outWall, new Vector2(j, i), Quaternion.Euler(0, 0, left));
                        }
                        else
                        {
                            Instantiate(outWall, new Vector2(j, i), Quaternion.identity);
                        }
                    }
                    else
                    {
                        Instantiate(outWall, new Vector2(j, i), Quaternion.Euler(0, 0, flip));
                    }
                    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                    /*
                    if (i - 1 < 0)
                    {
                        if (j - 1 < 0)
                        {
                            Instantiate(outWall, new Vector2(j, i), Quaternion.Euler(1, 1, right));
                        }
                        else
                        {
                            Instantiate(outWall, new Vector2(j, i), Quaternion.Euler(0, 0, flip));
                        }
                    }
                    else if (i - 1 >= 0)
                    {
                        if (levelMap[i - 1, j] == 1 || levelMap[i - 1, j] == 2)
                        {
                            if (j - 1 >= 0)
                            {
                                if (levelMap[i, j - 1] == 1 || levelMap[i, j - 1] == 2)
                                {
                                    Instantiate(outWall, new Vector2(j, i), Quaternion.Euler(0, 0, right));
                                }
                                else
                                {
                                    Instantiate(outWall, new Vector2(j, i), Quaternion.Euler(0, 0, right));
                                }
                            }
                            else
                            {
                                Instantiate(outWall, new Vector2(j, i), Quaternion.Euler(0, 0, left));
                            }
                        }
                        else
                        {
                            Instantiate(outWall, new Vector2(j, i), Quaternion.Euler(0, 0, flip));
                        }
                    }
                    else
                    {
                        Instantiate(outWall, new Vector2(j, i), Quaternion.identity);
                    }
                    */
                }
                else if (levelMap[i, j] == 3)
                {
                    Debug.Log(j + " " + i + " at 3");

                    if (i - 1 >= 0)
                    {
                        if (levelMap[i - 1, j] == 4 || levelMap[i - 1, j] == 3)
                        {
                            if (j - 1 >= 0)
                            {
                                if (levelMap[i, j - 1] == 4 || levelMap[i, j - 1] == 3)
                                {
                                    if (j + 1 < levelMap.GetLength(1))
                                    {
                                        if (levelMap[i, j + 1] == 4 || levelMap[i, j + 1] == 3)
                                        {
                                            if (levelMap[i + 1, j] == 3)
                                            {
                                                Instantiate(inCorner, new Vector2(j, i), Quaternion.identity);
                                            }
                                            else
                                            {
                                                Instantiate(inCorner, new Vector2(j, i), Quaternion.Euler(0, 0, left));
                                                
                                            }
                                        }
                                        else
                                        {
                                            Instantiate(inCorner, new Vector2(j, i), Quaternion.Euler(0, 0, right));
                                        }
                                    }
                                    else
                                    {
                                        if (levelMap[i + 1, j] == 5)
                                        {
                                            Instantiate(inCorner, new Vector2(j, i), Quaternion.Euler(0, 0, right));
                                        }
                                        else
                                        {
                                            Instantiate(inCorner, new Vector2(j, i), Quaternion.Euler(0, 0, flip));
                                        }
                                        
                                    }
                                    
                                }
                                else
                                {
                                    Instantiate(inCorner, new Vector2(j, i), Quaternion.identity);
                                }
                            }
                            else
                            {
                                Instantiate(inCorner, new Vector2(j, i), Quaternion.identity);
                            }
                        }
                        else
                        {
                            if (j - 1 >= 0)
                            {
                                if (levelMap[i, j - 1] == 4 || levelMap[i, j - 1] == 3)
                                {
                                    Instantiate(inCorner, new Vector2(j, i), Quaternion.Euler(0, 0, flip));
                                }
                                else
                                {
                                    Instantiate(inCorner, new Vector2(j, i), Quaternion.Euler(0, 0, left));
                                }
                            }
                            else
                            {
                                Instantiate(inCorner, new Vector2(j, i), Quaternion.identity);
                            }
                        }
                    }
                }
                else if (levelMap[i, j] == 4)
                {
                    Debug.Log(j + " " + i + " at 4");
                    if (i - 1 >= 0)
                    {
                        if (levelMap[i - 1, j] == 3 || levelMap[i - 1, j] == 4 || levelMap[i - 1, j] == 7)
                        {
                            if (i + 1 < levelMap.GetLength(0))
                            {
                                if (levelMap[i+1, j] == 3 || levelMap[i+1, j] == 4)
                                {
                                    if (j - 1 >= 0)
                                    {
                                        if (levelMap[i, j - 1] == 5 || levelMap[i, j -1] == 6)
                                        {
                                            Instantiate(inWall, new Vector2(j, i), Quaternion.Euler(0, 0, left));
                                        }
                                        else if (j + 1 < levelMap.GetLength(1))
                                        {
                                            if (levelMap[i, j + 1] == 0 && levelMap[i, j - 1] == 0)
                                            {
                                                Instantiate(inWall, new Vector2(j, i), Quaternion.Euler(0, 0, left));
                                            }
                                            else if (levelMap[i, j + 1] == 5 || levelMap[i, j + 1] == 6 || levelMap[i, j + 1] == 0)
                                            {
                                                Instantiate(inWall, new Vector2(j, i), Quaternion.Euler(0, 0, right));
                                            }
                                        }
                                        else if (levelMap[i, j - 1] == 0)
                                        {
                                            Instantiate(inWall, new Vector2(j, i), Quaternion.Euler(0, 0, left));
                                        }
                                        else
                                        {
                                            Instantiate(inWall, new Vector2(j, i), Quaternion.Euler(0, 0, right));
                                        }
                                    }
                                }
                                else if (levelMap[i - 1, j] == 3 || levelMap[i - 1, j] == 4)
                                {
                                    Instantiate(inWall, new Vector2(j, i), Quaternion.identity);
                                }
                                else if (j + 1 < levelMap.GetLength(1))
                                {
                                    if (levelMap[i, j + 1] == 5 || levelMap[i, j + 1] == 6 || levelMap[i, j + 1] == 0)
                                    {
                                        Instantiate(inWall, new Vector2(j, i), Quaternion.Euler(0, 0, right));
                                    } 
                                    else
                                    {
                                        Instantiate(inWall, new Vector2(j, i), Quaternion.identity);
                                    }
                                }
                                else
                                {
                                    Instantiate(inWall, new Vector2(j, i), Quaternion.Euler(0, 0, left));
                                }
                            }
                            else
                            {
                                Instantiate(inWall, new Vector2(j, i), Quaternion.Euler(0, 0, left));
                            }
                        }
                        else
                        {
                            if (levelMap[i - 1, j] == 5 || levelMap[i - 1, j] == 6)
                            {
                                Instantiate(inWall, new Vector2(j, i), Quaternion.Euler(0, 0, flip));
                            }
                            else
                            {
                                //stff
                                if (i + 1 < levelMap.GetLength(0))
                                {
                                    if (levelMap[i - 1, j] == 0 && levelMap[i + 1, j] == 0)
                                    {
                                        Instantiate(inWall, new Vector2(j, i), Quaternion.Euler(0, 0, flip));
                                    }
                                    else
                                    {
                                        Instantiate(inWall, new Vector2(j, i), Quaternion.identity);
                                    }
                                }
                                else
                                {
                                    Instantiate(inWall, new Vector2(j, i), Quaternion.identity);
                                }
                                
                            }
                        }
                    }
                    else
                    {
                        Instantiate(inWall, new Vector2(j, i), Quaternion.Euler(0, 0, flip));
                    }
                    /*
                    if (i - 1 < 0)
                    {
                        if (j - 1 < 0)
                        {
                            Instantiate(inWall, new Vector2(j, i), Quaternion.Euler(1, 1, right));
                        }
                        else
                        {
                            Instantiate(inWall, new Vector2(j, i), Quaternion.Euler(0, 0, flip));
                        }
                    }
                    else if (i - 1 >= 0)
                    {
                        if (levelMap[i - 1, j] == 3 || levelMap[i - 1, j] == 4)
                        {
                            if (j - 1 >= 0)
                            {
                                if (levelMap[i, j - 1] == 3 || levelMap[i, j - 1] == 4)
                                {
                                    Instantiate(inWall, new Vector2(j, i), Quaternion.Euler(0, 0, right));
                                }
                                else
                                {
                                    Instantiate(inWall, new Vector2(j, i), Quaternion.Euler(0, 0, left));
                                }
                            }
                            else
                            {
                                Instantiate(inWall, new Vector2(j, i), Quaternion.Euler(0, 0, left));
                            }
                        }
                        else
                        {
                            Instantiate(inWall, new Vector2(j, i), Quaternion.Euler(0, 0, flip));
                        }
                    }
                    else
                    {
                        Instantiate(inWall, new Vector2(j, i), Quaternion.identity);
                    }
                    */
                }
                else if (levelMap[i, j] == 5)
                {
                    Debug.Log(j + " " + i + " at 5");
                    Instantiate(pellet, new Vector2(j, i), Quaternion.identity);
                }
                else if (levelMap[i, j] == 6)
                {
                    Debug.Log(j + " " + i + " at 6");
                    Instantiate(powerPellet, new Vector2(j, i), Quaternion.identity);
                }
                else if (levelMap[i, j] == 7)
                {
                    Debug.Log(j + " " + i + " at 7");
                    Instantiate(tPiece, new Vector2(j, i), Quaternion.identity);
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
