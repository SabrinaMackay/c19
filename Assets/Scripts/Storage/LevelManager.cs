using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class LevelManager
{

    // save level data to a binary file
    public static void SaveLevel(Level level)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/LevelManager.bin";

        FileStream stream = new FileStream(path, FileMode.Create);

        LevelData data = new LevelData(level);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    // load level data
    public static LevelData LoadLevel()
    {
      string path = Application.persistentDataPath + "LevelManager.bin";

      if(File.Exists(path))
      {
          BinaryFormatter formatter = new BinaryFormatter();
          FileStream stream = new FileStream(path, FileMode.Open);

          LevelData data = formatter.Deserialize(stream) as LevelData;
          stream.Close();

          return data;
      }else
      {
        Debug.Log("Save file not found in "+ path);
        return null;
      }
    }

}
