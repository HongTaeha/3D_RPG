using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSVParsor : MonoBehaviour
{
    public List<string> lst = new List<string>();
    public string FileName;
    string[] stringList1;
    string[] stringList2;
    string fileFullPath;
    void Start()
    {

        TextAsset txtFile = Resources.Load(FileName) as TextAsset;
        fileFullPath = txtFile.text;

        stringList1 = fileFullPath.Split('\n');       
        for (int i = 0; i < stringList1.Length; i++)
        {
            stringList2 = stringList1[i].Split(',');
            foreach (string b in stringList2)
            {
                lst.Add(b);
                Debug.Log(b);
            }
        }
    }
  

}

