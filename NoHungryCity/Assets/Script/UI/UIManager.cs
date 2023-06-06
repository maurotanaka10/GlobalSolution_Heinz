using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text pointText;
    [SerializeField] private GameManager gameManager;

    [SerializeField] private TMP_Text timerText;
    [SerializeField] private float timerToDelivery;
    private bool timerIsRunning = false;
    private float currentTime;
    [SerializeField] private GameObject penaltyText;
    [SerializeField] private float penaltyTime;

    public bool gameIsOver;


    private void Awake()
    {
        ResetTimer();
    }

    private void FixedUpdate()
    {
        pointText.text = "" + gameManager.points;

        if (timerIsRunning)
        {
            currentTime -= Time.deltaTime;

            if (currentTime <= 0f)
            {
                currentTime = 0f;
                StopTimer();
                GameObject.Find("Canvas").GetComponent<GameOverBehavior>().GameOver();
            }

            string minutes = ((int)currentTime / 60).ToString("00");
            string seconds = (currentTime % 60).ToString("00");
            string timeText = minutes + ":" + seconds;
            timerText.text = timeText;
        }

        gameIsOver = currentTime <= 0 || GameObject.Find("Player").GetComponent<BatteryBehavior>().currentEnergy <= 0;

        if (gameIsOver)
        {
            StopTimer();
        }
    }

    public void StartTimer()
    {
        timerIsRunning = true;
    }

    public void StopTimer()
    {
        timerIsRunning = false;
    }

    public void ResetTimer()
    {
        currentTime = timerToDelivery;
        timerText.text = timerToDelivery.ToString("0");
    }

    public void Penalty()
    {
        currentTime -= penaltyTime;

        StartCoroutine(PenaltyText());
    }

    IEnumerator PenaltyText()
    {
        penaltyText.SetActive(true);
        yield return new WaitForSeconds(5f);
        penaltyText.SetActive(false);
    }
}
