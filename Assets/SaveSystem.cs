using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class Save_System
{

    public static void Save()
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/save.fun";
        FileStream stream = new FileStream(path, FileMode.Create);
            
        GameManager gameManager = GameManager.GetInstance();
        int[] levels = gameManager.SaveLevels();

        for (int i = 0; i < levels.Length; i++) {
            formatter.Serialize(stream,levels[i]);
            Debug.Log("saved " + (i + 1));
        }
        stream.Close();
    }

    public static void Load()
    {
        string path = Application.persistentDataPath + "/save.fun";
        if (File.Exists(path))
        {
            Debug.Log("save found");
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            int[] levels = new int[3];
            for (int i = 0; i < levels.Length; i++) {
            levels [i]=(int)formatter.Deserialize(stream);
            }
            GameManager gameManager = GameManager.GetInstance();
            gameManager.LoadLevels(levels);


            stream.Close();
        }
        else
        {
            Debug.LogError("save not found");
        }
    }

    public static void ResetSave()
    {
        string path = Application.persistentDataPath + "/save.fun";
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }
}
