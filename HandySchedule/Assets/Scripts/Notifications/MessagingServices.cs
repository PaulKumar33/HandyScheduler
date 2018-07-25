using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Messaging;
using Firebase.Unity.Editor;
using Firebase.Database;

public class MessagingServices : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//Firebase.Messaging.FirebaseMessaging.TokenReceived += 
	}

    public void OnTokenRecieved(object sender, Firebase.Messaging.TokenReceivedEventArgs token)
    {
        Debug.Log("Recieved registration token: " + token.Token);
    }

    public void OnMessageRecieved(object sender, MessageReceivedEventArgs e)
    {
        Debug.Log("New message recieved from: " + e.Message.From);
    }

    private void CheckDependencies()
    {
        //checkdependenciesasync() doesnt exist for some reason
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
