using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Category
{
    public String categoryID;
    public String categoryName;

    public override string ToString()
    {
        return UnityEngine.JsonUtility.ToJson(this, true);
    }

}
