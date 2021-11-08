using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBounds : MonoBehaviour
{
    Camera cam;
    public Bounds bounds;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        setBounds();
        Debug.Log(bounds);
    }

    private void setBounds()
    {
        var vertExtent = cam.orthographicSize;
        var horzExtent = vertExtent * Screen.height / Screen.width;
        bounds = new Bounds(cam.transform.position, new Vector3(vertExtent * 1.5f, horzExtent * 1.5f, 0));
    }

    //Returns a Bounds object that is 90% of Camera Bounds
    Bounds inBounds()
    {
        Bounds a = bounds;
        a.Expand(.9f);
        return a;
    }
}
