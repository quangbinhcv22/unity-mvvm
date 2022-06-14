using DG.Tweening;
using UnityEngine;

public class ScaleShaker : MonoBehaviour
{
    [SerializeField] private float duration;

    public void Shake()
    {
        transform.DOShakeScale(duration);
    }
}