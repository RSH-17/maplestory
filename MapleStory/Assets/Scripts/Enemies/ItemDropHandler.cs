using UnityEngine;

public class ItemDropHandler : MonoBehaviour
{
    private DeathHandler death;
    public GameObject item;

    void Awake()
    {
        if (death == null) death = GetComponent<DeathHandler>();
        death.OnDie += DropItem;
        
    }
    void ODisable()
    {
        
    }
    private void DropItem()
    {
        if (item != null)
        {
            Instantiate(item, transform.position, Quaternion.identity);
        }
    }
}
