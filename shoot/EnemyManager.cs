using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    float currentTime =0; //-
    float createTime; //- 278���� public ������   
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
        enemyObjectPool = new List<GameObject>(); //-288��������
        for (int i = 0; i < poolSize; i++) //-
        {
            GameObject enemy = Instantiate(enemyFactory); //-
            enemyObjectPool.Add(enemy); //- ������ ������ 33������ �Ʒ��� ���� �ٱŵ� �����ϴٰ� ��
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
                GameObject enemy = enemyObjectPool[0]; //- 289���� if�� �ȿ� ������
                enemyObjectPool.Remove(enemy); // å�� ����, ������ó�� ���� �ٲ�
                //enemyObjectPool.RemoveAt(0);   // ����
                int index = Random.Range(0, SpawnPoints.Length); //- enemy.SetActive(true); �Ʒ��ٿ��־��µ�289�������� �ø�
                enemy.transform.position = SpawnPoints[index].position; //- ���� ���� �̵�***���Ⱑ ������ �� ����. ���� �ν����Ϳ��� �۵��� ��                 
                enemy.SetActive(true); //�� ��ġ�� �־�� �Ѵ�. 
            }
            currentTime = 0;  // ��׵��� ���� �ø���, enemy�� ������
            createTime = Random.Range(minTime, maxTime);
        }
    }
}


