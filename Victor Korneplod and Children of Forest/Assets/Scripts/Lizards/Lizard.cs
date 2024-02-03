using UnityEngine;

public class Lizard : MonoBehaviour
{
    [SerializeField] float HP = 10;
    
    internal void TakeDamege(float damege)
    {
        HP -= damege;
    }

    private void Start()
    {
        gameObject.tag = "lizard";
    }

    private void Update()
    {
        if (HP <= 0)
        {
             Destroy(gameObject);
        }
    }

}
