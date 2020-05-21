using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    List<GameObject> _removeLst = new List<GameObject>();
    Dictionary<string, ObjectPool> _dictObjPool = new Dictionary<string, ObjectPool>();
    public static ObjectPooler instance = null;
    public List<string> tags = new List<string>();

    public class ObjectPool
    {
        class PoolableObject
        {
            public bool isActive = false;
            public GameObject obj;
        }
        List<PoolableObject> objLst = new List<PoolableObject>();


        
        public void AddObj(GameObject obj, int cnt)
        {
            for (int i = 0; i < cnt; i++)
            {
                GameObject gameObj = Instantiate(obj);
                PoolableObject poolableObj = new PoolableObject();
                poolableObj.obj = gameObj;
                gameObj.SetActive(false);
                objLst.Add(poolableObj);
            }

        }

        public List<GameObject> GetActiveObj()
        {
            List<GameObject> tmp = new List<GameObject>();
            foreach (var item in objLst)
            {
                if (item.isActive != false)
                {
                    tmp.Add(item.obj);
                }
            }
            return tmp;
        }

        public GameObject GetObj()
        {
            GameObject ret = null;
            foreach (var item in objLst)
            {
                if (item.isActive == false)
                {
                    ret = item.obj;
                    item.isActive = true;
                    break;
                }
            }
            if (ret != null)
            {
                ret.SetActive(true);
            }

            return ret;
        }
        public void ReleaseObj(GameObject obj)
        {
            foreach (var item in objLst)
            {
                if (item.obj == obj)
                {
                    obj.SetActive(false);
                    item.isActive = false;
                    break;
                }
            }
        }
    }
    private void Awake()
    {
        instance = this;
        Pooling_Obj("Enemy", "Prefab/Polygonal Metalon Green", 3);
        Pooling_Obj("Enemy_1", "Prefab/Polygonal Metalon Purple", 3);
        Pooling_Obj("Enemy_2", "Prefab/Polygonal Metalon Red", 3);
    }
    void Start()
    {
        
    }

    void Update()
    {

    }
    public void getActiveObject(out List<GameObject> list)
    {
        List<GameObject> lst = new List<GameObject>();
        foreach (string tag in tags)
        {
            foreach(GameObject tmp in _dictObjPool[tag].GetActiveObj())
            {
                lst.Add(tmp);
            }
        }
        list = lst;
    }

    void Pooling_Obj(string tag, string path, int cnt)
    {
        if (!tags.Contains(tag))
        {
            tags.Add(tag);
            ObjectPool objPool = new ObjectPool();
            GameObject prefab = Resources.Load(path) as GameObject;
            objPool.AddObj(prefab, cnt);
            _dictObjPool.Add(tag, objPool);
        }
    }
    public GameObject Generate_Obj(string tag, string path = "")
    {
        GameObject ret = null;
        if (tags.Contains(tag))
        {
            if (_dictObjPool[tag] != null)
            {
                ret = _dictObjPool[tag].GetObj();
            }
        }
        return ret;
    }

    public void ReleaseObj(GameObject obj)
    {
        if (tags.Contains(tag))
        {
            tags.Remove(tag);
            if (_dictObjPool.ContainsKey(obj.tag))
            {
                _dictObjPool[obj.tag].ReleaseObj(obj);
            }
            else
            {
                Destroy(obj);
            }
        }
    }
    public void AddRemoveObj(GameObject obj)
    {
        _removeLst.Add(obj);
    }

    private void LateUpdate()
    {
        foreach (var item in _removeLst)
        {
            //Destroy(item.gameObject);
            ObjectPooler.instance.ReleaseObj(item.gameObject);
        }
        _removeLst.Clear();
    }
}