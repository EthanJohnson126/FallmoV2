using UnityEngine;

public class UIManager : MonoBehaviour {

    public GUISkin NoahsGUISkin;
    public Texture2D aBackground, aLogo;

    public Rect guiWindow = new Rect(Screen.width / 2, Screen.height / 2, 100, 100);

    public string[] creditsText = new string[0];

    private string menuState;

    private string main = "main";
    private string options = "options";
    private string credits = "credits";

    private string texttodisplay = "Credits \n";

    private float volume = 1.0F;
	// Use this for initialization
	void Start () {

        menuState = "main";

        for (int x = 0; x > creditsText.Length; x++ )
        {
            texttodisplay += creditsText[x] + "\n";
        }

        texttodisplay += "Press Esc to go back";
	}

    public void OnGUI(){
        if (aBackground != null){
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), aBackground);
        }

        if (aLogo != null)
        {
            GUI.DrawTexture(new Rect((Screen.width / 3) - 100, 30, 200, 200), aLogo);
        }

        GUI.skin = NoahsGUISkin;

        if (menuState == main){
            guiWindow = GUI.Window(0, guiWindow, menuFunc, "gg");
        }

        if (menuState == credits)
        {
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), texttodisplay);
        }

        if (menuState == options)
        {
            guiWindow = GUI.Window(1, guiWindow, optionsFunc, "Options");
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (menuState == credits && Input.GetKey(KeyCode.Escape)){
            menuState = main;
        }
	}

    private void optionsFunc(int id){
        GUILayout.Box("Volume");
        volume = GUILayout.HorizontalSlider(volume, 0.0F, 1.0F);
        AudioListener.volume = volume;

        if (GUILayout.Button("Back"))
        {
            menuState = main;
        }
    }

    private void menuFunc (int id){
        if (GUILayout.Button("Play Game")){
            print("tttt");
        }

        if (GUILayout.Button("Options"))
        {
            menuState = options;
        }

        if (GUILayout.Button("Credits"))
        {
            menuState = credits;
        }
    }
}
