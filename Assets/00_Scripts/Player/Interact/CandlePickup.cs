using UnityEngine;

public class CandlePickup : MonoBehaviour
{
    private Inventory inventory;
    [SerializeField] private GameObject CandleInventory;

    private void Awake()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    public void Pickup()
    {
        if (inventory != null)
        {
            inventory.AddTorch();
            Destroy(gameObject);
        }
        CandleInventory.SetActive(true);
    }
}