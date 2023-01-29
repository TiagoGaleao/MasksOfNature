using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterOrb : MonoBehaviour
{
    private float _speed = 1.0f;

    // Update is called once per frame
    void Update()
    {
        Vector3 velocity = Vector3.right * _speed;
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition,Camera.MonoOrStereoscopicEye.Mono);
        Vector2 adjust = new Vector2(worldPoint.x, worldPoint.y);

        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPosition.z = 0;
        //worldPosition.x = 0;
        //worldPosition.y = 0;

        transform.position = worldPosition;

        if(Input.GetMouseButtonUp(0)){
            removeWaterOrb();
        }

    }

    void removeWaterOrb(){
        Destroy(gameObject);
    }
}
