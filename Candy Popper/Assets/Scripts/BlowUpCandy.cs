using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowUpCandy : MonoBehaviour
{
    GameObject firstChosenObject;
    GameObject onTheRightCandy, onTheLeftCandy;
    List<GameObject> candies;

    bool firstChosenObjectIsAdded;

    void Start()
    {
        candies = new List<GameObject>();
        firstChosenObjectIsAdded = false;
    }

    void Update()
    {        
        checkPositionX();

       
        
    }

    void checkPositionX()
    {
        if (gameObject.GetComponent<PlayerControl>().isTouched)
        {
            firstChosenObject = gameObject.GetComponent<PlayerControl>().firstChosenObject;

            // add the first chosen object to the list
            if (!firstChosenObjectIsAdded)
            {
                candies.Add(firstChosenObject);
                firstChosenObjectIsAdded = true;
            }

            // check to the left
            for (int checkLeft = (int)firstChosenObject.transform.position.x - 1; checkLeft >= 0; checkLeft--)
            {
                if(firstChosenObject.transform.position.x != 0)
                {
                    onTheLeftCandy = CreateCandy.candiesMatrix[checkLeft, (int)firstChosenObject.transform.position.y];
                    if (firstChosenObject.name == onTheLeftCandy.name)
                    {
                        candies.Add(onTheLeftCandy);
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

            // check to the right
            for (int checkRight = (int)firstChosenObject.transform.position.x + 1; checkRight <= 5; checkRight++)
            {
                if(firstChosenObject.transform.position.x != 5)
                {
                    onTheRightCandy = CreateCandy.candiesMatrix[checkRight, (int)firstChosenObject.transform.position.y];
                    if (firstChosenObject.name == onTheRightCandy.name)
                    {
                        candies.Add(onTheRightCandy);
                        if (onTheRightCandy.transform.position.x == 5)
                        {
                            break;
                        }
                    }
                    else
                    {
                        checkRight = 5;
                    }
                }
                else
                {
                    break;
                }
                
            }

            if (candies.Count >= 3)
            {
                for (int i = 0; i < candies.Count; i++)
                {
                    Destroy(candies[i]);
                    candies.RemoveAt(i);
                }
            }
            else
            {
                for (int i = 0; i < candies.Count; i++)
                {
                    Destroy(candies[i]);
                    candies.RemoveAt(i);
                }
            }

        }
    }

    void checkPositionY()
    {

    }
}
