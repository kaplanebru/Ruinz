using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour
{   
    public bool clicked = false;
 
    void Update()
    {
        Touched();
    }

    private void Touched()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                if(hit.collider != null && hit.transform.tag == "clickable")
                {
                    //counter++;
                    clicked = true;
                    Debug.Log("yo");
                    
                }
            }
        }
    }
}
