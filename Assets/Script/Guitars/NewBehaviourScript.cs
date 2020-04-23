using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void saveData()
    {
        if(!System.IO.Directory.Exists(@"C:\Users\Atents\Desktop\test"))
        {
            System.IO.Directory.CreateDirectory(@"C:\Users\Atents\Desktop\test");

            string strData = "dfsdf";
            WriteData(strData, "ttt.txt");
        }
    }
    public void WriteData(string strData,string strFile)
    {
        FileStream f = new FileStream(strFile, FileMode.Append, FileAccess.Write);
        StreamWriter writer = new StreamWriter(f, System.Text.Encoding.UTF8);
        writer.WriteLine(strData);
        writer.Close();
    }
}
