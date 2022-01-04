using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    Renderer rend;
    Color col;
    int columnId;
    private bool isClickable = false;

    public bool IsClickable { get => isClickable; set => isClickable = value; }

    void Awake()
    {   
        rend = gameObject.GetComponent<MeshRenderer>();
  
    }
    
	
    [SerializeField]
    public Block Init(Color col, bool isClickable, int columnId)
    {
        this.rend.material.color = col;
        this.IsClickable = isClickable;
        this.columnId = columnId;
        return this;
    }
 
    void Update()
    {
        if(IsClickable == true)
        {
            transform.tag = "clickable";
        }
        else
        {
            transform.tag = "not clickable";
        }

    }

   

    


}
