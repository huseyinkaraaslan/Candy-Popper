using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    int roundedNumberX, roundedNumberY, distanceX, distanceY;
    GameObject firstChosenObject, secondChosenObject,tempCandy, candySelectionFrame;
    Touch finger;
    Vector3 fingerPosition,tempCandyPosition;

    void Start()
    {
        candySelectionFrame = GameObject.FindGameObjectWithTag("Candy Selection");
        candySelectionFrame.transform.position = new Vector2(10, 10);
    }

    void Update()
    {
        Control();
    }

    public void Control()
    {
        if (Input.touchCount > 0)
        {
            finger = Input.GetTouch(0);
            fingerPosition = Camera.main.ScreenToWorldPoint(new Vector3(finger.position.x, finger.position.y, 5));
            roundedNumberX = Mathf.RoundToInt(fingerPosition.x);
            roundedNumberY = Mathf.RoundToInt(fingerPosition.y);
            candySelectionFrame.transform.position = new Vector3(roundedNumberX, roundedNumberY, 5);


            if (firstChosenObject == null)
            {
                firstChosenObject = gameObject.GetComponent<CreateCandy>().candiesMatrix[roundedNumberX, roundedNumberY];
            }

            else
            {
                secondChosenObject = gameObject.GetComponent<CreateCandy>().candiesMatrix[roundedNumberX, roundedNumberY];

                if (firstChosenObject != secondChosenObject)
                {
                    distanceX = Mathf.Abs(Mathf.RoundToInt(firstChosenObject.transform.position.x - secondChosenObject.transform.position.x));
                    distanceY = Mathf.Abs(Mathf.RoundToInt(firstChosenObject.transform.position.y - secondChosenObject.transform.position.y));

                    if (distanceX + distanceY == 1)
                    {
                        if (distanceX == 1)
                        {
                            changePosition();
                            gameObject.GetComponent<CreateCandy>().candiesMatrix[Mathf.RoundToInt(firstChosenObject.transform.position.x), Mathf.RoundToInt(firstChosenObject.transform.position.y)] = secondChosenObject;
                            gameObject.GetComponent<CreateCandy>().candiesMatrix[Mathf.RoundToInt(secondChosenObject.transform.position.x), Mathf.RoundToInt(secondChosenObject.transform.position.y)] = firstChosenObject;
                            firstChosenObject = null;
                            secondChosenObject = null;
                        }

                        else if (distanceY == 1)
                        {
                            changePosition();
                            gameObject.GetComponent<CreateCandy>().candiesMatrix[Mathf.RoundToInt(firstChosenObject.transform.position.x), Mathf.RoundToInt(firstChosenObject.transform.position.y)] = secondChosenObject;
                            gameObject.GetComponent<CreateCandy>().candiesMatrix[Mathf.RoundToInt(secondChosenObject.transform.position.x), Mathf.RoundToInt(secondChosenObject.transform.position.y)] = firstChosenObject;
                            firstChosenObject = null;
                            secondChosenObject = null;
                        }
                    }

                    else
                    {
                        firstChosenObject = secondChosenObject;
                        secondChosenObject = null;
                    }
                }

                else
                {
                    secondChosenObject = null;
                }
            }
        }
    }

    public void changePosition()
    {
        tempCandyPosition = firstChosenObject.transform.position;
        firstChosenObject.transform.position = secondChosenObject.transform.position;
        secondChosenObject.transform.position = tempCandyPosition;

    }
}
