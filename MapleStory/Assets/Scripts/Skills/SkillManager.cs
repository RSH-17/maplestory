using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public static SkillManager Instance;
    // private static SkillManager instance;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    [System.Serializable]
    public class JobSkill
    {
        public SOSkill[] skills;
    }
    public JobSkill[] JobSkillArray;
}