using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Horizontal : ColumnSpawner
{
    /*private void Awake() 
    {
        direction = transform.position.x;
        posY = transform.position.y;
    }*/

    
    public Horizontal()
    {
        amount = 3;
        baseSize = 0.5f; //pour qu'il ne se meut en arriere - parce que le demicube: 0.5
        startSize = 0.2f;
        //posX = posDir;
    }

    public override Vector3 SpawnDirPos(int i)
    {
        Vector3 pos = new Vector3(transform.position.x + i*startSize, transform.position.y, transform.position.z);
        return pos;
    }

    public override void Tweening(GameObject brick, float ease, float endSize, int i)
    {
        brick.transform.DOScaleY(endSize, ease);
        brick.transform.DOMoveX(baseSize + transform.position.x + i, ease);
    }

    //tag en tant que locked: si on hit sur locked, on va recevoir une message d'error.

    //on peut utiliser comme une ESCALIER

    /*public override void Tweening(GameObject brick, float ease, float endSize, int i)
    {
        base.Tweening(brick, ease, endSize, i);
        brick.transform.DOMoveX(baseSize + transform.position.x + i, ease);
    }*/
}

