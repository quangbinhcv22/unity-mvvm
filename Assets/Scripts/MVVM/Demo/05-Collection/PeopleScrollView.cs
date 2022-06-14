using System.Collections.Generic;
using UnityEngine;

namespace MVVM.Demo
{
    public class PeopleScrollView : MonoBehaviour
    {
        public List<People> Peoples
        {
            get => null;
            set => ReloadData(value);
        }

        [SerializeField] private Transform parents;
        [SerializeField] private PeopleCellView cellViewPrefab;

        private readonly List<PeopleCellView> _cellViews = new();

        private void ReloadData(List<People> peoples)
        {
            _cellViews.ForEach(cellView => Destroy(cellView.gameObject));
            _cellViews.Clear();

            if (peoples is null) return;

            foreach (var people in peoples)
            {
                var newCellView = Instantiate(cellViewPrefab, parents);
                newCellView.Setup(people);

                _cellViews.Add(newCellView);
            }
        }
    }
}