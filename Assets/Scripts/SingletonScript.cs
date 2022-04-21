/*
 Copyright 2020 American Water Works Company, Inc. All Rights Reserved.
*/

using UnityEngine;

/// <summary>
/// Keeps the object to which the script is attached to persistent throughout the application lifecycle.
/// </summary>
public class SingletonScript : MonoBehaviour
{

    public AudioSource audioSource;
    // Static instance for the SingletonScript.
    public static SingletonScript Instance;

    // Gets executed as soon as the script starts executing.
    private void Awake()
    {
        // Gets executed if the instance is null.
        if (Instance == null)
        {
            // Assignes this to the instance.
            Instance = this;
            // Makes the attached object undistructable throughout the app lifecycle.
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Destroys the attached gameobject if an instance already exists.
            Destroy(gameObject);
        }
    }
}