using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MVVM.Demo
{
    public class PeopleCellView : MonoBehaviour
    {
        [SerializeField] private new TMP_Text name;
        [SerializeField] private Image avatar;

        public void Setup(People people)
        {
            name.SetText(people.name);
            avatar.sprite = people.avatar;
        }
    }
}