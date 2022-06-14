using UnityEngine;

public class AlwayRotate : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(new Vector3(0, 1, 0));
    }
}