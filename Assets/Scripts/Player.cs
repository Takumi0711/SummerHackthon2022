using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 8f, jumpForce = 7f;

    private Rigidbody2D rb;

    private void Awake(){
        //rbにplayerが持っているコンポーネント（当たり判定とか）を保存
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        //一定秒数ごとに呼び出される.デフォルトは0.02
        MovePlayer();
    }

    private void MovePlayer(){
        //横に動く動作
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
    }
}
