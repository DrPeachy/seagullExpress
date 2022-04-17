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
    public static int playerWeight;
    public static int playerLevel = 1;
    

    //=========order info============

    public static package[] packages;
    public static int pkgNum;
    //==========animal info===========
    public static Animal[] animals = {
        new Animal("Mr.Bear", "cave", new string[]{"honey", "fish","berry"}),
        new Animal("Ms.Crocodile", "river", new string[]{"fried chicken", "burger", "human"}),
        new Animal("the G.O.A.T", "mountain top", new string[]{"Laptop", "Gundamn", "Unity4d", "Gamepad", "rocket","EVA-02"}),
        new Animal("Ms.Fox", "plain", new string[]{"Ducci", "Shanel", "Bior", "Vouis Luitton", "Drapa"})
        
    };

}
