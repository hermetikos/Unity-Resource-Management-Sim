using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    // we create a public static variable to store the 'this' of MainManager
    // this makes this 
    public static MainManager Instance;

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
    }
}
