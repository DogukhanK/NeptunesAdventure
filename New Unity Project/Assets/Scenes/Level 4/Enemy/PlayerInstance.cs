using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInstance : MonoBehaviour
{

    #region Singleton

    public static PlayerInstance instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject player;
}
