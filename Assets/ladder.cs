using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ladder : MonoBehaviour
{

    float posY;
    

    
    
    void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<Rigidbody2D>().constraints = ~RigidbodyConstraints2D.FreezePosition |RigidbodyConstraints2D.FreezeRotation;
        
    } 
    /*
    void OnTriggerStay2D(Collider2D other)
    {
        other.GetComponent<Rigidbody2D>().constraints = ~RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;  
    } 
    */
    void OnTriggerExit2D(Collider2D other)
    {

        var pos = GameObject.Find("Player").transform.position;
        if(pos.y != -1.820812f && pos.y != 2.06f && pos.y == 5.859997f)
        {
            Start();

            void Start()
            {
                StartCoroutine(waiter());
            }
                
            IEnumerator waiter()
            {             
                posY = -1.820812f;
                Vector3 newPos = new Vector3(pos.x, posY, pos.z);
                pos = Vector3.Lerp(pos, newPos, 1);
                Debug.Log("left");
                
                //Wait 
                Debug.Log("Waiting for Player landing ");
                yield return new WaitUntil(() => pos.y == posY);
                Debug.Log("Player has landed");

                
            }
        }

        other.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation | ~RigidbodyConstraints2D.FreezePositionX;
        
        
    } 
    
}
