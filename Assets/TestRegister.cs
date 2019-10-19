using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TestRegister : MonoBehaviour
{
    // Start is called before the first frame update
    private FirebaseAuth auth;
    public InputField email;
    public InputField uid;
    public Button submitButton;
    public DatabaseReference db;
    public bool[] purchesesCharactor = new bool[7] {true, false, false, false, false, false, false};
    void Start()
    {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://testfirebase-b970e.firebaseio.com");
        db = FirebaseDatabase.DefaultInstance.RootReference;
        int num = 5;
        submitButton.onClick.AddListener(() => Register("Somsak", "Jeam" + num));
        num++;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Register(string email, string uid){
        //PlayerPrefs.SetString("email: " + email);
        //PlayerPrefs.SetString("uid: " + uid);

        // Add Data to User
        int num = 112;
        Debug.LogFormat("Add Fucking Data Sucess" + num);
        db.Child("user").Child("1").Child("email").SetValueAsync(email);
        // db.Child("user/"+email).Child("userId").SetValueAsync(uid);
        // db.Child("user/"+email).Child("coin").SetValueAsync(0);
        // db.Child("user/"+email).Child("currentCharactor").SetValueAsync(0);
        // db.Child("user/"+email).Child("purchesesCharactor").SetValueAsync(purchesesCharactor);
        // db.Child("user/"+email).Child("score").SetValueAsync(0);
        
        Debug.LogFormat("Add Fucking Data Sucess2" + ++num);
    }
}
