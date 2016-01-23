using UnityEngine;
using UnityEngine.UI;

class PCInfo : MonoBehaviour {
    private PC pc;
    GameObject hp;

    private void Start()
    {
        pc = GameObject.Find("Carp").GetComponent<PC>();

        foreach (Transform child in transform) {
            if (child.gameObject.name == "HP") {
                hp = child.gameObject;
            }
        }
    }

    private void FixedUpdate()
    {
        hp.GetComponent<Text>().text = "HP : " + pc.GetComponent<AttackableTarget>().Hp.ToString();
    }
}