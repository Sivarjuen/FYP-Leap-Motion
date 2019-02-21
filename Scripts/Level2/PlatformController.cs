using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour {

	public GameObject highlight; 
	private Block block;
	private bool containsBlock;
	public Transform blockPosition;
	
	void Awake() {
		highlight.SetActive(false);
		containsBlock = false;
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setHighlight(bool b){
		highlight.SetActive(b);
	}

	public bool hasBlock(){
		return containsBlock;
	}

	public void setBlock(Block block){
		this.block = block;
		containsBlock = true;
		block.transform.position = blockPosition.position;
	}

	public void removeBlock(){
		containsBlock = false;
		block = null;
	}

	public Block getBlock(){
		return block;
	}

	public int blockType(){
		if(containsBlock){
			return block.getType();
		} else {
			return -1;
		}
		
	}
}
