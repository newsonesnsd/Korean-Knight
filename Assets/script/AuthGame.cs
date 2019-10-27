using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Firebase.Auth;
using Firebase.Database;
using Proyecto26;

public class AuthGame : MonoBehaviour
{
    private FirebaseAuth auth;
    public InputField email_input, password_input;
    public Button SignupButton, SigninButton;
    private FirebaseDatabase db;

    public String tempEmail;
    public String tempUid;

    public Image popupImage;
    public Button exitButton; 
    public Text popupText;

    private const string projectId = "testfirebase-b970e"; 
    private static readonly string databaseURL = $"https://testfirebase-b970e.firebaseio.com/";

    private bool checkRegis = false;

    // Use this for initialization
    public void Start()
    {
        hidePopup();
        db = FirebaseDatabase.DefaultInstance;
        auth = FirebaseAuth.DefaultInstance;

        SignupButton.onClick.AddListener(() => Signup(email_input.text, password_input.text));
        SigninButton.onClick.AddListener(() => LoginAction(email_input.text, password_input.text));
        exitButton.onClick.AddListener(() => hidePopup());
    }

    void Update() 
    {
        
    }

    public void Signup(string email, string password)
    {
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            //Error handling
            showPopup("Please enter email or password");
            return;
        }

        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync error: " + task.Exception);
                if (task.Exception.InnerExceptions.Count > 0)
                    showPopup("Duplicate Username");
                return;
            }

            FirebaseUser firebaseUser = task.Result; // Firebase user has been created.
            tempEmail = firebaseUser.Email;
            tempUid = firebaseUser.UserId;
            putUser(tempEmail, tempUid);
            showPopup("Signin Success!");
            Debug.LogFormat("Firebase user created successfully: {0} ({1})",
                firebaseUser.Email, firebaseUser.UserId);
            
        });
    }

    public void LoginAction(string email, string password)
    {
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                {
                    //Error handling
                    showPopup("Please enter email or password");
                    return;
                }
                
                Debug.LogError("SignInWithEmailAndPasswordAsync error: " + task.Exception);
                showPopup("Wrong Username or Password");
                if (task.Exception.InnerExceptions.Count > 0)
                    showPopup("Wrong Username or Password");
                return;
            }
            if (task.IsCompleted) {
                FirebaseUser user = task.Result;
                Debug.LogFormat("User signed in successfully: {0} \n" +
                    "User ID: ({1})", user.Email, user.UserId);
                String loginEmail = user.Email;
                String uid = user.UserId;
                // PlayerPrefs.SetString("LoginUser", user != null ? user.Email : "Unknown");
                User.usermail = loginEmail;
                User.userID = uid;
                SceneManager.LoadSceneAsync("Home");
                // StartCoroutine(LoadNewScene());
            }
        });
    }


    public void putUser(String mail, String id){
        User user = new User();
        user.setUser(mail, id);
        // name = tempEmail+"";
        // RestClient.Put<User>($"{databaseURL}users/{name}.json", user).Then(response => { 
        RestClient.Put<User>($"{databaseURL}users/{tempUid}.json", user).Then(response => { 
            Debug.Log("The user was successfully uploaded to the database");
            Debug.Log("Fuck You");
        });
    }

    public void hidePopup(){
        popupImage.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
        popupText.text = "";
    }

    public void showPopup(String message){
        popupImage.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
        popupText.text = message;
    }

    IEnumerator LoadNewScene()
    {

        yield return new WaitForSeconds(1);

        AsyncOperation async = SceneManager.LoadSceneAsync("Home");
        while (!async.isDone)
        {
            yield return null;
        }
    }
    
}