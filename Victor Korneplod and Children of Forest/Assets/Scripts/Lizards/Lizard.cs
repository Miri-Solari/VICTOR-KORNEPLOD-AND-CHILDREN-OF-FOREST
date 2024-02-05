using UnityEngine;
using UnityEngine.AI;

public class Lizard : MonoBehaviour
{
    [SerializeField] float HP = 10;
    private float MaxHP = 10;
    public Animator jasher;
    
    internal void TakeDamege(float damege)
    {
        HP -= damege;
    }

    private void Start()
    {
        MaxHP = HP;
        gameObject.tag = "lizard";
    }

    private void Update()
    {
        if (HP <= 0)
        {
            var agent = GetComponent<NavMeshAgent>();
            if (agent != null)
            {
                agent.enabled = false;
            }


            var collider = GetComponent<Collider>();
            if (collider != null)
            {
                Destroy(collider);
            }

            jasher.SetBool("Death", true);
            Invoke(nameof(SelfDestroy), 2f);
        }
    }

    public void HalfHp()
    {
        HP = MaxHP / 2;
    }

    public void AddTenPercHP()
    {
        HP += MaxHP / 10;
    }

    public bool IsFullHP()
    {
        return HP == MaxHP;
    }

    public void SelfDestroy()
    {
        Destroy(gameObject);
    }

    public void NaoralPolyak()
    {
        HP -= HP * 0.05f;
    }

    public float GiveMaxHP()
    {
        return MaxHP;
    }

    public float GiveCurrHP()
    {
        return HP;
    }

}
