using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoolCatcher : MonoBehaviour
{
    private Camera cam;

    [SerializeField]
    private LayerMask foolLayerMask;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) {
            Ray r = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(r, out RaycastHit hit, 50f, foolLayerMask)) {
                var fool = hit.collider.GetComponentInParent<Fool>();
                if(fool != null) {
                    fool.OnClick();
                }
            }
        }
    }
}
