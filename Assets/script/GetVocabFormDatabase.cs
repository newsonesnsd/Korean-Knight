using Proyecto26;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GetVocabFormDatabase : MonoBehaviour
{

    public string[] keepKoreaWord = new string[50];
    public string[] keepPronunciation = new string[50];
    public string[] keepthaiWord = new string[50];
    public string[] keepId = new string[50];

    public int x = 0;

    public Text[] txtKword = new Text[50];
    public Text[] txtReading = new Text[50];
    public Text[] txtTword = new Text[50];
    public Button[] txtbutton = new Button[50];

    public AudioSource BGVocab;

    public AudioClip soundV0;
    public AudioClip soundV1;
    public AudioClip soundV2;
    public AudioClip soundV3;
    public AudioClip soundV4;
    public AudioClip soundV5;
    public AudioClip soundV6;
    public AudioClip soundV7;
    public AudioClip soundV8;
    public AudioClip soundV9;
    public AudioClip soundV10;
    public AudioClip soundV11;
    public AudioClip soundV12;
    public AudioClip soundV13;
    public AudioClip soundV14;
    public AudioClip soundV15;
    public AudioClip soundV16;
    public AudioClip soundV17;
    public AudioClip soundV18;
    public AudioClip soundV19;
    public AudioClip soundV20;
    public AudioClip soundV21;
    public AudioClip soundV22;
    public AudioClip soundV23;
    public AudioClip soundV24;
    public AudioClip soundV25;
    public AudioClip soundV26;
    public AudioClip soundV27;
    public AudioClip soundV28;
    public AudioClip soundV29;
    public AudioClip soundV30;
    public AudioClip soundV31;
    public AudioClip soundV32;
    public AudioClip soundV33;
    public AudioClip soundV34;
    public AudioClip soundV35;
    public AudioClip soundV36;
    public AudioClip soundV37;
    public AudioClip soundV38;
    public AudioClip soundV39;
    public AudioClip soundV40;
    public AudioClip soundV41;
    public AudioClip soundV42;
    public AudioClip soundV43;
    public AudioClip soundV44;
    public AudioClip soundV45;
    public AudioClip soundV46;
    public AudioClip soundV47;
    public AudioClip soundV48;
    public AudioClip soundV49;


    // Start is called before the first frame update
    void Start()
    {
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
                    keepKoreaWord[x] = response[i].koreaWord;
                    keepPronunciation[x] = response[i].pronunciation;
                    keepthaiWord[x] = response[i].thaiWord;
                    keepId[x] = response[i].vacabId;

                    txtKword[x].text = keepKoreaWord[x];
                    txtReading[x].text = keepPronunciation[x];
                    txtTword[x].text = keepthaiWord[x];

                    x++;
                    /*
                    txtWord1.text = keepKoreaWord[1];
                    txtWord2.text = keepKoreaWord[2];
                    txtWord3.text = keepKoreaWord[3];
                    txtWord4.text = keepKoreaWord[4];
                    txtWord5.text = keepKoreaWord[5];
                    txtWord6.text = keepKoreaWord[6];*/

                    Debug.Log(txtKword[x]);
                    Debug.Log(txtReading[x]);
                    Debug.Log(txtTword[x]);
                    Debug.Log(keepId[x]);
                    //Debug.Log(x+ " " + keepKoreaWord[x] + " " + keepPronunciation[x] + " " + keepthaiWord[x]);
                }
            }

            //Debug.Log("finish");

        });
    }


    public void getInput(string search)
    {

        //let x = keepthaiWord.Where(word => word.Contains(search)).ToArray();

        for (int i = 0; i < 50; i++)
        {
            if (search == "")
            {
                txtKword[i].gameObject.SetActive(true);
                txtReading[i].gameObject.SetActive(true);
                txtTword[i].gameObject.SetActive(true);
                txtbutton[i].gameObject.SetActive(true);
            }
            else
            {
                if (search == keepthaiWord[i])
                {
                    txtKword[i].gameObject.SetActive(true);
                    txtReading[i].gameObject.SetActive(true);
                    txtTword[i].gameObject.SetActive(true);
                    txtbutton[i].gameObject.SetActive(true);
                }
                else
                {
                    txtKword[i].gameObject.SetActive(false);
                    txtReading[i].gameObject.SetActive(false);
                    txtTword[i].gameObject.SetActive(false);
                    txtbutton[i].gameObject.SetActive(false);
                }
            }
            Debug.Log(search);
        }
    }

    public void onClick(int i)
    {
        switch (i)
        {
            case (0):
                BGVocab.clip = soundV0;
                BGVocab.Play();
                break;
            case (1):
                BGVocab.clip = soundV1;
                BGVocab.Play();
                break;
            case (2):
                BGVocab.clip = soundV2;
                BGVocab.Play();
                break;
            case (3):
                BGVocab.clip = soundV3;
                BGVocab.Play();
                break;
            case (4):
                BGVocab.clip = soundV4;
                BGVocab.Play();
                break;
            case (5):
                BGVocab.clip = soundV5;
                BGVocab.Play();
                break;
            case (6):
                BGVocab.clip = soundV6;
                BGVocab.Play();
                break;
            case (7):
                BGVocab.clip = soundV7;
                BGVocab.Play();
                break;
            case (8):
                BGVocab.clip = soundV8;
                BGVocab.Play();
                break;
            case (9):
                BGVocab.clip = soundV9;
                BGVocab.Play();
                break;
            case (10):
                BGVocab.clip = soundV10;
                BGVocab.Play();
                break;
            case (11):
                BGVocab.clip = soundV11;
                BGVocab.Play();
                break;
            case (12):
                BGVocab.clip = soundV0;
                BGVocab.Play();
                break;
            case (13):
                BGVocab.clip = soundV1;
                BGVocab.Play();
                break;
            case (14):
                BGVocab.clip = soundV0;
                BGVocab.Play();
                break;
            case (15):
                BGVocab.clip = soundV1;
                BGVocab.Play();
                break;
            case (16):
                BGVocab.clip = soundV0;
                BGVocab.Play();
                break;
            case (17):
                BGVocab.clip = soundV1;
                BGVocab.Play();
                break;
            case (18):
                BGVocab.clip = soundV0;
                BGVocab.Play();
                break;
            case (19):
                BGVocab.clip = soundV1;
                BGVocab.Play();
                break;
            case (20):
                BGVocab.clip = soundV0;
                BGVocab.Play();
                break;
            case (21):
                BGVocab.clip = soundV1;
                BGVocab.Play();
                break;

        }
    }


}
