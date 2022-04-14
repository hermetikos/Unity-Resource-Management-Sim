using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainManager : MonoBehaviour
{
    // we create a public static variable to store the 'this' of MainManager
    // this makes this 
    public static MainManager Instance { get; private set; }
    // init Main Mananger as a getter with a private setter
    // basically, mark it as read only for public access
    // but allow it to modify itself
    // any variable with a get/set accessor is considered a property
    // a property is a class variable that provides access to internal class data

    public Color TeamColor;

    // Update is called once per frame
    void Awake()
    {
        // we want to ensure that only one instance of this class exists
        if (Instance != null)
        {
            // if an instance of MainManager exists already
            // destroy this extra instance
            Destroy(gameObject);
            // and return to stop further code execution
            return;
        }

        Instance = this;
        // this ensures that the MainManager GameObject will persist during scene changes
        DontDestroyOnLoad(gameObject);

        // load the previously saved color
        LoadColor();
    }

    [System.Serializable]
    class SaveData
    {
        public Color TeamColor;
    }

    public void SaveColor()
    {
        SaveData data = new SaveData();
        data.TeamColor = TeamColor;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadColor()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            TeamColor = data.TeamColor;
        }
    }
}
