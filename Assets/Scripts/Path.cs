using UnityEngine;
using System.Collections;

public class Path :MonoBehaviour{
	//List of Vector3s for the Path
	ArrayList nodes;
	//List of GameObjects. Used to remove prefabs.
	ArrayList navNodes;
	
	//The current node we are going towards.
	int index;
	
	//If the path is in reverse mode. 
	bool reverseMode = false;
	
	GameObject nodePrefab;
	
	public Path(ArrayList n, GameObject o){
		nodes = n;
		nodePrefab = o;
		index = -1;
		AddNodesToScene();
	}
	
	void AddNodesToScene(){
		print (nodes);
		navNodes = new ArrayList();
		foreach(Vector3 pos in nodes){
			navNodes.Add (Instantiate(nodePrefab, pos, Quaternion.identity));
		}
	
	}
	
	
	//Handles conditions for Index increments.
	void UpdateIndex(){
		if(reverseMode){
			index--;
		}
		else{
			index++;
		}
		if(index >= nodes.Count){
			reverseMode = !reverseMode;
			index = nodes.Count - 2;
		}
		else if(index< 0){
			reverseMode = !reverseMode;
			index = 1;
		}
	}
	
	//Grabs the next node available.
	public Vector3 GetNextNode(){
		UpdateIndex();
		return (Vector3)nodes[index];
	}
	
}
