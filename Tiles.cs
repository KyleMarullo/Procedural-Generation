using UnityEngine;
using System.Collections;

public class Tile  {

	public enum TileType {DeepWater, ShallowWater,Beach,Grassland,Savannah, Forest, Mountin};

	TileType type;
	int x;
	int y;
	float heightvalue;
	public float moisturevalue;
	public float heatvalue;	

	public Tile( int x, int y){
		this.x = x;
		this.y = y;

	}

	public int X {
		get {
			return x;
		}
	}

	public int Y {
		get {
			return y;
		}
	}

	public float returnheightvalue(){
		return this.heightvalue;
	}

	public void setheightvalue(float value){
		this.heightvalue = value;
	}

	public float returnmoisturevalue(){
		return this.moisturevalue;
	}

	public void setmoisturevalue(float value){
		this.moisturevalue = value;
	}

	public float returnheatvalue(){
		return this.heatvalue;
	}

	public void setheatvalue(float value){
		this.heatvalue = value;
	}

	public TileType getType(){
		return this.type;
	}

	public void setType(TileType value){
		this.type = value;
	}


	public void biomegen(){
		if (this.heightvalue < .0f) {
			this.type = TileType.DeepWater;
		}
		else if (this.heightvalue < .3f) {
			this.type = TileType.ShallowWater;
		}
		else if (this.heightvalue < .35f) {
			this.type = TileType.Beach;
		}
		else if (this.heightvalue < .65f) {
			if (this.moisturevalue < .4) {
				this.type = TileType.Savannah;
			} else if (this.moisturevalue < .7) {
				this.type = TileType.Grassland;
			} else {
				this.type = TileType.Forest;
			}
		}
		else{
			this.type = TileType.Mountin;
		}
	}
}
