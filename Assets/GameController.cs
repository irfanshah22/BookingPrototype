using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class GameController : MonoBehaviour
{
    public const string MatchEmailPattern =
        @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
        + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
        + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
        + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";
    /// <All Panels>
    public GameObject MainPanel;
     public GameObject SignupPanel;
     public GameObject SigninPanel;

    
    public Button SignUpBtn;
    public Button SignInBtn;


    /// <Sign Up>
    public InputField _nameField;
    public InputField _emailField;
    public InputField _passwordField;
    public Button RegisternowBtn;
    public Button noAccountSigninBtn;
    public Button BackSignupBtn;

    /// </Sign Up ENDED>

    /// <Sign In>
    public InputField _emailFieldLogin;
    public InputField _passwordFieldLogin;
    public Button loginBtn;
    public Button RegisteredSigninPanelBtn;
    public Button BackSignInBtn;
    /// </Sign in ENDED>

    // Start is called before the first frame update
    void Start()
    {
        MainPanel.SetActive(true);
        SignupPanel.SetActive(false);
        SigninPanel.SetActive(false);

        BackSignInBtn.onClick.AddListener(OnbackPanel);
        BackSignupBtn.onClick.AddListener(OnbackPanel);


        SignUpBtn.onClick.AddListener(OnSignUpClick);
        RegisteredSigninPanelBtn.onClick.AddListener(OnSignUpClick);
        SignInBtn.onClick.AddListener(OnSignInClick);
        noAccountSigninBtn.onClick.AddListener(OnSignInClick);
        loginBtn.onClick.AddListener(Login);
        RegisternowBtn.onClick.AddListener(CreateAccount);
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
        MainPanel.SetActive(false);
        SignupPanel.SetActive(true);
        SigninPanel.SetActive(false);
     }
    void OnSignInClick()
    {
        print("Sign in");
        MainPanel.SetActive(false);
        SignupPanel.SetActive(false);
        SigninPanel.SetActive(true);
    }
    void Login()
    {
        print("Login");
        if(_emailFieldLogin.text == "" || _passwordFieldLogin.text == "")
        {
            Debug.LogError("Email or password must not be empty");
        }
        _emailFieldLogin.text = _emailFieldLogin.text.Trim();
        _passwordFieldLogin.text = _passwordFieldLogin.text.Trim();
        if (validateEmail(_emailFieldLogin.text))
        {
            Debug.Log("email is valid");
        }
        else
        {
            Debug.LogError("email format is not valid");
         }  
    }
    void CreateAccount()
    {
        print("CreateAccount");
 
         if (_nameField.text == "" || _emailField.text == ""  || _passwordField.text == "")
        {
            Debug.LogError("Fields must not be empty");
            return;
        }
        _nameField.text = _nameField.text.Trim();
        _emailField.text = _emailField.text.Trim();
        _passwordField.text = _passwordField.text.Trim();
        if (validateEmail(_emailField.text))
        {
            Debug.Log("email is valid");
         }
        else
        {
            Debug.LogError("email format is not valid");

        }


    }
    public static bool validateEmail(string email)
    {
        if (email != null)
            return Regex.IsMatch(email, MatchEmailPattern);
        else
            return false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
