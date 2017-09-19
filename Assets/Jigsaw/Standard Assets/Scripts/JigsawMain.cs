using UnityEngine;
using System.Collections;

// The JigsawMain Class is used to access the (blender - fbx) imported piece prototypes and 
// to access materials for lines, sample image, scattered pieces and piece bases.
//
// You need to attach this script to an object in your scene. easiest way is to add the JigsawMain prefab
// to you scene.
//
public class JigsawMain: MonoBehaviour {

    // ---------------------------------------------------------------------------------------------------------
    // public attributes
    // ---------------------------------------------------------------------------------------------------------
    public GameObject jigsaw = null;  		// 	will contain the FBX imported blender file with all (25*9) puzzle peaces
    public Material linesHorizontal = null;	//	material for horizontal lines
    public Material linesVertical = null;	//	material for vertical ines
    public Material sampleImage = null;		//	material for sample image
    public Material scatteredPieces = null;	//	material for scattered pieces
    public Material pieceBase = null;		//	material for piece bases
    public int layerMask = 31;				//	default layer mask for quick RayCasting
	
	// is true if this class has been initialized correctly
    public bool isValid
    {
        get
        {
            return _isValid;
        }
    }


    // ---------------------------------------------------------------------------------------------------------
    // private attributes
    // ---------------------------------------------------------------------------------------------------------
    private Hashtable basePieceTransforms = new Hashtable();
    private bool _isValid = false;


    // ---------------------------------------------------------------------------------------------------------
    // methods
    // ---------------------------------------------------------------------------------------------------------

	// Use this for initialization
	void Start () {
        // load references to all puzzle piece Transform objects into HashTable
        GetBasePieces();        
    }
	
	// get base piece prototype
	//获得基本块原型
    public Transform GetBase(string ident)
    {
        return jigsaw.transform.FindChild(ident) as Transform;
    }
	
	// get specific piece prototype
	//获得特殊块原型
    public Transform GetPiece(string ident, string piece)
    {
        Transform basePiece = basePieceTransforms[ident] as Transform;
        if (basePiece != null)
            return basePiece.FindChild(ident + piece.ToUpper());
        else
            return null;
    }

    // Load all 25 base puzzle pieces into HashTable
	//加载25个拼图方块
    private void GetBasePieces()
    {
        bool aPieceNotFound = false;
        for (int px = 1; px <= 5; px++)
        {
            for (int py = 1; py <= 5; py++)
            {
                string ident = "" + px + "" + py;
                Transform t = GetBase(ident);
                if (t == null)
                    aPieceNotFound = true;
                basePieceTransforms.Add(ident, t);
            }
        }
        _isValid = !aPieceNotFound;
    }


}
