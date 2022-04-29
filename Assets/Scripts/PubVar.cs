using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PubVar
{
    //=========general stats=========
    public static float money = 10;
    public static int fatigue;
    public static int rating;

    public static int playerWeight = 0;
    public static int playerLevel = 1;
    public static int deliveredPkg = 0;

    public static Vector3 checkPoint = new Vector3(10, -25, 0);
    public static Vector3 originPoint = new Vector3(10, -25, 0);

    //========variable for upgrade=====
    public static float realTimeForMin = 0.2f;
    public static float movSpeed = 5;
    public static float actualSpeed = movSpeed;
    public static float damage = 40;
    public static float pkgBaseIncome = 500f;

    public static Upgrade[] upgrades = {
        new Upgrade("SpeedUp", 200, 3),
        new Upgrade("DmgDown", 200, 3),
        new Upgrade("SlowerTime", 200, 3),
        new Upgrade("RandomUpgrade", 150, 50),
        new Upgrade("PackageLimit + 1", 1500, 1)
    };

    //===========timer===============
    public static float Timer;
    public static StaticTime initTime;
    

    //=========order info============

    public static package[] packages;
    public static int pkgNum;
    public static int pkglimit = 4;
    //==========animal info===========
    public static Animal[] animals = {
        new Animal("Ms.Crocodile", "lake", new string[]{"fried chicken", "burger", "human"}),
        new Animal("the G.O.A.T", "mountain top", new string[]{"Laptop", "Gundamn", "Unity4d", "Gamepad", "rocket","EVA-30"}),
        new Animal("Ms.Fox", "plain", new string[]{"Ducci", "Shanel", "Bior", "Vouis Luitton", "Drapa"}),
        new Animal("Mr.Bear", "cave", new string[]{"honey", "fish","berry"}),
    };




}
