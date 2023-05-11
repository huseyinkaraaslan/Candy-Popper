using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    int roundedNumberX, roundedNumberY, distanceX, distanceY;
    public GameObject firstChosenObject, secondChosenObject, candySelectionFrame;
    Touch finger;
    Vector2 fingerPosition, firstChosenObjectTargetPos, secondChosenObjectTargetPos;
    public bool isBlowed, isTouched, isPositionChanging;

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
            isTouched = true;
            finger = Input.GetTouch(0);
            fingerPosition = Camera.main.ScreenToWorldPoint(new Vector2(finger.position.x, finger.position.y));
            roundedNumberX = Mathf.RoundToInt(fingerPosition.x);
            roundedNumberY = Mathf.RoundToInt(fingerPosition.y);
            candySelectionFrame.transform.position = new Vector3(roundedNumberX, roundedNumberY, 5);

            if (firstChosenObject == null)
            {
                firstChosenObject = CreateCandy.candiesMatrix[roundedNumberX, roundedNumberY];
            }
            else
            {
                secondChosenObject = CreateCandy.candiesMatrix[roundedNumberX, roundedNumberY];

                if (firstChosenObject != secondChosenObject)
                {
                    distanceX = Mathf.Abs((int)(firstChosenObject.transform.position.x - secondChosenObject.transform.position.x));
                    distanceY = Mathf.Abs((int)(firstChosenObject.transform.position.y - secondChosenObject.transform.position.y));

                    if (distanceX + distanceY == 1)
                    {
                        secondChosenObject = CreateCandy.candiesMatrix[roundedNumberX, roundedNumberY];
                        changePosition();
                        changeMatrixValues();
                        firstChosenObject = null;
                    }
                    else
                    {
                        firstChosenObject = secondChosenObject;
                    }
                }
                secondChosenObject = null;
            }
        }
    }

    public void changeMatrixValues()
    {
        CreateCandy.candiesMatrix[(int)firstChosenObject.transform.position.x, (int)firstChosenObject.transform.position.y] = firstChosenObject;
        CreateCandy.candiesMatrix[(int)secondChosenObject.transform.position.x, (int)secondChosenObject.transform.position.y] = secondChosenObject;
    }

    public void  changePosition()
    {
        firstChosenObjectTargetPos = secondChosenObject.transform.position;
        secondChosenObjectTargetPos = firstChosenObject.transform.position;

        firstChosenObject.transform.position = firstChosenObjectTargetPos;
        secondChosenObject.transform.position = secondChosenObjectTargetPos;
     
    }

}
