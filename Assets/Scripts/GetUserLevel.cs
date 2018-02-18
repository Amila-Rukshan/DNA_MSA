using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DatabaseControl; // << Remember to add this reference to your scripts which use DatabaseControl

public class GetUserLevel  : MonoBehaviour {

	public InputField playerUsername;
    
	public InputField playerPassword;

	public Text levelText;

	//saving username and password for later use in other scene and load level
	public void SetUsernameAndPassword(){
		UserData.SetUsername(playerUsername.text);
		UserData.SetPassword(playerPassword.text);
		LoadData(playerUsername.text, playerPassword.text);
	}

	void Awake(){
		DontDestroyOnLoad (transform.gameObject);
	}

    IEnumerator GetData (string playerUsername, string playerPassword)
    {	

        IEnumerator e = DCF.GetUserData(playerUsername, playerPassword); // << Send request to get the player's data string. Provides the username and password
        while (e.MoveNext())
        {
            yield return e.Current;
        }
        string response = e.Current as string; // << The returned string from the request

        if (response == "Error")
        {
            //There was another error.
        }
        else
        {
            //The player's data was retrieved. Goes back to loggedIn UI and displays the retrieved data in the InputField
           
				levelText.text = response;
				Debug.Log("got data");
            
        }
    }
    

    public void LoadData (string playerUsername, string playerPassword)
    {
        //Called when the player hits 'Get Data' to retrieve the data string on their account. Switches UI to 'Loading...' and starts coroutine to get the players data string from the server
        //loadingParent.gameObject.SetActive(true);
        //loggedInParent.gameObject.SetActive(false);
        StartCoroutine(GetData(playerUsername, playerPassword));
    }
    
}
