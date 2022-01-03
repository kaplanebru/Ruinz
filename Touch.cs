using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Touch : MonoBehaviour
{   
    
    bool clickable;
    int counter = 0;
    List <GameObject> clicked = new List<GameObject>();

    /*public delegate void ClickAction();
	public static event ClickAction OnClicked;*/
    //GameObject[] clicked = new GameObject[1];
 
    void Start() 
    {
        DOTween.Init();
        
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Touched();
            
        }

        
        

    }

    void Touched()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {

            if(hit.collider != null && hit.transform.tag == "clickable")
            {   
                //not clickable
                //Renderer rend = hit.transform.GetComponent<MeshRenderer>();

                
                hit.transform.GetComponent<Block>().Init(Color.red, true);
                clicked.Add(hit.transform.gameObject);
                Debug.Log("clicked: " + clicked.Count);

                counter++;
                Debug.Log("counter: " + counter);
                DebugClicked();

                if(counter>1)
                {
                    Compare();
                    clicked.Clear();
                    counter = 0;
                }
   
                //yield return new WaitUntil(isClicked);
                //if more than 2 clear list.

            }

        }
    }

    public bool isClicked()
    {
        if(counter > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void DebugClicked()
    {
        Debug.Log(clicked[0]);
    }
    void Compare()
    {
        Color[] col = new Color[2];

        for(int i=0; i<2; i++)
        {
            col[i] = clicked[i].GetComponent<MeshRenderer>().material.color;
        }
        
        if (col[0]==col[1])
        {
            clicked[0].transform.position = clicked[1].transform.position + new Vector3(0,1,0);
        }
        //color id
    }




    /* IEnumerator Touched()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {

            if(hit.collider != null && hit.transform.tag == "clickable")
            {   
                Renderer rend = hit.transform.GetComponent<MeshRenderer>();
                Material blockMat = rend.material;
                Color currentCol = blockMat.color;

            
                clicked = true;
                blockMat.DOColor(Color.white, 1f);


                yield return new WaitForSeconds(2);
                
                blockMat.color = currentCol;
            }
        }
    }*/


}
