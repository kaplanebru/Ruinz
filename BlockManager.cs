using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BlockManager : MonoBehaviour
{ 
    int counter = 0;
    float defaultGlow = 0.6f;
    List <GameObject> clicked = new List<GameObject>();
    List <GameObject> theBase = new List<GameObject>();

    //GameObject theBase;
    
    
    public delegate void Transposition(GameObject brick, Transform column2);
	public static event Transposition OnTransposition;

    
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
            if(hit.collider != null && hit.transform.tag == "clickable")
            {   
                clicked.Add(hit.transform.gameObject);
                counter++;

                Glow(clicked[0], 0);
 
                yield return new WaitUntil(ReadyToCompare);
                //if more than 2 clear list.

            }
        }
    }

    public bool ReadyToCompare()
    {
        if(counter > 1)
        {
            Glow(clicked[0], defaultGlow);
            Compare(counter);
            clicked.Clear();
            counter = 0;
            return true;
        }
    return false;     
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
        //Debug.Log("col1: " + col[0] + "col2: " + col[1]);
        
        if (col[0]==col[1] || theBase.Contains(clicked[1]))
        //pendant le 2eme click, cad quand c'est clicked1, on evoque une nouvelle event qui pourrait changer le base.
        {
            MoveRuin();
            
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
        
        if(OnTransposition != null)
        {
            OnTransposition(clicked[0], checkClicked2()); 
        }

        SetParent();
    }

    Transform checkClicked2()
    {
        Transform column2;
        if(theBase.Contains(clicked[1]))
        {
            column2 = clicked[1].transform.GetChild(0);
            return column2;
        }
        else
        {
            column2 = clicked[1].transform.parent;
            return column2;
        }
    }

    void SetParent()
    {
       if(theBase.Contains(clicked[1]))//clicked[1].name == "Base" - clicked[1] == theBase
       {
            clicked[0].transform.parent = clicked[1].transform.GetChild(0);
            clicked[1].tag = "Untagged";
            theBase.Remove(clicked[1]);
            Glow(clicked[1], defaultGlow);
         
       }
       else
       {
           clicked[0].transform.parent = clicked[1].transform.parent;
       }
    }

    private void OnEnable() 
    {
        ColumnManager.OnEmpty += EmptyColumn;
    }
    private void OnDisable() 
    {
        ColumnManager.OnEmpty -= EmptyColumn;
    }

    void EmptyColumn()
    {
        //theBase = leBase;
        //theBase = clicked[0].transform.parent.transform.parent.gameObject;
        theBase.Add(clicked[0].transform.parent.transform.parent.gameObject);
        Debug.Log(theBase.Count);
        if(theBase.Count > 0)
        {
            for(int i=0; i<theBase.Count; i++)
            {
                theBase[i].tag = "clickable";
                Glow(theBase[i], 0);
            }
        }
        //theBase.tag = "clickable";
        
    }

    void Glow(GameObject obj, float i)
    {
        
        obj.GetComponent<MeshRenderer>().material.SetFloat("_Metallic", i);
        //obj.GetComponent<MeshRenderer>().material.EnableKeyword()
    }

   


    

}
