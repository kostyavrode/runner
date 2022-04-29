using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using TMPro;

public class PlayerInfoAndUI : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreBar;
    [SerializeField] private TMP_Text bestScoreBar;
    [SerializeField] private GameObject panel;
    private int currentScore;
    [HideInInspector] public bool playerAlive=true;
    private void Start()
    {

        if (!PlayerPrefs.HasKey("BestScore"))
        {
            PlayerPrefs.SetFloat("BestScore", currentScore);
        }
        Observable.EveryFixedUpdate().Where(x=>playerAlive==true).TakeUntilDisable(gameObject).Subscribe(x =>
        {
            currentScore += 1;
            scoreBar.text = "Score:"+currentScore.ToString();
        });
    }
    public void WriteBestScore()
    {
        Debug.Log(PlayerPrefs.GetFloat("BestScore"));
        if(PlayerPrefs.GetFloat("BestScore")<currentScore)
        PlayerPrefs.SetFloat("BestScore", currentScore);
        panel.SetActive(true);
        bestScoreBar.text = "Best score:" + PlayerPrefs.GetFloat("BestScore").ToString();

    }
}
