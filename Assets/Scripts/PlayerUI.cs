using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] TMP_Text HpValue;

    public void SetHpText(int value)
    {
        HpValue.SetText(value.ToString());
    }
   

}
