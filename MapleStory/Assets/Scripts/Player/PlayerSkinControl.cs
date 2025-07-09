using UnityEngine;

public class PlayerSkinControl : MonoBehaviour
{
    public static PlayerSkinControl Instance { get; private set; }
    private static PlayerSkinControl instance;


    public PlayerSkin[] playerSkins;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Change Skin
    public void SkinSetTrigger(string animName)
    {
        foreach (PlayerSkin skin in playerSkins)
            skin.anim.SetTrigger(animName);
    }
}
