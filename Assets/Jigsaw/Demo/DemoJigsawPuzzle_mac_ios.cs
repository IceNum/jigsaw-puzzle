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
public class DemoJigsawPuzzle_mac_ios : DemoJigsawPuzzle
{
   

    // ActivatePiece is called when one clicks - and hold mouse left button
    // on a (loose) puzzle piece.
    protected override void ActivatePiece(GameObject piece)
    {
        // show real colors of this piece by setting diffuse color
        piece.GetComponent<Renderer>().material.color = new Color(1.0f,1.0f,1.0f);
    }

    // DeativatePiece is called when one releases left mouse button
    // and a puzzle piece was active
    protected override void DeactivatePiece(GameObject piece)
    {
        // show lightened colors of this piece by setting diffuse color
        piece.GetComponent<Renderer>().material.color = new Color(0.8f,0.8f,0.8f);
    }
	
	// PiecePlace is called when a puzzle piece is fit on the correct spot 
    protected override void PiecePlaced(GameObject piece)
    {
        // show real colors of this piece by setting diffuse color
        piece.GetComponent<Renderer>().material.color = new Color(1.0f,1.0f,1.0f);
    }
	

}
