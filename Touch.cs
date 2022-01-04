using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Touch : MonoBehaviour
{ 
    int counter = 0;
    List <GameObject> clicked = new List<GameObject>();
    
    /*public delegate void OnScale();
	public static event OnScale OnScaled;*/
    
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
            var clickable = hit.transform.GetComponent<Block>().IsClickable;
            if(hit.collider != null && clickable == true)
            {   
                
                clicked.Add(hit.transform.gameObject);
                clicked[0].tag = "moving";
                //Debug.Log("clicked: " + clicked.Count);

                counter++;
                //Debug.Log("counter: " + counter);
                
                yield return new WaitUntil(ReadyToCompare);
                //if more than 2 clear list.

            }
        }
    }

    public bool ReadyToCompare()
    {
        if(counter > 1)
        {
            //clicked[0].GetComponent<Block>().IsClickable = true;
            //clicked[1].GetComponent<Block>().IsClickable = true;
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
        //CheckIfSame();
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
            clicked[0].transform.position = clicked[1].transform.position + new Vector3(0,1,0);
            clicked[0].transform.parent = clicked[1].transform.parent;
        }
    }




    /* 
    {
        //Renderer rend = hit.transform.GetComponent<MeshRenderer>();
        //Block hitBlock = hit.transform.GetComponent<Block>();
        //hitBlock.Init(Color.red, false, 1);

        Renderer rend = hit.transform.GetComponent<MeshRenderer>();
        Material blockMat = rend.material;
        Color currentCol = blockMat.color;

        clicked = true;
        blockMat.DOColor(Color.white, 1f);

        yield return new WaitForSeconds(2);
                
        blockMat.color = currentCol;

        Block block;

        public void Initialize(Block block)
        {
            this.block = block;
        }

    }*/


}
