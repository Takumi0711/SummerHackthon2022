using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform playerPos;

    [SerializeField]
    private float offSetX = -6f; //プレイヤーよりちょっとずらしたい

    private Vector3 tempPos;

    private void Awake(){
        FindPlayer();
    }

    private void LateUpdate(){//カメラの追跡処理はLateUpdateで行う
        FollowPlayer();        
    }

    private void FindPlayer(){//プレイヤーを見つける
        playerPos = GameObject.FindWithTag("Player").transform;
    }

    private void FollowPlayer(){
        if(playerPos){//プレイヤーを認識できているかの確認と、できていたら追跡
            tempPos = transform.position;
            tempPos.x = playerPos.position.x - offSetX;

            transform.position = tempPos;
        }
    }
}
