using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Level Handler",menuName ="Levels")]
public class LevelHandler : ScriptableObject
{
    public LevelDetails[] LevelDeatils;


}

[System.Serializable]
public class LevelDetails
{
    public int LevelNumber, TargetCount;
    
}