using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    List<GameObject> _removeLst = new List<GameObject>();
    Dictionary<string, ObjectPool> _dictObjPool = new Dictionary<string, ObjectPool>();
    public static ObjectPooler instance = null;

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
        Pooling_Obj("Enemy", "Prefab/Polygonal Metalon Purple", 3);
        Pooling_Obj("Enemy", "Prefab/Polygonal Metalon Red", 3);
    }
    void Start()
    {
        
    }

    void Update()
    {

    }
    public void getActiveObject(string tag, out List<GameObject> list)
    {
        List<GameObject> lst = new List<GameObject>();
        foreach (GameObject tmp in _dictObjPool[tag].GetActiveObj())
        {
            lst.Add(tmp);
        }        
        list = lst;
    }

    void Pooling_Obj(string tag, string path, int cnt)
    {
        ObjectPool objPool = new ObjectPool();
        GameObject prefab = Resources.Load(path) as GameObject;


        if (!_dictObjPool.ContainsKey(tag))
        {
            objPool.AddObj(prefab, cnt);
            _dictObjPool.Add(tag, objPool);
        }
        else
            _dictObjPool[tag].AddObj(prefab, cnt);
        
    }
    public GameObject Generate_Obj(string tag, string path = "")
    {
        GameObject ret = null;
        if (_dictObjPool[tag] != null)
        {
            ret = _dictObjPool[tag].GetObj();
        }       
        return ret;
    }

    public void ReleaseObj(GameObject obj)
    {
            
            if (_dictObjPool.ContainsKey(obj.tag))
            {
                _dictObjPool[obj.tag].ReleaseObj(obj);
            }
            else
            {
                Destroy(obj);
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