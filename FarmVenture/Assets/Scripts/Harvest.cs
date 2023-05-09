using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harvest : MonoBehaviour
{
    public GameObject harvestPrefab;
    public Transform spawnPoint;
    public GameObject Player;
    public List<GameObject> harvestList = new List<GameObject>(); // Hasat prefablar�n� saklamak i�in liste

    public void PerformHarvest()
    {
        if (harvestList.Count < 5)
        {
            GameObject newHarvest = Instantiate(harvestPrefab, spawnPoint.position, Player.transform.localRotation);
            newHarvest.transform.parent = Player.transform; // Karakterin s�rt�nda kalmas�n� sa�la
            harvestList.Insert(0, newHarvest); // Listeye en ba�a ekle

            NewSpawnPoint();
        }
    }

    public void SellHarvest()
    {
        if (harvestList.Count > 0)
        {
            Destroy(harvestList[0]); // En �stteki hasat� yok et
            harvestList.RemoveAt(0); // Listeden ��kar
        }
    }

    void NewSpawnPoint()
    {
        spawnPoint.position += new Vector3(0, 0.5f, 0); // spawnPoint'i bir birim yukar� kayd�r
    }
}
