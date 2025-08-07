using UnityEngine;

[CreateAssetMenu(fileName = "AddCoinSO", menuName = "CollectEffect/AddCoinSO")]
public class AddCoinSO : ScriptableObject, ICollectEffect
{
    public void Apply(GameObject player, DropItem item)
    {
        Debug.Log("코인획득"+player.transform.position.x);
    }
}
