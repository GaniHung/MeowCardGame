using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveManager : MonoBehaviour
{
    public void SaveGame()
    {
        Debug.Log(Application.persistentDataPath);
        if (!Directory.Exists(Application.persistentDataPath + "/gamedate")){
            Directory.CreateDirectory(Application.persistentDataPath + "/gamedate");
        }

    }
    public void LoadGame()
    {

    }
}
