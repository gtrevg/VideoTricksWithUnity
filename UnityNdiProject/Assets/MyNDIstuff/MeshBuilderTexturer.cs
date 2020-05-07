using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshBuilderTexturer : MonoBehaviour
{
    public Material leMateriel;
    private Vector2[] headDownUv;
    public GameObject targ;
    Mesh mesh;

    private void OnEnable()
    {
        MasterEVNTmanager.OnRectReady += HeardNEwRect;
            
    }
    private void OnDisable()
    {
        MasterEVNTmanager.OnRectReady -= HeardNEwRect;
    }

    void HeardNEwRect(int x, int y, int w, int h) {
          _head_x = x;
         _head_y = _textureHeight- y;
         _head_W = w;
         _head_H =h;
      //  print(x + " " + y+ " " + w+ " " +h );
      headDownUv = GetUVRectFromPixels(_head_x, _head_y, _head_W, _head_H, _textureWidth, _textureHeight);
      ApplyUvToUvArray(headDownUv, ref uv);
        mesh.uv = uv;
    }
    int _head_x = 0;
    int _head_y = 64;
    int _head_W = 50;
    int _head_H = 50;
    int _textureWidth = 256;
    int _textureHeight = 256;
    // Start is called before the first frame update1
    Vector2[] uv = new Vector2[4];
    void Start()
    {
        Vector3[] vertices = new Vector3[4]
      {
            new Vector3(0,  1),
            new Vector3(1, 1),
            new Vector3(0, 0),
            new Vector3(1, 0)
      };



        //{
        //        new Vector2(0, 0),
        //        new Vector2(1, 0),
        //        new Vector2(0, 1),
        //        new Vector2(1, 1)
        //};

        headDownUv = GetUVRectFromPixels(_head_x, _head_y, _head_W,_head_H, _textureWidth, _textureHeight);
        ApplyUvToUvArray(headDownUv, ref uv);
        Vector3[] normals = new Vector3[4]
        {
            -Vector3.forward,
            -Vector3.forward,
            -Vector3.forward,
            -Vector3.forward
        };

        int[] tris = new int[6]
        {
           0,1,2,2,1,3
        };

 

       

        //MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
        //meshRenderer.sharedMaterial = new Material(Shader.Find("Standard"));

        //MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();

        //  meshFilter.mesh = mesh;
         mesh = new Mesh();


        mesh.vertices = vertices;
        mesh.triangles = tris;
        mesh.uv = uv;
        mesh.normals = normals;

        GameObject go = new GameObject("Mesh", typeof(MeshFilter), typeof(MeshRenderer));
        go.transform.localScale = new Vector3(0.35f, 0.4f, 1);
        go.GetComponent<MeshFilter>().mesh = mesh;
        go.GetComponent<MeshRenderer>().material = leMateriel;
        go.transform.parent = this.transform;
        go.transform.localPosition = new Vector3(0, 0, 0);


    }


    public Vector2 ConvertPixelsToUvCoordinate(int x, int y, int textureWidth, int textureHeight)
    {
        return new Vector2((float)x / textureWidth, (float)y / textureHeight);
    }
    private Vector2[] GetUVRectFromPixels(int x, int y, int argwidth, int argheight, int argTextureWidth, int argTextureHeight)
    {
        // 0,1
        // 1,1
        // 0,0
        // 1,0

        return new Vector2[]
      {
          ConvertPixelsToUvCoordinate(x,y+argheight, argTextureWidth, argTextureHeight),
          ConvertPixelsToUvCoordinate(x+argwidth,y+argheight, argTextureWidth, argTextureHeight),
          ConvertPixelsToUvCoordinate(x,y, argTextureWidth, argTextureHeight),
          ConvertPixelsToUvCoordinate(x+argwidth,y, argTextureWidth, argTextureHeight)
      };
    }


    private void ApplyUvToUvArray(Vector2[] argUV, ref Vector2[] mainUv)
    {
        //remove later for performance
        if (argUV == null || argUV.Length < 4 || mainUv == null || mainUv.Length < 4) return;// throw new System.Exception();
        mainUv[0] = argUV[0];
        mainUv[1] = argUV[1];
        mainUv[2] = argUV[2];
        mainUv[3] = argUV[3];

    }

    // Update is called once per frame
    void Update()
    {
      //  headDownUv = GetUVRectFromPixels(_head_x, _head_y, _head_W, _head_H, _textureWidth, _textureHeight);
     //   ApplyUvToUvArray(headDownUv, ref uv);
    }
}
