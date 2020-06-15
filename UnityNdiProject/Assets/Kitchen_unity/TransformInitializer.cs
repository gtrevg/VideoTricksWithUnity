using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformInitializer : MonoBehaviour
{

    Vector3 InitialProsition= new Vector3();
   // public Vector3 GetInitialPosition() { return this.InitialProsition; }
    Quaternion InitialRotation = new Quaternion();
   // public Quaternion GetInitialRotation() { return this.InitialRotation; }

    // Start is called before the first frame update
    void Start()
    {
        InitialProsition = this.transform.position;
        InitialRotation = this.transform.rotation;
    }
    public void ResetPosRot() {
        this.transform.localPosition = InitialProsition;
        this.transform.rotation=InitialRotation;
    }

}
