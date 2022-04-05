using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    float currentTime =0; //-
    float createTime; //- 278에서 public 삭제함   
    float minTime = 0.1f; //- 
    float maxTime = 1.5f; //-
    public GameObject enemyFactory; //-
    public int poolSize = 10; //-
    public List<GameObject> enemyObjectPool; //-
    public Transform[] SpawnPoints; //-
    // Start is called before the first frame update
    void Start()
    {
        createTime = Random.Range(minTime, maxTime);        
        enemyObjectPool = new List<GameObject>(); //-288에서변경
        for (int i = 0; i < poolSize; i++) //-
        {
            GameObject enemy = Instantiate(enemyFactory); //-
            enemyObjectPool.Add(enemy); //- 순서는 동영상 33번에서 아래와 순서 바궈도 동일하다고 함
            enemy.SetActive(false); //-
        }
    }
            // Update is called once per frame
      void Update()
       {
         currentTime += Time.deltaTime; //-
         if (currentTime > createTime) //-
         {            
            if (enemyObjectPool.Count > 0)                
             {
                GameObject enemy = enemyObjectPool[0]; //- 289에서 if문 안에 들어가있음
                enemyObjectPool.Remove(enemy); // 책은 여기, 동영상처럼 위로 바꿈
                //enemyObjectPool.RemoveAt(0);   // 영상
                int index = Random.Range(0, SpawnPoints.Length); //- enemy.SetActive(true); 아랫줄에있었는데289에서위로 올림
                enemy.transform.position = SpawnPoints[index].position; //- 위와 같이 이동***여기가 문제인 것 같다. 전혀 인스펙터에서 작동을 안                 
                enemy.SetActive(true); //이 위치에 있어야 한다. 
            }
            currentTime = 0;  // 얘네들을 위로 올리니, enemy가 생성됨
            createTime = Random.Range(minTime, maxTime);
        }
    }
}


