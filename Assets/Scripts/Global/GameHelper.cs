using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eLayer { Player= 7, Monster = 8 }

static public class GameHelper
{
    static public Vector3? GetYpos(Vector3 pos, eLayer layer){
        Vector3 raypos = pos;
        raypos.y += 50f;

        RaycastHit hitInfo;
        int layermask = 1 << (int)layer;;
        layermask = ~layermask;


        Vector3 returnpos = pos;
        if(Physics.Raycast(raypos, -Vector3.up, out hitInfo, Mathf.Infinity, layermask)){
            returnpos.y = hitInfo.point.y;
            return returnpos;
        }
        return null;
        
    }
}
