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
        candiesMatrix = new GameObject[6, 6];

        for (x = 0; x < 6; x++)
        {
            for (y = 0; y < 6; y++)
            {
                createCandies(x, y);
            }
        }
    }

    void Update()
    {
        transform.position = Vector2.Lerp(transform.position, new Vector2(0, -y), Time.deltaTime * 2);
        //checkMatrix();
    }

    public GameObject chooseCandy()
    {
        int randomNumber = Random.Range(0, candies.Length);
        return candies[randomNumber];
    }

    public void createCandies(int x,int y)
    {
        GameObject newCandy = Instantiate(chooseCandy(), new Vector2(x, y+6), Quaternion.identity);
        candiesMatrix[x, y] = newCandy;
        newCandy.transform.SetParent(candyParent);
    }

    void checkMatrix()
    {
        for (x = 0; x < 6; x++)
        {
            for (y = 0; y < 6; y++)
            {
                if(candiesMatrix[x, y] == null)
                {
                    createCandies(x, y);
                }
            }
        }
    }


}
