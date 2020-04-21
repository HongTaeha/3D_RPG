using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Player player;
    Vector3 oldpos = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        player = player.GetComponent<Player>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LateUpdate() 
    {
        Vector3 deltapos = player.transform.position - oldpos;
        transform.position += deltapos;
        oldpos = player.transform.position;
    }
}
