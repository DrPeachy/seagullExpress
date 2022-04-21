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
        public float integrity {get;set;}
        public Vector3 dropPos {get;set;}
        public string dropScene {get;set;}

    /*
        -1: not avaible, 0: avaible, 1: delivering, 2: dropped, 3: delivered, 4: broken
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

        public string BackpackString(){
            return "package id: " + id
                        + "\nname: " + name
                        + "\nweight: " + weight
                        + "\n\nto: " + to
                        + "\naddress: " + address
                        + "\n\nship before: " + due
                        + "\nintegrity: " + integrity + "%";
                        
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
            if(integrity > 0) integrity -= num;
            if(integrity <= 0){
                integrity = 0;
                state = 4;  // set broken
            }
        }

        public string GetState() {
            switch (state) {
                case -1: return "Not Available";
                case  0: return "Available";
                case  1: return "Delivering";
                case  2: return "Dropped";
                case  3: return "Delivered";
                case  4: return "Broken";
                case  5: return "Late";
                default: return "";
            }
        }

        public int Results(ref string resStr) {
            int payOut = (int)(income * (integrity/100));
            if (GetState() == "Late") {
                payOut = (int)(payOut * 0.2f);
            }
            if (integrity == 0) {
                payOut = -(income/2);
            }
            resStr += "Package ID: " + id
                    + "\n Name: " + name
                    + "\n Status: " + GetState()
                    + "\n Payout: " + payOut; 
            return payOut;
        }
}
