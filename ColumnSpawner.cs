using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEditor;

public class ColumnSpawner : MonoBehaviour
{ 
    //[SerializeField] private ColumnType columnType = null;
    public GameObject blockPb;
    public GameObject column;

    [SerializeField] protected int amount; 

    [SerializeField]
    protected List<GameObject> columnList = new List<GameObject>();
    protected float direction;
    protected float posX;
    protected float posY;
    protected float posDir;
    protected float baseSize;
    //float endSize = 1f;
    float StartSize = 0.2f;
    //float baseSize = 1.5f;
    //float ease = 2f;
    
    [SerializeField]
    Color[] colorSet;



    void Start()
    {
        //amount = columnType.amount;
        SpawnColumn(amount);
        DOTween.Init();
        colorSet = new Color[amount];
    }

    public virtual void SpawnColumn(int amount)
    {
        for(int i=0; i<amount; i++)
        {
           SpawnBlocks(i);
        }
    }

    void SpawnBlocks(int i)
    {
        var brick = Object.Instantiate(blockPb, SpawnDirPos(i), transform.rotation);
        var brickS = brick.GetComponent<Block>();

        brickS.Init(colorSet[i], "Untagged", i); 
        brick.transform.parent = column.transform;

        Tweening(brick, 2f, 1f, i);

        columnList.Add(brick);
        //Debug.Log(columnType.colorSet[i]);
            
    }

    Vector3 SpawnDirPos(int i)
    {
        posDir = direction + i*StartSize; // + 1.1f
        Vector3 pos = new Vector3(posX, posY, transform.position.z);
        return pos;
    }

    public virtual void Tweening(GameObject brick, float ease, float endSize, int i) //override edilebilir.
    {
        brick.transform.DOScaleY(endSize, ease);
        brick.transform.DOMoveY(baseSize + i, ease);
    }

    

}

