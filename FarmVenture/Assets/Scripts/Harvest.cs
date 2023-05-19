using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harvest : MonoBehaviour
{
    public GameObject harvestPrefab;
    public GameObject harvestPrefab2;
    public Transform spawnPoint;
    public List<GameObject> harvestList = new List<GameObject>(); // Hasat prefablar�n� saklamak i�in liste
    public Milk milk;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Field"))
        {
            // FieldInteraction fieldInteraction = other.GetComponent<FieldInteraction>();
        }
        if (other.gameObject.tag == "CowHay" || other.gameObject.tag == "CowWater" || other.gameObject.tag == "Milk")
        {
            milk.MilkCow();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Field"))
        {


        }
    }

    public void PerformHarvest(int a)
    {

        if (harvestList.Count < 5)
        {

            if (a == 1)
            {
                GameObject newHarvest = Instantiate(harvestPrefab, spawnPoint.position, spawnPoint.rotation);
                newHarvest.transform.parent = transform; // Harvest objesinin alt�nda kalmas�n� sa�la
                harvestList.Insert(0, newHarvest); // Listeye en ba�a ekle
            }
            else if (a == 2)
            {
                GameObject newHarvest = Instantiate(harvestPrefab2, spawnPoint.position, spawnPoint.rotation);
                newHarvest.transform.parent = transform; // Harvest objesinin alt�nda kalmas�n� sa�la
                harvestList.Insert(0, newHarvest); // Listeye en ba�a ekle

            }

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
