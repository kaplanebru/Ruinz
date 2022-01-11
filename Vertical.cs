using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public override void SpawnColumn(int amount)
    {
        base.SpawnColumn(amount);
        columnList[columnList.Count-1].tag = "clickable";
    }

}
