using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ColumnSpawner : MonoBehaviour
{   [SerializeField] private ColumnType columnType = null;
    int amount;
    public GameObject blockPb;
    public GameObject column;
    float endSize = 1f;
    float StartSize = 0.2f;
    float baseSize = 1.5f;

    List<GameObject> columnL = new List<GameObject>();

    void Start()
    {
        amount = columnType.amount;
        SpawnBlocks(amount);
        DOTween.Init();

        //Debug.Log(baseSize);
    }

    void Update()
    {
        
    }
  
    void SpawnBlocks(int amount)
    {
        for(int i=0; i<amount; i++)
        {
           SpawnBlock(i, 2f);
        }
        columnL[columnL.Count-1].gameObject.GetComponent<Block>().isClickable = true;
    }


    void SpawnBlock(int i, float ease)
    {
       
        var posy = transform.position.y + i*StartSize; // + 1.1f
        Vector3 pos = new Vector3(transform.position.x, posy, transform.position.z);
        
        var brick = Object.Instantiate(blockPb, pos, transform.rotation);
        var brickS = brick.GetComponent<Block>();

        brickS.Init(columnType.colorSet[i], false); //colorPalette[Random.Range(0, 3)]
        brick.transform.parent = column.transform;

        brick.transform.DOScaleY(endSize, ease);
        brick.transform.DOMoveY(baseSize + i, ease);

        columnL.Add(brick);
    
    }
}

