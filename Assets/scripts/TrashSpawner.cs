using UnityEngine;
using System.Collections;


public class TrashSpawner : MonoBehaviour
{
    public Transform TrashPoint;
    public GameObject Trash; 
    public GameObject trashExists;

    public bool facingRight = true;

    
    void Start()
    {
        StartCoroutine(TrashSpawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TrashSpawn() 
    {
        while (true)
        {
            if (trashExists == null)
            {
                trashExists = Instantiate(Trash, TrashPoint.position, facingRight ? TrashPoint.rotation : Quaternion.Euler(0, 180, 0));

                yield return new WaitForSeconds(10f);
            }
            
        }
        
    }
}
