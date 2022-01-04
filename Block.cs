using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    Renderer rend;
    Color col;
    public int blockId;

    //[SerializeField] 
    private bool isClickable = false;

    public bool IsClickable { get {return isClickable;} 
        set
        {
            if(value == true)
                transform.tag = "clickable";
                //add fx
            else
            isClickable = value;
        }  
    }

    void Awake()
    {   
        rend = gameObject.GetComponent<MeshRenderer>();
  
    }
    
	
    [SerializeField]
    public Block Init(Color col, bool isClickable, int blockId)
    {
        this.rend.material.color = col;
        //this.transform.tag = tag;
        this.IsClickable = isClickable;
        this.blockId = blockId;
        //this.colorId
        return this;
    }

    public void DebugYoko()
    {
        Debug.Log("Yoko");
    }
 
    void Update()
    {
        /*if(IsClickable == true)
        {
            transform.tag = "clickable";
        }
        else
        {
            transform.tag = "not clickable";
        }*/

    }

   

    


}
