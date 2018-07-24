using UnityEngine;

/// <summary>
/// Sets transform's Right vector to the direction of click from the this transform
/// </summary>
public class FaceDirectionOfClick : MonoBehaviour
{
	void Update ()
	{
        // set this transform's right to the direction of the mouse click
	    if (Input.GetKeyDown(KeyCode.Mouse0))
	    {
	        Vector2 direction = (Vector2) (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);

            transform.right = direction; 
        }
    }
}
