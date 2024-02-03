using UnityEngine;

public class Effect : MonoBehaviour
{
    public static float secForTile = 0.5f;
    public float time;
    public int multi;
    public GameObject Target;
    [SerializeField] private int _tile;


    protected virtual void Awake()
    {
        Target = gameObject.transform.parent.gameObject;
        _tile *= multi;
        time = _tile * secForTile;
    }

    private void FixedUpdate()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void SetTile(int tile) { _tile = tile;}
}
