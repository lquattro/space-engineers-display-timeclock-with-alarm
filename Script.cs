public Program() {
    // The constructor, called only once every session and
    // always before any other method is called. Use it to
    // initialize your script. 
    //     
    // The constructor is optional and can be removed if not
    // needed.
}

public void Save() {
    // Called when the program needs to save its state. Use
    // this method to save your state to the Storage field
    // or some other means. 
    // 
    // This method is optional and can be removed if not
    // needed.
}

public void Main(string argument) {
    // The main entry point of the script, invoked every time
    // one of the programmable block's Run actions are invoked.
    // 
    // The method itself is required, but the argument above
    // can be removed if not needed.

    /**
     * Constants
     */
    const string nameLCD = "CC LCD ";
    const string nameSonor = "CD-Block Sonor ";
    const int nbLCD = 5;
    const bool alarm = true;

    /**
     * Variables
     */
    string time;
    string timeTest;
    Color colorRed = new Color(255, 0, 0);
    Color colorGreen = new Color(0, 201, 35);

    // List Panels LCDs
    List< IMyTextPanel> blocklist = new List< IMyTextPanel>();
    // SoundBlock
    IMySoundBlock soundWarning = GridTerminalSystem.GetBlockWithName( nameSonor + 1 ) as IMySoundBlock;

    TimeSpan timeOffset = new TimeSpan(0, 0, 0, 0);     
    DateTime currentTime = DateTime.Now;     
    currentTime = currentTime.Add(timeOffset);

    time = currentTime.ToString("HH:mm:ss");
    timeTest = currentTime.ToString("HHmmss");

    // Alarm clock, disable
    if ( alarm == true && timeTest.CompareTo("020000") > 0 && timeTest.CompareTo("060000") < 0) {
        // Play sound.
        soundWarning.Play();
        // Write alert in LCDs
        time += "\nSleep Time!";
    }   

    // Write texts in Displays and show it.
    IMyTextPanel display; 
    for ( int i = 1; i <= nbLCD; i++ ) { 
        display = GridTerminalSystem.GetBlockWithName( nameLCD + i ) as IMyTextPanel;

        if ( alarm == true && timeTest.CompareTo("020000") > 0 && timeTest.CompareTo("060000") < 0) {
            display.SetValue("FontColor", colorRed ); 
        } else {
            display.SetValue("FontColor", colorGreen ); 
        }

        // Write text in display
        display.WritePublicText(time, false);

        // Show public text in display
        display.ShowPublicTextOnScreen(); 
    }
}
