using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {//colliderを持つオブジェクトがぶつかったときに呼び出される
    //collisionにはぶつかった相手の情報が格納される
        if(collision.CompareTag("Ground") || collision.CompareTag("Bamboo")
        || collision.CompareTag("Obstacle")){
            collision.gameObject.SetActive(false);
            //非表示にして使いまわせるようになった
        }
    }
}
