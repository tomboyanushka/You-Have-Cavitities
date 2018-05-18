
using UnityEngine;

public class Interact : MonoBehaviour
{
    public float radius = 3f;
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radius);
    }


}
