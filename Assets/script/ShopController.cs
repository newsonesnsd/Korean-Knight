using System;
using UnityEngine;
using UnityEngine.UI;
using Proyecto26;
// using UnityEngine.UI.Image;

public class ShopController : MonoBehaviour
{
    // Character Button
    public Button char1;
    public Button char2;
    public Button char3;
    public Button char4;
    // Character Price
    public Text char1Price;
    public Text char2Price;
    public Text char3Price;
    public Text char4Price;
    // Charactor Image
    public Image char1pic;
    public Image char2pic;
    public Image char3pic;
    public Image char4pic;
    // Shop Element
    public Button buyButton;
    public Text charName;
    public Text userCoin;

    private string[] json = new string[4]; 
    // Set Character
    // Character ch1 = new Character("1", "CHAR1", 200);
    Character ch1 = new Character();
    Character ch2 = new Character();
    Character ch3 = new Character();
    Character ch4 = new Character();
    User user = new User();

    // Start is called before the first frame update
    void Start()
    {
        user.setUser(User.usermail);
        getCharacter();
        // Debug.Log(json[1]);
        // Set Character Property
        // JsonUtility.FromJsonOverwrite(json[0], ch1);
        // JsonUtility.FromJsonOverwrite(json[1], ch2);
        // JsonUtility.FromJsonOverwrite(json[2], ch3);
        // JsonUtility.FromJsonOverwrite(json[3], ch4);

        // Debug.Log(user.showData());
        // Debug.Log(ch1.ToString());
        char1Price.text = ch1.getPrice() + "";
        char2Price.text = ch2.getPrice() + "";
        char3Price.text = ch3.getPrice() + "";
        char4Price.text = ch4.getPrice() + "";
        userCoin.text = user.getCoin() + "";
        // Default Character
        updateName(ch1.getName());
        hidePicture(1);
        hidePicture(2);
        hidePicture(3);
        // Listener Onclick Character
        char1.onClick.AddListener(() => updateName(ch1.getName()));
        char2.onClick.AddListener(() => updateName(ch2.getName()));
        char3.onClick.AddListener(() => updateName(ch3.getName()));
        char4.onClick.AddListener(() => updateName(ch4.getName()));
        buyButton.onClick.AddListener(() => buyCharAction(charName.GetComponent<Text>().text));
    }

    // Update is called once per frame
    void Update()
    {
        // HaveMoneyText.text = haveMoney.ToString();

        // if (haveMoney >= 20 && charSold == 0)
        //     buyButton.gameObject.SetActive(true);
        // else
        //     buyButton.gameObject.SetActive(true);
    }

    public void buyChar(int charIndex)
    {
        if (charIndex == 1)
        {
            user.delCoin(ch1.getPrice());
            userCoin.text = user.getCoin() + "";
            user.updateChar(1);
            Debug.Log(user.purchesesCharactor[1]);
            char1Price.text = "Sold";
        }
        else if (charIndex == 2)
        {
            user.delCoin(ch2.getPrice());
            userCoin.text = user.getCoin() + "";
            user.updateChar(1);
            Debug.Log(user.purchesesCharactor[1]);
            char2Price.text = "Sold";
        }
        else if (charIndex == 3)
        {
            user.delCoin(ch3.getPrice());
            userCoin.text = user.getCoin() + "";
            user.updateChar(1);
            Debug.Log(user.purchesesCharactor[1]);
            char3Price.text = "Sold";
        }
        else 
        {
            user.delCoin(ch4.getPrice());
            userCoin.text = user.getCoin() + "";
            user.updateChar(1);
            Debug.Log(user.purchesesCharactor[1]);
            char4Price.text = "Sold";
        }
    }

    void buyCharAction(string charname){
        if (charname == ch1.getName()){
            if (user.getCoin() < ch1.getPrice())
            {
                disableBuy();
            }
            else
            {
                ableBuy();
                buyChar(1);
                //buyButton.gameObject.SetActive(false);
            }
        }
        else if (charname == ch2.getName()){
            if (user.getCoin() < ch2.getPrice())
            {
                disableBuy();
            }
            else
            {
                ableBuy();
                buyChar(2);
            }
        }
        else if (charname == ch3.getName()){
            if (user.getCoin() < ch3.getPrice())
            {
                disableBuy();
            }
            else
            {
                ableBuy();
                buyChar(3);
            }
        }
        else if (charname == ch4.getName()){
            if (user.getCoin() < ch4.getPrice())
            {
                disableBuy();
            }
            else
            {
                ableBuy();
                buyChar(4);
            }
        }
    }

    // Check Character is Buy? if yes > Disable Buybutton
    void checkCharIsBuy(int index){
        --index;
        if (user.purchesesCharactor[index] == true)
        {
            disableBuy();
        }
    }

    void updateName(string name){
        charName.GetComponent<Text>().text = name;
        ableBuy(); 
        if (name == ch1.getName())
        {
            showPicture(1);
            
        }
        else if (name == ch2.getName())
        {
            showPicture(2);    
            // checkCharIsBuy(2);           
        }
        else if (name == ch3.getName())
        {
            showPicture(3);
            // checkCharIsBuy(3);               
        }
        else
        {
            showPicture(4);    
            // checkCharIsBuy(4);           
        }
        
        Debug.Log(charName.text);
    }

    // Disable Buy Button
    void disableBuy(){
        buyButton.GetComponent<Button>().interactable = false;
    }
    // Able Buy Button
    void ableBuy(){
        buyButton.GetComponent<Button>().interactable = true;
    }
    // Show Picture in Shop
    void showPicture(int index){
        if (index == 1)
        {
            char1pic.enabled = true;
            hidePicture(2);
            hidePicture(3);
            hidePicture(4);            
        }
        else if (index == 2)
        {
            char2pic.enabled = true;
            hidePicture(1);
            hidePicture(3);
            hidePicture(4);
        }
        else if (index == 3)
        {
            char3pic.enabled = true;
            hidePicture(1);
            hidePicture(2);
            hidePicture(4);
        }
        else
        {
            char4pic.enabled = true;
            hidePicture(1);
            hidePicture(2);
            hidePicture(3);
        }
    }
    // To Hide Character Image
    void hidePicture(int index){
        if (index == 1)
        {
            char1pic.enabled = false;
        }
        else if (index == 2)
        {
            char2pic.enabled = false;
        }
        else if (index == 3)
        {
            char3pic.enabled = false;
        }
        else
        {
            char4pic.enabled = false;
        }
    }

    public void getCharacter(){
        for (int i = 0; i < 4; i++)
        {
            RestClient.Get("https://testfirebase-b970e.firebaseio.com/Character/CH000" + (i+1) +".json").Then(response =>
            {
                
                // Debug.Log(response.Text.ToString());
                json[i] = response.Text.ToString();
                Debug.Log(json[i]);
                // JsonUtility.FromJsonOverwrite(json);
                // Debug.Log(newChar);
                // return newChar;
            });
        }
        
         
    }
    

}
