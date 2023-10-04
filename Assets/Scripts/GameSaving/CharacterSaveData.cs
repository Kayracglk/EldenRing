using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class CharacterSaveData
{
    [Header("Character Name")]
    public string characterName;

    [Header("Time Player")]
    public float secondPlayed;

    [Header("World Coordinates")]
    public float xPosition;
    public float yPosition;
    public float zPosition;

}
