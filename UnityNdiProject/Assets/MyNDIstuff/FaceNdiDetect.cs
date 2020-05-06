using Klak.Ndi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenCvSharp;
using OpenCvSharp.Demo;

public class FaceNdiDetect : MonoBehaviour
{

    public NdiReceiver ndiReceiver;

    public GameObject SurfaceOutputObject;
    private RenderTexture ndiCamTexture = null;
    private Texture2D renderedTextureoutput = null;




    // Start is called before the first frame update
    void Start()
    {
        //ndiCamTexture = ndiReceiver.targetTexture;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
