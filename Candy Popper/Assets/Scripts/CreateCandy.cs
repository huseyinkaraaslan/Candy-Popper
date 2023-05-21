using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCandy : MonoBehaviour
{
    int x, y;
    public GameObject[] candies;
    public static GameObject[,] candiesMatrix;
    public Transform candyParent;

    void Start()
    {       
        candiesMatrix = new GameObject[7, 7];

        // Create candies for each position in the matrix
        for (x = 0; x < 7; x++)
        {
            for (y = 0; y < 7; y++)
            {
                createCandies(x, y);
            }
        }
    }

    void Update()
    {
        checkMatrix();

        // Move candies to their target positions
        for (x = 0; x < 7; x++)
        {
            for (y = 0; y < 7; y++)
            {
                if (candiesMatrix[x, y] != null)
                {
                    GameObject candy = candiesMatrix[x, y];
                    Vector2 targetPosition = new Vector2(x, y);
                    candy.transform.position = Vector2.Lerp(candy.transform.position, targetPosition, Time.deltaTime * 2);
                }
            }
        }
    }

    public GameObject chooseCandy()
    {
        int randomNumber = Random.Range(0, candies.Length);
        return candies[randomNumber];
    }

    public void createCandies(int x,int y)
    {
        GameObject newCandy = Instantiate(chooseCandy(), new Vector2(x, y+7), Quaternion.identity);
        candiesMatrix[x, y] = newCandy;
        newCandy.transform.SetParent(candyParent);
    }

    // Check the matrix for null positions and create candies if necessary
    void checkMatrix()
    {
        for (x = 0; x < 7; x++)
        {
            for (y = 0; y < 7; y++)
            {
                if(candiesMatrix[x, y] == null)
                {
                    createCandies(x, y);
                }
            }
        }
    }
}
