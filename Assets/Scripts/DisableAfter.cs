using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAfter : MonoBehaviour
{
    public float disableTime;

    void OnEnable()
    {
        Invoke("DisableObject", disableTime);
    }

    void DisableObject()
    {
        this.gameObject.SetActive(false);
    }
}
