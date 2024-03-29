using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class package
{
        public string name{get;set;}
        public int id {get;set;}
        public int state {get;set;}
        public Animal receiver {get;set;}
        public string address {get;set;}
        public StaticTime due {get;set;}
        public int income {get;set;}
        public int weight {get;set;}
        public string requirement {get;set;}
        public float integrity {get;set;}
        public Vector3 dropPos {get;set;}
        public string dropScene {get;set;}
        public Color color {get;set;}

    /*
        -1: not avaible, 0: avaible, 1: delivering, 2: dropped, 3: delivered, 4: broken, 5: past due
    */
        public package(string name, int anId, int aState, Animal receiver, string anAddress, StaticTime aDue, int aIncome, int aWeight){
            this.name = name;
            id = anId;
            state = aState;
            this.receiver = receiver;
            address = anAddress;
            due = aDue;
            income = aIncome;
            weight = aWeight;
            integrity = 100;
            setRequirement();
            this.color = new Color(
                Random.Range(0.3f, 1f), 
                Random.Range(0.3f, 1f), 
                Random.Range(0.3f, 1f));
        }

        public override string ToString(){
            return "package id: " + id
                        + "\nname: " + name
                        + $"\nweight: {weight} kg"
                        + "\n\nto: " + receiver.name
                        + "\naddress: " + address
                        + "\n\nship before: " + due
                        + "\nincome: $" + income;
        }

        public string BackpackString(){
            return "package id: " + id
                        + "\nname: " + name
                        + $"\nweight: {weight} kg"
                        + "\n\nto: " + receiver.name
                        + "\naddress: " + address
                        + "\n\nship before: " + due
                        + $"\nintegrity: {integrity:.00}%";
                        
        }

        public bool checkAvailable(string a = null){
            if(requirement == null) return true;
            else if(requirement == a) return true;
            else return false;
        }

        private void setRequirement(){
            this.state = 0;
            requirement = null;
        }
        
        public string getHit(float num){
            if(num == 100) return "You drop your package in the air? Seriously?";
            if(integrity > 0) integrity -= num;
            if(integrity <= 0){
                integrity = 0;
            }
            return (integrity == 0)? $"package(#{id}) is broken!\n" : $"package(#{id}) receives {num:.00} damages!\n";

        }

        public bool UpdateState(){
            if(!due.check(PubVar.initTime.hr, PubVar.initTime.min)){ // if late
                state = 5;
                if(integrity == 0) state = 6; // late & broken
                return false;
            }
            else if(integrity == 0){
                state = 4;
                return false;
            }
            return true;
        }
        public string GetState() {
            switch (state) {
                case -1: return "Not Available";
                case  0: return "Available";
                case  1: return "Not Delivered";
                case  2: return "Dropped";
                case  3: return "Delivered";
                case  4: return "Broken";
                case  5: return "Late";
                case  6: return "Late & Broken";
                default: return "";
            }
        }

        public float Results(ref string resStr) {
            // money up
            float payOut = (income * (integrity/100));

            if (GetState() == "Late") {
                payOut = (payOut * 0.88f);
            }
            if(GetState() == "Delivered"){
                PubVar.deliveredPkg ++;
                Debug.Log(PubVar.deliveredPkg);
            }
            // money down
            if (GetState() == "Broken") {
                payOut = -(income/2);
            }
            if (GetState() == "Late & Broken") {
                payOut = -(income/1.5f);
            }
            if(GetState() == "Not Delivered"){
                payOut = -(income);
            }

            // set result string
            resStr += "Package ID: " + id
                    + "\n Name: " + name
                    + "\n Status: " + GetState()
                    + $"\n Payout: {payOut:.}"; 
            return payOut;
        }
}
