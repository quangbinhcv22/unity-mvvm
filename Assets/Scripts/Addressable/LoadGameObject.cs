using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

public class LoadGameObject : MonoBehaviour
{
    [SerializeField] private Image image;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(UpdateArt), default, 1f);
    }

    private void UpdateArt()
    {
        var sprite = (Addressables.LoadAssetAsync<Sprite>($"Avatar/00{Random.Range(1, 5)}")).WaitForCompletion();
        image.sprite = sprite;

        
        // PropertyChangedEventHandler a = new PropertyChangedEventHandler();
        // a?.Invoke(this, new PropertyChangedEventArgs(nameof(UpdateArt)));
    }
}