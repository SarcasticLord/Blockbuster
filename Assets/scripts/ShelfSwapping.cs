using UnityEngine;

public class ShelfSwapping : MonoBehaviour
{

    public GameObject[] shelves;
    public int shelfIndex;
    [SerializeField] PlayerController player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("pickUp"))
        {
            if (shelfIndex >= shelves.Length - 1) return;

            GameObject box = other.gameObject;
            
            if (shelfIndex < shelves.Length - 1)
            {
                GameObject newShelf = Instantiate(shelves[shelfIndex +1], transform.position, transform.rotation);
                newShelf.GetComponent<ShelfSwapping>().shelfIndex = shelfIndex +1;
                Destroy(gameObject);

                if (shelfIndex == 6)
                {
                    player.stockCount++;
                }

                
                
            }
            Destroy(box);
        }
    }
}
