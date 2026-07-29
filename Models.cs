namespace finals;

enum SettingComponentType
{
    BUTTON_LIST,
    SECTION,
    DEVICES_SECTION,
}

interface SettingComponent {
    public SettingComponentType getType();
}

class ButtonDetails {

    public string title {get; set;} = "";
    public string icon {get; set;} = "";
    public bool hasToggle {get; set;} = false;
    public bool toggleState {get; set;} = false;

}

class DeviceDetails {

    public string name {get; set;} = "";
    public bool isConnected {get; set;} = false;
    public string icon {get; set;} = "";

}

class ButtonListDetails : SettingComponent
{

    public List<ButtonDetails>? buttons {get; set;}

    public SettingComponentType getType()
    {
        return SettingComponentType.BUTTON_LIST;
    }

}

class SectionDetails : SettingComponent
{

    public string title {get; set;} = "";
    public string subtitle {get; set;} = "";
    public List<ButtonDetails>? buttons {get; set;}
    
    public SettingComponentType getType()
    {
        return SettingComponentType.SECTION;
    }

}

class DevicesSectionDetails : SettingComponent
{

    public string title {get; set;} = "";
    public string subtitle {get; set;} = "";
    public bool bluetoothOn {get; set;} = true;
    public List<DeviceDetails>? buttons {get; set;}
    
    public SettingComponentType getType()
    {
        return SettingComponentType.DEVICES_SECTION;
    }

}

class NavMenuDetails
{

    public string? icon {get; set;}
    public string name {get; set;} = "Nav";
    public List<SettingComponent>? items {get; set;}
    
}
