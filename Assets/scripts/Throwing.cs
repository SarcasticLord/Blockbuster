using UnityEngine;

public class Throwing : MonoBehaviour
{

public GameObject[] throwableObjects;
public Transform throwPoint;
public float throwForce = 15f;
public float despawnTime = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
        
        if (Input.GetMouseButtonDown(1))
        {
            Throw();
            
        }
    }

    public void Throw()
    {
        if (throwableObjects.Length == 0) return;

        int random = Random.Range(0, throwableObjects.Length);
        GameObject itemToThrow = throwableObjects[random];

        GameObject spawnRandom = Instantiate(itemToThrow, throwPoint.position, throwPoint.rotation);
        Rigidbody rb = spawnRandom.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.AddForce(throwPoint.forward * throwForce, ForceMode.Impulse);
        }

        Destroy(spawnRandom, despawnTime);
    }
}
