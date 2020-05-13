using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Spawner : MonoBehaviour
{
    public GameObject _enemy;
    float dt = 0;
    string tag = "Enemy";
    string tag1 = "Enemy_1";
    string tag2 = "Enemy_2";
    List<Vector3> lst = null;

    void Start()
    {
        Spawn_Table.instance.Spawn_table.TryGetValue(tag, out List<Vector3> lst);
        /*
        foreach (Vector3 a in lst)
        {
            GenMonster(a,tag);
        }*/
        GenMonster(lst[0],tag);
        GenMonster(lst[1], tag1);
        GenMonster(lst[2], tag2);
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