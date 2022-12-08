using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject poi;
    public GameObject[] panels;
    public float scrollSpeed = -30f;
    public float motionMult = 0.25f;

    private float panelHit;
    private float depth;

    // Start is called before the first frame update
    void Start()
    {
        panelHit = panels[0].transform.localScale.y;
        depth = panels[0].transform.position.z;

        panels[0].transform.position = new Vector3(0, 0, depth);
        panels[1].transform.position = new Vector3(0, panelHit, depth);
    }

    // Update is called once per frame
    void Update()
    {
        float tY, tX = 0;
        tY = Time.time * scrollSpeed % panelHit + (panelHit * 0.5f);

        if(poi != null)
        {
            tX = -poi.transform.position.x * motionMult;
        }

        panels[0].transform.position = new Vector3(tX, tY, depth);

        if(tY >= 0)
        {
            panels[1].transform.position = new Vector3(tX, tY - panelHit, depth);
        }
        else
        {
            panels[1].transform.position = new Vector3(tX, tY + panelHit, depth);
        }
    }
}
