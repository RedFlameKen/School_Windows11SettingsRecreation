namespace finals;

public partial class Form1 : Form
{

    int curNav = 0;

    private List<NavMenuDetails> nav_items
        = new List<NavMenuDetails>(){
        new NavMenuDetails() {
            id = "home",
            icon = "home_color.svg",
            items = new List<SettingComponent>(){
                new SectionDetails(){
                    id = "recommended",
                    buttons = new List<ButtonDetails>(){
                        new ButtonDetails(){
                            id = "storage",
                            icon = "storage.svg",
                        },
                        new ButtonDetails(){
                            id = "default_apps",
                            icon = "calendar_check.svg",
                        },
                        new ButtonDetails(){
                            id="search",
                            icon = "search_square.svg",
                        }
                    }
                },
                new DevicesSectionDetails(){
                    id = "devices",
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
            id = "system",
            icon = "laptop_color.svg",
            items = new List<SettingComponent>(){
                new ButtonListDetails(){
                    buttons = new List<ButtonDetails>(){
                        new ButtonDetails(){
                            id = "display",
                            icon = "storage.svg",
                        },

                        new ButtonDetails(){
                            id = "sound",
                            icon = "storage.svg",
                        },

                        new ButtonDetails(){
                            id = "notifications",
                            icon = "storage.svg",
                        },

                        new ButtonDetails(){
                            id = "focus",
                            icon = "storage.svg",
                        },

                        new ButtonDetails(){
                            id = "power_and_battery",
                            icon = "storage.svg",
                        },

                        new ButtonDetails(){
                            id = "storage",
                            icon = "storage.svg",
                        },

                        new ButtonDetails(){
                            id = "nearby_sharing",
                            icon = "storage.svg",
                        },

                        new ButtonDetails(){
                            id = "multitasking",
                            icon = "storage.svg",
                        },

                        new ButtonDetails(){
                            id = "advanced",
                            icon = "storage.svg",
                        },

                        new ButtonDetails(){
                            id = "activation",
                            icon = "storage.svg",
                        },

                        new ButtonDetails(){
                            id = "troubleshooting",
                            icon = "storage.svg",
                        },

                        new ButtonDetails(){
                            id = "recovery",
                            icon = "storage.svg",
                        },

                        new ButtonDetails(){
                            id = "projecting_to_this_pc",
                            icon = "storage.svg",
                        },

                        new ButtonDetails(){
                            id = "remote_desktop",
                            icon = "storage.svg",
                        },

                        new ButtonDetails(){
                            id = "clipboard",
                            icon = "storage.svg",
                        },

                        new ButtonDetails(){
                            id = "system_components",
                            icon = "storage.svg",
                        },

                        new ButtonDetails(){
                            id = "ai_components",
                            icon = "storage.svg",
                        },

                        new ButtonDetails(){
                            id = "optional_features",
                            icon = "storage.svg",
                        },

                        new ButtonDetails(){
                            id = "about",
                            icon = "storage.svg",
                        },

                    }
                }
            }
        },
        new NavMenuDetails() {
            id = "network_and_internet",
            icon = "wifi_color.svg",
            items = new List<SettingComponent>(){
            }
        },
        new NavMenuDetails() {
            id = "personalization",
            icon = "brush_color.svg",
            items = new List<SettingComponent>(){
            }
        },
        new NavMenuDetails() {
            id = "apps",
            icon = "apps_color.svg",
            items = new List<SettingComponent>(){
            }
        },
        new NavMenuDetails() {
            id = "accounts",
            icon = "person_color.svg",
            items = new List<SettingComponent>(){
            }
        },
        new NavMenuDetails() {
            id = "accessibility",
            icon = "accessibility_color.svg",
            items = new List<SettingComponent>(){
            }
        },
        new NavMenuDetails() {
            id = "privacy_and_security",
            icon = "shield_color.svg",
            items = new List<SettingComponent>(){
            }
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

    private void changeLanguage(string langCode){
        Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(langCode);
        this.Controls.Clear();
        InitializeComponent();
    }

}
