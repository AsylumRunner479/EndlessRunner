using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneFollow : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    
    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = player.position;
        transform.position = new Vector3(0, playerPos.y, playerPos.z);
    }
}
