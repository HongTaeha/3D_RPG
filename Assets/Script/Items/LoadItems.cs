using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadItems : MonoBehaviour
{
    public Items_DB db = null;
    void Awake()
    {
        db = Resources.Load<Items_DB>("Items_DB");
        if (db.item.Count == 0)
            db.Update_DB();
    }
    private void Start()
    {
        db.wakeup();
        //Destroy(this);
    }
    private void Update()
    {

    }

    private void OnDestroy()
    {
        db.Clear();
    }
}
