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


    // Start is called before the first frame update
    void Start()
    {
        // User newUser = new User(usernameInput.Text);
        // submitActionCallback callback = new submitActionCallback(); 
        submitButton.onClick.AddListener(() => submitAction(usernameInput.text, "112"));
        getButton.onClick.AddListener(() => getUser(usernameInput.text));
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

    public void getUser(string username){
        // RestClient.Put<User>($"{databaseURL}users/{usernameInput.text}.json", user)
        RestClient.Get($"{databaseURL}users/{username}.json").Then(response => {
            // EditorUtility.DisplayDialog("Response", response.Text.ToString(), "Ok");
            Debug.Log(response.Text);
            Debug.Log(response.Text.ToString());
            // Debug.Log();
        });
    }

}
