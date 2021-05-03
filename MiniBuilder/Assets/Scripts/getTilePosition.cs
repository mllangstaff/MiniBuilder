using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class getTilePosition : MonoBehaviour
{
    private Camera camera;
    public static getTilePosition inst;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        inst = this;
    }
    private void Awake()
    {
        
    }
    public Vector3 getCurPos()
    {
        Vector3 pos = new Vector3(0, -99, 0);
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return pos;
        }

        Plane plane = new Plane(Vector3.up, Vector3.zero);
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        float rayOut = 0.0f;

        if (plane.Raycast(ray, out rayOut))
        {
            Vector3 newPos = ray.GetPoint(rayOut) - new Vector3(0.2f, 0.0f, 0.2f);
            pos = new Vector3(newPos.x, 0.25f,newPos.z);
            return pos;
        }
        return pos;
    }
}
