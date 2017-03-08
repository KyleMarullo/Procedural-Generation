using UnityEngine;
using System.Collections;

public class World: MonoBehaviour {

	public Sprite tile;

	Tile[,] tiles;
	GameObject[,]tiles_go;

	public int width;
	public int height;
	public int seedvalue;

	public string seed;

	public bool userandomseed;

	public Color savanah;
	public Color forest;
	public Color grassland;
	public Color beach;
	public Color shallowwater;
	public Color deepwater;
	public Color mountin;

	float value = 0;

	int numofdeepwater = 0;
	int numofshallowwater = 0;
	int numofbeach = 0;
	int numofgrass = 0;
	int numofsavannah = 0;
	int numofforest = 0;
	int numofmountin = 0;


	public void Start() {

		if (userandomseed) {
			this.seedvalue = Random.Range (0, 1000);
		} else {
			seedvalue = seed.GetHashCode() / (int)Mathf.Pow(seed.Length,2f);
		}
			
		tiles = new Tile[width, height];
		tiles_go = new GameObject[width, height];

		for (int i = 0; i < width; i++) {
			for (int j = 0; j < height; j++) {
				tiles [i, j] = new Tile (i, j);
				GameObject tile_go = new GameObject();
				tile_go.name = "Tile_" + i + "_" + j;
				SpriteRenderer tile_sr = tile_go.AddComponent<SpriteRenderer>();
				tile_sr.sprite = tile;
				tile_go.transform.position = new Vector2 (i, j);
				tiles_go [i, j] = tile_go;

			}
		}

		setCamera ();
		GenerateMoistureMap ();
		GenerateHeightmap ();
		DisplayBiomes ();
	}

	public void GenerateHeightmap(){
		for (int i = 0; i < width; i++) {
			for(int j =0; j< height; j++){
				
				value = Mathf.PerlinNoise (((width - i) - seedvalue) / 75f,((height - j) - seedvalue) / 75f) * 1f  + Mathf.PerlinNoise (((4*i- width) - seedvalue) / 20f,((4*j - height) - seedvalue) / 20f) * .25f;
				value /= (1.0f + .25f);
				Mathf.Pow (value, 1.3f);
				//Euclidean calculation of distance from the center
				float d =2 * Mathf.Sqrt(Mathf.Pow((i - (width/2)),2) + Mathf.Pow((j - (height/2)),2));
				//Normalization of the distance
				d = (d - 0 )/( width - 0 );
				//calculate the elevation
				value = ((value) + .3f) - (1f - .8f + Mathf.Pow((d), 5f));
				Debug.Log (value);
				//set the biome
				tiles[i, j].setheightvalue(value);
				tiles [i, j].biomegen ();
			}
		}
	}

	public void DisplayBiomes(){
						
		for (int i = 0; i < width; i++) {
			for (int j = 0; j < height; j++) {
				SpriteRenderer sprite = tiles_go [i, j].GetComponent<SpriteRenderer> ();
			
				if (tiles [i, j].getType () == Tile.TileType.DeepWater) {
					sprite.color = deepwater;
				} else if (tiles [i, j].getType () == Tile.TileType.ShallowWater) {
					sprite.color = shallowwater;
				} else if (tiles [i, j].getType () == Tile.TileType.Beach) {
					sprite.color = beach;
				} else if (tiles [i, j].getType () == Tile.TileType.Grassland) {
					sprite.color = grassland;
				} else if (tiles [i, j].getType () == Tile.TileType.Forest) {
					sprite.color = forest;
				} else if (tiles [i, j].getType () == Tile.TileType.Savannah) {
					sprite.color = savanah;
				}else {
					sprite.color = mountin;
				}
			}
		}


	}

	public void GenerateHeatMap(){
		for (int i = 0; i < width; i++) {
			for(int j = 0 ;j < height; j++){
				float value = Mathf.PerlinNoise ((i- seedvalue) / 1f,(j - seedvalue) / 1f);

			}
		}
	}

	public void GenerateMoistureMap(){
		for (int i = 0; i < width; i++) {
			for (int j = 0; j < height; j++) {

				float value = Mathf.PerlinNoise (((i - width) - seedvalue) / 50f, ((j - height) - seedvalue) / 50f) * 1f + Mathf.PerlinNoise (((i - width) - seedvalue) / 20f, ((j - height) - seedvalue) / 20f) * .5f;
				value = Mathf.Pow (value, 1f);

				tiles [i, j].setmoisturevalue(value);
			}
		}
	}

	public void setCamera(){
		Camera main = Camera.main;
		main.transform.position = new Vector3 (width/2, height/2, -10f);
		main.orthographicSize = 120f;
	}
}