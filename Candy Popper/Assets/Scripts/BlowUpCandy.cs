using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowUpCandy : MonoBehaviour
{
    GameObject firstChosenObject, secondObject, thirdObject;
    GameObject onTheRightCandy, onTheLeftCandy;
    List<GameObject> candies;

    int checkLeft,checkRight,listCount;
    bool isAdded;

    void Start()
    {
        candies = new List<GameObject>();
        isAdded = false;
    }

    // Update is called once per frame
    void Update()
    {
        firstChosenObject = gameObject.GetComponent<PlayerControl>().firstChosenObject;
        checkPositionX();
    }

    public void checkPositionX()
    {
        if (gameObject.GetComponent<PlayerControl>().isTouched)
        {
            checkLeft = (int)firstChosenObject.transform.position.x;
            checkRight = (int)firstChosenObject.transform.position.x;

            for(checkLeft = (int)firstChosenObject.transform.position.x; checkLeft >= 0; checkLeft--)
            {           
                if(!(isAdded))
                {
                    candies.Add(firstChosenObject);
                    listCount++;
                }

                if(checkLeft > 0)
                {
                    onTheLeftCandy = CreateCandy.candiesMatrix[checkLeft - 1, (int)firstChosenObject.transform.position.y];
                    if (firstChosenObject.name == onTheLeftCandy.name)
                    {
                        candies.Add(onTheLeftCandy);
                        listCount++;
                    }
                }
                
            }

            for(checkRight = (int)firstChosenObject.transform.position.x; checkRight <= 5; checkRight++)
            {
                if (!(isAdded))
                {
                    candies.Add(firstChosenObject);
                    listCount++;
                }

                if(checkRight < 5)
                {
                    onTheRightCandy = CreateCandy.candiesMatrix[checkRight + 1, (int)firstChosenObject.transform.position.y];
                    if (firstChosenObject.name == onTheRightCandy.name)
                    {
                        candies.Add(onTheRightCandy);
                        listCount++;
                    }
                }
                              
            }

            for(int i=0; i< candies.Count; i++)
            {
                candies.RemoveAt(i);
            }
            

        }
    }
}
