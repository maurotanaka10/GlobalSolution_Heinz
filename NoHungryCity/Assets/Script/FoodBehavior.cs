using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBehavior : MonoBehaviour
{
    [SerializeField] private GameObject[] foodBox;
    [SerializeField] private GameObject restockedPoint;
    [SerializeField] private float numberOfBox = 6;
    public bool noFood;

    private void Update()
    {
        if(numberOfBox == 0)
        {
            noFood = true;
            restockedPoint.SetActive(true);
        }
        else
        {
            noFood = false;
        }
    }

    public void DeliveryFood()
    {
        numberOfBox--;

        if(numberOfBox == 5)
        {
            foodBox[5].SetActive(false);
        }
        else if(numberOfBox == 4)
        {
            foodBox[4].SetActive(false);
        }
        else if (numberOfBox == 3)
        {
            foodBox[3].SetActive(false);
        }
        else if (numberOfBox == 2)
        {
            foodBox[2].SetActive(false);
        }
        else if (numberOfBox == 1)
        {
            foodBox[1].SetActive(false);
        }
        else if (numberOfBox == 0)
        {
            foodBox[0].SetActive(false);
        }
    }

    public void Restocked()
    {
        numberOfBox = 6;

        foodBox[0].SetActive(true);
        foodBox[1].SetActive(true);
        foodBox[2].SetActive(true);
        foodBox[3].SetActive(true);
        foodBox[4].SetActive(true);
        foodBox[5].SetActive(true);
    }
}
