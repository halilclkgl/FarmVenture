using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Data", menuName = "PlayerSo")]
public class PlayerSo : ScriptableObject
{
    public string playerName;
    public string farmName;
    public float playerSpeed;
    public float horseSpeed;
    public float harvestSpeed;
    public float playerNightSpeed;
    public int cowCount;
    public int cowAreaLimit = 10;
    public int chickenCount;
    public int chickenAreaLimit = 10;
}
