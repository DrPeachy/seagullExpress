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

    public static Vector3 checkPoint = new Vector3(35, -20, 0);
    public static Vector3 originPoint = new Vector3(35, -20, 0);

    //========variable for upgrade=====
    public static bool hasObstacle = true;
    public static float realTimeForMin = 0.2f;
    public static float movSpeed = 5;
    public static float actualSpeed = movSpeed;
    public static float damage = 40;
    public static float pkgBaseIncome = 500f;
    public static int pkglimit = 4;

    public static bool flagShop = false;

    public static Upgrade[] upgrades = {
        new Upgrade("SpeedUp", 300, 3, "You will be granted with a permanent speed up with this turbo charger, and be careful during your flight."),
        new Upgrade("DmgDown", 300, 3, "With the Wno reverse card, the damage recevied by your package will be reduced."),
        new Upgrade("SlowerTime", 300, 3, "Except from the red and blue pill, you can choose this green pill. It makes you feel time flows slower."),
        new Upgrade("RandomUpgrade", 200, 50, "No one knows what is inside this gashapon machine."),
        new Upgrade("PackageLimit + 1", 1000, 1, "Your boss will grant you one more choice(You can do more delivery now!)")
    };

    //===========timer===============
    public static float Timer;
    public static StaticTime initTime;
    

    //=========order info============

    public static package[] packages;
    public static int pkgNum;
    //==========animal info===========
    public static Animal[] animals = {
        new Animal("Ms.Crocodile", "Lake", new string[]{"fried chicken", "burger", "human"}),
        new Animal("the G.O.A.T", "MountainTop", new string[]{"Laptop", "Gundamn", "Unity4d", "Gamepad", "rocket","EVA-30"}),
        new Animal("Ms.Fox", "Plain", new string[]{"Ducci", "Shanel", "Bior", "Vouis Luitton", "Drapa"}),
        new Animal("Mr.Bear", "Cave", new string[]{"honey", "fish","berry"}),
    };


    // for pause_menu
    public static bool sound_on = true;

}
