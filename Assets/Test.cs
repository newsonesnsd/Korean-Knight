using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Proyecto26;
// using Firebase.Auth;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEditor;
using UnityEngine.SceneManagement;


public class Test : MonoBehaviour
{
    public Button submitButton;
    public Button getButton;
    public InputField usernameInput; 
    private const string projectId = "testfirebase-b970e"; // You can find this in your Firebase project settings
    private static readonly string databaseURL = $"https://testfirebase-b970e.firebaseio.com/";
    Character newChar = new Character();
    Character user = new Character();
    // Start is called before the first frame update
    void Start()
    {
        
        Debug.Log(user.ToString());
        Character ch1 = new Character();
        // User newUser = new User(usernameInput.Text);
        // submitActionCallback callback = new submitActionCallback(); 
        // 
        // submitButton.onClick.AddListener(() => submitAction(usernameInput.text, "112"));

        getButton.onClick.AddListener(() => getDatafromDatabase());
        Debug.Log("n");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void submitAction(String name, String id){
        User user = new User();
        user.setUser(name, id);
        RestClient.Put<User>($"{databaseURL}users/{name}.json", user).Then(response => { 
            Debug.Log("The user was successfully uploaded to the database");
            Debug.Log("Fuck You");
        });
    }
    public void getDatafromDatabase(){
        // Debug.Log("Call Functuin");
        // string name = "CH0001";
        
        // Debug.Log("https://testfirebase-b970e.firebaseio.com/Character/" + name +".json");
        // RestClient.Get("https://testfirebase-b970e.firebaseio.com/Character" + name + ".json").Then(response =>
        //     {
        //         user=response;
        //     });
        // Debug.Log("End");
        // Debug.Log(user.characterId);
        // Debug.Log(user.characterName);
        // Debug.Log(user.price);

        RestClient.Get("https://testfirebase-b970e.firebaseio.com/Character/CH0001.json").Then(response => {
            Debug.Log(response.Text.ToString());
            JsonUtility.FromJsonOverwrite(response.Text.ToString(), user);
            Debug.Log(user);
        });    
    }

    public void getUser(){
        getDatafromDatabase();
        

    }

}
