using UnityEngine;

class PCControl : MonoBehaviour {
    private PC pc;

    private void Start()
    {
        pc = GetComponent<PC>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z)) {
            pc.Action();
        }
    }
}