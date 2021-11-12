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
        var horzExtent = vertExtent * Screen.width / Screen.height;
        bounds = new Bounds(cam.transform.position, new Vector3(horzExtent * 2f, vertExtent * 2f, 0));
        Debug.Log(bounds.min.x);
    }

    //Returns a Bounds object that is 90% of Camera Bounds
    Bounds inBounds()
    {
        Bounds a = bounds;
        a.Expand(.9f);
        return a;
    }
}
