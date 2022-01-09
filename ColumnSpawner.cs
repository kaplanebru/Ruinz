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
    }

    void SpawnColumn(int amount)
    {
        for(int i=0; i<amount; i++)
        {
           SpawnBlocks(i, 2f); //amount-i
        }
        columnList[columnList.Count-1].tag = "clickable";
        //columnType.colorSet[0] = columnType.colorSet[1];
        
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
        //Debug.Log(columnType.colorSet[i]);
        
    }

    private void OnEnable()
    {
        BlockManager.OnTransposition += UpdateColumn;
    }

    private void OnDisable() 
    {
        BlockManager.OnTransposition -= UpdateColumn;
    }

    void UpdateColumn(GameObject firstBrick, Transform column2)
    //column2: c.a.d column du deuxiemme brick
    {
        if(columnList.Count > 0)
        {
            var movingBrick = columnList[columnList.Count-1];
            if(firstBrick == movingBrick)
            {
                RemoveBrick(firstBrick, movingBrick);
            }
        }

        if(column.transform == column2) 
            //ici on inspecte tt les columns 
            //avant c'etait: movingBrick.transform.parent == column2
            {
                AddBrick(firstBrick);
            }

    }

    void RemoveBrick(GameObject firstBrick, GameObject movingBrick)
    {
        columnList.Remove(movingBrick);
        if(columnList.Count > 0)
        {
            columnList[columnList.Count-1].tag = "clickable";
        }
        else
        {
            GameObject leBase = firstBrick.transform.parent.transform.parent.gameObject;
            leBase.tag = "clickable";
        }
    }

    void AddBrick(GameObject firstBrick)
    {
        columnList.Add(firstBrick); // movingBrick ne marche ici car il compris tt les terminal bricks dans le scene.
        if(columnList.Count > 1)
        {
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

