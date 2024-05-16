using UnityEngine;
using UnityEngine.UI;

public class HealButton : MonoBehaviour
{
    [SerializeField] string _HealerName;
    [SerializeField] string _HealedName;
    [SerializeField] int _HealDistance;
    PlayerBehaviour _Healer;
    PlayerBehaviour _Healed;

    private void Start()
    {
        _Healer = GameObject.Find(_HealerName).GetComponent<PlayerBehaviour>();
        _Healed = GameObject.Find(_HealedName).GetComponent<PlayerBehaviour>();

    }
    /*private void Update ()
    {
        Vector2 HealerPos = _Healer.GetPosition(); 
        Vector2 HealedPos = _Healed.GetPosition();
        if (Mathf.Abs(HealedPos.x - HealerPos.x) <= _HealDistance && Mathf.Abs(HealedPos.y - HealerPos.y) <= _HealDistance)
        {
            buttonVisual.enabled = true;
        }
        else
        {
            buttonVisual.enabled = false;
        }
    }*/
    public void OnButtonPress()
    {
        if (TurnManager.CheckIfCanAct())
        {
            Vector2 HealerPos = _Healer.GetPosition();
            Debug.Log(HealerPos);
            Vector2 HealedPos = _Healed.GetPosition();
            Debug.Log(HealedPos);
            if (Mathf.Abs(HealedPos.x - HealerPos.x) <= _HealDistance && Mathf.Abs(HealedPos.y - HealerPos.y) <= _HealDistance)
            {
                TurnManager.ConsumeAction();
                _Healed.Heal(_Healer.GetHealthDone());
            }
            else
            {
                Debug.Log("Out of range");
            }
        }
    }

    public void OnSelfHeal()
    {
        if (TurnManager.CheckIfCanAct())
        {
            TurnManager.ConsumeAction();
            _Healer.OnSelfHeal();
        }
    }

}
