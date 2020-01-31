using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTextController : MonoBehaviour
{
    public GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    void uText(string s)
    {
        text.GetComponent<AutoText>().UpdateText(s);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
