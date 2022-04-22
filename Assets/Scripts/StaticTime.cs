using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticTime
{
    // Start is called before the first frame update
    public int min {get;set;}
    public int hr {get;set;}

    public StaticTime(int hr, int min){
        this.min = min;
        this.hr = hr;
    }
    public bool check(int hr, int min){
        if(hr >= this.hr && min > this.hr) return false;
        else return true;
    }

    public override string ToString()
    {
        return $"{this.hr:00}:{this.min:00}";
    }

    public void IncMin(){
        if(++this.min == 60){
            this.hr ++;
            this.min = 0;
        }
    }
}
