using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterEVNTmanager : MonoBehaviour
{
    public static MasterEVNTmanager Instance = null;
    private void Awake()
    {
        // Debug.Log("GAME eventMANAGER Awake");

        //  FindObjectOfType<cursorkiller>().ShouldIkillCursor();
        if (Instance == null)
        {
            Instance = this;
        }
        else
            Destroy(gameObject);
    }

    #region Events
    public delegate void EVENT_REct(int x, int y , int w, int h);
    public static event EVENT_REct OnRectReady;
    public static void CALL_RectReady(int x, int y, int w, int h)
    {
        if (OnRectReady != null) OnRectReady(x,y,w,h);
    }
 

    #endregion
}