using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class head_follow : MonoBehaviour
{
    public Transform shoebill, player;

    void Update()
    {
        shoebill.transform.LookAt(new Vector3(player.position.x, player.position.y, player.position.z));    
    }
}
