using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSVParsor : MonoBehaviour
{
    public List<Vector3> lst = new List<Vector3>();
    public string FileName;
    string[] stringList1;
    string[] stringList2;
    string fileFullPath;
    void Start()
    {       
       
    }


    private void Awake()
    {
        TextAsset txtAsset = Resources.Load<TextAsset>(FileName);
        fileFullPath = txtAsset.text;
        stringList1 = fileFullPath.Split('\n');
        for (int i = 0; i < stringList1.Length-1; i++)
        {
            stringList2 = stringList1[i].Split(',');
            for(int j=0;j<stringList2.Length;j+=3)
            {
                lst.Add(new Vector3(float.Parse(stringList2[j]), float.Parse(stringList2[j + 1]), float.Parse(stringList2[j + 2])));
                
            }
        }

        Spawn_Table.instance.Spawn_table.Add("Enemy", lst);
    }





}

