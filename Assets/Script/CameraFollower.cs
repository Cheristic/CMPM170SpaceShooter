using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFollower : MonoBehaviour
{
    public Transform followee;

    public float DISTANCE_MULTIPLIER;
    public float VELOCITY_GAIN;
    public float DERIVATIVE_GAIN;
    public float MAX_DISTANCE_FROM_PLAYER;
    public float MAX_VELOCITY;
    Vector3 error, lastError, deltaError, velocity;

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = transform.position.y;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        mousePos.y = followee.position.y;

        Vector3 targetDir = mousePos - followee.position;
        targetDir = Vector3.ClampMagnitude(targetDir * DISTANCE_MULTIPLIER, MAX_DISTANCE_FROM_PLAYER) ;
        Vector3 targetPos = targetDir + followee.position;
        targetPos.y = transform.position.y;

        error = targetPos - transform.position;

        deltaError = (error - lastError) / Time.deltaTime;
        lastError = error;

        velocity += (VELOCITY_GAIN * deltaError) + DERIVATIVE_GAIN * error;
        velocity = Vector3.ClampMagnitude(velocity, MAX_VELOCITY);

        transform.Translate(velocity, Space.World);
    }
}
