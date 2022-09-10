using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundGenetator : MonoBehaviour
{
    [SerializeField]
    private GameObject groundPrefab, bambooPrefab;

    [SerializeField]
    private float groundToSpawn = 10, bambooToSpawn = 5;//最初に生成する数を決めて、これを使いまわす

    private List<GameObject> groundPool = new List<GameObject>();
    private List<GameObject> bambooPool = new List<GameObject>();

    //生成する位置の調整
    [SerializeField]
    private float ground_Y_Pos = 0f, bamboo_Y_Pos = 0f;
    [SerializeField]
    private float ground_X_Distance = 17.98f, bamboo_X_Distance = 18f;

    private float nextGroundXPos, nextBambooXPos; //次に生成する位置

    [SerializeField]
    private float generateLevelWaitTime = 11f;//何秒おきに生成するか
    
    private float waitTime;

    void Update(){
        Generate();
    }

    private void Generate(){
        Vector3 groundPosition = Vector3.zero; //地面を生成する位置を格納する変数
        GameObject newGround;
        for (int i = 0; i < groundToSpawn; i++)
        {
            //最初に決めた生成する数だけ位置をずらしながら生成する
            groundPosition = new Vector3(nextGroundXPos, ground_Y_Pos, 0f);//生成する位置を格納
            newGround = Instantiate(groundPrefab, groundPosition, Quaternion.identity);//生成
            newGround.transform.SetParent(transform);
            groundPool.Add(newGround);//リストに加える
            nextGroundXPos += ground_X_Distance;//次に生成する位置へと移動
        }

        Vector3 bambooPosition = Vector3.zero; //地面を生成する位置を格納する変数
        GameObject newBamboo;
        for (int i = 0; i < bambooToSpawn; i++)
        {
            //最初に決めた生成する数だけ位置をずらしながら生成する
            bambooPosition = new Vector3(nextBambooXPos, bamboo_Y_Pos, 0f);//生成する位置を格納
            newBamboo = Instantiate(bambooPrefab, bambooPosition, Quaternion.identity);//生成
            newBamboo.transform.SetParent(transform);
            groundPool.Add(newBamboo);//リストに加える
            nextBambooXPos += bamboo_X_Distance;//次に生成する位置へと移動
        }
    }
}
