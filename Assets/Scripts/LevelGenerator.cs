using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class LevelGenerator : MonoBehaviour
{
	public GameObject player;
	//public GameObject end;
	
	public GameObject[] tiles;
	public GameObject wall;

	public List<Vector3> createdTiles;
	
	public int tileAmount;
	public float tileSize;

	public float chanceLeft;
	public float chanceRight;
	public float chanceUp;
	
	public float waitTime;


	public float minY = 99999999;
	public float maxY = 0;
	public float minX = 99999999;
	public float maxX = 0;

	public float xAmount;
	public float yAmount;
	public float extraWallX;
	public float extraWallY;
	
	void Start()
	{
		StartCoroutine(GenerateLevel());
	}

	IEnumerator GenerateLevel()
	{
		for (int i = 0; i < tileAmount; i++)
		{
			float dir = Random.Range(0f, 1f);
			int tile = Random.Range(0, tiles.Length);

			CreateTile(tile);
			CallMoveGen(dir);

			yield return new WaitForSeconds(waitTime);

			if (i == tileAmount - 1)
			{
				finish();
			}
		}

		yield return 0;
	}

	void CallMoveGen(float ranDir)
	{
		if (ranDir < chanceLeft)
		{
			MoveGen(0);
		}
		else if (ranDir < chanceRight)
		{
			MoveGen(1);
		}
		else if (ranDir < chanceUp)
		{
			MoveGen(2);
		}
		else
		{
			MoveGen(3);
		}
	}

	void MoveGen(int dir)
	{
		switch (dir)
		{
			case 0:
				
				transform.position = new Vector3(transform.position.x - tileSize, transform.position.y, 0);
				break;
			
			case 1:
				
				transform.position = new Vector3(transform.position.x + tileSize, transform.position.y, 0);
				break;
			
			case 2:
				
				transform.position = new Vector3(transform.position.x, transform.position.y + tileSize, 0);
				break;
			
			case 3:
				
				transform.position = new Vector3(transform.position.x, transform.position.y - tileSize, 0);
				break;
		}

	}

	void CreateTile(int tileIndex)
	{
		if (!createdTiles.Contains(transform.position))
		{
			GameObject tileObject;

			tileObject = Instantiate(tiles[tileIndex], transform.position, transform.rotation) as GameObject;

			createdTiles.Add(tileObject.transform.position);
		}
		else
		{
			tileAmount++;
		}
		
	}

	void finish()
	{
		CreateWallValues();
		CreateWall();
		SpawnObjects();
	}

	void CreateWallValues()
	{
		for (int i = 0; i < createdTiles.Count; i++)
		{
			if (createdTiles[i].y < minY)
			{
				minY = createdTiles[i].y;
			}

			if (createdTiles[i].y > maxY)
			{
				maxY = createdTiles[i].y;
			}
			if (createdTiles[i].x < minX)
			{
				minX = createdTiles[i].x;
			}

			if (createdTiles[i].x > maxX)
			{
				maxX = createdTiles[i].x;
			}

			xAmount = ((maxX - minX) / tileSize) + extraWallX;
			yAmount = ((maxY - minY) / tileSize) + extraWallY;
		}
	}

	void SpawnObjects()
	{
		Instantiate(player, createdTiles[Random.Range(0, createdTiles.Count)], Quaternion.identity);
	}

	void CreateWall()
	{
		for (int x = 0; x < xAmount; x++)
		{
			for (int y = 0; y < yAmount; y++)
			{
				if (createdTiles.Contains(new Vector3((minX - (extraWallX * tileSize) / 2) + (x * tileSize),
					(minY - (extraWallY * tileSize) / 2) + (y * tileSize))))
				{
					Debug.Log("hola");
					//Instantiate(wall, new Vector3((minX - (extraWallX * tileSize) / 2) + (x * tileSize),
					//	(minY - (extraWallY * tileSize) / 2) + (y * tileSize)), transform.rotation);
				}
				else
				{
					Instantiate(wall, new Vector3((minX - (extraWallX * tileSize) / 2) + (x * tileSize),
						(minY - (extraWallY * tileSize) / 2) + (y * tileSize)), transform.rotation);
				}
			}
		}
	
	}








}
