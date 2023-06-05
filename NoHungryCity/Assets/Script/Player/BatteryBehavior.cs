using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryBehavior : MonoBehaviour
{
    [SerializeField] private Slider sliderBattery;

    [SerializeField] private int maxEnergy;
    public int currentEnergy;

    void SetMaxBattery(int battery)
    {
        sliderBattery.maxValue = battery;
        sliderBattery.value = battery;
    }

    void SetBattery(int battery)
    {
        sliderBattery.value = battery;
    }

    private void Awake()
    {
        currentEnergy = maxEnergy;
        SetMaxBattery(maxEnergy);
    }

    private void Update()
    {
        if(currentEnergy <= 0)
        {
            GameObject.Find("Canvas").GetComponent<GameOverBehavior>().GameOver();
        }
    }

    public void SpendEnergy(int energy)
    {
        currentEnergy -= energy;

        SetBattery(currentEnergy);
    }

    public void RecoveryEnergy()
    {
        currentEnergy = maxEnergy;
    }
}
