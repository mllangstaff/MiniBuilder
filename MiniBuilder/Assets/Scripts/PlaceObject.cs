using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObject : MonoBehaviour
{
    private bool placing;
    private ObjectPresets curObject;

    private float placementUpdate = 0.025f;
    private float lastUpdated;
    public GameObject placer;
    private Vector3 curPlacementPos;

    public static PlaceObject inst;

    public List<GameObject> clones = new List<GameObject>();
    public GameObject text;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void Awake()
    {
        inst = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastUpdated > placementUpdate && placing)
        {
            lastUpdated = Time.time;
            curPlacementPos = getTilePosition.inst.getCurPos();
            placer.transform.position = curPlacementPos;
        }
        if (placing && Input.GetMouseButtonDown(0))
        {
            bool valid = true;
            foreach (GameObject g in clones)
            {
                float maxX=0.0f;
                float minX=0.0f;
                if (g.name == "Sphere")
                {
                     maxX = g.transform.position.x + .15f;
                     minX = g.transform.position.x - .15f;
                }else if (g.name == "Cube"||g.name=="Cylinder")
                {
                     maxX = g.transform.position.x + .2f;
                     minX = g.transform.position.x - .2f;
                }/*else if (g.name == "Cylinder")
                {
                    maxX = g.transform.position.x + .2f;
                    minX = g.transform.position.x - .2f;
                }*/
                if (curPlacementPos.x > minX && curPlacementPos.x < maxX)
                {
                    valid = false;
                    text.SetActive(true);
                }
                else
                {
                    valid = true;
                    text.SetActive(false);
                }
            }
            if (valid)
            {
                text.SetActive(false);
                confirmPlacing();
            }
        }
    }

    public void beginPlacing(ObjectPresets objectPreset)
    {
        placing = true;
        curObject = objectPreset;
        placer.SetActive(true);
        for (int i = 0; i < placer.transform.childCount; i++)
        {
            if (placer.transform.GetChild(i).name == objectPreset.name)
            {
                //Debug.Log(placer.transform.GetChild(i).name);
                placer.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }
    public void confirmPlacing()
    {
        GameObject newObject = Instantiate(curObject.prefab, curPlacementPos, Quaternion.identity);
        newObject.name = curObject.name;
        clones.Add(newObject);

        placing = false;
        placer.SetActive(false);
        for (int i = 0; i < placer.transform.childCount; i++)
        {
            if (placer.transform.GetChild(i).name == newObject.name)
            {
                Debug.Log(placer.transform.GetChild(i).name);
                placer.transform.GetChild(i).gameObject.SetActive(false);
            }
        }

    }
}
