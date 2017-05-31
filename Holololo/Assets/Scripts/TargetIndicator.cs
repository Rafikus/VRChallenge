using UnityEngine;
using System.Collections;


public class TargetIndicator : MonoBehaviour {

    public Texture2D icon;
    public float iconSize = 50f;
    [HideInInspector]
    public GUIStyle gooey;
    Vector2 indRange;
    float scaleRes = Screen.width / 500;
    Camera cam;
    bool visible = true;
    Collider objCollider;
    private Plane[] planes;



    void Start() {
        objCollider = gameObject.GetComponent<Collider>();
        cam = Camera.main; 
        planes = GeometryUtility.CalculateFrustumPlanes(cam);   


        indRange.x = Screen.width - (Screen.width / 6);
        indRange.y = Screen.height - (Screen.height / 7);
        indRange /= 2f;

        gooey.normal.textColor = new Vector4(0, 0, 0, 0);

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
            Vector3 dir = transform.position - cam.transform.position;
            dir = Vector3.Normalize(dir);
            dir.y *= -1f;

            Vector2 indPos = new Vector2(indRange.x * dir.x, indRange.y * dir.y);
            indPos = new Vector2((Screen.width / 2),
                                 (Screen.height / 2));

            Vector3 pdir = transform.position - cam.ScreenToWorldPoint(new Vector3(indPos.x, indPos.y,
                                                                                    transform.position.z));
            pdir = Vector3.Normalize(pdir);

            float angle = Mathf.Atan2(pdir.x, pdir.y) * Mathf.Rad2Deg;
            indPos = new Vector2(indPos.x + angle, indPos.y + angle);
            GUIUtility.RotateAroundPivot(angle, indPos); 
            GUI.Box(new Rect(indPos.x, indPos.y, scaleRes * iconSize, scaleRes * iconSize), icon, gooey);
            GUIUtility.RotateAroundPivot(0, indPos); 
        }
    }
}