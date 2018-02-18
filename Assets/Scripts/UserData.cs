using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UserData {

	private static string username;

	private static string password;

	public static void SetUsername(string name){
		username = name;
	}

	public static void SetPassword(string pass){
		password = pass;
	}

	public static string GetUsername(){
		return username;
	}

	public static string GetPassword(){
		return password;
	}
}
