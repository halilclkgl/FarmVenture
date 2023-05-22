using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Data", menuName = "PlayerSo")]
public class PlayerSo : ScriptableObject
{
    public int cowCount;
    public int cowAreaLimit = 10;
}
