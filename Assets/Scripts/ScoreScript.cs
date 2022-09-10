using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{

    private static Canvas scoreCanvas;

    private void Awake(){
        scoreCanvas = GetComponent<Canvas>();
    }

    public static void ShowScorePanel(){
        Time.timeScale = 0f; //ゲーム内時間の停止
        scoreCanvas.enabled = true;//スコアのパネルを表示する
    }

}
