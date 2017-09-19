// IMPORTANT ! 
// To run the Javascript Sample you need to move the /Jigsaw/Standard Assets folder into the {root}/ of your project.,
// The reason for this is because the JigsawPuzzle class we are extending is a C# class and has to be pre-compiled.
//  This file was commented to avoid import package compiler errors.

	public var guiTitle:Texture = null;
    public var guiMenu:Texture = null;
    public var guiMenuPuzzle:Texture = null;
    public var guiMenuPieces:Texture = null;
    public var guiMenuRestart:Texture = null;
    public var image1:Texture = null;
    public var image2:Texture  = null;
    public var image3:Texture = null;
    public var puzzle:GameObject;
	
/*

	// we will select all images and game objects that have to be accessed on the linked script
	// so we dant have to do lookups or put stuff in Resources
    

    private var jigsawPuzzle:JSDemoJigsawPuzzle  = null;
    private var puzzleImage:int = 1;
    private var sizeMode:int = 3;

	// Use this for initialization
	function Start () {
        if (puzzle != null)
        {
			// puzzle was set so get linked DemoJigsawPuzzle class
            jigsawPuzzle = puzzle.GetComponent("JSDemoJigsawPuzzle") as JSDemoJigsawPuzzle;
            if (jigsawPuzzle!=null) 
				// if we have a jigsawPuzzle set size related to puzzleImage (1-3) and sizeMode (1-6)
				SetSize();
        }        
	}
	
    // translate Input mouseposition to GUI coordinates using camera viewport
    function GuiMousePosition():Vector2
    {
        var mp:Vector2 = Input.mousePosition;
        var vp:Vector3 = Camera.main.ScreenToViewportPoint(new Vector3(mp.x, mp.y, 0));
        mp = new Vector2(vp.x * Camera.main.pixelWidth, (1 - vp.y) * Camera.main.pixelHeight);
        return mp;
    }
	
	// menu 'puzzle' is clicked so go to next puzzle
    function Puzzle()
    {
		// increase puzzle image (1-3)
        puzzleImage++;
        if (puzzleImage == 4) puzzleImage = 1;
		// scale puzzle and set image related to puzzleImage
        switch (puzzleImage)
        {
            case 1:
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
    function SetSize()
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

    function Pieces()
    {
		// loop possible sizes - if on mobile platform we can not have too many polygons so cap size at Mode 5 max
        sizeMode++;
		if ((Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android) && sizeMode == 6) 
			sizeMode = 1;
		else
		if (sizeMode == 7) sizeMode = 1;
        SetSize();
    }

    function Restart()
    {
		// determine random topleft piece
        var topLeft:String = "" + ((Mathf.Floor(Random.value * 5)) + 1) + ((Mathf.Floor(Random.value * 5)) + 1);
        while (jigsawPuzzle.topLeftPiece == topLeft)
            topLeft = "" + ((Mathf.Floor(Random.value * 5)) + 1) + ((Mathf.Floor(Random.value * 5)) + 1);
		// set puzzle top left piece so restart is forced
        jigsawPuzzle.topLeftPiece = topLeft;
    }
	
	// handle GUI drawing
    function OnGUI()
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
            var mp:Vector2 = GuiMousePosition();
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
	private function DispTime():String
	{
		if (jigsawPuzzle.time<60)
		{
			return String.Format("{0:0} seconds",jigsawPuzzle.time);
		}
		else
		{
			return String.Format("{0:0.0} minutes",jigsawPuzzle.time/60);
		}	
	}

*/