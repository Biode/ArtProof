using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSwap : MonoBehaviour
{
    public Material Purple, Teal, Tan, Blue, White;

    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<Renderer>().material = Tan;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            GetComponent<Renderer>().material = Tan;
        }
        if (Input.GetKeyDown("2"))
        {
            GetComponent<Renderer>().material = Purple;
        }
        if (Input.GetKeyDown("3"))
        {
            GetComponent<Renderer>().material = Teal;
        }
        if (Input.GetKeyDown("4"))
        {
            GetComponent<Renderer>().material = White;
        }
        if (Input.GetKeyDown("5"))
        {
            GetComponent<Renderer>().material = Blue;
        }
    }
}
