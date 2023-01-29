using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkWater : MonoBehaviour
{
    public GameObject waterOrb;
    private bool waterOrbExists = false;
    public void Spawn(Vector2 position){
        Instantiate(waterOrb).transform.position = position;
        waterOrbExists = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            Debug.Log("LMB Pressed");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray,Mathf.Infinity);

            if(hit.collider != null){
                if(hit.collider.name == "Water"){
                    //Debug.Log(hit.collider.name);
                    Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition,Camera.MonoOrStereoscopicEye.Mono);
                    Vector2 adjust = new Vector2(worldPoint.x, worldPoint.y);
                    Instantiate(waterOrb);
                    if(!waterOrbExists){
                        waterOrb.transform.position = adjust;
                        waterOrbExists = true;
                    }
                }
            }
        }

        if(Input.GetMouseButtonUp(0)){
            if(waterOrbExists){
                //waterOrb = null;
                waterOrbExists = false;
            }
        }
    }
}
