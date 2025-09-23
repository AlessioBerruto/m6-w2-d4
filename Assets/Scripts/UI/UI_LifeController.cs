using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_LifeController : MonoBehaviour
{
    [SerializeField] private Image _lifeBarImage;
    [SerializeField] private Gradient _lifeBarGradient;

    public void UpdateLifeBar(float value)
    {
        _lifeBarImage.fillAmount = value;
        _lifeBarImage.color = _lifeBarGradient.Evaluate(value);
    }
}
