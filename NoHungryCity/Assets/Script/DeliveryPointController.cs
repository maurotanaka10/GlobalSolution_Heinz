using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryPointController : MonoBehaviour
{
    private GameManager gameManager;

    [SerializeField] private GameObject[] deliveryPoint;
    [SerializeField] private GameObject restockedPoint;

    private int nextLocationDelivery;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void ConclusionDelivery()
    {
        if(GameObject.Find("Player").GetComponent<FoodBehavior>().noFood == false)
        {
            Debug.Log("concluiu entrega");
            gameManager.points++;
            deliveryPoint[nextLocationDelivery].SetActive(false);

            NextDeliveryPoint();
            GameObject.Find("Player").GetComponent<FoodBehavior>().DeliveryFood();
        }
    }

    public void NextDeliveryPoint()
    {
        Debug.Log("ProximaLocalizacao");
        nextLocationDelivery = Random.Range(0, deliveryPoint.Length);
        deliveryPoint[nextLocationDelivery].SetActive(true);
    }

    public void StartGame()
    {
        nextLocationDelivery = Random.Range(0, deliveryPoint.Length);
        deliveryPoint[nextLocationDelivery].SetActive(true);

        GameObject.Find("Canvas").GetComponent<UIManager>().StartTimer();
    }

    public void RestockedFood()
    {
        GameObject.Find("Player").GetComponent<FoodBehavior>().Restocked();
        restockedPoint.SetActive(false);
    }
}
