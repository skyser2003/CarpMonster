using UnityEngine;

class GravityObject : MonoBehaviour {
    private float gravity = 20;
    public float Speed { get; set; }

    private void FixedUpdate()
    {
        var dt = Time.fixedDeltaTime;

        Speed -= gravity * dt;

        if (transform.localPosition.y == 0 && Speed <= 0) {
            return;
        }

        var delta = new Vector3(0, Speed * dt, 0);
        var newPos = transform.localPosition + delta;

        if (newPos.y <= 0) {
            newPos.y = 0;
        }

        transform.localPosition = newPos;
    }
}