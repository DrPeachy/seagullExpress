using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class package
{
        public int id;
        public int state;
        public string to;
        public string address;
        public float due;
        public int income;
        public int weight;

    /*
        -1: not avaible, 0: avaible, 1: delivering, 2: delivered
    */
        public package(int anId, int aState, string aTo, string anAddress, float aDue, int aIncome, int aWeight){
            id = anId;
            state = aState;
            to = aTo;
            address = anAddress;
            due = aDue;
            income = aIncome;
            weight = aWeight;
        }



        



}
