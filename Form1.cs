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
                    id="system",
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
                new ButtonListDetails(){
                    id="network",
                    buttons = new List<ButtonDetails>(){
                        new ButtonDetails(){
                            id = "wifi",
                            icon = "storage.svg",
                        },
                        new ButtonDetails(){
                            id = "ethernet",
                            icon = "storage.svg",
                        },
                        new ButtonDetails(){
                            id = "vpn",
                            icon = "storage.svg",
                        },
                        new ButtonDetails(){
                            id = "mobile_hotspot",
                            icon = "storage.svg",
                        },
                        new ButtonDetails(){
                            id = "airplane_mode",
                            icon = "storage.svg",
                        },
                        new ButtonDetails(){
                            id = "proxy",
                            icon = "storage.svg",
                        },
                        new ButtonDetails(){
                            id = "dial-up",
                            icon = "storage.svg",
                        },
                        new ButtonDetails(){
                            id = "advanced_network_settings",
                            icon = "storage.svg",
                        },
                    }
                }
            }
        },
        new NavMenuDetails() {
            id = "personalization",
            icon = "brush_color.svg",
            items = new List<SettingComponent>(){
                new ButtonListDetails(){
                    id="personalization",
                    buttons = new List<ButtonDetails>(){
                        new ButtonDetails(){
                            id = "background",
                            icon = "storage.svg",
                        },
                        new ButtonDetails(){
                            id = "colors",
                            icon = "storage.svg",
                        },
                        new ButtonDetails(){
                            id = "themes",
                            icon = "storage.svg",
                        },
                        new ButtonDetails(){
                            id = "dynamic_lighting",
                            icon = "storage.svg",
                        },
                        new ButtonDetails(){
                            id = "lock_screen",
                            icon = "storage.svg",
                        },
                        new ButtonDetails(){
                            id = "text_input",
                            icon = "storage.svg",
                        },
                        new ButtonDetails(){
                            id = "start",
                            icon = "storage.svg",
                        },
                        new ButtonDetails(){
                            id = "taskbar",
                            icon = "storage.svg",
                        },
                        new ButtonDetails(){
                            id = "fonts",
                            icon = "storage.svg",
                        },
                        new ButtonDetails(){
                            id = "device_usage",
                            icon = "storage.svg",
                        },
                    }
                }
            }
        },
        new NavMenuDetails() {
            id = "apps",
            icon = "apps_color.svg",
            items = new List<SettingComponent>(){
                new ButtonListDetails(){
                    id="apps",
                    buttons = new List<ButtonDetails>(){
                        new ButtonDetails(){
                            id = "installed_apps",
                            icon = "storage.svg",
                        },
                        new ButtonDetails(){
                            id = "advanced_app_settings",
                            icon = "storage.svg",
                        },
                        new ButtonDetails(){
                            id = "default_apps",
                            icon = "storage.svg",
                        },
                        new ButtonDetails(){
                            id = "actions",
                            icon = "storage.svg",
                        },
                        new ButtonDetails(){
                            id = "offline_maps",
                            icon = "storage.svg",
                        },
                        new ButtonDetails(){
                            id = "apps_for_websites",
                            icon = "storage.svg",
                        },
                        new ButtonDetails(){
                            id = "video_playback",
                            icon = "storage.svg",
                        },
                        new ButtonDetails(){
                            id = "startup",
                            icon = "storage.svg",
                        },
                        new ButtonDetails(){
                            id = "resume",
                            icon = "storage.svg",
                        },
                    }
                }
            }
        },
        new NavMenuDetails() {
            id = "accounts",
            icon = "person_color.svg",
            items = new List<SettingComponent>(){
                new ButtonListDetails(){
                    id="account_settings",
                    hasTitle = true,
                    buttons = new List<ButtonDetails>(){
                        new ButtonDetails(){
                            id = "your_info",
                            icon = "storage.svg",
                        },
                        new ButtonDetails(){
                            id = "sign-in_options",
                            icon = "storage.svg",
                        },
                        new ButtonDetails(){
                            id = "linked_devices",
                            icon = "storage.svg",
                        },
                        new ButtonDetails(){
                            id = "your_accounts",
                            icon = "storage.svg",
                        },
                        new ButtonDetails(){
                            id = "family",
                            icon = "storage.svg",
                        },
                        new ButtonDetails(){
                            id = "windows_backup",
                            icon = "storage.svg",
                        },
                        new ButtonDetails(){
                            id = "other_users",
                            icon = "storage.svg",
                        },
                        new ButtonDetails(){
                            id = "access_work_or_school",
                            icon = "storage.svg",
                        },
                        new ButtonDetails(){
                            id = "passkeys",
                            icon = "storage.svg",
                        },
                    }
                },
                new ButtonListDetails(){
                    id="related_settings",
                    hasTitle = true,
                    buttons = new List<ButtonDetails>(){
                        new ButtonDetails(){
                            id = "account_privacy",
                            icon = "storage.svg",
                        },
                        new ButtonDetails(){
                            id = "subscriptions",
                            icon = "storage.svg",
                        },
                        new ButtonDetails(){
                            id = "payment_options",
                            icon = "storage.svg",
                        },
                        new ButtonDetails(){
                            id = "order_history",
                            icon = "storage.svg",
                        },
                        new ButtonDetails(){
                            id = "account_and_billing_help",
                            icon = "storage.svg",
                        },
                    }
                }
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
