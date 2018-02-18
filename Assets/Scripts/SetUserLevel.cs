using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DatabaseControl;

public class SetUserLevel : MonoBehaviour {

	IEnumerator SetData (string playerUsername, string playerPassword, string data)
    {
        IEnumerator e = DCF.SetUserData(playerUsername, playerPassword, data); // << Send request to set the player's data string. Provides the username, password and new data string
        while (e.MoveNext())
        {
            yield return e.Current;
        }
        string response = e.Current as string; // << The returned string from the request

        if (response == "Success")
        {
            //The data string was set correctly. Goes back to LoggedIn UI
			Debug.Log("Level was successfully saved!");
        }
        else
        {
            //There was another error. Automatically logs player out. This error message should never appear, but is here just in case.
           
            //"Error: Unknown Error. Please try again later.";
        }
    }

    public void SaveData (string level)
    {
        //Called when the player hits 'Set Data' to change the data string on their account. Switches UI to 'Loading...' and starts coroutine to set the players data string on the server
        //loadingParent.gameObject.SetActive(true);
        //loggedInParent.gameObject.SetActive(false);
        StartCoroutine(SetData(UserData.GetUsername(),UserData.GetPassword(),level));
    }	
	
}
