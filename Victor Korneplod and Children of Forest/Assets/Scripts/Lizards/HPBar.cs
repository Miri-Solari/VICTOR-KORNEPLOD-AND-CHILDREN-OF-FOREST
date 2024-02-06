
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] Image HP;
    private float _maxHP;
    private float _currHP;

    private void Awake()
    {
        //HP = GetComponent<Image>();
        HP.fillMethod = Image.FillMethod.Horizontal;
        HP.type = Image.Type.Filled;
        _maxHP = gameObject.GetComponentInParent<Lizard>().GiveMaxHP();
    }

    private void Update()
    {
        _currHP = gameObject.GetComponentInParent<Lizard>().GiveCurrHP();
        HP.fillAmount = _currHP/_maxHP;
        
    }
}
