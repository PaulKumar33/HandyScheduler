using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class _Event{
    public static _Event current;
    public static string dispString;

    public string time;
    public string name;
    public string location;

    public int day;
    public int month;
    public int year;

    public _Event()
    {

    }

    public string Time
    {
        get{return this.time;}
        set{this.time = value;}
    }

    public string Name
    {
        get{return this.name;
        }
            
        set{this.name = value;
        }
    }

    public string Location
    {
        get{return this.location;}
        set{this.location = value;}
    }

    public int Day
    {
        get{return this.day;}
        set{this.day = value;}
    }

    public int Month
    {
        get{return this.month;}
        set{this.month = value+1;
        }
    }

    public int Year
    {
        get{return this.year;}
        set{this.year = value;}

    }

    public void SetParam(string name, string location, string time, int day, int month, int year)
    {
        Name = name;
        Location = location;
        time = null;
        Day = day;
        Month = month;
        Year = year;
    }
}
