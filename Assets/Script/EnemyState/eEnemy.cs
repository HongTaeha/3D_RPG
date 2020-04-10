using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eEnemy : MonoBehaviour
{
    public Vector3 vEnd = Vector3.zero;
    Vector3 vSpawn = Vector3.zero;

    public Vector3 SPAWN
    {
        get { return vSpawn; }
        set { vSpawn = value; }
    }

    void Awake()
    {
        // 레벨디자이너가 설정한 테이블에서 읽어와 스폰위치를 저장하는 구조로 다시 제작.
        vEnd = transform.position;
        vSpawn = transform.position;
    }

    void Start()
    {
    }

    // 동작전이 코드
    // Idle에서 Walk로 전이하기 위한 코드
    public void SetEndPosition()
    {
        // 몬스터 생성 위치로 부터 일정한 범위안에서만 이동할수 있도록 코드 작성
        int nR = Random.Range(0, 10);
        if( nR == 0 || nR == 4 || nR == 9)
        {
            float dx = Random.Range(-3f, 3f);
            float dz = Random.Range(-3f, 3f);
            vEnd.x = vSpawn.x + dx;
            vEnd.z = vSpawn.z + dz;
        }
    }

    public void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position,
            vEnd, Time.deltaTime * 1f);
    }

    public void Rotate()
    {
        Vector3 targetDir = vEnd - transform.position;

        if (Vector3.Dot(targetDir.normalized, transform.forward).CompareTo(0.99f) >= 0)
            return;

        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir.normalized,
            Time.deltaTime * 4f, 0);
        transform.rotation = Quaternion.LookRotation(newDir);
    }

    void Update()
    {
        
    }
}
