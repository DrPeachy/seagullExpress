using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class package
{
        public string name{get;set;}
        public int id {get;set;}
        public int state {get;set;}
        public string to {get;set;}
        public string address {get;set;}
        public float due {get;set;}
        public int income {get;set;}
        public int weight {get;set;}
        public string requirement {get;set;}
        public float integrity;

    /*
        -1: not avaible, 0: avaible, 1: delivering, 2: droped, 3: delivered
    */
        public package(string name, int anId, int aState, string aTo, string anAddress, float aDue, int aIncome, int aWeight){
            this.name =name;
            id = anId;
            state = aState;
            to = aTo;
            address = anAddress;
            due = aDue;
            income = aIncome;
            weight = aWeight;
            integrity = 100;
            setRequirement();
        }

        public override string ToString(){
            return "package id: " + id
                        + "\nname: " + name
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

        private void setRequirement(){
            if(due < 120 && income > 400 && weight > 400) requirement = "plane";
            else if(due < 240 && income > 300 && weight > 300) requirement = "jetpack";
            else{
                this.state = 0;
                requirement = null;
            }

        }
        
        public void getHit(float num){
            integrity -= num;
        }
}
