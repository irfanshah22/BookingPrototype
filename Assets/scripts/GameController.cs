using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;
 using System.Linq;
using System;
public class GameController : MonoBehaviour
{
   public static  GameController Instance;
    public const string MatchEmailPattern =
        @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
        + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
        + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
        + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";
    /// <All Panels>
    public GameObject MainPanel;
     public GameObject SignupPanel;
     public GameObject SigninPanel;
     public GameObject WelcomePanel;
     public GameObject CalenderUI;
     public GameObject BookingPanelUI;

    
    public Button SignUpBtn;
    public Button SignInBtn;


    /// <Sign Up>
    public InputField _nameField;
    public InputField _emailField;
    public InputField _passwordField;
    public Button RegisternowBtn;
    public Button noAccountSigninBtn;
    public Button BackSignupBtn;
    public GameObject ErrorSignUp;

    /// </Sign Up ENDED>

    /// <Sign In>
    public InputField _emailFieldLogin;
    public InputField _passwordFieldLogin;
    public Button loginBtn;
    public Button RegisteredSigninPanelBtn;
    public Button BackSignInBtn;
    public GameObject ErrorSignIn;
    /// </Sign in ENDED>

    //// Welcome Screen //////
    public Button BookOnline;
      ////////////////////////////
    // Booking Panel
    public Button BooknowBtn; 
    //////////
    public List< PlayerData> Obj;


    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
     
         if (PlayerPrefs.HasKey("PlayerData"))
        {
          //  Obj = LoadPlayerData();
        }
     

         MainPanel.SetActive(true);
        SignupPanel.SetActive(false);
        SigninPanel.SetActive(false);
        WelcomePanel.SetActive(false);
        BooknowBtn.onClick.AddListener(ShowGroundforbooking);
        BookOnline.onClick.AddListener(BookOnlineTickets);
        BackSignInBtn.onClick.AddListener(OnbackPanel);
        BackSignupBtn.onClick.AddListener(OnbackPanel);
        SignUpBtn.onClick.AddListener(OnSignUpClick);
        RegisteredSigninPanelBtn.onClick.AddListener(OnSignUpClick);
        SignInBtn.onClick.AddListener(OnSignInClick);
        noAccountSigninBtn.onClick.AddListener(OnSignInClick);
        loginBtn.onClick.AddListener(Login);
        RegisternowBtn.onClick.AddListener(CreateAccount);
        if (AlreadySignedIn.Instance.SignedInBool)
        {
            ShowWelcomeScreen();
        }
    }
    void BookOnlineTickets()
    {
        WelcomePanel.SetActive(false);
        CalenderUI.SetActive(true);  
    }
    public void BookNow()
    {
      BookingPanelUI.SetActive(true);
     }
    public void ShowGroundforbooking()
    {
        SceneManager.LoadScene(1);
    }  
    void OnbackPanel()
    {
        MainPanel.SetActive(true);
        SignupPanel.SetActive(false);
        SigninPanel.SetActive(false);
    }
    void OnSignUpClick()
    {
        print("Sign Up");
        ErrorSignUp.SetActive(false);
         MainPanel.SetActive(false);
        SignupPanel.SetActive(true);  
        SigninPanel.SetActive(false);
     }
    void OnSignInClick()
    {
        print("Sign in");
        ErrorSignIn.SetActive(false);
        MainPanel.SetActive(false);
        SignupPanel.SetActive(false);
        SigninPanel.SetActive(true);
    }
    void ShowWelcomeScreen()
    {
         MainPanel.SetActive(false);
        SignupPanel.SetActive(false);
        SigninPanel.SetActive(false);
        WelcomePanel.SetActive(true);

    }
    void Login()
    {
        print("Login");
        if(_emailFieldLogin.text == "" || _passwordFieldLogin.text == "")
        {
            Debug.LogError("Email or password must not be empty");
            ErrorSignIn.SetActive(true);
            ErrorSignIn.GetComponent<Text>().text = "Email or password must not be empty";
            StartCoroutine(OffErrorMsg(ErrorSignIn));
            return;
        }
        _emailFieldLogin.text = _emailFieldLogin.text.Trim();
        _emailFieldLogin.text = _emailFieldLogin.text.ToLower();
        _passwordFieldLogin.text = _passwordFieldLogin.text.Trim();
        if (validateEmail(_emailFieldLogin.text))
        {
            Debug.Log("email is valid");
         }
        else
        {
            Debug.LogError("email format is not valid");
            ErrorSignIn.SetActive(true);
            ErrorSignIn.GetComponent<Text>().text = "email format is not valid";
            StartCoroutine(OffErrorMsg(ErrorSignIn));
            return;
        }
        //if (PlayerPrefs.HasKey("PlayerData"))
        //{
        //    Obj = LoadPlayerData();
            if (Obj.Count > 0)
            {
                bool _emailcheck = false;

                for(int i=0; i<Obj.Count; i++)
                {
                    if(Obj[i].email == _emailFieldLogin.text)
                    {
                        _emailcheck = true;
                        if (Obj[i].password == _passwordFieldLogin.text)
                        {
                            print("email and password matched");
                            ShowWelcomeScreen();
                            AlreadySignedIn.Instance.SignedInBool = true;
                        }
                        else
                        {
                            Debug.LogError("Wrong Password");
                        ErrorSignIn.SetActive(true);
                        ErrorSignIn.GetComponent<Text>().text = "Wrong Password";
                        StartCoroutine(OffErrorMsg(ErrorSignIn));
                        return;
                     } 
                }
                }
                if(_emailcheck== false)
                {
                    Debug.LogError("user not found");
                ErrorSignIn.SetActive(true);
                ErrorSignIn.GetComponent<Text>().text = "user not found";
                   StartCoroutine(OffErrorMsg(ErrorSignIn));
                }
            }
        //}
    }
    IEnumerator OffErrorMsg(GameObject _errorObj)
    {
        yield return new WaitForSeconds(1.5f);
        _errorObj.SetActive(false);
    }
    void CreateAccount()
    {
        print("CreateAccount");
 
         if (_nameField.text == "" || _emailField.text == ""  || _passwordField.text == "")
        {
            Debug.LogError("Fields must not be empty");
            ErrorSignUp.SetActive(true);
            ErrorSignUp.GetComponent<Text>().text = "Email or password must not be empty";
            StartCoroutine(OffErrorMsg(ErrorSignUp));  
            return;
        }
        _nameField.text = _nameField.text.Trim();
        _emailField.text = _emailField.text.Trim();
        _emailField.text = _emailField.text.ToLower();
        _passwordField.text = _passwordField.text.Trim();   
        if (validateEmail(_emailField.text))
        {
            Debug.Log("email is valid");
         }
        else
        {
            Debug.LogError("email format is not valid");
            ErrorSignUp.SetActive(true);
            ErrorSignUp.GetComponent<Text>().text = "email format is not valid";
            StartCoroutine(OffErrorMsg(ErrorSignUp));
            return;
        }
  
        if (PlayerPrefs.HasKey("PlayerData"))
        {
              if (Obj.Count > 0) 
            {
                 bool _emailcheck = false;

                for (int i = 0; i < Obj.Count; i++)
                {
                    print(Obj[i].email);
                    if (Obj[i].email == _emailField.text)
                    {
                          _emailcheck = true;
                     }
                }
                if (_emailcheck == true)
                {
                     Debug.LogError("user already existed, try another email");
                    ErrorSignUp.SetActive(true);
                    ErrorSignUp.GetComponent<Text>().text = "user already existed, try another email";
                    StartCoroutine(OffErrorMsg(ErrorSignUp));
                    return;
                }   
            }
        }     
         PlayerData player1 = new PlayerData();
        player1.name = _nameField.text;
        player1.email = _emailField.text;  
        player1.password = _passwordField.text;
        Obj.Add(player1);
        SavePlayerData(Obj);   
       // StartCoroutine(loaddata());
        ShowWelcomeScreen();
        AlreadySignedIn.Instance.SignedInBool = true;
         // _playerObj.name.Add(_nameField.text) ;
        //_playerObj.email.Add(_emailField.text);
        //_playerObj.password.Add( _passwordField.text);
    }
    IEnumerator loaddata()
    {
        yield return new WaitForSeconds(.1f);
        //if (PlayerPrefs.HasKey("PlayerData"))
        //{
        //    Obj = LoadPlayerData();
        //}      
    }
     
    public static bool validateEmail(string email) 
    {  
        if (email != null)
            return Regex.IsMatch(email, MatchEmailPattern);
        else
            return false;
    }


    public void SavePlayerData(List<PlayerData> dataList)
    {
        string jsonData = JsonHelper.ToJson(dataList.ToArray(), true);
        PlayerPrefs.SetString("PlayerDataList", jsonData);
        PlayerPrefs.Save();
    }

    public List<PlayerData> LoadPlayerData()
    {
        if (PlayerPrefs.HasKey("PlayerDataList"))
        {
            string jsonData = PlayerPrefs.GetString("PlayerDataList");
            return JsonHelper.FromJson<PlayerData>(jsonData).ToList();
        }
        else
        {
            Debug.LogWarning("No player data list found.");
            return new List<PlayerData>();
        }
    }

  
}


[System.Serializable]
 public class PlayerData
{
    public string name;
    public string email;
    public string password;
 }

// JsonHelper class for serializing and deserializing arrays in JSON
[System.Serializable]
public class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }

    public static string ToJson<T>(T[] array, bool prettyPrint)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }

    [System.Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }
}



