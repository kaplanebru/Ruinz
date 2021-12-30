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
        return this;
    }
 
    void Update()
    {
        if(isClickable == true)
        {
            transform.tag = "clickable";
        }
      
        ChangeColor();
    }

    void ChangeColor()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rend.material.color = Color.red;
            Debug.Log("sPACE");
        }
    }

}
