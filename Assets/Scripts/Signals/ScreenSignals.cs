using Assets.Scripts.Data.Vo;
using strange.extensions.signal.impl;

public class ScreenSignals
{
    public Signal<PanelVo> OpenPanel = new Signal<PanelVo>();
    public Signal<int> ClearPanel = new Signal<int>();
}
