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
using RSG;
using System.Threading.Tasks;

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
    async void Start()
    {
        
        // Debug.Log(user.ToString());
        Character ch1 = await getDatafromDatabase("CH0001");
        Debug.Log("30: Display ch1 Data: " + ch1);
        
        // Character ch2 = new Character();
        // User newUser = new User(usernameInput.Text);
        // submitActionCallback callback = new submitActionCallback(); 
        // 
        // submitButton.onClick.AddListener(() => submitAction(usernameInput.text, "112"));
        
        // getButton.onClick.AddListener(() => getDatafromDatabase());
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
    public async Task<Character> getDatafromDatabase(String id){
        Character character = new Character();

        RestClient.Get("https://testfirebase-b970e.firebaseio.com/Character/" + id + ".json").Then(response => {
            String responseString = response.Text.ToString();
            Debug.Log("response: " + responseString);
            character = Character.firebaseResponse(responseString);
            Debug.Log("Character: " + character);
        });
        await new WaitUntil(() => character.getID() != null);
        return character;
    }

    public void getUser(){
        // getDatafromDatabase();
        
    }

}
