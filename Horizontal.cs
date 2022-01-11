using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Horizontal : ColumnSpawner
{
    private void Awake() 
    {
        direction = transform.position.x;
        posY = transform.position.y;
    }
    public Horizontal()
    {
        amount = 3;
        posX = posDir;
        baseSize = 0.5f; 
    }

    public override void Tweening(GameObject brick, float ease, float endSize, int i)
    {
        brick.transform.DOScaleY(endSize, ease);
        brick.transform.DOMoveX(baseSize + i, ease);
    }

    //tag en tant que locked: si on hit sur locked, on va recevoir une message d'error.

    /*on peut utiliser comme une ESCALIER

    public override void Tweening(GameObject brick, float ease, float endSize, float baseSize, int i)
    {
        base.Tweening(brick, ease, endSize, baseSize, i);
        brick.transform.DOMoveX(baseSize + i, ease);
    }*/
}

