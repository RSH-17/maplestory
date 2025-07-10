using UnityEngine;

public interface ISkill
{
    void Active();
    void OnTriggerEnter(Collider other);
}
