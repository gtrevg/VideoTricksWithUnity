using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotAnimEvventListener : MonoBehaviour
{

    public KitchenCtrl kitchenController;

    public void PivottAnimaState(int x) {

        kitchenController.DropCrumbs(x);

    } 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
