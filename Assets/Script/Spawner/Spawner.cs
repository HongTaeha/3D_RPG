using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Spawner : MonoBehaviour
{
    List<Vector3> lst = new List<Vector3>();
    void Start()
    {        
        
        Spawn_Table.instance.Spawn_table.TryGetValue("Enemy", out List<Vector3> lst);

        foreach (Vector3 a in lst)
        {
            foreach (string tag in ObjectPooler.instance.tags)
            {
                GenMonster(a, tag);
            }
        }
    }    
    void Update()
    {


    }
    void GenMonster(Vector3 pos,string tag)
    {
        GameObject prefab = ObjectPooler.instance.Generate_Obj(tag);
        prefab.transform.Rotate(0, 180, 0);
        prefab.GetComponent<Enemy>().Spawn_Point=pos;
        prefab.transform.position = pos;
    }
}