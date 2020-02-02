using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CharacterControllerLevelSelect2D : MonoBehaviour
{
    public string xAxis = "Horizontal";
    public string yAxis = "Vertical";
    public string jumpAxis = "Jump";

    public float drag = 0.4f;
    public float moveSpeed = 50f;

    private void FixedUpdate()
    {
        // Read the inputs.
        float dx = CrossPlatformInputManager.GetAxis(xAxis);
        float dy = CrossPlatformInputManager.GetAxis(yAxis);

        //Move
        GetComponent<Rigidbody2D>().velocity *= drag;
        GetComponent<Rigidbody2D>().AddForce(new Vector2(dx, dy)*moveSpeed);

        GetComponent<Animator>().SetFloat( "Speed", GetComponent<Rigidbody2D>().velocity.magnitude);

        if(GetComponent<Rigidbody2D>().velocity.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if(GetComponent<Rigidbody2D>().velocity.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }
}
