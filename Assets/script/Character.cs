using Proyecto26;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Database;
using Firebase.Unity.Editor;

public class Character : MonoBehaviour
{
    public string characterId;
    public string characterName;
    public int price;

    public Character(){

    }

    public Character(string id, string name, int rate) {
        characterId = id;
        characterName = name;
        price = rate;
    }
    // Start is called before the first frame update
    void Start()
    {
        //getData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Test Only อย่าแตะ
    public string getCID(){
        return characterId;
    }

    public string getcName(){
        return characterName;
    }

    public int getcPrice(){
        return price;
    }

    public void setCharacter(String charID){
        RestClient.Get<Character>("https://testfirebase-b970e.firebaseio.com/Character/" + charID +".json").Then(response =>
            {
                characterId = response.characterId;
                characterName = response.characterName;
                price = response.price;
                // return newChar;
            });
        
          
    }

}
