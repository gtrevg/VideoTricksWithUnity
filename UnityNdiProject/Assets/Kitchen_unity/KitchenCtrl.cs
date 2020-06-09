using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenCtrl : MonoBehaviour
{
    public GameObject KitchenObj;
    public GameObject PivotPoint;

    private GameObject IslandObj;
    private GameObject FridgeDoorObj;
    private GameObject CabL1Obj;
    private GameObject CabCornObj;
    private GameObject CabR1Obj;
    private GameObject HauteObj;
    private GameObject Trashcan;
    private GameObject Fridge;
    private GameObject Barsool1Obj;
    private GameObject Barsool2Obj; 
    private GameObject Barsool3Obj;
    private GameObject WoodStool;
    private GameObject CoffeMaker;
    private GameObject Nespresso;
    private GameObject KnifeBlock;
    private GameObject WoodenSpoonVase;
    private GameObject WaterBoiler;
    private GameObject Toaster;
    private GameObject LargeYellowBowl;
    private GameObject Britta;
    private GameObject BrownSquareBasket;
    private GameObject Lightbasket;
    private GameObject SmallWhiteBowl;
    private GameObject TissueBox;
    private GameObject Grabbabble_CeilingObj;

    private GameObject Solid_Ceiling;
    public List<GameObject> Crumbs_Ceiling= new List<GameObject>();

    private GameObject Solid_MidWall;
    public List<GameObject> Crumbs_MidWall = new List<GameObject>();

    private GameObject Solid_BackWall;
    public List<GameObject> Crumbs_BackWall = new List<GameObject>();

    private GameObject Solid_Bar;
    public List<GameObject> Crumbs_Bar = new List<GameObject>();

    private GameObject Solid_RightWall;
    public List<GameObject> Crumbs_RightWall = new List<GameObject>();

    private GameObject IslandColliderObj;
    private GameObject FloorColliderObj;
    private GameObject CounterColliderObj;

    int childcount = 0;
    // Start is called before the first frame update
    void Start()
    {

        //gather elements
        GatherObjects();

        StripColliders();

        ToggleListObjects(Crumbs_Ceiling, false);
        ToggleListObjects(Crumbs_Bar, false);
        ToggleListObjects(Crumbs_MidWall, false);
        ToggleListObjects(Crumbs_BackWall, false);
        ToggleListObjects(Crumbs_RightWall, false);
        // create psudoarmature

        AttacheRlevantOjectsToPivot();

    }

    #region privates
    void GatherObjects() {

        for (int c = 0; c < this.KitchenObj.transform.childCount; c++)
        {
            if (this.KitchenObj.transform.GetChild(c).name.Contains("Ceiling.Crumb_"))
            {
                Crumbs_Ceiling.Add(this.KitchenObj.transform.GetChild(c).gameObject);
            }
            else
            if (this.KitchenObj.transform.GetChild(c).name.Contains("CeilingBar.Crumb_cell"))
            {
                Crumbs_Bar.Add(this.KitchenObj.transform.GetChild(c).gameObject);
            }
            else
            if (this.KitchenObj.transform.GetChild(c).name.Contains("WallMid.Crumb_cell"))
            {
                Crumbs_MidWall.Add(this.KitchenObj.transform.GetChild(c).gameObject);
            }
            else
            if (this.KitchenObj.transform.GetChild(c).name.Contains("WallBack.Crumb_"))
            {
                Crumbs_BackWall.Add(this.KitchenObj.transform.GetChild(c).gameObject);
            }
            else
            if (this.KitchenObj.transform.GetChild(c).name.Contains("WallRigh.Crumb_"))
            {
                Crumbs_RightWall.Add(this.KitchenObj.transform.GetChild(c).gameObject);
            }
            else
            if (this.KitchenObj.transform.GetChild(c).name.CompareTo("Ceiling.Crumb") == 0)
            {
                Solid_Ceiling = this.KitchenObj.transform.GetChild(c).gameObject;
            }
            else
            if (this.KitchenObj.transform.GetChild(c).name.CompareTo("CeilingBar.Crumb") == 0)
            {
                Solid_Bar = this.KitchenObj.transform.GetChild(c).gameObject;
            }
            else
            if (this.KitchenObj.transform.GetChild(c).name.CompareTo("WallBack.Crumb") == 0)
            {
                Solid_BackWall = this.KitchenObj.transform.GetChild(c).gameObject;
            }
            else
            if (this.KitchenObj.transform.GetChild(c).name.CompareTo("WallMid.Crumb") == 0)
            {
                Solid_MidWall = this.KitchenObj.transform.GetChild(c).gameObject;
            }
            else
            if (this.KitchenObj.transform.GetChild(c).name.CompareTo("WallRigh.Crumb") == 0)
            {
                Solid_RightWall = this.KitchenObj.transform.GetChild(c).gameObject;
            }
            else
        if (this.KitchenObj.transform.GetChild(c).name.Contains("MidIsland")) { IslandObj = this.KitchenObj.transform.GetChild(c).gameObject; }
            else
        if (this.KitchenObj.transform.GetChild(c).name.Contains("FridgeDoor")) { FridgeDoorObj = this.KitchenObj.transform.GetChild(c).gameObject; }
            else
        if (this.KitchenObj.transform.GetChild(c).name.Contains("Cab_up_01")) { CabL1Obj = this.KitchenObj.transform.GetChild(c).gameObject; }
            else
        if (this.KitchenObj.transform.GetChild(c).name.Contains("Cab_up_02")) { CabCornObj = this.KitchenObj.transform.GetChild(c).gameObject; }
            else
        if (this.KitchenObj.transform.GetChild(c).name.Contains("Cab_up_03")) { CabR1Obj = this.KitchenObj.transform.GetChild(c).gameObject; }
            else
        if (this.KitchenObj.transform.GetChild(c).name.Contains("Haute")) { HauteObj = this.KitchenObj.transform.GetChild(c).gameObject; }
            else
        if (this.KitchenObj.transform.GetChild(c).name.Contains("Trashcan")) { Trashcan = this.KitchenObj.transform.GetChild(c).gameObject; }
            else
        if (this.KitchenObj.transform.GetChild(c).name.Contains("Fridge")) { Fridge = this.KitchenObj.transform.GetChild(c).gameObject; }
            else
        if (this.KitchenObj.transform.GetChild(c).name.Contains("BarStool.001")) { Barsool1Obj = this.KitchenObj.transform.GetChild(c).gameObject; }
            else
        if (this.KitchenObj.transform.GetChild(c).name.Contains("BarStool.002")) { Barsool2Obj = this.KitchenObj.transform.GetChild(c).gameObject; }
            else
        if (this.KitchenObj.transform.GetChild(c).name.Contains("BarStool.003")) { Barsool3Obj = this.KitchenObj.transform.GetChild(c).gameObject; }
            else
        if (this.KitchenObj.transform.GetChild(c).name.Contains("WoodStool")) { WoodStool = this.KitchenObj.transform.GetChild(c).gameObject; }
            else
        if (this.KitchenObj.transform.GetChild(c).name.Contains("Coffeemaker")) { CoffeMaker = this.KitchenObj.transform.GetChild(c).gameObject; }
            else
        if (this.KitchenObj.transform.GetChild(c).name.Contains("Nespresso")) { Nespresso = this.KitchenObj.transform.GetChild(c).gameObject; }
            else
        if (this.KitchenObj.transform.GetChild(c).name.Contains("Knifeblock")) { KnifeBlock = this.KitchenObj.transform.GetChild(c).gameObject; }
            else
        if (this.KitchenObj.transform.GetChild(c).name.Contains("WoodSpoonjar")) { WoodenSpoonVase = this.KitchenObj.transform.GetChild(c).gameObject; }
            else
        if (this.KitchenObj.transform.GetChild(c).name.Contains("Boiler")) { WaterBoiler = this.KitchenObj.transform.GetChild(c).gameObject; }
            else
        if (this.KitchenObj.transform.GetChild(c).name.Contains("Toaster")) { Toaster = this.KitchenObj.transform.GetChild(c).gameObject; }
            else
        if (this.KitchenObj.transform.GetChild(c).name.Contains("BowlYellow")) { LargeYellowBowl = this.KitchenObj.transform.GetChild(c).gameObject; }
            else
        if (this.KitchenObj.transform.GetChild(c).name.Contains("Britta")) { Britta = this.KitchenObj.transform.GetChild(c).gameObject; }
            else
        if (this.KitchenObj.transform.GetChild(c).name.Contains("BasketSquare")) { BrownSquareBasket = this.KitchenObj.transform.GetChild(c).gameObject; }
            else
        if (this.KitchenObj.transform.GetChild(c).name.Contains("BasketRound")) { Lightbasket = this.KitchenObj.transform.GetChild(c).gameObject; }
            else
        if (this.KitchenObj.transform.GetChild(c).name.Contains("BowlSmall")) { SmallWhiteBowl = this.KitchenObj.transform.GetChild(c).gameObject; }
            else
        if (this.KitchenObj.transform.GetChild(c).name.Contains("Tissues")) { TissueBox = this.KitchenObj.transform.GetChild(c).gameObject; }
            else
        if (this.KitchenObj.transform.GetChild(c).name.Contains("Collider.LongCounter")) { CounterColliderObj = this.KitchenObj.transform.GetChild(c).gameObject; }
            else
        if (this.KitchenObj.transform.GetChild(c).name.Contains("Collider_KitchenFloor")) { IslandColliderObj = this.KitchenObj.transform.GetChild(c).gameObject; }
            else
        if (this.KitchenObj.transform.GetChild(c).name.Contains("Collider_Island")) { FloorColliderObj = this.KitchenObj.transform.GetChild(c).gameObject; }
            else
                if (this.KitchenObj.transform.GetChild(c).name.Contains("Grabbabble_Ceilin")) { Grabbabble_CeilingObj = this.KitchenObj.transform.GetChild(c).gameObject; }




        }

    }

    void ToggleListObjects(List<GameObject> argList, bool argOnOff) {
        foreach (GameObject go in argList) {
            go.SetActive(argOnOff);
        }
    }

    void StripColliders() {
       IslandColliderObj.GetComponent<MeshRenderer>().enabled = false;
        IslandColliderObj.AddComponent<MeshCollider>();
        //IslandColliderObj.GetComponent<MeshCollider>().convex = true;
        IslandColliderObj.AddComponent<Rigidbody>();
        IslandColliderObj.GetComponent<Rigidbody>().isKinematic = true;
        IslandColliderObj.GetComponent<Rigidbody>().useGravity = false;

        FloorColliderObj.GetComponent<MeshRenderer>().enabled = false;
        FloorColliderObj.AddComponent<MeshCollider>();
        FloorColliderObj.GetComponent<MeshCollider>().convex=true;
        FloorColliderObj.AddComponent<Rigidbody>();
        FloorColliderObj.GetComponent<Rigidbody>().isKinematic = true;
        FloorColliderObj.GetComponent<Rigidbody>().useGravity = false;

        CounterColliderObj.AddComponent<MeshCollider>();
        CounterColliderObj.GetComponent<MeshCollider>().convex=true;
        CounterColliderObj.GetComponent<MeshRenderer>().enabled = false;
        CounterColliderObj.AddComponent<Rigidbody>();
        CounterColliderObj.GetComponent<Rigidbody>().isKinematic = true;
        CounterColliderObj.GetComponent<Rigidbody>().useGravity = false;


        foreach (GameObject go in Crumbs_Ceiling) {
           go.AddComponent<MeshCollider>();
           go.GetComponent<MeshCollider>().convex = true;
            go.AddComponent<Rigidbody>();
            go.GetComponent<Rigidbody>().isKinematic = true;
            go.GetComponent<Rigidbody>().useGravity = false;
        }
    }

    void AttacheRlevantOjectsToPivot() {

        Solid_Ceiling.transform.parent = PivotPoint.transform;
        Solid_BackWall.transform.parent = PivotPoint.transform;
        Solid_MidWall.transform.parent = PivotPoint.transform;
        Solid_Bar.transform.parent = PivotPoint.transform;
        Solid_RightWall.transform.parent = PivotPoint.transform;
        Grabbabble_CeilingObj.transform.parent = PivotPoint.transform;
        CabL1Obj.transform.parent = PivotPoint.transform;
        CabCornObj.transform.parent = PivotPoint.transform;
       // CabR1Obj.transform.parent = PivotPoint.transform;
        HauteObj.transform.parent = PivotPoint.transform;
        foreach (GameObject go in Crumbs_Ceiling) { go.transform.parent = PivotPoint.transform; }

        foreach (GameObject go in Crumbs_Bar) { go.transform.parent = PivotPoint.transform; }

        foreach (GameObject go in Crumbs_BackWall) { go.transform.parent = PivotPoint.transform; }

    }

    #endregion

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {

            Solid_Ceiling.GetComponent<MeshRenderer>().enabled = false;
            ToggleListObjects(Crumbs_Ceiling, true);
            foreach (GameObject go in Crumbs_Ceiling)
            {
                //go.GetComponent<MeshRenderer>().enabled = true;

                go.GetComponent<Rigidbody>().isKinematic = false;
                go.GetComponent<Rigidbody>().useGravity = true;
            }

        }
        
    }
}
