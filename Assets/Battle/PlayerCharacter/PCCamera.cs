using UnityEngine;

class PCCamera : MonoBehaviour {
    private void FixedUpdate()
    {
        var pc = GameObject.Find("Carp");
        if (pc != null) {
            transform.localPosition = new Vector3(pc.transform.localPosition.x + 5, pc.transform.localPosition.y, -10);
        }
    }
}