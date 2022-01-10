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
    protected float endSize = 1f;
    protected float StartSize = 0.2f;
    protected float baseSize = 1.5f;
    public int amount = 3;
    
    public Color[] colorSet;

    [SerializeField]
    protected List<GameObject> columnList = new List<GameObject>();

    void Start()
    {
        //amount = columnType.amount;
        SpawnColumn(amount);
        DOTween.Init();
        
        colorSet = new Color[amount];
        columnList[columnList.Count-1].tag = "clickable";
    }

    void SpawnColumn(int amount)
    {
        for(int i=0; i<amount; i++)
        {
           SpawnBlocks(i, 2f); //amount-i
        }     
    }

    void SpawnBlocks(int i, float ease)
    {
        var brick = Object.Instantiate(blockPb, SpawnDirPos(i), transform.rotation);
        var brickS = brick.GetComponent<Block>();

        brickS.Init(colorSet[i], "Untagged", i); 
        brick.transform.parent = column.transform;

        Tweening(brick, ease, i);

        columnList.Add(brick);
        //Debug.Log(columnType.colorSet[i]);
            
    }

    public virtual Vector3 SpawnDirPos(int i)
    {
        var posDir = transform.position.y + i*StartSize; // + 1.1f
        Vector3 pos = new Vector3(transform.position.x, posDir, transform.position.z);
        return pos;
    }

    void Tweening(GameObject brick, float ease, int i)
    {
        brick.transform.DOScaleY(endSize, ease);
        brick.transform.DOMoveY(baseSize + i, ease);
    }

    

}

