using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScoreScript : MonoBehaviour
{

    // private static Canvas scoreCanvas;

    // private void Awake(){
    //     scoreCanvas = GetComponent<Canvas>();
    // }

    public static void ShowScorePanel(){
        Time.timeScale = 0f; //ゲーム内時間の停止
        double Score = Math.Round(Time.time, 1, MidpointRounding.AwayFromZero);
        // Type == Number の場合
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking (Score);
    }

}
