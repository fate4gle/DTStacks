using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FancyTestClass
{


    public string name = "Jonas";
    public int age = 27;
    public string mood = "lazy";
    public float iq = 1.1f;

    public string MakeJson()
    {
        return JsonUtility.ToJson(this);
    }
    public void ProcessJSON(string s)
    {
        JsonUtility.FromJsonOverwrite(s, this);
    }
}
    
