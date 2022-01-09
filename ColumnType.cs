using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



[CreateAssetMenu(fileName = "New Column Type", menuName = "Column Type")]


[System.Serializable]
public class ColumnType : ScriptableObject
{
    Color blockColor;
    int num;
    public int amount = 5;
    //internal Color[] colorSet = {Color.red, Color.green, Color.blue, Color.yellow};
    public int[] colorId;
    
    
    
    public void Awake() 
    {
        colorId = new int[amount];
        //colorSet  = new Color[amount];
    }

    void ColorId(int amount) //ce n'etait plus durable
    {
        for (int i=0; i<amount; i++)
        {
            colorId[i] = num;
        }
    }

    //COLOR SET NUMBER - COLOR DICT YAP

    //URGENT: il faut faire attention a colorSet[0]:
    // tjrs faire une double check avec le pickup color tool
    //+faut faire le meme control entre autre scriptable objects

    /*void ColorSet(int amount)
    {
        for (int i=0; i<amount; i++)
        {
             colorSet[i] = blockColor;
            //EditorUtility.SetDirty(this);
        }
    }*/

    

}
