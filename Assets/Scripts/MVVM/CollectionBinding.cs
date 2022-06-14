using MVVM;
using Sirenix.OdinInspector;
using UnityEngine;

public class CollectionBinding : MonoBehaviour
{
    [Header("View Model"), SerializeField, Space, HideLabel]
    private ViewModelProperty viewModel;
}
