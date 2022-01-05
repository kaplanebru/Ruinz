using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BlockManager : MonoBehaviour
{ 
    int counter = 0;
    List <GameObject> clicked = new List<GameObject>();
    
    
    void Start() 
    {
        DOTween.Init();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Touched());
        }
    }

    IEnumerator Touched()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            //var clickable = hit.transform.GetComponent<Block>().IsClickable;
            if(hit.collider != null && hit.transform.tag == "clickable")//clickable == true)
            {   
                clicked.Add(hit.transform.gameObject);
                clicked[0].tag = "moving";
                
                counter++;
                
                yield return new WaitUntil(ReadyToCompare);
                //if more than 2 clear list.

            }
        }
    }

    public bool ReadyToCompare()
    {
        
        if(counter > 1)
        {
            //clicked[0] ve [1] isclickable;
            Compare(counter);

            clicked.Clear();
            counter = 0;
            return true;
        }
        else
        {
            return false;
        }
    }

    void Compare(int counter)
    {
        //checkIfSame
        if(clicked[0] == clicked[1])
        {
            clicked.Clear();
            return;
        }

        Color[] col = new Color[2];

        for(int i=0; i<2; i++)
        {
            col[i] = clicked[i].GetComponent<MeshRenderer>().material.color;
        }
        
        if (col[0]==col[1])
        {
            MoveRuin();
        }
        else if(clicked[1].name == "Cube")
        {
            MoveIfEmpty();
        }
        else
        {
            Debug.Log("No match");
            //set fx. life time: 1 second.
        }
    }
    void MoveRuin()
    {
        clicked[0].transform.position = clicked[1].transform.position + new Vector3(0,1,0);
        clicked[0].transform.parent = clicked[1].transform.parent;
    }
    void MoveIfEmpty()
    {
        clicked[0].transform.position = clicked[1].transform.position + new Vector3(0,1,0);
        clicked[0].transform.parent = clicked[1].transform.GetChild(0);
        clicked[1].tag = "Untagged";
    }




}