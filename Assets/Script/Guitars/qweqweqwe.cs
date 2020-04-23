using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//FBX와 프리팹
/*
 FBX파일은 3D데이터의 원본 파일(3dmax로 작업)
 유니티에서는 MAX원본파일인 max파일을 지원하지만
 내부적으로 FBX포맷으로 다시 변환되어지기 떄문에
 속도가 느리다고 말할 수 있다.

프리팹(Prefab)


    3D데이터 : *.fbx
    2D데이터 : *.png
    사운드 데이터 : *.ogg
    */



public class qweqweqwe : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //카메라를 기준으로 마우스 위치로부터 모니터 안쪽으로 향하는 광선 생성
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo; 
            if(Physics.Raycast(ray,out hitInfo))
            {
                Debug.Log("교차한 게임 오브젝트 = " + hitInfo.collider.name);
                Debug.Log("교차한 위치 = " + hitInfo.point);
            }
        }
        
    }
}
