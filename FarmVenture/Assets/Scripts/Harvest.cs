using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harvest : MonoBehaviour
{

    public GameObject harvestPrefab;
    public Transform spawnPoint;
    public GameObject Player;
    private int stok = 0;

    public int Stok
    {

        get { return stok; }

        set { stok = value; }
    }
    public void PerformHarvest()
    {
        if (stok<5)
        {
            stok++;
            GameObject newHarvest = Instantiate(harvestPrefab, spawnPoint.position, Player.transform.localRotation);
            newHarvest.transform.parent = Player.transform; // Karakterin sýrtýnda kalmasýný saðla
            NewSpawnPoint();
        }
        return;
    }
    void NewSpawnPoint()
    {
        spawnPoint.position += new Vector3(0,0.5f,0);// spawnPoint'i bir birim yukarý kaydýr
    }
}
