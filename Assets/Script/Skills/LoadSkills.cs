using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSkills : MonoBehaviour
{
    Skills_DB db = null;
    void Awake()
    {
        db = Resources.Load<Skills_DB>("Skills_DB");

        if (db.skills.Count == 0)
            db.Update_DB();
    }
    private void Start()
    {

    }
    private void Update()
    {

    }

    private void OnDestroy()
    {
        db.Clear();
    }
}