using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Vocab
{
    public String vacabId;
    public String koreaWord;
    public String thaiWord;
    public String englishWord;
    public String pronunciation;
    public String categoryID;

    public override string ToString(){
			return UnityEngine.JsonUtility.ToJson (this, true);
		}

}
