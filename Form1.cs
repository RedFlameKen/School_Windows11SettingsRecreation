namespace finals;

public partial class Form1 : Form
{

    int curNav = 0;

    private List<NavMenuDetails> nav_items
        = new List<NavMenuDetails>(){
        new NavMenuDetails() {
            name = "Home",
            icon = "home_color.svg",
            items = new List<SettingComponent>(){
                new SectionDetails(){
                    title = "Recommended Settings",
                    subtitle = "Recent and commonly used settings",
                    buttons = new List<ButtonDetails>(){
                        new ButtonDetails(){
                            title = "Storage",
                            icon = "storage.svg",
                        },
                        new ButtonDetails(){
                            title = "Default Apps",
                            icon = "calendar_check.svg",
                        },
                        new ButtonDetails(){
                            title = "Search",
                            icon = "search_square.svg",
                        }
                    }
                },
                new DevicesSectionDetails(){
                    title = "Bluetooth Devices",
                    subtitle = "Manage, add, and remove devices",
                    buttons = new List<DeviceDetails>(){
                        new DeviceDetails(){
                            name = "AirPods Pro",
                            icon = "headset.svg",
                        },
                        new DeviceDetails(){
                            name = "GamePadPlus V3",
                            icon = "controller.svg",
                        },
                        new DeviceDetails(){
                            name = "soundcore R50i",
                            icon = "headset.svg",
                        }
                    }
                }
            }
        },
        new NavMenuDetails() {
            name = "System",
            icon = "laptop_color.svg",
        },
        new NavMenuDetails() {
            name = "Network && internet",
            icon = "wifi_color.svg",
        },
        new NavMenuDetails() {
            name = "Personalization",
            icon = "brush_color.svg",
        },
        new NavMenuDetails() {
            name = "Apps",
            icon = "apps_color.svg",
        },
        new NavMenuDetails() {
            name = "Accounts",
            icon = "person_color.svg",
        },
        new NavMenuDetails() {
            name = "Accessibility",
            icon = "accessibility_color.svg",
        },
        new NavMenuDetails() {
            name = "Privacy && Security",
            icon = "shield_color.svg",
        },
    };



    public Form1()
    {
        InitializeComponent();
    }


    private void setSettingMenu(int item){
        mainPanel.Controls.Clear();
        SettingMenu settingMenu = new SettingMenu(nav_items[item]){
            Dock = DockStyle.Top,
            AutoSize = true,
        };

        mainPanel.Controls.Add(settingMenu);

    }
}
