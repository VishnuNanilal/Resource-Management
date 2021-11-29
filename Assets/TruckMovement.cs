using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckMovement : MonoBehaviour
{
    [SerializeField] Building dropPoint;
    [SerializeField] float speed = 1f;
    [SerializeField] Transform targetTransform;

    // Update is called once per frame
    private Vector3 initialPos;
    private Vector3 targetPos;
    
    private void Awake() {
        initialPos = transform.position;    
        targetPos = targetTransform.position;
        dropPoint.InventoryFullEvent += StartMovement;
    }

    public void StartMovement()
    {   
        StartCoroutine(MoveTruck());
    }

    private IEnumerator MoveTruck()
    {
        while(true)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed*Time.deltaTime);
            if(Mathf.Approximately(transform.position.z, targetPos.z))
            {
                StopAllCoroutines();
                StartCoroutine(MoveBackTruck());
            }
            yield return null;
        }
       
    }

    private IEnumerator MoveBackTruck()
    {
        //StopCoroutine("MoveTruck");
        while (true)
        {
            transform.position = Vector3.MoveTowards(transform.position, initialPos, speed * Time.deltaTime);
            if (Mathf.Approximately(transform.position.z, initialPos.z))
            {
                dropPoint.
                StopAllCoroutines();
            }
            yield return null;
        }
    }

}
