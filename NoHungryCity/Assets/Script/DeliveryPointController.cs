using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryPointController : MonoBehaviour
{
    private GameManager gameManager;

    [SerializeField] private GameObject[] deliveryPoint;

    private int nextLocationDelivery;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void ConclusionDelivery()
    {
        Debug.Log("concluiu entrega");
        gameManager.points++;
        deliveryPoint[nextLocationDelivery].SetActive(false);

        NextDeliveryPoint();
    }

    public void NextDeliveryPoint()
    {
        Debug.Log("ProximaLocalizacao");
        nextLocationDelivery = Random.Range(0, deliveryPoint.Length);
        deliveryPoint[nextLocationDelivery].SetActive(true);
    }
}
