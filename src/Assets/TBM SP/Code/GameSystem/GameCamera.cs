using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera:MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var player=Player.GetTransform();
        var pos=transform.position;
        if(player!=null)
        {
           pos.x=player.position.x; 
        }
        transform.position=pos;
    }
}
