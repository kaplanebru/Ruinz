using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ColumnSpawner : MonoBehaviour
{ 
    [SerializeField] private ColumnType columnType = null;
    int amount;
    public GameObject blockPb;
    public GameObject column;
    float endSize = 1f;
    float StartSize = 0.2f;
    float baseSize = 1.5f;
    

    /*public delegate void EmptyColumn();
	public static event EmptyColumn OnEmptyColumn;*/

    [SerializeField]
    public List<GameObject> columnList = new List<GameObject>();

    void Start()
    {
        amount = columnType.amount;
        SpawnBlocks(amount);
        DOTween.Init();
        //Debug.Log(baseSize);
    }



    void Update()
    {
        UpdateColumn();
    }

  
    void SpawnBlocks(int amount)
    {
        for(int i=0; i<amount; i++)
        {
           SpawnBlock(i, 2f); //amount-i
        }
        //columnList[columnList.Count-1].gameObject.GetComponent<Block>().IsClickable = true;
        
    }

    void SpawnBlock(int i, float ease)
    {
       
        var posy = transform.position.y + i*StartSize; // + 1.1f
        Vector3 pos = new Vector3(transform.position.x, posy, transform.position.z);
        
        var brick = Object.Instantiate(blockPb, pos, transform.rotation);
        var brickS = brick.GetComponent<Block>();

        brickS.Init(columnType.colorSet[i], false, i); //colorPalette[Random.Range(0, 3)] 
        //brickS.Init(columnType.colorSet[i], false, i).DebugYoko();
        brick.transform.parent = column.transform;

        brick.transform.DOScaleY(endSize, ease);
        brick.transform.DOMoveY(baseSize + i, ease);

        columnList.Add(brick);
    
    }

    void UpdateColumn()
    {
        if (column.transform.childCount < columnList.Count)
        {
            var movingBrick = columnList[columnList.Count-1];
            columnList.Remove(movingBrick);

        }
        else if(column.transform.childCount > columnList.Count)
        { 
            var moving = GameObject.FindGameObjectWithTag("moving");
            columnList.Add(moving);
            moving.tag = "Untagged";
        }
        else if(column.transform.childCount == 0)
        {
            //transform.GetChild(0).tag = "clickable";
            column.transform.parent.tag = "clickable";
            //add glow fx
            //OnEmptyColumn();
        }
        Clickability();
    }

    void Clickability()
    {
        for(int i = 0; i < columnList.Count; i++)
        {
            if(i==columnList.Count-1)
            {
                //columnList[i].gameObject.GetComponent<Block>().IsClickable = true;
                columnList[i].tag = "clickable";
            }
            else
            {
                //columnList[i].gameObject.GetComponent<Block>().IsClickable = false;
                columnList[i].tag = "Untagged";
            }
        }

    }

}

