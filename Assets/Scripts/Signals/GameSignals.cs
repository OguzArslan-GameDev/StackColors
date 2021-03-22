using strange.extensions.signal.impl;

public class GameSignals
{
    public Signal Init = new Signal();
    public Signal CharacterLoaded = new Signal();
    public Signal GameStart = new Signal();
    public Signal TestSignal = new Signal();

    //-- PlayerSignals--
    public Signal PlayerMove = new Signal();
    
    //-- InputSignals--
    public Signal SwipeChanged = new Signal();

}
