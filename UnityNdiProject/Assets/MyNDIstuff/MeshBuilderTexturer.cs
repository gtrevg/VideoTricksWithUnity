using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshBuilderTexturer : MonoBehaviour
{
    public Material leMateriel;
    private Vector2[] headDownUv;

    // Start is called before the first frame update
    void Start()
    {
        Vector3[] vertices = new Vector3[4]
      {
            new Vector3(0,  1),
            new Vector3(1, 1),
            new Vector3(0, 0),
            new Vector3(1, 0)
      };


        Vector2[] uv = new Vector2[4];

        //{
        //        new Vector2(0, 0),
        //        new Vector2(1, 0),
        //        new Vector2(0, 1),
        //        new Vector2(1, 1)
        //};

        headDownUv = GetUVRectFromPixels(0, 380, 128, 128, 258, 256);
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

        int headx = 0;
        int heady = 380;
        int headWidth = 128;
        int headHeight = 128;

        int _textureWidth = 256;
        int _textureHeight = 256;

        //MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
        //meshRenderer.sharedMaterial = new Material(Shader.Find("Standard"));

        //MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();

        //  meshFilter.mesh = mesh;
        Mesh mesh = new Mesh();


        mesh.vertices = vertices;
        mesh.triangles = tris;
        mesh.uv = uv;
        mesh.normals = normals;

        GameObject go = new GameObject("Mesh", typeof(MeshFilter), typeof(MeshRenderer));
        go.transform.localScale = new Vector3(1, 1, 1);
        go.GetComponent<MeshFilter>().mesh = mesh;
        go.GetComponent<MeshRenderer>().material = leMateriel;


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
        if (argUV == null || argUV.Length < 4 || mainUv == null || mainUv.Length < 4) throw new System.Exception();
        mainUv[0] = argUV[0];
        mainUv[1] = argUV[1];
        mainUv[2] = argUV[2];
        mainUv[3] = argUV[3];

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
