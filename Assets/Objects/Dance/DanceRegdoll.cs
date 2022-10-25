using UnityEngine;

public class DanceRegdoll : MonoBehaviour
{
    public Animator animator;
    public Rigidbody[] AllRigidBodys;

    void Start()
    {
        for(int i = 0; i < AllRigidBodys.Length; i++)
        {
            AllRigidBodys[i].isKinematic = true;
        }

        Invoke("SetRegdoll", 5f);
    }

    void SetRegdoll()
    {
        animator.enabled = false;
        for(int i = 0; i < AllRigidBodys.Length; i++)
        {
            AllRigidBodys[i].isKinematic = false;
        }
    }
}