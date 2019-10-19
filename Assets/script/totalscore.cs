using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class totalscore : MonoBehaviour
{
    public static string[] questionKoreanWord = new string[25] {null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null};
    public static string[] questionThaiWord = new string[25] {null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null};
    public static bool?[] answer = new bool?[25] {null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null};

    public Text[] koreanWordText = new Text[25];
    public Text[] thaiWordText = new Text[25]; 
    public Image[] correctImage = new Image[25];
    public Image[] wrongImage = new Image[25];
    public Button returnImage;
    // Start is called before the first frame update
    void Start()
    {
        showTotal();
        returnImage.onClick.AddListener(() => backToHome());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showTotal(){
        for (int i = 0; i < 25; i++)
        {
            koreanWordText[i].text = questionKoreanWord[i];
            thaiWordText[i].text = questionThaiWord[i];
            //Bug From Pramuk Code
            if (answer[i] == null)
            {
               koreanWordText[i].text = "";
                thaiWordText[i].text = ""; 
            }
            listAnswerImage();
        }
    }

    public void listAnswerImage(){
        for (int i = 0; i < 25; i++)
        {
            if (answer[i] == true)
            {
                showCorrectImage(i);
            }
            else if (answer[i] == false)
            {
                showWrongImage(i);
            }
            else
            {
                hideAllAnswerImage(i);
            }
        }        
    }

    public static void addQuestionKoreanWord(int index, string koreanWord){
        questionKoreanWord[index] = koreanWord;
    }

    public static void addQuestionThaiWord(int index, string thaiWord){
        questionThaiWord[index] = thaiWord;
    }

    public static void updateAnswer(int index, bool bol){
        answer[index] = bol;
        showLogAnswer();
    }

    public static void clearData(){
        questionKoreanWord = new string[25] {null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null};
        questionThaiWord = new string[25] {null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null};
        answer = new bool?[25] {null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null};
    }

    public void showCorrectImage(int i){
        hideWrongImage(i);
    }

    public void showWrongImage(int i){
        hideCorrectImage(i);
    }

    public void hideCorrectImage(int i){
        correctImage[i].enabled = false;
    }

    public void hideWrongImage(int i){
        wrongImage[i].enabled = false;
    }

    public void hideAllAnswerImage(int i){
        hideCorrectImage(i);
        hideWrongImage(i);
    }

    public static void showLogAnswer(){
        string showAns = "";
        for (int i = 0; i < 25; i++)
        {
            showAns = answer[i] + " ";
        }
        Debug.Log(showAns);
    }



    public void backToHome(){
        SceneManager.LoadScene("Home");
    }

}
