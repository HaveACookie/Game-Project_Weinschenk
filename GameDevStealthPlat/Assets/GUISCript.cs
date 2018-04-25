using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUISCript : MonoBehaviour
{
    string TimeString;
    public Font font;
    public Color color;
    // Use this for initialization
    void Start()
    {

        //TimeString = GameManager.Instance.timer.ToString ;
        //GUI.skin.font = font;
        GUI.color = color;

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnGUI()
    {
        GUIStyle myStyle = new GUIStyle(GUI.skin.GetStyle("label"));
        myStyle.fontSize = 32;
        GUI.Label(new Rect(0,0, 1000, 1000), "Find the key to activate the exit portal!", myStyle);
    }

}
