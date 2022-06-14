using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MVVM.Demo
{
    [Binding]
    public class ManagerPeopleViewModel : MonoBehaviour, IBindingEvent
    {
        [SerializeField] private List<People> peoples;
        [SerializeField] private List<string> fakeNames;
        [SerializeField] private List<Sprite> avatars;

        [Binding]
        public List<People> Peoples
        {
            get => peoples;
            set
            {
                peoples = value;

                BindingEvent.Invoke(nameof(Peoples));
                BindingEvent.Invoke(nameof(PeopleCount));
            }
        }

        [Binding] public string PeopleCount => Peoples.Count.ToString();


        [Binding]
        public void GenRandomPeople()
        {
            var newPeoples = new List<People>();

            for (int i = 0; i < Random.Range(10, 20); i++)
            {
                newPeoples.Add(new People
                {
                    name = fakeNames[Random.Range(0, fakeNames.Count)], avatar = avatars[Random.Range(0, avatars.Count)]
                });
            }

            Peoples = newPeoples;
        }

        public BindingEvent BindingEvent { get; set; }

        public ManagerPeopleViewModel()
        {
            BindingEvent = new BindingEvent();
            Peoples = new();
        }
    }
}