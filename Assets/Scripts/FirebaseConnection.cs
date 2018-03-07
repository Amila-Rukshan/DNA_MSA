using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using Firebase.Database;
using Firebase.Unity.Editor;

public static class FirebaseConnection {

    private static DatabaseReference reference;
    
    public static void Config() {
        // Set up the Editor before calling into the realtime database.
        Firebase.FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://dna-msa.firebaseio.com/");

        // Get theFirebaseDatabase root reference location of the database.
        reference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    public static void SaveLevelDetails() {
        reference.Child("players").Child(UserData.GetUsername()).Child("L" + (BuildAncestorAndScore.level - 1)).Child("score").SetValueAsync(BuildAncestorAndScore.score2);
        reference.Child("players").Child(UserData.GetUsername()).Child("L" + (BuildAncestorAndScore.level - 1)).Child("sequenceAlignment").SetValueAsync(BuildAncestorAndScore.GetStringOfSequenceAlignment());
        Debug.Log("level saved L" + (BuildAncestorAndScore.level - 1));
    }

}
