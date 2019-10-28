using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject cubePrefab;
    Vector3 cubePosition; 
    public static GameObject ActiveCube;
    // Start is called before the first frame update
    int AirplaneXPos, AirplaneYPos;
    GameObject[,] cubeGrid; //2d array, a collection of game objects
    int gridXmax, gridYmax;
    bool airplaneActive;
    int spinX, spinY, spinZ;

    void Start()
    {
       
        gridXmax = 16; //make variables if you are repeating numbers that make it a pain to go in a individually retype
        gridYmax = 9;

        cubeGrid = new GameObject[gridXmax, gridYmax]; //keep track of each cube you made by putting them all in an array


        for (int y = 0; y < gridYmax; y++)
        {
            for (int x = 0; x < gridXmax; x++)
            {
                cubePosition = new Vector3(x * 2, y * 2, 0);
                cubeGrid[x, y] = Instantiate(cubePrefab, cubePosition, Quaternion.identity);//make cube, tell grid to store it in array
                cubeGrid[x, y].GetComponent<CubeController>().myX =  x;//the cubegrid x,y specifies where the cube is in the array, referencing the one that already exists
                cubeGrid[x, y].GetComponent<CubeController>().myY = y;
            }
        }
        AirplaneXPos = 0;
        AirplaneYPos = 8;
        cubeGrid[AirplaneXPos, AirplaneYPos].GetComponent<Renderer>().material.color = Color.red;
        airplaneActive = false;
    }

    public void ClickProcess(GameObject clickedCube, int x, int y)
    {
        if (x == AirplaneXPos && y == AirplaneYPos)
        {
            if (airplaneActive)
            {
                //deactivate the active plane, put this first to make code clearer to read without no
                airplaneActive = false;
                clickedCube.transform.localScale /= (1.5f);
            }
            else
            {
                airplaneActive = true;
                clickedCube.transform.localScale *= (1.5f);
            }
        }
        //clicking on the white cubes and not the plane
        else
        {
            if (airplaneActive)
            {
                cubeGrid[AirplaneXPos, AirplaneYPos].GetComponent<Renderer>().material.color = Color.white;
                cubeGrid[AirplaneXPos, AirplaneYPos].transform.localScale /= (1.5f);

                AirplaneXPos = x;
                AirplaneYPos = y;
                cubeGrid[x, y].GetComponent<Renderer>().material.color = Color.red;
                cubeGrid[AirplaneXPos, AirplaneYPos].transform.localScale *= (1.5f);
            }

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    
   
}
