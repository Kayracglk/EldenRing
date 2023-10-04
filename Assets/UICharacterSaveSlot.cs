using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UICharacterSaveSlot : MonoBehaviour
{
    SaveFileDataWriter saveFileWriter;
    [Header("Game Slot")]
    public CharacterSlot characterSlot;

    [Header("Character Info")]
    public TMP_Text characterName;
    public TMP_Text timePlayed;

    private void OnEnable()
    {
        LoadSaveSlots();
    }

    private void LoadSaveSlots()
    {
        saveFileWriter = new SaveFileDataWriter();

        saveFileWriter.saveDataDirectoryPath = Application.persistentDataPath;

        switch (characterSlot)
        {
            case CharacterSlot.CharacterSlot_01:
                saveFileWriter.saveFileName = WorldSaveGameManager.instance.DecideCharacterFileNameBasedOnCharacterSlotBeingUsed(characterSlot);
                if(saveFileWriter.CheckToSeeIfFileExist())
                {
                    characterName.text = WorldSaveGameManager.instance.characterSlot01.characterName;
                }
                else
                {
                    gameObject.SetActive(false);
                }
                break;
            case CharacterSlot.CharacterSlot_02:
                break;
            case CharacterSlot.CharacterSlot_03:
                break;
            case CharacterSlot.CharacterSlot_04:
                break;
            case CharacterSlot.CharacterSlot_05:
                break;
            case CharacterSlot.CharacterSlot_06:
                break;
            case CharacterSlot.CharacterSlot_07:
                break;
            case CharacterSlot.CharacterSlot_08:
                break;
            case CharacterSlot.CharacterSlot_09:
                break;
            case CharacterSlot.CharacterSlot_010:
                break;
            default:
                break;
        }
        
    }
}
