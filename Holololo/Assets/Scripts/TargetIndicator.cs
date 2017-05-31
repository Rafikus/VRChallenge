using UnityEngine;
using System.Collections;


public class TargetIndicator : MonoBehaviour {

    public Texture2D icon;
    public GameObject arrowPrefab;
    public Canvas canvas;
    public float iconSize = 50f;
    [HideInInspector]
    public GUIStyle gui;
    float scaleRes = Screen.width / 700;
    Camera cam;
    bool visible = true;
    Collider objCollider;
    private Plane[] planes;

    void Start() {
        objCollider = gameObject.GetComponent<Collider>();
        cam = Camera.main;

        gui.normal.textColor = new Vector4(0, 0, 0, 0);
     }

    void Update() {
        planes = GeometryUtility.CalculateFrustumPlanes(cam);
        if (GeometryUtility.TestPlanesAABB(planes, objCollider.bounds)){
            visible = true;
        }
        else {
            visible = false;
        }
    }

    void OnGUI() {
        if (!visible) {

            Vector2 arrowPosition = new Vector2((Screen.width / 2), (Screen.height / 2));

            Vector3 pdir = gameObject.transform.position - cam.ScreenToWorldPoint(new Vector3(arrowPosition.x, arrowPosition.y,
                                                                                    transform.position.z));
            pdir = Vector3.Normalize(pdir);

            float angle = Mathf.Atan2(pdir.x, pdir.y) * Mathf.Rad2Deg;
            
            GUIUtility.RotateAroundPivot(angle, arrowPosition); 
            GUI.Box(new Rect(arrowPosition.x, arrowPosition.y, iconSize, scaleRes * iconSize), icon, gui);
            GUIUtility.RotateAroundPivot(0, arrowPosition); 
        }
    }
}