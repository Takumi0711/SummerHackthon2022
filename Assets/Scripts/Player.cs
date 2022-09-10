using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 8f, jumpForce = 7f;

    private Rigidbody2D rb;

    private Transform groundCheckPosition;

    [SerializeField]
    private LayerMask groundLayer;

    private Animations playerAnimations;

    private void Awake(){
        //rbにplayerが持っているコンポーネント（当たり判定とか）を保存
        rb = GetComponent<Rigidbody2D>();

        groundCheckPosition = transform.GetChild(0).transform;

        playerAnimations = GetComponent<Animations>();
    }

    private void Update(){
        PlayerJump();
        AnimatePlayer();
    }

    private void FixedUpdate() {
        //一定秒数ごとに呼び出される.デフォルトは0.02
        MovePlayer();
    }

    private void MovePlayer(){
        //横に動く動作
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
    }

    private void PlayerJump(){
        if(Input.GetMouseButtonDown(0)){//0番はマウスの左クリック（スマホだとタップで出来るはず）
            Debug.Log("ジャンプボタン");
            if(IsGrounded() == true){
                Debug.Log("ジャンプ動作");
                rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                //Impulseは、jumpForceの力が瞬間的に伝わるようにするモード
                //永続的にできたりもする
            }
        }
    }

    private bool IsGrounded(){//bool型を返す
        //プレイヤーの足元の当たり判定が、groundLayerと設置しているときにtrueを返す
        return Physics2D.OverlapCircle(groundCheckPosition.position, 0.1f, groundLayer);
    }

    private void AnimatePlayer(){
        playerAnimations.Jumping(rb.velocity.y);//PlayJumpの引数にrigidbodyのY軸速度を割り当て
        playerAnimations.Running(IsGrounded() == true);
    }
}
