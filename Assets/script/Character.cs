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
    private string[] cId = new string[6];
    private string[] cName = new string[6];
    private int[] cPrice = new int[6];
    private int characterId;
    private string characterName;
    private int price;

    public Character(int id, string name, int rate) {
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

    // public void setId(string charId){
    //     id = charId;
    // }
    
    public string getId(int index){
        return cId[index];
    }

    // public void setName(string charName){
    //     name = charName;
    // }

    public string getName(int index){
        return cName[index];
    }

    // public void setPrice(int charPrice){
    //     this.charPrice = charPrice;
    // }

    public int getPrice(int index){
        return cPrice[index];
    }

    // private void getData(){
    //     RestClient.GetArray<Character>("https://testfirebase-b970e.firebaseio.com/Character.json").Then(response =>
    //     {
    //         for (int i = 0; i < response.Length; i++){
    //             cId[i] = response[i].characterId;
    //             cName[i] = response[i].characterName;
    //             cPrice[i] = response[i].price;
    //         }
    //     });
    // }

    // Test Only อย่าแตะ
    public int getCID(){
        return characterId;
    }

    public string getcName(){
        return characterName;
    }

    public int getcPrice(){
        return price;
    }

}
