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
    

    [SerializeField]
    public List<GameObject> columnList = new List<GameObject>();

    void Start()
    {
        amount = columnType.amount;
        SpawnColumn(amount);
        DOTween.Init();
        //Debug.Log(baseSize);
    }

    void SpawnColumn(int amount)
    {
        for(int i=0; i<amount; i++)
        {
           SpawnBlocks(i, 2f); //amount-i
        }
        columnList[columnList.Count-1].tag = "clickable";
        
    }

    void SpawnBlocks(int i, float ease)
    {
       
        var posy = transform.position.y + i*StartSize; // + 1.1f
        Vector3 pos = new Vector3(transform.position.x, posy, transform.position.z);
        
        var brick = Object.Instantiate(blockPb, pos, transform.rotation);
        var brickS = brick.GetComponent<Block>();

        brickS.Init(columnType.colorSet[i], "Untagged", i); 
        brick.transform.parent = column.transform;

        brick.transform.DOScaleY(endSize, ease);
        brick.transform.DOMoveY(baseSize + i, ease);

        columnList.Add(brick);
        
    }

    private void OnEnable()
    {
        BlockManager.OnTransposition += UpdateColumn;
    }

    private void OnDisable() 
    {
        BlockManager.OnTransposition -= UpdateColumn;
    }

    void UpdateColumn(GameObject brick, Transform column)
    {
        var movingBrick = columnList[columnList.Count-1];
        if(brick == movingBrick)
        {
            columnList.Remove(movingBrick);
            columnList[columnList.Count-1].tag = "clickable";
            
        }
        else if(movingBrick.transform.parent == column)
        {
            columnList.Add(brick);
            columnList[columnList.Count-2].tag = "Untagged";
        }
    }


    

    //ALTERNATIVE APROACH
    /*if (column.transform.childCount < columnList.Count)
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
            column.transform.parent.tag = "clickable";
            //add glow fx
        }*/


}

