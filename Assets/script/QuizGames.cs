using Proyecto26;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Quizgames : MonoBehaviour
{

    public static string[] keepQuestions = new string[25];
    public string[] keepPronunciation = new string[25];
    public string[] keepCorrectAnswers = new string[25];

    public Text txtQuiz;
    public Text[] txtAnswers;
    public int correctPosition;
    public int indexQuiz;
    public int[] indexAnswers;

    public int x = 0;
    public int stageNumber = 1;

    public Image start;
    public Image win;
    public Image lose;
    public Image reload;
    public Image home;

    public int scoreCorrect = 0;
    public int scoreWrong = 0;
    public Text txtCorrect;
    public Text txtWrong;
    public int countQuestion = 0;
    public int countAnswer = 0;
    public int countCorrectAnswer = 0;


    void Start()
    {
        Debug.Log(PlayerPrefs.GetString("CategoryID"));
        //PlayerPrefs.DeleteKey("CategoryID");
        totalscore.clearData();
        start.gameObject.SetActive(true);
        win.gameObject.SetActive(false);
        lose.gameObject.SetActive(false);
        reload.gameObject.SetActive(false);
        home.gameObject.SetActive(false);

        getData();

    }

    public void getData()
    {
        RestClient.GetArray<Vocab>("https://testfirebase-b970e.firebaseio.com/Vocab.json").Then(response =>
        {
            //Debug.Log("connect");
            for (int i = 0; i < response.Length; i++)
            {
                if (response[i].categoryID == PlayerPrefs.GetString("CategoryID"))
                {
                    keepQuestions[x] = response[i].koreaWord;
                    keepCorrectAnswers[x] = response[i].thaiWord;
                    keepPronunciation[x] = response[i].pronunciation;
                    Debug.Log(x + " " + keepQuestions[x] + " " + keepCorrectAnswers[x] + " " + keepPronunciation[x]);
                    x++;
                }
            }

            //Debug.Log("finish");

        });
        //start.gameObject.SetActive(false);
        randomQuiz();
        randomAnswers();
    }

    public void randomQuiz()
    {
        indexAnswers = new int[4];
        indexQuiz = UnityEngine.Random.Range(0, keepQuestions.Length);
        txtQuiz.text = stageNumber + " " + keepQuestions[indexQuiz] + " \n(" + keepPronunciation[indexQuiz] + ")";
        totalscore.addQuestionKoreanWord(stageNumber - 1, keepQuestions[indexQuiz]);
        Debug.Log(totalscore.questionKoreanWord[stageNumber - 1]);
        //PlayerPrefs.SetString("question", keepQuestions[indexQuiz]);
        //Debug.Log(PlayerPrefs.GetString("question"));
    }

    public void randomAnswers()
    {
        correctPosition = UnityEngine.Random.Range(0, txtAnswers.Length);
        txtAnswers[correctPosition].text = keepCorrectAnswers[indexQuiz];
        totalscore.addQuestionThaiWord(stageNumber - 1, keepCorrectAnswers[indexQuiz]);
        for (int i = 0; i < txtAnswers.Length; i++)
        {
            if (i != correctPosition)
            {
                int random = UnityEngine.Random.Range(0, keepCorrectAnswers.Length);
                while (random == indexQuiz)
                {
                    random = UnityEngine.Random.Range(0, keepCorrectAnswers.Length);
                }
                txtAnswers[i].text = keepCorrectAnswers[random];
                indexAnswers[i] = random;
                //PlayerPrefs.SetString("answer", keepCorrectAnswers[indexQuiz] + stageNumber);
                //Debug.Log(PlayerPrefs.GetString("answer"));
                //Debug.Log(random);
            }
        }

    }

    /*public bool checkDupAnswers(int index, int random)
    {
        for (int i = 0; i < index; i++){
            if (indexAnswers[i] == random){
                return true;
            }
        }
        return false;
    }*/

    public void TouchAnswerButton(int index)
    {
        if (index == correctPosition)
        {
            Hero1_Controller.UpdateStatus();
            castleController.UpdateStatus();
            totalscore.updateAnswer(stageNumber - 1, true);
            Debug.Log(totalscore.answer[stageNumber - 1]);
            stageNumber++;
            checkwin();
            scoreCorrect += 1;
            txtCorrect.text = "" + scoreCorrect;


        }
        else
        {
            totalscore.updateAnswer(stageNumber - 1, false);
            Debug.Log(totalscore.answer[stageNumber - 1]);
            stageNumber++;
            checkwin();
            scoreWrong += 1;
            txtWrong.text = "" + scoreWrong;
            ControlHeart.heart -= 1;
            if (ControlHeart.heart == 0)
            {
                lose.gameObject.SetActive(true);
                reload.gameObject.SetActive(true);
                home.gameObject.SetActive(true);
                SceneManager.LoadScene("totalscore");
            }
            Debug.Log(ControlHeart.heart);

        }

        randomQuiz();
        randomAnswers();
    }

    public void checkwin()
    {
        if (stageNumber == 26)
        {
            win.gameObject.SetActive(true);
            SceneManager.LoadScene("totalscore");
        }
    }
}
