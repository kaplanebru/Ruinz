using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Horizontal : ColumnSpawner
{

    private void Awake() 
    {
        var baseRenderer = column.transform.parent.GetComponent<MeshRenderer>();
        if(baseRenderer != null)
        {
            baseRenderer.enabled = false;
        }
    }
    
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



    public override void SpawnBlocks(int i)
    {
        base.SpawnBlocks(i);
        Tweening(i);
    }

    public virtual void Tweening(int i)
    {
        brick.transform.DOScaleY(endSize, ease);
        brick.transform.DOMoveX(baseSize + transform.position.x + i, ease);
    }

    /*public override void Tweening(GameObject brick, float ease, float endSize, int i)
    {
        brick.transform.DOScaleY(endSize, ease);
        brick.transform.DOMoveX(baseSize + transform.position.x + i, ease);
    }*/

    /*public override void SpawnColumn(int amount)
    {
        base.SpawnColumn(amount);
        for(int j=0; j<amount; j++)
        {
            //columnList[j].tag = "locked";
            columnList[j].GetComponent<Block>().locked = true;
        }   
    }*/

    //tag en tant que locked: si on hit sur locked, on va recevoir une message d'error.

    //on peut utiliser comme une ESCALIER

}

