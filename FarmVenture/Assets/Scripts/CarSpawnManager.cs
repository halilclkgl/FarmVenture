using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawnManager : MonoBehaviour
{
    public CarMovement carMovement;
    public Transform[] spawnPoints;
    public GameObject[] carPrefabs;
    public GameObject car;
    public float minSpawnTime = 2f;
    public float maxSpawnTime = 5f;

    private GameObject[] carPool;

    private void Start()
    {
        InitializeCarPool();
        StartCoroutine(SpawnCars());
    }

    private void InitializeCarPool()
    {
        int carTypeCount = carPrefabs.Length;
        carPool = new GameObject[carTypeCount];

        for (int i = 0; i < carTypeCount; i++)
        {
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            carPool[i] = Instantiate(carPrefabs[i], spawnPoint.position, spawnPoint.rotation);
            carPool[i].transform.parent = car.transform;
            carPool[i].SetActive(false);
        }
    }

    private IEnumerator SpawnCars()
    {
        while (true)
        {
            float spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(spawnTime);

            GameObject carPrefab = GetRandomCarPrefab();
            GameObject car = GetPooledCar(carPrefab);

            if (car != null)
            {
                car.transform.position = car.transform.position; // Pozisyonu sýfýrla
                car.SetActive(true);
                carMovement = car.GetComponent<CarMovement>();
                carMovement.MoveToDestination();
            }
        }
    }

    private GameObject GetRandomCarPrefab()
    {
        int randomIndex = Random.Range(0, carPrefabs.Length);
        return carPrefabs[randomIndex];
    }

    private GameObject GetPooledCar(GameObject carPrefab)
    {
        for (int i = 0; i < carPool.Length; i++)
        {
            if (!carPool[i].activeInHierarchy && carPool[i].CompareTag(carPrefab.tag))
            {
                return carPool[i];
            }
        }

        return null;
    }
}
