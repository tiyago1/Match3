using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GameManager : MonoBehaviour
{
    #region Constants

    public const float CELL_MARGIN_VALUE = 0.55f;
    public const float CELL_CENTER = 0.0f;
    public const float CELL_DOUBLE_FIRST_CENTER = -0.275f;
    public const float CELL_DOUBLE_SECOND_CENTER = 0.275f;

    #endregion // Constants

    #region Fields

    public GameObject CellPrefab;

    public int XValue;
    public int YValue;

    public List<Vector2> Coordinare;
    public List<GameObject> Elements;

    private float bigValueX;
    private float bigValueY;

    #endregion // Fields

    #region Unity Methods

    private void Start()
    {
        // initalize
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CellAlignCalculate(XValue);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            CellCreate(bigValueY, XValue, YValue);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
           
        }
    }

    #endregion // Unity Methods

    #region Private Methods

    private void CellCreate(float cellPositionY, int cellWidth, int cellHeight)
    {
        if ((cellWidth % 2) == 1)
        {
            float centerPosition = CELL_CENTER;
            float PositionY = cellPositionY + CELL_MARGIN_VALUE;

            centerPosition = CELL_CENTER;

            for (int x = 0; x < cellWidth / 2; x++)
            {
                centerPosition -= CELL_MARGIN_VALUE;

                for (int i = 0; i < cellHeight; i++)
                {
                    PositionY -= CELL_MARGIN_VALUE;
                    Vector3 position = new Vector3(centerPosition, PositionY, CELL_CENTER);
                    Instantiate(CellPrefab, position, Quaternion.identity);
                }

                PositionY = cellPositionY + CELL_MARGIN_VALUE;
            }

            centerPosition = CELL_CENTER;
            PositionY = cellPositionY + CELL_MARGIN_VALUE;

            for (int x = 0; x < cellWidth / 2; x++)
            {
                centerPosition += CELL_MARGIN_VALUE;

                for (int i = 0; i < cellHeight; i++)
                {
                    PositionY -= CELL_MARGIN_VALUE;
                    Vector3 position = new Vector3(centerPosition, PositionY, CELL_CENTER);
                    Instantiate(CellPrefab, position, Quaternion.identity);
                }

                PositionY = cellPositionY + CELL_MARGIN_VALUE;
            }
        }
        else if ((cellWidth % 2) == 0)
        {
            float centerPosition = 0.275f;
            float PositionY = cellPositionY + CELL_MARGIN_VALUE;

            centerPosition = CELL_DOUBLE_SECOND_CENTER;

            for (int x = 0; x < cellWidth / 2; x++)
            {
                centerPosition -= CELL_MARGIN_VALUE;

                for (int i = 0; i < cellHeight; i++)
                {
                    PositionY -= CELL_MARGIN_VALUE;
                    Vector3 position = new Vector3(centerPosition, PositionY, CELL_CENTER);
                    Instantiate(CellPrefab, position, Quaternion.identity);
                }

                PositionY = cellPositionY + CELL_MARGIN_VALUE;
            }

            centerPosition = CELL_DOUBLE_FIRST_CENTER;
            PositionY = cellPositionY + CELL_MARGIN_VALUE;

            for (int x = 0; x < cellWidth / 2; x++)
            {
                centerPosition += CELL_MARGIN_VALUE;

                for (int i = 0; i < cellHeight; i++)
                {
                    PositionY -= CELL_MARGIN_VALUE;
                    Vector3 position = new Vector3(centerPosition, PositionY, CELL_CENTER);
                    Instantiate(CellPrefab, position, Quaternion.identity);
                }

                PositionY = cellPositionY + CELL_MARGIN_VALUE;
            }
        }
    }

    private void CellAlignCalculate(int cellWidth)
    {
        float centerPoint;

        if ((cellWidth % 2) == 1)
        {
            centerPoint = 0.0f;
            int centerValue = (cellWidth / 2);
            Debug.Log(" Center Value : " + centerValue);

            for (int i = 0; i < centerValue; i++)
            {
                centerPoint += CELL_MARGIN_VALUE;
                Vector3 position = new Vector3(CELL_CENTER, centerPoint, CELL_CENTER);
                Coordinare.Add(position);
            }

            centerPoint = CELL_CENTER;

            for (int i = 0; i < centerValue; i++)
            {
                centerPoint += CELL_MARGIN_VALUE;
                Vector3 position = new Vector3(centerPoint, CELL_CENTER, CELL_CENTER);
                Coordinare.Add(position);
            }

            Coordinare.Add(Vector2.zero);
            centerPoint = CELL_CENTER;

            for (int i = 0; i < centerValue; i++)
            {
                centerPoint -= CELL_MARGIN_VALUE;
                Vector3 position = new Vector3(CELL_CENTER, centerPoint, CELL_CENTER);
                Coordinare.Add(position);
            }

            centerPoint = CELL_CENTER;

            for (int i = 0; i < centerValue; i++)
            {
                centerPoint -= CELL_MARGIN_VALUE;
                Vector3 position = new Vector3(centerPoint, CELL_CENTER, CELL_CENTER);
                Coordinare.Add(position);
            }
        }
        else
        {
            // Çift
            float VerticalPoint = CELL_DOUBLE_FIRST_CENTER;
            float HorizontalPoint = 0.0f;

            int centerValue = (cellWidth / 2);

            for (int i = 0; i < centerValue; i++)
            {
                HorizontalPoint += CELL_MARGIN_VALUE;
                Vector3 position = new Vector3(CELL_DOUBLE_SECOND_CENTER, HorizontalPoint - CELL_MARGIN_VALUE, CELL_CENTER);
                GameObject element = Instantiate(CellPrefab, position, Quaternion.identity) as GameObject;
                Coordinare.Add(position);
            }

            VerticalPoint = CELL_DOUBLE_FIRST_CENTER;

            for (int i = 0; i < centerValue; i++)
            {
                VerticalPoint += CELL_MARGIN_VALUE;
                Vector3 position = new Vector3(VerticalPoint, CELL_CENTER, CELL_CENTER);
                GameObject element = Instantiate(CellPrefab, position, Quaternion.identity) as GameObject;
                Coordinare.Add(position);
            }

            HorizontalPoint = CELL_CENTER;

            for (int i = 0; i < centerValue; i++)
            {
                HorizontalPoint -= CELL_MARGIN_VALUE;
                Vector3 position = new Vector3(CELL_DOUBLE_SECOND_CENTER, HorizontalPoint, CELL_CENTER);
                GameObject element = Instantiate(CellPrefab, position, Quaternion.identity) as GameObject;
                Coordinare.Add(position);
            }

            VerticalPoint = CELL_DOUBLE_SECOND_CENTER;

            for (int i = 0; i < centerValue; i++)
            {
                VerticalPoint -= CELL_MARGIN_VALUE;
                Vector3 position = new Vector3(VerticalPoint, CELL_CENTER, CELL_CENTER);
                GameObject element = Instantiate(CellPrefab, position, Quaternion.identity) as GameObject;
                Coordinare.Add(position);
            }
        }

        // list vector2 
        //foreach (GameObject item in Elements)
        //{
            //Coordinare.Add(new Vector2(item.transform.position.x,item.transform.position.y));
        //}

        Vector2[] descX = Coordinare.OrderByDescending(it => it.x).Reverse().ToArray();
        Vector2[] descY = Coordinare.OrderByDescending(it => it.y).ToArray();

        Debug.Log(" x : " + descX[0].x + " y  : " + descY[0].y);

        bigValueX = descX[0].x;
        bigValueY = descY[0].y;
    }

    #endregion // Private Methods
}
/*
    x 0.55f right and left magnitude.

    9*6

    -2.2f , 1.0f  Left Top Corner 
    -2.2f , -1.75f Left Bottom Corner
    2.2f , 1.0f Right Top Corner 
    2.2f , -1.75f Left Bottom Corner


    Bana bir float türünde bir sayı verilecek. 
    
    Bir x pozisyonun değeri 


    Max Pozisyon 

    y value -22.2  22.2
    x value -22.2  22.2


    0.275 width cift sayı olduğu zaman center positon vector3.zero ile değilde 0.275f / -0.275f değerlerinin arasında bir değer arasında değer alıcaktır. 
   
*/
