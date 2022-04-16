using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class package
{
        public int id {get;set;}
        public int state {get;set;}
        public string to {get;set;}
        public string address {get;set;}
        public float due {get;set;}
        public int income {get;set;}
        public int weight {get;set;}
        public string requirement {get;set;}

    /*
        -1: not avaible, 0: avaible, 1: delivering, 2: delivered
    */
        public package(int anId, int aState, string aTo, string anAddress, float aDue, int aIncome, int aWeight, string req = null){
            id = anId;
            state = aState;
            to = aTo;
            address = anAddress;
            due = aDue;
            income = aIncome;
            weight = aWeight;
            requirement = req;
        }

        public override string ToString(){
            return "package id: " + id
                        + "\nweight: " + weight
                        + "\n\nto: " + to
                        + "\naddress: " + address
                        + "\n\nship before: " + due
                        + "\nincome: " + income
                        + (checkAvailable()? "\navailable":"\nnot available");
        }


        public bool checkAvailable(string a = null){
            if(requirement == null) return true;
            else if(requirement == a) return true;
            else return false;
        }



}
