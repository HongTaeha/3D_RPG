using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Table : SingleTon<Spawn_Table>
{    
    public Dictionary<string, List<Vector3>> Spawn_table = new Dictionary<string, List<Vector3>>();
}
