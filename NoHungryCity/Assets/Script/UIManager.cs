using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text pointText;
    [SerializeField] private GameManager gameManager;

    private void Awake()
    {
        pointText.text = "" + gameManager.points;
    }

    private void FixedUpdate()
    {
        pointText.text = "" + gameManager.points;
    }
}
