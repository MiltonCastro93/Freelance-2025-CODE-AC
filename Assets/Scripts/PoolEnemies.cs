using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

public class PoolEnemies : MonoBehaviour,IObserve {
    public GameObject[] TypesEnemies = new GameObject[3];
    public GameObject[] RespawnPoints = new GameObject[4];
    private ObjectPool<GameObject> EnemiesPool;

    private float currentTime = 0f;
    public float MaxTimeRespawn = 2f;
    public float wavePointMax = 25f;
    private float LifePlayer, GetPoints;

    private void Awake() {
        Arbitro arbitro = FindObjectOfType<Arbitro>();
        arbitro.RegisterObserver(this);

        EnemiesPool = new ObjectPool<GameObject>(CreatePoolItem, OnTakeFromPool, OnReturnedToPool, OnDestryPoolObject, false, 10, 100);
    }



    // Update is called once per frame
    void Update() {
        if(LifePlayer >= 1) {
            currentTime += Time.deltaTime;
            currentTime = Mathf.Clamp(currentTime,0f,MaxTimeRespawn);
            if (currentTime >= MaxTimeRespawn) {
                int random = Random.Range(0, RespawnPoints.Length);
                currentTime = 0f;
                GameObject currentEnemy = EnemiesPool.Get();
                currentEnemy.transform.position = RespawnPoints[random].transform.position;
            }
            if(GetPoints >= wavePointMax) {
                wavePointMax *= 2;
                if(MaxTimeRespawn >= 0.11f) {
                    MaxTimeRespawn -= 0.10f;
                }

            }
        }

    }

    private GameObject CreatePoolItem() {
        int random = Random.Range(0, TypesEnemies.Length);
        GameObject instancia = Instantiate(TypesEnemies[random]);
        instancia.gameObject.SetActive(false);
        instancia.GetComponent<InEarth>().pool = EnemiesPool;
        //instancia.pool = EnemiesPool; //Error
        return instancia;
    }

    private void OnTakeFromPool(GameObject enemy) {
        enemy.gameObject.SetActive(true);
    }

    private void OnReturnedToPool(GameObject enemy) {
        enemy.gameObject.SetActive(false);
    }

    private void OnDestryPoolObject(GameObject enemy) {
        Destroy(enemy.gameObject);
    }

    public void Points(float p) {
        GetPoints = p;
    }

    public void Life(float l) {
        LifePlayer = l;
    }

}
