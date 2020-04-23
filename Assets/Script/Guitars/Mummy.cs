using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mummy : MonoBehaviour
{
    public string strName = "Mummy";

    // 선택한 Enemy를 기억
    public Transform target = null;
    public float fAttackRange = 2f;

    Animator ani;
    private Vector3 vEnd = Vector3.zero;
    public Vector3 vEND { get { return vEnd; }
        set
        {
            vEnd = value;
        }
    }

    public float TARGETDISTANCE
    {
        get
        {
            return Vector3.Distance(transform.position, target.position);
        }
    }

    void Start()
    {
        ani = GetComponent<Animator>();
        vEnd = transform.position;
    }

    void MousePick()
    {
        if( Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if( Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Terrain"))
                {
                    vEnd = hit.point;
                    target = null;
                }
                else if(hit.collider.CompareTag("Enemy"))
                {
                    vEnd = hit.collider.transform.position;
                    target = hit.collider.transform;
                }
            }
        }
    }

    public void Move(Vector3 _vEnd)
    {
        transform.position = Vector3.MoveTowards(transform.position,
            _vEnd, Time.deltaTime * 1f);
        if (transform.position == _vEnd)
        {
            ani.SetInteger("iAniIndex", 0);
        }
    }

    public void Rotate(Vector3 _vEnd)
    {
        Vector3 targetDir = _vEnd - transform.position;
        if (Vector3.Dot(targetDir.normalized, transform.forward).CompareTo(0.99f) >= 0)
            return;

        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir.normalized,
            Time.deltaTime * 4f, 0);
        transform.rotation = Quaternion.LookRotation(newDir);
    }

    void Update()
    {
        MousePick();
    }
}
