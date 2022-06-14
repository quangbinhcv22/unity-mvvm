using System;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

public class CastAbilityPresenter : MonoBehaviour
{
    [ShowInInspector] private CastAbilityProperty[] _properties;

    [SerializeField] private Image castRangeImage;
    [SerializeField] private Image castShapeImage;
    [SerializeField] private Sprite circleSprite;

    [SerializeField] private Vector2 direction;


    private void Awake()
    {
        Setup(new CastAbilityProperty {key = CastAbilityPropertyType.CastRange, value = 8f},
            new CastAbilityProperty {key = CastAbilityPropertyType.CastShape, value = "Circle"});
    }

#if UNITY_EDITOR
    private void Update()
    {
        UpdateView();
        
        SetIndicator(direction);
    }
#endif


    public void Setup(params CastAbilityProperty[] properties)
    {
        _properties = properties;

        UpdateView();
    }

    public void SetIndicator(Vector2 indicator)
    {
        castRangeImage.rectTransform.localRotation = Quaternion.Euler(new Vector3(default, default, Angle(indicator)));
        
        // Vector2.SignedAngle()
    }
    
    public static float Angle(Vector2 vector2)
    {
        if (vector2.x < 0)
        {
            return 360 - (Mathf.Atan2(vector2.x, vector2.y) * Mathf.Rad2Deg * -1);
        }
        else
        {
            return Mathf.Atan2(vector2.x, vector2.y) * Mathf.Rad2Deg;
        }
    }

    
    private void UpdateView()
    {
        SetCastRange();
        SetCastShape();
    }

    
    private void SetCastRange()
    {
        var nullableCastRange = _properties.FirstOrDefault(property => property.key is CastAbilityPropertyType.CastRange)?.value;
        if (nullableCastRange is float castRange)
        {
            castRangeImage.rectTransform.sizeDelta = Vector2.one * castRange;
        }
    }
    
    private void SetCastShape()
    {
        var nullableCastShape = _properties.FirstOrDefault(property => property.key is CastAbilityPropertyType.CastShape)?.value;
        
        if (nullableCastShape is string castShape)
        {
            switch (castShape)
            {
                case "Circle":
                    castShapeImage.sprite = circleSprite;
                    break;
            }
        }
    }
}

[Serializable]
public class DataBase<TKey, TValue> where TKey : IComparable
{
    public TKey key;
    public TValue value;
}


public class CastAbilityProperty : DataBase<CastAbilityPropertyType, object>
{
}

public enum CastAbilityPropertyType
{
    CastRange = 1,
    CastShape = 2,
}

