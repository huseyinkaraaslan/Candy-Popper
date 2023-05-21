using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowUpCandy : MonoBehaviour
{
    GameObject onTheRightCandy, onTheLeftCandy, onTheUpCandy, onTheDownCandy;
    List<GameObject> candiesX,candiesY;
    public int score;
    void Start()
    {
        candiesX = new List<GameObject>();
        candiesY = new List<GameObject>();
    }

    void Update()
    {
        if (gameObject.GetComponent<PlayerControl>().isTouched)
        {
            // Iterate through all candies positions and find candies to be blown up
            for (int x = 0; x < 7; x++)
            {
                for (int y = 0; y < 7; y++)
                {
                    checkPositionX(CreateCandy.candiesMatrix[x, y]); 
                    checkPositionY(CreateCandy.candiesMatrix[x, y]); 
                }
            }
        }           
    }

    void checkPositionX(GameObject candy)
    {
        candiesX.Clear();   
        candiesX.Add(candy);

        // Check candies to the left
        for (int checkLeft = (int)candy.transform.position.x - 1; checkLeft >= 0; checkLeft--)
        {
            if(candy.transform.position.x != 0)
            {
                onTheLeftCandy = CreateCandy.candiesMatrix[checkLeft, (int)candy.transform.position.y];
                // If the candy is of the same type, add it to the blow up list
                if (candy.name == onTheLeftCandy.name)
                {
                    candiesX.Add(onTheLeftCandy);
                    if(onTheLeftCandy.transform.position.x == 0)
                    {
                        break;
                    }
                }
                else
                {
                    checkLeft = 0;
                }
            }
            else
            {
                break;
            }                
        }

        // Check candies to the right
        for (int checkRight = (int)candy.transform.position.x + 1; checkRight <= 6; checkRight++)
        {
            if(candy.transform.position.x != 6)
            {
                onTheRightCandy = CreateCandy.candiesMatrix[checkRight, (int)candy.transform.position.y];
                // If the candy is of the same type, add it to the blow up list
                if (candy.name == onTheRightCandy.name)
                {
                    candiesX.Add(onTheRightCandy);
                    if (onTheRightCandy.transform.position.x == 6)
                    {
                        break;
                    }
                }
                else
                {
                    checkRight = 6;
                }
            }
            else
            {
                break;
            }                
        }
        clearCandiesList(candiesX);       
    }

    void checkPositionY(GameObject candy)
    {
        candiesY.Clear();
        candiesY.Add(candy);

        // Check candies below
        for (int checkDown = (int)candy.transform.position.y - 1; checkDown >= 0; checkDown--)
        {
            if (candy.transform.position.y != 0)
            {
                onTheDownCandy = CreateCandy.candiesMatrix[(int)candy.transform.position.x, checkDown];
                // If the candy is of the same type, add it to the blow up list
                if (candy.name == onTheDownCandy.name)
                {
                    candiesY.Add(onTheDownCandy);
                    if (onTheDownCandy.transform.position.y == 0)
                    {
                        break;
                    }
                }
                else
                {
                    checkDown = 0;
                }
            }
            else
            {
                break;
            }
        }

        // Check candies above
        for (int checkUp = (int)candy.transform.position.y + 1; checkUp <= 6; checkUp++)
        {
            if (candy.transform.position.y != 6)
            {
                onTheUpCandy = CreateCandy.candiesMatrix[(int)candy.transform.position.x, checkUp];
                // If the candy is of the same type, add it to the blow up list
                if (candy.name == onTheUpCandy.name)
                {
                    candiesY.Add(onTheUpCandy);
                    if (onTheUpCandy.transform.position.y == 6)
                    {
                        break;
                    }
                }
                else
                {
                    checkUp = 6;
                }
            }
            else
            {
                break;
            }
        }
        clearCandiesList(candiesY);
    }

    void clearCandiesList(List<GameObject> candies)
    {
        if(candies.Count >= 3)
        {
            for(int i=0; i<candies.Count; i++)
            {
                switch (candies.Count)
                {
                    case 3:
                        score += 7;
                        break;
                    case 4:
                        score += 11;
                        break;
                    case 5: 
                        score += 15;
                        break;
                    case 6: 
                        score += 19;
                        break;
                    case 7:
                        score += 23;
                        break;
                }
                CreateCandy.candiesMatrix[(int)candies[i].transform.position.x, (int)candies[i].transform.position.y] = null;
                Destroy(candies[i]);
            }
        }
    }
}
