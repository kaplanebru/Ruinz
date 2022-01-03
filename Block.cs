using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    Renderer rend;
    Color col;
    public bool isClickable = false;

    void Awake()
    {   
        rend = gameObject.GetComponent<MeshRenderer>();
  
    }
    
	

    public Block Init(Color col, bool isClickable)
    {
        this.rend.material.color = col;
        this.isClickable = isClickable;
        //this.clicked = clicked;
        return this;
    }
 
    void Update()
    {
        if(isClickable == true)
        {
            transform.tag = "clickable";
        }
        else
        {
            transform.tag = "not clickable";
        }

    }

   

    


}
