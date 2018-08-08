using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class EventScript : MonoBehaviour {

    struct PublicEvent
    {
        public string Name;
        public string Location;
        public string Time;

        public int Year;
        public int Month;
        public int Day;
    };

    //important globals belonging to the class
    string eName;
    string eLocation;
    string eTime;

    int eYear;
    int eMonth;
    int eDay;

    List<PublicEvent> eventList;
    List<_Event> eList;



    public EventScript(string eventName, string eventLocation, int eventYear, int eventDay, int eventMonth, string eventTime)
    {
        /*
         * creates an instance of an event object. Should handle multiple events
         */

        //initialize a list to hold event structures in case of multiple events and initialize it null
        eList = new List<_Event>();

        //initialize and create a new event object
        _Event.current = new _Event();
        _Event cur = _Event.current;
        cur.SetParam(eventName, eventLocation, eventTime, eventDay, eventMonth, eventYear);

        Debug.Log(eventLocation);
        Debug.Log(_Event.current.Location);
        eList.Add(_Event.current);
    }

    public void CreateEventCall()
    {
        _SaveLoad.Save();
    }

    public void DisplayLocalEventContents(string eventName, Action<bool, string> callback)
    {
        /*
         *Displays the content of a given event given the event name
         */
        string nameHold = null;
        if (eList != null)
        {
            foreach (_Event e in _SaveLoad.savedEvents)
            {
                _Event.current = e;
                _Event cur = _Event.current;
                Debug.Log(cur.Name);
                Debug.Log(cur.Location);
                if(cur.Name == eventName)
                {
                    string res = string.Format("{0}, Location: {1}. \n" +
                                           "{2}/{3}/{4}", cur.Name, cur.Location, cur.Day, cur.Month, cur.Year);
                    callback(true, res);
                    return;
                }
                else
                {
                    continue;
                }
                
            }

            Debug.Log("No Such Event Exists. Try another name");
            callback(false, "No Such Event Exists. Try another name");
        }
        else
        {
            Debug.Log("Event List is null. No events exist");
            callback(false, "Event List is null. No events exist");
        }
    }



    /*public bool EditLocalEvent(string eventName, string eventLocation = null, string eventTime = null, int eventYear = 0, int eventDay = 0, int eventMonth = 0)
    {
        /*
         * for now
         * 
        foreach(PublicEvent element in eventList)
        {

        }
        return false;
        
    }*/

}
