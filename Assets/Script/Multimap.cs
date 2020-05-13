using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Multimap(키,리스트/큐/스택) : 키에 해당되는 값이 여러개가 되는것

public class Multimap <TKey, TValue>
{
   public Dictionary<TKey,List<TValue>> dic  = new Dictionary<TKey,List<TValue>>();

   public bool ContainsKey(TKey key)
    {
        if (dic.ContainsKey(key))
            return true;
        else
            return false;
    }
    public void Add(TKey key, TValue value)
    {
        List<TValue> list;
        if(dic.TryGetValue(key,out list))
        {
            // 키가 있을경우
            // - 해당 키에 해당되는 리스트에 값을 추가 
            dic[key].Add(value);
        }
        else
        {
            // 키가 없을경우(처음 데이터가 추가될때)
            // - 리스트를 생성
            // - 리스트에 값을 추가
            // - 리스트를 딕셔너리에 추가 
            list = new List<TValue>();
            list.Add(value);
            dic.Add(key, list);
        }

    }
    public List<TValue> GetData(TKey key)
    {
        List<TValue> list;
        if (dic.TryGetValue(key, out list))
        {
            return list;
        }
        return null;
        
    }
   

}
