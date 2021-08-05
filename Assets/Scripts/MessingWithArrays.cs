using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessingWithArrays : MonoBehaviour
{
    //[SerializeField] <- for private if you do private
    public string[] myStringArray;
    public int x = 0;
    // Start is called before the first frame update
    void Start()
    {

        //Debug.Log( myStringArray[x] );


        myStringArray[x] = "Whatever I want";
        //Debug.LogWarning(myStringArray[1]);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
