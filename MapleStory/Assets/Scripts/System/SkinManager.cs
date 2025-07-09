using UnityEngine;

public class SkinManager : MonoBehaviour
{
    public static SkinManager Instance;
    private static SkinManager instance;

    [System.Serializable]
    public class WeaponAnimArray
    {
        public AnimationClip[] AnimClips;
    }
    public WeaponAnimArray[] WeaponArrays;
}
