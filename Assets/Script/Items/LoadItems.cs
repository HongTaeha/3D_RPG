using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadItems : MonoBehaviour
{
    private void Awake()
    {        
        Items_DB.instance.wakeup();

    }
    private void Start()
    {
        
    }
    private void Update()
    {

    }

    private void OnDestroy()
    {
    }
}
