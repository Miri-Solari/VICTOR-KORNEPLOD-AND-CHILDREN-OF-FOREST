using UnityEngine;

public class Lizard : MonoBehaviour
{
    [SerializeField] float HP = 10;
    private float MaxHP = 10;
    
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
             SelfDestroy();
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

}
