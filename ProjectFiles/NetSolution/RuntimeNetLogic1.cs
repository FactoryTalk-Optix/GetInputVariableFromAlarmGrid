#region Using directives
using System;
using UAManagedCore;
using OpcUa = UAManagedCore.OpcUa;
using FTOptix.HMIProject;
using FTOptix.Retentivity;
using FTOptix.NativeUI;
using FTOptix.UI;
using FTOptix.Core;
using FTOptix.CoreBase;
using FTOptix.NetLogic;
using FTOptix.Alarm;
#endregion

public class RuntimeNetLogic1 : BaseNetLogic
{
    public override void Start()
    {
        // Insert code to be executed when the user-defined logic is started
    }

    public override void Stop()
    {
        // Insert code to be executed when the user-defined logic is stopped
    }

    [ExportMethod]
    public void banana() {
        IUANode alarmVar = InformationModel.Get(InformationModel.Get(((DataGrid)Owner.Get("AlarmGrid1/AlarmsDataGrid")).SelectedItem).Get<IUAVariable>("InputNode").Value);
        Log.Info(alarmVar.BrowseName);
        Log.Info(GetParentName(alarmVar.NodeId, alarmVar.BrowseName));
    }

    private string GetParentName(NodeId inputObj, string outPath = "") {
        var myVar = InformationModel.Get(inputObj);
        IUANode myVarOwner = myVar.Owner ?? null;
        if (myVarOwner != null) {
            outPath = GetParentName(myVarOwner.NodeId, myVarOwner.BrowseName + "/" + outPath);
        }
        return outPath;
    }
}
