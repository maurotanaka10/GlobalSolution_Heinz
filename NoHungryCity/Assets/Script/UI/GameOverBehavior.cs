using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverBehavior : MonoBehaviour
{
    [SerializeField] private TMP_Text pointText;
    [SerializeField] private GameObject gameover;

    public void GameOver()
    {
        gameover.SetActive(true);
        pointText.text = "" + GameObject.Find("GameManager").GetComponent<GameManager>().points;
    }
}
