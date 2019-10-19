using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine.SceneManagement;


public class User : MonoBehaviour
{
    public static String usermail;
    public static String userID;
    public String email;
    public String uid;
    public Double score;
    public int coin;
    public int currentCharactor;
    public bool[] purchesesCharactor;

    public DatabaseReference db; // Call Database in Firebase for Write Data

    // Start is called before the first frame update
    void Start()
    {
        // Call For Database
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://testfirebase-b970e.firebaseio.com/");
        db = FirebaseDatabase.DefaultInstance.RootReference;
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    // Test Only
    public void setUser(String username) {
        email = username;
        coin = 500;
        currentCharactor = 0;
        purchesesCharactor = new bool[4] {true, false, false, false};
    }

    public void setUser(String username, String id) {
        email = username;
        uid = id;
        coin = 0;
        currentCharactor = 0;
        purchesesCharactor = new bool[4] {true, false, false, false};
    }

    public String getUser(String id) {
        return email;
    }


    public int getCoin(){
        return coin;
    }

    public int addCoin(){
        ++coin;
        return coin;
    }

    public int delCoin(int num){
        if(num < 0) {
            coin = coin+num;
            return coin;
        }
        else if (num > 0){
            coin = coin-num;
            return coin;
        }
        else
        {
            return coin;
        }
    }

    // Change Coin Text On Screen
    public void changeCoinText(){
        //coin;
    }

    public int setCurrentCharactor(int charID){
        return charID;
    }

    public int getCurrentCharactor(){
        return currentCharactor;
    }

    public bool[] updateChar(int indexOfChar){
        purchesesCharactor[indexOfChar] = true;
        Debug.Log(purchesesCharactor);
        return purchesesCharactor;
    }
    public string showData(){
        string userData = "Email: " + email + " coin: " + coin + " Buyed Char " + purchesesCharactor.ToString(); 
        return userData;
    }

}
