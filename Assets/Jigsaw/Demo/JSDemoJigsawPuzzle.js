// IMPORTANT ! 
// To run the Javascript Sample you need to move the /Jigsaw/Standard Assets folder into the {root}/ of your project.,
// The reason for this is because the JigsawPuzzle class we are extending is a C# class and has to be pre-compiled.
//  This file was commented to avoid import package compiler errors.

/*
public class JSDemoJigsawPuzzle extends JigsawPuzzle
{
    private var _LightUp:float;
    private var _Color:float;
	
	// is true when the puzzle is solved
	public function get solved():boolean
	{
		return _solved;
	}
	
	// contains the move count if the puzzle is solved
	public function get moves():int
	{
		return _moves;
	}
	
	// contains the puzzle time if the puzzle is solved
	public function get time():float
	{
		return _time;
	}
	
	private var _solved:boolean = false;
	private var _moves:int = 0;
	private var _time:float = 0;

	// Use this for initialization
	new public function Start () {	
	}
	
	// Update is called once per frame
	new public function Update () {
        // call inherited JigsawPuzzle.Update();
        super.Update();
	}
	
	// PuzzleStart is called when a new puzzle is started
	override function PuzzleStart()
	{
		_solved = false;
	}

    // ActivatePiece is called when one clicks - and hold mouse left button
    // on a (loose) puzzle piece.
    override function ActivatePiece(piece:GameObject)
    {
        // show real colors of this piece by removing brightness and 
        // adding all color with the 'shaderGrayColored' shader
        _LightUp = piece.renderer.material.GetFloat("_LightUp");
        _Color = piece.renderer.material.GetFloat("_Color");
        piece.renderer.material.SetFloat("_LightUp", 0.01f);
        piece.renderer.material.SetFloat("_Color", 1);
    }

    // DeativatePiece is called when one releases left mouse button
    // and a puzzle piece was active
    override function DeactivatePiece(piece:GameObject)
    {
        // reset LightUp and Color of the shader
        piece.renderer.material.SetFloat("_LightUp", _LightUp);
        piece.renderer.material.SetFloat("_Color", _Color);
    }

    override function PiecePlaced(piece:GameObject)
    {
        // show real colors of this piece by removing Lightness and 
        // adding all color with the 'shaderGrayColored' shader
        piece.renderer.material.SetFloat("_LightUp", 0.01f);
        piece.renderer.material.SetFloat("_Color", 1f);
    }

	// PiecePlace is called when a puzzle piece is fit on the correct spot 
    override function PuzzleSolved(moves:int , time:float)
    {
        _solved = true;
		_moves = moves;
		_time = time;
    }
	
	// Scatter Piece is called to set the 'scattered' place of a puzzle piece when starting a puzzle
	// return null to perform 'default' scattering. The starting location of a piece is it's right
	// puzzle spot.
	override function ScatterPiece(piece:GameObject):GameObject
	{
		return null;
	}
}

*/