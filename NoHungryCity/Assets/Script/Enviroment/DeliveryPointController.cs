using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DeliveryPointController : MonoBehaviour
{
    private GameManager gameManager;

    [SerializeField] private GameObject[] deliveryPoint;
    [SerializeField] private GameObject restockedPoint;

    private int nextLocationDelivery;

    //-----------

    [SerializeField]
    private Transform Player;
    [SerializeField]
    private LineRenderer Path;
    [SerializeField]
    private float PathHeightOffset = 1.25f;
    [SerializeField]
    private float SpawnHeightOffset = 1.5f;
    [SerializeField]
    private float PathupdateSpeed = 0.25f;
    [SerializeField]
    private AudioSource audioCollectable;

    private Coroutine DrawPathCoroutine;
    private GameObject pointSpawnObject;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();


    }

      public void ConclusionDelivery()
    {
         if(GameObject.Find("Player").GetComponent<FoodBehavior>().noFood == false)
        {
        print("entrei no primeiro if do conclusion");
        Debug.Log("concluiu entrega");
        gameManager.points++;
        deliveryPoint[nextLocationDelivery].SetActive(false);

        NextDeliveryPoint();
        GameObject.Find("Player").GetComponent<FoodBehavior>().DeliveryFood();
        }
    }

    public void NextDeliveryPoint()
    {
        audioCollectable.Play();


        Debug.Log("ProximaLocalizacao");
        nextLocationDelivery = Random.Range(0, deliveryPoint.Length);
        deliveryPoint[nextLocationDelivery].SetActive(true);

        //----------
        pointSpawnObject = deliveryPoint[nextLocationDelivery];
        if (DrawPathCoroutine != null)
        {
            StopCoroutine(DrawPathCoroutine);
        }
        DrawPathCoroutine = StartCoroutine(DrawPathCollectable());
    }

    public void StartGame()
    {
        nextLocationDelivery = Random.Range(0, deliveryPoint.Length);
        deliveryPoint[nextLocationDelivery].SetActive(true);

        pointSpawnObject = deliveryPoint[nextLocationDelivery];
        if (DrawPathCoroutine != null)
        {
            StopCoroutine(DrawPathCoroutine);
        }
        DrawPathCoroutine = StartCoroutine(DrawPathCollectable());

        GameObject.Find("Canvas").GetComponent<UIManager>().StartTimer();
    }

    public void RestockedFood()
    {
        GameObject.Find("Player").GetComponent<FoodBehavior>().Restocked();
        restockedPoint.SetActive(false);
    }

    private IEnumerator DrawPathCollectable()
    {
        WaitForSeconds Wait = new WaitForSeconds(PathupdateSpeed);
        NavMeshPath path = new NavMeshPath();
        while (pointSpawnObject.active)
        {

            if (NavMesh.CalculatePath(Player.position, pointSpawnObject.transform.position, NavMesh.AllAreas, path))
            {
                Path.positionCount = path.corners.Length;

                for (int i = 0; i < path.corners.Length; i++)
                {
                    Path.SetPosition(i, path.corners[i] + Vector3.up * PathHeightOffset);
                }

            }
            else
            {
                print($"Unable to calculate a path on the navMesh between {Player.position} and {pointSpawnObject.transform.position}");
            }
            yield return Wait;
        }


    }

}

