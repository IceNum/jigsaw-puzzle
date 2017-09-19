using UnityEngine;
using System.Collections;

// the DemoJigsawPuzzle Class is a sub class of JigsawPuzzle that can be used to create an ingame puzzle
// The following base functions can be overridden :
//
// - PuzzleStart(); 						: is called when new puzzle is started
// - ActivatePiece(GameObject piece); 		: is called when a 'loose' puzzle piece is selected (start drag)
// - DeactivatePiece(GameObject piece);		: is called when a 'loose' puzzle piece is released (stop drag)
// - PiecePlaced(GameObject piece); 		: is called when a puzzle piece is placed on the puzzle on the right spot
// - PuzzleSolved(int moves, float time);	: is called when the puzzle has been solved
// 
// To Create an Ingame Puzzle
//
// 1. Add The JigsawMain prefab to the current scene
// 2. Create a puzzle cube primitive - the puzzle will be place on the 'forward' side of this cube
// 3. Set the right dimensions ( width/height/Thickness = scale x/y/z) of your puzzle
// 4. Add your 'custom' JigsawPuzzle subclass to your puzzle 'cube' game object
// 5. adjust the settings of your puzzle
//		-	image 			: 	will contain the jigsaw projected picture
// 		-	size			:	how many pieces will this puzzle have (x,y)
//		-	topLeftPiece 	:	format YX (1,2,3,4,5) so 11 to 55 - 25 unique start possiblities
//		-	showImage		:	display 'helper' semi-transparant - greyscale sample picture
//		-	showLines		:   display 'helper' puzzle matrix 
//		-	placePrecision	:	how precise must a piece beeing placed on the puzzle (12-15-25 depending on difficuly)
//
public class DemoJigsawPuzzle : JigsawPuzzle
{
    private float _LightUp;
    private float _Color;
	
	// is true when the puzzle is solved
	public bool solved
	{
		get
		{
			return _solved;
		}
	}
	
	// contains the move count if the puzzle is solved
	public int moves
	{
		get
		{
			return _moves;
		}
	}
	
	// contains the puzzle time if the puzzle is solved
	public float time
	{
		get
		{
			return _time;
		}
	}
	
	bool _solved = false;
	int _moves = 0;
	float _time = 0.0f;

	// Use this for initialization
	void Start () {	
	}
	
	// Update is called once per frame
	new void Update () {
        // call inherited JigsawPuzzle.Update();
        base.Update();
	}
	
	// PuzzleStart is called when a new puzzle is started
	protected override void PuzzleStart()
	{
		_solved = false;
	}

    // ActivatePiece is called when one clicks - and hold mouse left button
    // on a (loose) puzzle piece.
    protected override void ActivatePiece(GameObject piece)
    {
        // show real colors of this piece by removing brightness and 
        // adding all color with the 'shaderGrayColored' shader
        _LightUp = piece.GetComponent<Renderer>().material.GetFloat("_LightUp");
        _Color = piece.GetComponent<Renderer>().material.GetFloat("_Color");
        piece.GetComponent<Renderer>().material.SetFloat("_LightUp", 0.01f);
        piece.GetComponent<Renderer>().material.SetFloat("_Color", 1);
    }

    // DeativatePiece is called when one releases left mouse button
    // and a puzzle piece was active
    protected override void DeactivatePiece(GameObject piece)
    {
        // reset LightUp and Color of the shader
        piece.GetComponent<Renderer>().material.SetFloat("_LightUp", _LightUp);
        piece.GetComponent<Renderer>().material.SetFloat("_Color", _Color);
    }

    protected override void PiecePlaced(GameObject piece)
    {
        // show real colors of this piece by removing Lightness and 
        // adding all color with the 'shaderGrayColored' shader
        piece.GetComponent<Renderer>().material.SetFloat("_LightUp", 0.01f);
        piece.GetComponent<Renderer>().material.SetFloat("_Color", 1f);
    }

	// PiecePlace is called when a puzzle piece is fit on the correct spot 
    protected override void PuzzleSolved(int moves, float time)
    {
        _solved = true;
		_moves = moves;
		_time = time;
    }

	// Scatter Piece is called to set the 'scattered' place of a puzzle piece when starting a puzzle
	// return null to perform 'default' scattering. The starting location of a piece is it's right
	// puzzle spot.
	protected override GameObject ScatterPiece(GameObject piece)
	{
		return null;
	}



}
