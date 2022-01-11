using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    Renderer rend;
    Color col;
    public int blockId;
    public bool locked;

    //[SerializeField] 
    /*private bool isClickable = false;

    public bool IsClickable 
    { 
        get {return isClickable;} 
        set
        {
            if(value == true)
                transform.tag = "clickable";
            else
            isClickable = value;
        }  
    }*/

    void Awake()
    {   
        rend = gameObject.GetComponent<MeshRenderer>();
    }
    
	
    [SerializeField]
    public Block Init(Color col, string tag, bool locked)
    {
        this.rend.material.color = col;
        this.transform.tag = tag;
        //this.IsClickable = isClickable;
        //this.blockId = blockId;
        this.locked = locked;
        //this.colorId
        return this;
    }

    public void DebugYoko()
    {
        Debug.Log("Yoko");
    }
 

   

    


}
