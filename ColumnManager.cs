using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnManager : ColumnSpawner
{
    public delegate void Empty(); //avant y'avait le base + void
    public static event Empty OnEmpty;

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
            //GameObject leBase = firstBrick.transform.parent.transform.parent.gameObject;
            
            if(OnEmpty != null)
            {
                OnEmpty();
            }
        }
    }

    void AddBrick(GameObject firstBrick)
    {
        columnList.Add(firstBrick); // movingBrick ne marche ici car il compris tt les terminal bricks dans le scene.
        //reste une
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
