using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


//will be refernced by other scripts,must be static
public static class _SaveLoad {
    public static List<_Event> savedEvents = new List<_Event>();

    public static void Save()
    {
        savedEvents.Add(_Event.current);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/savedEvents.gd");
        bf.Serialize(file, _SaveLoad.savedEvents);
        file.Close();
    }

    public static void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/savedGames.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedGames.gd", FileMode.Open);
            _SaveLoad.savedEvents = (List<_Event>)bf.Deserialize(file);
            file.Close();
        }
    }
}
