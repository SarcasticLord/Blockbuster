using UnityEngine;

public class RollWallDamage : MonoBehaviour
{
    public RollPlayerHealth rollPlayerHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rollPlayerHealth.TakeDamage(1);
        }
    }
}
