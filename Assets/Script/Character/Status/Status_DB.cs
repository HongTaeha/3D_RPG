using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status_DB : SingleTon<Status_DB>
{
    public Dictionary<string, Status> status_dic = new Dictionary<string, Status>();
}
