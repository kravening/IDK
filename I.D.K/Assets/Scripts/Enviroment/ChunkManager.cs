using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChunkManager : MonoBehaviour
{
	[Header("Chunk prefabs")]
	public List<GameObject> chunks = new List<GameObject>();
	
	//screen width in game unit
	private float screenWidthGameUnits;
	private bool removed = false;
	public float difficulty;
	
	private List<GameObject> chunkClones = new List<GameObject>();
	
	void Awake()
	{
		this.screenWidthGameUnits = this.getHalfScreenWidth();
	}
	
	void Start()
	{
		difficulty = 1f;
		for (int i = 0; i < 4; i++)
		{
			chunkClones.Add(getRandomChunk(Vector3.zero));
		}
		for (int j = 0; j < chunkClones.Count; j++)
		{
			chunkClones[j].transform.position = new Vector3(j * getChunkWidth(chunkClones[j]),0);
		}
		chunkClones[0].transform.position = new Vector3(0 - screenWidthGameUnits,0);
		Vector3 eersteChunkPos = chunkClones[0].transform.position;
		
		for (int k = 0; k < chunkClones.Count; k++)
		{
			chunkClones[k].transform.position = new Vector3(eersteChunkPos.x+getChunkWidth(chunkClones[k])*k,0);
		}
	}
	
	void Update()
	{
		difficulty += 0.0001f;
		if (removed) {
			chunkClones.Add(getRandomChunk(Vector3.zero));
			removed = false;
		}
		
		sortChunks (chunkClones);
		for (int i = (chunkClones.Count - 1); i > -1; i--) {
			//Debug.Log("ayy");
			if(checkBoundsChunk(chunkClones[i])){
				Destroy(chunkClones[i]);
				chunkClones.RemoveAt(i);
				removed = true;
			}
			moveChunk(chunkClones[i], difficulty);
		}
	}
	
	//Gets the chunks back to back
	private void sortChunks(List<GameObject> _chunks)
	{
		if (_chunks.Count < 1)
		{
			Debug.Log("Error sort chunk! list does not have elements");
			return;
		}
		var l_offset = screenWidthGameUnits;
		//get first chunk position
		var l_firstChunkV3 = _chunks[0].transform.position;
		//sort chunks
		for (int i = 0; i < _chunks.Count; i++)
		{
			_chunks[i].transform.position = new Vector3(l_firstChunkV3.x + (getChunkWidth(_chunks[i]) * i), 0);
		}
	}
	
	//Checks if chunk left the screen on the left side
	private bool checkBoundsChunk(GameObject _chunk)
	{
		if (_chunk.transform.position.x < 0 - (screenWidthGameUnits + getChunkWidth(_chunk)))
		{
			return true;
		}
		else
		{
			return false;
		}
	}
	
	//Set movement speed and move chunk
	private void moveChunk(GameObject _chunk, float _speed)
	{
		_chunk.transform.position -= new Vector3(_speed * Time.deltaTime, 0);
	}
	
	//Get random chunk
	private GameObject getRandomChunk(Vector3 _position)
	{
		return spawnChunk(chunks[Random.Range(0, chunks.Count)], _position);
	}
	
	//Spawn and position a chunk
	private GameObject spawnChunk(GameObject _chunk, Vector3 _position)
	{
		return (GameObject)Instantiate(_chunk, _position, Quaternion.identity);
	}
	
	//Gets width of chunk
	private float getChunkWidth(GameObject _chunk)
	{
		return _chunk.GetComponent<BoxCollider2D>().size.x;
	}
	
	//Gets half of screen width in game units
	private float getHalfScreenWidth()
	{
		return (Camera.main.orthographicSize / Camera.main.pixelHeight * Camera.main.pixelWidth);
	}
}