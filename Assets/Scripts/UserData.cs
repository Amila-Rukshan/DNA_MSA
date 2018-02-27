using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UserData {

	private static string username;

	private static string password;

    private static int currentLevel;

    public static void SetUsername(string name){
		username = name;
	}

	public static void SetPassword(string pass){
		password = pass;
	}

    public static void SetLevel(int level)
    {
        currentLevel = level;
    }

    public static int GetLevel()
    {
        return currentLevel;
    }

    public static string GetUsername(){
		return username;
	}

	public static string GetPassword(){
		return password;
	}
}
