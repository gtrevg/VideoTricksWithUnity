using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenCtrl : MonoBehaviour
{
    public GameObject KitchenObj;

    public GameObject IslandObj;
    public GameObject FridgeDoorObj;
    public GameObject CabL1Obj;
    public GameObject CabCornObj;
    public GameObject CabR1Obj;
    public GameObject HauteObj;
    public GameObject Trashcan;
    public GameObject Fridge;
    public GameObject Barsool1Obj;
    public GameObject Barsool2Obj; 
    public GameObject Barsool3Obj;
    public GameObject WoodStool;
    public GameObject CoffeMaker;
    public GameObject Nespresso;
    public GameObject KnifeBlock;
    public GameObject WoodenSpoonVase;
    public GameObject WaterBoiler;
    public GameObject Toaster;
    public GameObject LargeYellowBowl;
    public GameObject Britta;
    public GameObject BrownSquareBasket;
    public GameObject Lightbasket;
    public GameObject SmallWhiteBowl;
    public GameObject TissueBox;

    public GameObject Solid_Ceiling;
     List<GameObject> Crumbs_Ceiling= new List<GameObject>();

    public GameObject Solid_MidWall;
     List<GameObject> Crumbs_MidWall = new List<GameObject>();

    public GameObject Solid_BackWall;
     List<GameObject> Crumbs_BackWall = new List<GameObject>();

    public GameObject Solid_Bar;
     List<GameObject> Crumbs_Bar = new List<GameObject>();

    public GameObject Solid_RightWall;
     List<GameObject> Crumbs_RightWall = new List<GameObject>();


    int childcount = 0;
    // Start is called before the first frame update
    void Start()
    {

        //gather elements
       
        for (int c = 0; c < this.transform.childCount; c++) {
            if (this.transform.GetChild(c).name.Contains("Ceiling.Crumb_"))
            {
                Crumbs_Ceiling.Add(this.transform.GetChild(c).gameObject);
            }
            else
            if (this.transform.GetChild(c).name.Contains("CeilingBar.Crumb_"))
            {
                Crumbs_Bar.Add(this.transform.GetChild(c).gameObject);
            }
            else
            if (this.transform.GetChild(c).name.Contains("WallMid.Crumb_"))
            {
                Crumbs_MidWall.Add(this.transform.GetChild(c).gameObject);
            }
            else
            if (this.transform.GetChild(c).name.Contains("WallBack.Crumb_"))
            {
                Crumbs_BackWall.Add(this.transform.GetChild(c).gameObject);
            }
            else
            if (this.transform.GetChild(c).name.Contains("WallRigh.Crumb_"))
            {
                Crumbs_RightWall.Add(this.transform.GetChild(c).gameObject);
            }
            else
            if (this.transform.GetChild(c).name.CompareTo("Ceiling.Crumb") == 0)
            {
                Solid_Ceiling = this.transform.GetChild(c).gameObject;
            }
            else
            if (this.transform.GetChild(c).name.CompareTo("CeilingBar.Crumb") == 0)
            {
                Solid_Bar = this.transform.GetChild(c).gameObject;
            }
            else
            if (this.transform.GetChild(c).name.CompareTo("WallBack.Crumb") == 0)
            {
                Solid_BackWall = this.transform.GetChild(c).gameObject;
            }
            else
            if (this.transform.GetChild(c).name.CompareTo("WallMid.Crumb") == 0)
            {
                Solid_MidWall = this.transform.GetChild(c).gameObject;
            }
            else
            if (this.transform.GetChild(c).name.CompareTo("WallRigh.Crumb") == 0)
            {
                Solid_RightWall = this.transform.GetChild(c).gameObject;
            }
            else
                    if (this.transform.GetChild(c).name.Contains("IslandObj")) { IslandObj = this.transform.GetChild(c).gameObject; }
            else
        if (this.transform.GetChild(c).name.Contains("FridgeDoorObj")) { FridgeDoorObj = this.transform.GetChild(c).gameObject; }
            else
        if (this.transform.GetChild(c).name.Contains("Cab_up_01")) { CabL1Obj = this.transform.GetChild(c).gameObject; }
            else
        if (this.transform.GetChild(c).name.Contains("Cab_up_02")) { CabCornObj = this.transform.GetChild(c).gameObject; }
            else
        if (this.transform.GetChild(c).name.Contains("Cab_up_03")) { CabR1Obj = this.transform.GetChild(c).gameObject; }
            else
        if (this.transform.GetChild(c).name.Contains("HauteObj")) { HauteObj = this.transform.GetChild(c).gameObject; }
            else
        if (this.transform.GetChild(c).name.Contains("Trashcan")) { Trashcan = this.transform.GetChild(c).gameObject; }
            else
        if (this.transform.GetChild(c).name.Contains("Fridge")) { Fridge = this.transform.GetChild(c).gameObject; }
            else
        if (this.transform.GetChild(c).name.Contains("BarStool.001")) { Barsool1Obj = this.transform.GetChild(c).gameObject; }
            else
        if (this.transform.GetChild(c).name.Contains("BarStool.002")) { Barsool2Obj = this.transform.GetChild(c).gameObject; }
            else
        if (this.transform.GetChild(c).name.Contains("BarStool.003")) { Barsool3Obj = this.transform.GetChild(c).gameObject; }
            else
        if (this.transform.GetChild(c).name.Contains("WoodStool")) { WoodStool = this.transform.GetChild(c).gameObject; }
            else
        if (this.transform.GetChild(c).name.Contains("Coffemaker")) { CoffeMaker = this.transform.GetChild(c).gameObject; }
            else
        if (this.transform.GetChild(c).name.Contains("Nespresso")) { Nespresso = this.transform.GetChild(c).gameObject; }
            else
        if (this.transform.GetChild(c).name.Contains("Knifeblock")) { KnifeBlock = this.transform.GetChild(c).gameObject; }
            else
        if (this.transform.GetChild(c).name.Contains("WoodenSpoonJar")) { WoodenSpoonVase = this.transform.GetChild(c).gameObject; }
            else
        if (this.transform.GetChild(c).name.Contains("Boiler")) { WaterBoiler = this.transform.GetChild(c).gameObject; }
            else
        if (this.transform.GetChild(c).name.Contains("Toaster")) { Toaster = this.transform.GetChild(c).gameObject; }
            else
        if (this.transform.GetChild(c).name.Contains("BowlYellow")) { LargeYellowBowl = this.transform.GetChild(c).gameObject; }
            else
        if (this.transform.GetChild(c).name.Contains("Britta")) { Britta = this.transform.GetChild(c).gameObject; }
            else
        if (this.transform.GetChild(c).name.Contains("BasketSquare")) { BrownSquareBasket = this.transform.GetChild(c).gameObject; }
            else
        if (this.transform.GetChild(c).name.Contains("BasketRound")) { Lightbasket = this.transform.GetChild(c).gameObject; }
            else
        if (this.transform.GetChild(c).name.Contains("SmallWhiteBowl")) { SmallWhiteBowl = this.transform.GetChild(c).gameObject; }
            else
        if (this.transform.GetChild(c).name.Contains("TissueBox")) { TissueBox = this.transform.GetChild(c).gameObject; }
           

        }

        ToggleListObjects(Crumbs_Ceiling, false);
        ToggleListObjects(Crumbs_Bar, false);
        ToggleListObjects(Crumbs_MidWall, false);
        ToggleListObjects(Crumbs_BackWall, false);
        ToggleListObjects(Crumbs_RightWall, false);
        // create psudoarmature

    }

    #region privates

    void ToggleListObjects(List<GameObject> argList, bool argOnOff) {
        foreach (GameObject go in argList) {
            go.SetActive(argOnOff);
        }
    }


    #endregion

    // Update is called once per frame
    void Update()
    {
        
    }
}
