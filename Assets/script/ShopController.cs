using UnityEngine;
using UnityEngine.UI;
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
    // Set Character
    Character ch1 = new Character();
    string ch1id = "CH0001";
    
    Character ch2 = new Character("2", "CHAR2", 150);
    Character ch3 = new Character("3", "CHAR3", 100);
    Character ch4 = new Character("4", "CHAR4", 50);
    User user = new User();

    // Start is called before the first frame update
    void Start()
    {
        user.setUser(User.usermail);
        Debug.Log(user.showData());
        char1Price.text = ch1.getcPrice() + "";
        char2Price.text = ch2.getcPrice() + "";
        char3Price.text = ch3.getcPrice() + "";
        char4Price.text = ch4.getcPrice() + "";
        userCoin.text = user.getCoin() + "";
        // Default Character
        updateName(ch4.getcName());
        hidePicture(1);
        hidePicture(2);
        hidePicture(3);
        // Listener Onclick Character
        char1.onClick.AddListener(() => updateName(ch1.getcName()));
        char2.onClick.AddListener(() => updateName(ch2.getcName()));
        char3.onClick.AddListener(() => updateName(ch3.getcName()));
        char4.onClick.AddListener(() => updateName(ch4.getcName()));
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
            user.delCoin(ch1.getcPrice());
            userCoin.text = user.getCoin() + "";
            user.updateChar(1);
            Debug.Log(user.purchesesCharactor[1]);
            char1Price.text = "Sold";
        }
        else if (charIndex == 2)
        {
            user.delCoin(ch2.getcPrice());
            userCoin.text = user.getCoin() + "";
            user.updateChar(1);
            Debug.Log(user.purchesesCharactor[1]);
            char2Price.text = "Sold";
        }
        else if (charIndex == 3)
        {
            user.delCoin(ch3.getcPrice());
            userCoin.text = user.getCoin() + "";
            user.updateChar(1);
            Debug.Log(user.purchesesCharactor[1]);
            char3Price.text = "Sold";
        }
        else 
        {
            user.delCoin(ch4.getcPrice());
            userCoin.text = user.getCoin() + "";
            user.updateChar(1);
            Debug.Log(user.purchesesCharactor[1]);
            char4Price.text = "Sold";
        }
    }

    void buyCharAction(string charname){
        if (charname == ch1.getcName()){
            if (user.getCoin() < ch1.getcPrice())
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
        else if (charname == ch2.getcName()){
            if (user.getCoin() < ch2.getcPrice())
            {
                disableBuy();
            }
            else
            {
                ableBuy();
                buyChar(2);
            }
        }
        else if (charname == ch3.getcName()){
            if (user.getCoin() < ch3.getcPrice())
            {
                disableBuy();
            }
            else
            {
                ableBuy();
                buyChar(3);
            }
        }
        else if (charname == ch4.getcName()){
            if (user.getCoin() < ch4.getcPrice())
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
        if (name == ch1.getcName())
        {
            showPicture(1);
            
        }
        else if (name == ch2.getcName())
        {
            showPicture(2);    
            // checkCharIsBuy(2);           
        }
        else if (name == ch3.getcName())
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

}
