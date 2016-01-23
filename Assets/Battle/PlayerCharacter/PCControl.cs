using UnityEngine;

class PCControl : MonoBehaviour {
    private PC pc;

    private void Start()
    {
        pc = GetComponent<PC>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) || (Input.touchSupported && Input.GetTouch(0).phase == TouchPhase.Began)) {
            pc.Action();
        }
    }
}