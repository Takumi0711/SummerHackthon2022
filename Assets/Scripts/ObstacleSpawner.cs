using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject makibisiPrefab, rockPrefab, fallentreePrefab;

    [SerializeField]
    private float makibisiYPos = -3.75f, rockYPos = -3.5f, fallentreeYPos = -3.75f;

    [SerializeField]
    private float minSpawnWaitTime = 2f, maxSpawnWaitTime = 3.5f;//生成する時間の最小値と最大値

    private float spawnWaitTime;//生成する時間

    private int obstacleTypeCount = 3;//障害物の酒類を扱う変数
    private int obstacleToSpawn = 0;//生成するオブジェクトを扱う数値

    private Camera mainCamera;

    private Vector3 obstacleSpawnPos = Vector3.zero;//生成する位置を格納する変数
    private GameObject newObstacle;//生成するオブジェクトを

    [SerializeField]
    private List<GameObject> makibisiPool, rockPool, fallentreePool;//オブジェクトを管理するリスト

    [SerializeField]
    private int initialObstacleToSpawn = 5; //最初に作っておく数

    private void Awake(){
        mainCamera = Camera.main;
        GenerateObstacles();
    }

    void Update(){
        ObstacleSpawning();
    }

    void GenerateObstacles(){
        for (int i = 0; i < 3; i++)
        {
            SpawnObstacles(i);
        }
    }

    void SpawnObstacles(int obstacleType){
        switch (obstacleType){//obstacleTypeの数によって生成するオブジェクトを変える
            case 0:
                for (int i = 0; i < initialObstacleToSpawn; i++)
                {
                    newObstacle = Instantiate(makibisiPrefab);//インスタンス化
                    newObstacle.transform.SetParent(transform);//親を指定して生成した時に見やすくする
                    makibisiPool.Add(newObstacle);//
                    newObstacle.SetActive(false);//リストに格納し、非表示にする
                }
                break;

            case 1:
                for (int i = 0; i < initialObstacleToSpawn; i++)
                {
                    newObstacle = Instantiate(rockPrefab);//インスタンス化
                    newObstacle.transform.SetParent(transform);//親を指定して生成した時に見やすくする
                    rockPool.Add(newObstacle);//
                    newObstacle.SetActive(false);//リストに格納し、非表示にする
                }
                break;
            
            case 2:
                for (int i = 0; i < initialObstacleToSpawn; i++)
                {
                    newObstacle = Instantiate(fallentreePrefab);//インスタンス化
                    newObstacle.transform.SetParent(transform);//親を指定して生成した時に見やすくする
                    fallentreePool.Add(newObstacle);//
                    newObstacle.SetActive(false);//リストに格納し、非表示にする
                }
                break;
        }
    }

    private void ObstacleSpawning(){
        if(Time.time > spawnWaitTime){//ゲームを開始してからある程度時間がたったら...
            SpawnObstacleInGame();
            spawnWaitTime = Time.time + Random.Range(minSpawnWaitTime, maxSpawnWaitTime);//一定の範囲内のランダムな時間で生成
        }
    }

    private void SpawnObstacleInGame(){
        obstacleToSpawn = Random.Range(0, obstacleTypeCount);

        obstacleSpawnPos.x = mainCamera.transform.position.x + 20f;

        switch(obstacleToSpawn){
            case 0:
                for (int i = 0; i < makibisiPool.Count; i++)//リストに格納されているオブジェクトの数だけループ
                {
                    if(!makibisiPool[i].activeInHierarchy){
                        makibisiPool[i].SetActive(true);
                        obstacleSpawnPos.y = makibisiYPos;
                        newObstacle = makibisiPool[i];
                        break;
                    }
                }
                break;

            case 1:
                for (int i = 0; i < rockPool.Count; i++)//リストに格納されているオブジェクトの数だけループ
                {
                    if(!rockPool[i].activeInHierarchy){
                        rockPool[i].SetActive(true);
                        obstacleSpawnPos.y = rockYPos;
                        newObstacle = rockPool[i];
                        break;
                    }
                }
                break;

            case 2:
                for (int i = 0; i < fallentreePool.Count; i++)//リストに格納されているオブジェクトの数だけループ
                {
                    if(!fallentreePool[i].activeInHierarchy){
                        fallentreePool[i].SetActive(true);
                        obstacleSpawnPos.y = fallentreeYPos;
                        newObstacle = fallentreePool[i];
                        break;
                    }
                }
                break;
        }
            newObstacle.transform.position = obstacleSpawnPos;//生成したオブジェクトをobstacleSpawnPosへ

    }
}
