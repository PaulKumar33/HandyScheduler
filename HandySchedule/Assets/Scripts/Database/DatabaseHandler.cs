using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using System.Globalization;
using System;

public class DatabaseHandler : MonoBehaviour {
    DependencyStatus dS = DependencyStatus.UnavailableOther;


    public DatabaseHandler()
    {
        //check dependencies -> for some reason task.result is undefined and shouldnt be
        /*FirebaseApp.FixDependenciesAsync().ContinueWith(task =>
        {
            dS = task.Result;
        });*/
        InitializeFirebase();
    }

    private void InitializeFirebase()
    {
        Debug.Log("creating DB instance....");
        WaitForSeconds wait = new WaitForSeconds(3f);
        FirebaseApp app = FirebaseApp.DefaultInstance;
        app.SetEditorDatabaseUrl("https://handyscheduler-b716b.firebaseio.com/"); //need to define later
        if(app.Options.DatabaseUrl != null)
        {
            app.SetEditorDatabaseUrl(app.Options.DatabaseUrl);
        }
        Debug.Log("instance created...");
        //StartListener();
    }

    protected void StartListener()
    {
        //DB update flow
    }

    protected int HandleMonths(string eventMonth)
    {
        string[] monthArray = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
        Dictionary<string, int> monthDict = new Dictionary<string, int>();
        int i = 1;
        foreach (string month in monthArray)
        {
            monthDict[month] = i;
            i++;
        }
        return monthDict[eventMonth];
    }

    public void AddToDatabase(string day, string month, string year, string name, string time, Action<bool, string> callback)
    {
        AddToDB(name, day, month, year, time, callback);
    }

    protected void AddToDB(string eventName, 
        string eventDay, string eventMonth, string eventYear, string eventTime, Action<bool, string> callback)
    {
        //Adds the Event to the DB
        Dictionary<string, object> newEvent = new Dictionary<string, object>();

        //IMPORTANT. we need a consistent db addition/read flow. I think it should be
        //as follows....

        /*key={
         * value1
         * value2
         * .
         * .
         * .
         * .
         * value_n} 
         */
        //newEvent["Event Name"] = eventName;
        newEvent["Event Time"] = eventTime;
        newEvent["Day of Event"] = eventDay;
        DateTime time = DateTime.Now;
        string timeString = time.ToString();
        string[] characterArray = timeString.Split('/');

        if (characterArray[2] != eventYear || characterArray[0] != eventMonth)
        {
            newEvent["Month of Event"] = eventMonth;
            newEvent["Event Year"] = eventYear;
        }

        DatabaseReference reference = FirebaseDatabase.DefaultInstance.GetReference(eventName);
        if(reference == null)
        {
            reference.SetValueAsync(eventName);
        }
        Debug.Log("Checking database for entry....");
        Debug.Log("Event Name: " + newEvent.ToString());
        Debug.Log("Event: " + newEvent.Values.ToString());
        reference.SetValueAsync(newEvent);
    }

    protected void ReadDatabase(string eventName)
    {
        DatabaseReference dbRef = FirebaseDatabase.DefaultInstance.GetReference(eventName);
        string msg;
        dbRef.GetValueAsync().ContinueWith(task => {
            if (task.IsFaulted)
            {
                Debug.Log(task);
                msg = "Error: " + task.Exception;
                Debug.Log(msg);
                return;
            }

            else if (task.IsCanceled)
            {
                msg = "Error: Test Cancelled";
                Debug.Log(msg);
                return;
            }
            else if (task.IsCompleted)
            {
                Debug.Log("Accessing db....");
                DataSnapshot snap = task.Result;
                //flow for reading an event
            }

        });

    }


    //handling the database
}
