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
    Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        ani.SetInteger("iAniIndex", 1);
        ani.SetInteger("iAniIndex", 2);
        ani.SetInteger("iAniIndex", 3);
        ani.SetTrigger("triger");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
