using Proyecto26;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizGameMulti : MonoBehaviour
{
    // Start is called before the first frame update
    public static string[] keepQuestions;
    public string[] keepPronunciation;
    public string[] keepCorrectAnswers;

    public Text txtQuiz;
    public Text[] txtAnswers;
    public int correctPosition;
    public int indexQuiz;
    public int[] indexAnswers;

    public int x = 0;
    public int stageNumber = 1;

    //public Image start;
    //public Image win;
    //public Image lose;
    //public Image reload;
    //public Image home;

    public int scorePlayer1 = 0;
    public int scorePlayer2 = 0;
    public Text txtscorePlayer1;
    public Text txtscorePlayer2;



    void Start()
    {
        //Debug.Log(PlayerPrefs.GetString("CategoryID"));
        //PlayerPrefs.DeleteKey("CategoryID");

        /*start.gameObject.SetActive(true);
        win.gameObject.SetActive(false);
        lose.gameObject.SetActive(false);
        reload.gameObject.SetActive(false);
        home.gameObject.SetActive(false);*/

        getData();

    }

    public void getData()
    {
        RestClient.GetArray<Vocab>("https://testfirebase-b970e.firebaseio.com/Vocab.json").Then(response =>
        {
            keepQuestions = new string[response.Length];
            keepCorrectAnswers = new string[response.Length];
            keepPronunciation = new string[response.Length];

            //Debug.Log("connect");
            for (int i = 0; i < response.Length; i++)
            {
                keepQuestions[x] = response[i].koreaWord;
                keepCorrectAnswers[x] = response[i].thaiWord;
                keepPronunciation[x] = response[i].pronunciation;
                Debug.Log(x + " " + keepQuestions[x] + " " + keepCorrectAnswers[x] + " " + keepPronunciation[x]);
                x++;
            }
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
        //PlayerPrefs.SetString("question", keepQuestions[indexQuiz]);
        //Debug.Log(PlayerPrefs.GetString("question"));
    }

    public void randomAnswers()
    {
        correctPosition = UnityEngine.Random.Range(0, txtAnswers.Length);
        txtAnswers[correctPosition].text = keepCorrectAnswers[indexQuiz];
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

    public bool checkDupAnswers(int index, int random)
    {
        for (int i = 0; i < index; i++){
            if (indexAnswers[i] == random){
                return true;
            }
        }
        return false;
    }

    public void TouchAnswerButton(int index)
    {
        if (index == correctPosition)
        {
            stageNumber++;
            scorePlayer1 += 1;
            txtscorePlayer1.text = "" + scorePlayer1;
        }
        else
        {
            scorePlayer2 += 1;
            txtscorePlayer2.text = "" + scorePlayer2;
            stageNumber++;
        }

        randomQuiz();
        randomAnswers();
    }

    /*public void checkwin()
    {
        if (stageNumber == 3)
        {
            win.gameObject.SetActive(true);
        }
    }*/

    void Update()
    {
        txtscorePlayer1.text = "" + scorePlayer1;
        txtscorePlayer2.text = "" + scorePlayer2;
    }
}
