using UnityEngine;
using System.Collections;


public class TargetIndicator : MonoBehaviour {

    public Texture2D icon;
    public GameObject arrowPrefab, arrow;
    public Canvas canvas;
    Camera cam;
    bool visible = true;
    Collider objCollider;
    private Plane[] planes;

    void Start() {
        objCollider = gameObject.GetComponent<Collider>();
        cam = Camera.main;
        canvas = FindObjectOfType<Canvas>();
        arrow = Instantiate(arrowPrefab, canvas.transform);
        
        
     }

    void Update() {
        //planes = GeometryUtility.CalculateFrustumPlanes(cam);
        //if (GeometryUtility.TestPlanesAABB(planes, objCollider.bounds)){
        //    arrow.gameObject.SetActive(false);
        //}
        //else {
            arrow.gameObject.SetActive(true);

            Vector3 target = new Vector3(Camera.main.transform.position.x - transform.position.x, Camera.main.transform.position.z - transform.position.z);

            arrow.transform.rotation.SetFromToRotation(Camera.main.transform.position, gameObject.transform.position);
           
                //(cam.transform.position, transform.position);
        //}
    }
}