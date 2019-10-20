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

    public Character(string name){
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
    public string getID(){
        return characterId;
    }

    public string getName(){
        return characterName;
    }

    public int getPrice(){
        return price;
    }

    public string setCharacter(string charID){
        string json = null;
        RestClient.Get("https://testfirebase-b970e.firebaseio.com/Character/" + charID +".json").Then(response =>
            {
                json = response.Text.ToString();
                return json;
                // JsonUtility.FromJsonOverwrite(json);
                // Debug.Log(newChar);
                // return newChar;
            });
        return null;
          
    }

    public override string ToString(){
        string text = "CharacterID: " + characterId + " Name: " + characterName + " Price: " + price;
        return text;
    }

}
