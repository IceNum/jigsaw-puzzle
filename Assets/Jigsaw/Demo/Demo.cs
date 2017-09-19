using UnityEngine;
using System.Collections;

// this Demo is the main process class for the WyrmTale Jigsaw Puzzle Pack Demo
// this script was added to the Demo scene main Camera
public class Demo : MonoBehaviour {
	
	// we will select all images and game objects that have to be accessed on the linked script
	// so we dant have to do lookups or put stuff in Resources
    public Texture guiTitle = null;
    public Texture guiMenu= null;
    public Texture guiMenuPuzzle = null;
    public Texture guiMenuPieces = null;
    public Texture guiMenuRestart = null;
    public Texture image1 = null;
    public Texture image2 = null;
    public Texture image3 = null;
    public GameObject puzzle;

    DemoJigsawPuzzle jigsawPuzzle = null;
    int puzzleImage = 1;
    int sizeMode = 3;

	// Use this for initialization
	void Start () {
        if (puzzle != null)
        {
			// puzzle was set so get linked DemoJigsawPuzzle class
            jigsawPuzzle = puzzle.GetComponent("DemoJigsawPuzzle") as DemoJigsawPuzzle;
			if (jigsawPuzzle==null)
			     jigsawPuzzle = puzzle.GetComponent("DemoJigsawPuzzle_mac_ios") as DemoJigsawPuzzle_mac_ios;
			if (jigsawPuzzle==null)
			     jigsawPuzzle = puzzle.GetComponent("JSDemoJigsawPuzzle") as DemoJigsawPuzzle;
            if (jigsawPuzzle!=null) 
				// if we have a jigsawPuzzle set size related to puzzleImage (1-3) and sizeMode (1-6)
				SetSize();
        }        
	}
	
    // translate Input mouseposition to GUI coordinates using camera viewport
    private Vector2 GuiMousePosition()
    {
        Vector2 mp = Input.mousePosition;
        Vector3 vp = Camera.main.ScreenToViewportPoint(new Vector3(mp.x, mp.y, 0));
        mp = new Vector2(vp.x * Camera.main.pixelWidth, (1 - vp.y) * Camera.main.pixelHeight);
        return mp;
    }
	
	// menu 'puzzle' is clicked so go to next puzzle
    void Puzzle()
    {
		// increase puzzle image (1-3)
        puzzleImage++;
        if (puzzleImage == 4) puzzleImage = 1;
		// scale puzzle and set image related to puzzleImage
        switch (puzzleImage)
        {
            case 1:
			//z轴高度 棋盘高度
                puzzle.transform.localScale = new Vector3(8,5, puzzle.transform.localScale.z);
                jigsawPuzzle.image = image1;
                SetSize();
                break;
            case 2:
                puzzle.transform.localScale = new Vector3(6, 6, puzzle.transform.localScale.z);
                jigsawPuzzle.image = image2;
                SetSize();
                break;
            case 3:
                puzzle.transform.localScale = new Vector3(5, 7, puzzle.transform.localScale.z);
                jigsawPuzzle.image = image3;
                SetSize();
                break;
        }
    }
	
	// set current puzzle size
    void SetSize()
    {
        switch (puzzleImage)
        {
            case 1:
                switch (sizeMode)
                {
                    case 1: jigsawPuzzle.size = new Vector2(3, 2); break;
                    case 2: jigsawPuzzle.size = new Vector2(4, 3); break;
                    case 3: jigsawPuzzle.size = new Vector2(6, 4); break;
                    case 4: jigsawPuzzle.size = new Vector2(8, 6); break;
                    case 5: jigsawPuzzle.size = new Vector2(12, 8); break;
                    case 6: jigsawPuzzle.size = new Vector2(25, 15); break;
                }
                break;
            case 2:
                switch (sizeMode)
                {
                    case 1: jigsawPuzzle.size = new Vector2(3, 3); break;
                    case 2: jigsawPuzzle.size = new Vector2(4, 4); break;
                    case 3: jigsawPuzzle.size = new Vector2(6, 6); break;
                    case 4: jigsawPuzzle.size = new Vector2(8, 8); break;
                    case 5: jigsawPuzzle.size = new Vector2(12, 12); break;
                    case 6: jigsawPuzzle.size = new Vector2(25, 25); break;
                }
                break;
            case 3:
                switch (sizeMode)
                {
                    case 1: jigsawPuzzle.size = new Vector2(2, 3); break;
                    case 2: jigsawPuzzle.size = new Vector2(3, 4); break;
                    case 3: jigsawPuzzle.size = new Vector2(4, 6); break;
                    case 4: jigsawPuzzle.size = new Vector2(6, 8); break;
                    case 5: jigsawPuzzle.size = new Vector2(8, 12); break;
                    case 6: jigsawPuzzle.size = new Vector2(25, 25); break;
                }
                break;
        }
    }

    void Pieces()
    {
		// loop possible sizes - if on mobile platform we can not have too many polygons so cap size at Mode 5 max
        sizeMode++;
		if ((Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android) && sizeMode == 6) 
			sizeMode = 1;
		else
		if (sizeMode == 7) sizeMode = 1;
        SetSize();
    }

    void Restart()
    {
		// determine random topleft piece
        string topLeft = "" + ((int)(Mathf.Floor(Random.value * 5)) + 1) + ((int)(Mathf.Floor(Random.value * 5)) + 1);
        while (jigsawPuzzle.topLeftPiece == topLeft)
            topLeft = "" + ((int)(Mathf.Floor(Random.value * 5)) + 1) + ((int)(Mathf.Floor(Random.value * 5)) + 1);
		// set puzzle top left piece so restart is forced
        jigsawPuzzle.topLeftPiece = topLeft;
    }
	
	// handle GUI drawing
	//拼图
    void OnGUI()
    {
		// we must have a puzzle
        if (jigsawPuzzle == null) 
        {
            Debug.LogError("JigsawPuzzle not found!");
            return;
        }
		// draw titel image
        if (guiTitle!=null)
            GUI.DrawTexture(new Rect(5, 5, 472, 113), guiTitle, ScaleMode.ScaleToFit, true, 0f);
		// draw menu
        if (guiMenu != null)
        {
            Vector2 mp = GuiMousePosition();
            // check current GUI mouse position 
            if (new Rect(8, 92, 107, 50).Contains(mp))
            {
                GUI.DrawTexture(new Rect(8, 92, 107, 150), guiMenuPuzzle, ScaleMode.ScaleToFit, true, 0f);
				// check if 'puzzle' menu was clicked
                if (Input.GetMouseButtonUp(0) && Event.current.type == EventType.MouseUp)
                    Puzzle();
            }
            else
                if (new Rect(8, 142, 107, 50).Contains(mp))
                {
                    GUI.DrawTexture(new Rect(8, 92, 107, 150), guiMenuPieces, ScaleMode.ScaleToFit, true, 0f);
					// check if 'pieces' menu was clicked
                    if (Input.GetMouseButtonUp(0) && Event.current.type == EventType.MouseUp)
                        Pieces();
                }
                else
                    if (new Rect(8, 192, 107, 50).Contains(mp))
                    {
                        GUI.DrawTexture(new Rect(8, 92, 107, 150), guiMenuRestart, ScaleMode.ScaleToFit, true, 0f);
						// check if 'restart' menu was clicked
                        if (Input.GetMouseButtonUp(0) && Event.current.type == EventType.MouseUp)
                            Restart();
                    }
                    else
                        GUI.DrawTexture(new Rect(8, 92, 107, 150), guiMenu, ScaleMode.ScaleToFit, true, 0f);
        }
		
		if (jigsawPuzzle.solved)
		{
			// if puzzle is solved display stats
			GUI.skin.box.fontSize = 24;
			GUI.skin.box.alignment = TextAnchor.MiddleCenter;
			GUI.Box(new Rect((Screen.width-320),20,300,100), new GUIContent("- SOLVED -\n"+jigsawPuzzle.moves+" moves\n"+DispTime()));
		}
		
    }
	
	// format time display string
	private string DispTime()
	{
		if (jigsawPuzzle.time<60)
		{
			return string.Format("{0:0} seconds",jigsawPuzzle.time);
		}
		else
		{
			return string.Format("{0:0.0} minutes",jigsawPuzzle.time/60);
		}	
	}
	
}
