using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PubVar
{
    //=========general stats=========
    public static int money;
    public static int fatigue;
    public static int rating;
    public static float flySpd;
    public static float walkSpd;
    public static float pkgWeight;
    public static int level;
    

    //=========order info============

    /*
        -1: empty, 0: ready, 1: delivering, 2: delivered
    */
    public static int[] pkgStates = {-1,-1,-1,-1,-1,-1};
    public static float[] pkgWeights = {0,0,0,0,0,0};
    public static int pkgNum;

}
