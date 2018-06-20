using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class DatabaseHandler : MonoBehaviour {
    DependencyStatus dS = DependencyStatus.UnavailableOther;


    private DatabaseHandler()
    {
        //check dependencies -> for some reason task.result is undefined and shouldnt be
        /*FirebaseApp.FixDependenciesAsync().ContinueWith(task =>
        {
            dS = task.Result;
        });*/
    }

    private void InitializeFirebase()
    {
        FirebaseApp app = FirebaseApp.DefaultInstance;
        app.SetEditorDatabaseUrl("NULL"); //need to define later
        if(app.Options.DatabaseUrl != null)
        {
            app.SetEditorDatabaseUrl(app.Options.DatabaseUrl);
        }
        //StartListener();
    }

    protected void StartListener()
    {
        //DB update flow
    }

    protected void AddToDB(string eventName, 
        string eventDay, string eventMonth, string eventYear, string eventTime)
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
         newEvent["Event Name"] = 
    }


    //handling the database
}
