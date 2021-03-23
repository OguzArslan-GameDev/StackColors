using strange.extensions.signal.impl;

public class GameSignals
{
    public Signal Init = new Signal();
    public Signal CharacterLoaded = new Signal();
    public Signal GameStart = new Signal();
    public Signal Fail = new Signal();
    public Signal Success = new Signal();
    public Signal RuntimeDataReset = new Signal();

    //-- PlayerSignals--
    public Signal PlayerMove = new Signal();
    
    //-- InputSignals--
    public Signal SwipeChanged = new Signal();

    //-- CollectSignals---
    public Signal Correct = new Signal();
    public Signal Wrong = new Signal();
}
