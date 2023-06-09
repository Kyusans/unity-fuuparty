using UnityEngine;

public class SpinScript : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 100 * Time.deltaTime * speed));
    }
}
