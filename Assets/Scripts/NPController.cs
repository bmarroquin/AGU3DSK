using UnityEngine;
using System.Collections;

public class NPController : MonoBehaviour {
	public GameObject navNodePrefab;
	public float speed = 1f;
	public float snapDistance = 1.5f;
	public float treasureSnap = 1.5f;
	Terrain terrain;
	private Path mainPath;
	Vector3 nextGoal;
	Vector3 nextTreasure;
	bool treasureMode = false;
	
	public Vector3 NextTarget{
		get{
			if(treasureMode){
				return nextTreasure;
			}
			else{
				return nextGoal;
			}
		}
	}
	
	void Start () {
//		navNodePrefab = Resources.Load<GameObject>("Prefabs/NanNode");
		terrain = GameObject.FindObjectOfType<Terrain>();
		GeneratePath();
		nextGoal = mainPath.GetNextNode();
		transform.LookAt(CalculateLookAtVector(nextGoal));
	}
	
	void GeneratePath(){
		ArrayList path = new ArrayList();
		path.Add(new Vector3(10,terrain.SampleHeight(new Vector3(10,0,10)),10));
		path.Add(new Vector3(20,terrain.SampleHeight(new Vector3(20,0,15)),15));	
		path.Add(new Vector3(15,terrain.SampleHeight(new Vector3(15,0,20)),20));	
		path.Add(new Vector3(100,terrain.SampleHeight(new Vector3(100,0,10)),10));	
		path.Add(new Vector3(34,terrain.SampleHeight(new Vector3(34,0,25)),25));	
		mainPath = new Path(path, navNodePrefab);
	}
	
	private Vector3 findNearestTreasure(){
		GameObject[] treasures = GameObject.FindGameObjectsWithTag("treasure");
		Vector3 min = Vector3.zero;

		foreach (GameObject treasure in GameObject.FindGameObjectsWithTag("treasure")) {
			if (!treasure.GetComponent<Treasure>().isTagged) {
				if(Vector3.zero == min) {
					min = treasure.transform.position;
				}

				if(Vector3.Distance(treasure.transform.position, transform.position) < Vector3.Distance(min, transform.position)) {
					min = treasure.transform.position;
				}
			
			}
		}

		return min;
	}
	
	public void SwitchToTreasureMode(){
		if(treasureMode){
			return;
		}
		treasureMode = true;
		nextTreasure = findNearestTreasure();
		if(nextTreasure==Vector3.zero){
			treasureMode = false;
			return;
		}
		transform.LookAt(CalculateLookAtVector(nextTreasure));
	}
	
	public void SwitchToPathMode(){
		treasureMode = false;
		transform.LookAt(CalculateLookAtVector(nextGoal));
	}
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.N)){
			SwitchToTreasureMode();
		}
		if(treasureMode){
			if(Vector3.Distance(transform.position, nextTreasure)<treasureSnap){
				SwitchToPathMode();
			}
		}
		else{
			if(Vector3.Distance(transform.position, nextGoal)<snapDistance){
				nextGoal = mainPath.GetNextNode();
				transform.LookAt(CalculateLookAtVector(nextGoal));
			}
		}
		Vector3 newPos= transform.position + transform.forward * speed * Time.deltaTime;
		transform.position = new Vector3(newPos.x, terrain.SampleHeight(new Vector3(newPos.x,0, newPos.z)), newPos.z);
	}
	/// <summary>
	/// Calculates the look at vector so the the body isn't rotated to weird angles and stuff.
	/// </summary>
	private Vector3 CalculateLookAtVector(Vector3 pos){
		return new Vector3(pos.x, transform.position.y, pos.z);
	}


	void OnTriggerEnter (Collider hit ) {
		if (hit.gameObject.tag == "treasure") {
			
			GameObject treasure = hit.gameObject;
			
			if (treasure.GetComponent<Treasure>().isTagged == false) {
				GameObject taggedTreasure = (GameObject)Instantiate(Resources.Load("treasure_tagged"), treasure.transform.position, treasure.transform.rotation);
				Destroy(treasure);
				
				taggedTreasure.AddComponent("Treasure");
				taggedTreasure.tag = "treasure";
				taggedTreasure.GetComponent<Treasure>().isTagged = true;
				taggedTreasure.GetComponent<Treasure>().whoTagged = "NPAgent";
			}			
		}
	}
	void OnCollisionEnter(Collision collision){
		print ("boom");
	}

	void OnControllerColliderHit(ControllerColliderHit hit) {	
		Debug.Log ("ControllerColliderHit");
		if (hit.gameObject.tag == "treasure") {
			
			GameObject treasure = hit.gameObject;
			
			if (treasure.GetComponent<Treasure>().isTagged == false) {
				GameObject taggedTreasure = (GameObject)Instantiate(Resources.Load("treasure_tagged"), treasure.transform.position, treasure.transform.rotation);
				Destroy(treasure);
				
				taggedTreasure.AddComponent("Treasure");
				taggedTreasure.tag = "treasure";
				taggedTreasure.GetComponent<Treasure>().isTagged = true;
				taggedTreasure.GetComponent<Treasure>().whoTagged = "NPAgent";
			}			
		}
	}
}
