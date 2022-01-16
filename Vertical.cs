using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Vertical : ColumnManager
{
    private void Awake() 
    {
        direction = transform.position.y;
        posX = transform.position.x;
    }
    public Vertical()
    {
        amount = 3;
        posY = posDir;
        baseSize = 1.5f;
        startSize = 0.2f;
    }

    public override void SpawnBlocks(int i)
    {
        base.SpawnBlocks(i);
        columnList[columnList.Count-1].tag = "clickable";
        Tweening(i);
    }

    void Tweening(int i)
    {
        brick.transform.DOScaleY(endSize, ease);
        brick.transform.DOMoveY(baseSize + transform.position.y + i, ease);
    }

}
