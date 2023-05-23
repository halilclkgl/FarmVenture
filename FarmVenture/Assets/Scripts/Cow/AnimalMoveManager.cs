using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMoveManager : MonoBehaviour
{
    public static AnimalMoveManager Instance { get; private set; }

    public List<Transform> cowWaypoints = new List<Transform>();
    public List<Transform> chickenWaypoints = new List<Transform>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    // Yeni bir tarla eklemek için çaðrýlacak metot
    public void AddCowWaypoints(Transform[] waypoints)
    {
        cowWaypoints.AddRange(waypoints);
    }
    public void AddChickenWaypoints(Transform[] waypoints)
    {
        chickenWaypoints.AddRange(waypoints);
    }
}
