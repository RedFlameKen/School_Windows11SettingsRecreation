namespace finals;

public partial class Form1 : Form
{

    int curNav = 0;
    int curLang = 0;

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
                            icon = "laptop.svg",
                        },

                        new ButtonDetails(){
                            id = "sound",
                            icon = "speaker.svg",
                        },

                        new ButtonDetails(){
                            id = "notifications",
                            icon = "alert.svg",
                        },

                        new ButtonDetails(){
                            id = "focus",
                            icon = "target.svg",
                        },

                        new ButtonDetails(){
                            id = "power_and_battery",
                            icon = "power.svg",
                        },

                        new ButtonDetails(){
                            id = "storage",
                            icon = "storage.svg",
                        },

                        new ButtonDetails(){
                            id = "nearby_sharing",
                            icon = "share.svg",
                        },

                        new ButtonDetails(){
                            id = "multitasking",
                            icon = "panel_separate_window.svg",
                        },

                        new ButtonDetails(){
                            id = "advanced",
                            icon = "wrench_screwdriver.svg",
                        },

                        new ButtonDetails(){
                            id = "activation",
                            icon = "checkmark_circle.svg",
                        },

                        new ButtonDetails(){
                            id = "troubleshooting",
                            icon = "wrench.svg",
                        },

                        new ButtonDetails(){
                            id = "recovery",
                            icon = "reset.svg",
                        },

                        new ButtonDetails(){
                            id = "projecting_to_this_pc",
                            icon = "laptop_multiple.svg",
                        },

                        new ButtonDetails(){
                            id = "remote_desktop",
                            icon = "remote.svg",
                        },

                        new ButtonDetails(){
                            id = "clipboard",
                            icon = "clipboard_paste.svg",
                        },

                        new ButtonDetails(){
                            id = "system_components",
                            icon = "panel_right_gallery.svg",
                        },

                        new ButtonDetails(){
                            id = "ai_components",
                            icon = "sparkle.svg",
                        },

                        new ButtonDetails(){
                            id = "optional_features",
                            icon = "apps_add_in.svg",
                        },

                        new ButtonDetails(){
                            id = "about",
                            icon = "info.svg",
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
                            icon = "wifi.svg",
                        },
                        new ButtonDetails(){
                            id = "ethernet",
                            icon = "plug_connected.svg",
                        },
                        new ButtonDetails(){
                            id = "vpn",
                            icon = "shield_keyhole.svg",
                        },
                        new ButtonDetails(){
                            id = "mobile_hotspot",
                            icon = "hotspot.svg",
                        },
                        new ButtonDetails(){
                            id = "airplane_mode",
                            icon = "airplane.svg",
                        },
                        new ButtonDetails(){
                            id = "proxy",
                            icon = "server_link.svg",
                        },
                        new ButtonDetails(){
                            id = "dial-up",
                            icon = "dialpad.svg",
                        },
                        new ButtonDetails(){
                            id = "advanced_network_settings",
                            icon = "globe_desktop.svg",
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
                            icon = "image.svg",
                        },
                        new ButtonDetails(){
                            id = "colors",
                            icon = "color.svg",
                        },
                        new ButtonDetails(){
                            id = "themes",
                            icon = "paint_brush.svg",
                        },
                        new ButtonDetails(){
                            id = "dynamic_lighting",
                            icon = "circle_highlight.svg",
                        },
                        new ButtonDetails(){
                            id = "lock_screen",
                            icon = "calendar_lock.svg",
                        },
                        new ButtonDetails(){
                            id = "text_input",
                            icon = "keyboard.svg",
                        },
                        new ButtonDetails(){
                            id = "start",
                            icon = "app_folder.svg",
                        },
                        new ButtonDetails(){
                            id = "taskbar",
                            icon = "taskbar.svg",
                        },
                        new ButtonDetails(){
                            id = "fonts",
                            icon = "text_font.svg",
                        },
                        new ButtonDetails(){
                            id = "device_usage",
                            icon = "laptop_checkmark.svg",
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
                            icon = "apps_list.svg",
                        },
                        new ButtonDetails(){
                            id = "advanced_app_settings",
                            icon = "table_settings.svg",
                        },
                        new ButtonDetails(){
                            id = "default_apps",
                            icon = "calendar_checkmark.svg",
                        },
                        new ButtonDetails(){
                            id = "actions",
                            icon = "sparkle_circle.svg",
                        },
                        new ButtonDetails(){
                            id = "offline_maps",
                            icon = "map.svg",
                        },
                        new ButtonDetails(){
                            id = "apps_for_websites",
                            icon = "arrow_square_up_right.svg",
                        },
                        new ButtonDetails(){
                            id = "video_playback",
                            icon = "video.svg",
                        },
                        new ButtonDetails(){
                            id = "startup",
                            icon = "calendar_assistant.svg",
                        },
                        new ButtonDetails(){
                            id = "resume",
                            icon = "phone_desktop.svg",
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
                            icon = "person.svg",
                        },
                        new ButtonDetails(){
                            id = "sign-in_options",
                            icon = "key.svg",
                        },
                        new ButtonDetails(){
                            id = "linked_devices",
                            icon = "tablet_laptop.svg",
                        },
                        new ButtonDetails(){
                            id = "your_accounts",
                            icon = "people_list.svg",
                        },
                        new ButtonDetails(){
                            id = "family",
                            icon = "person_heart.svg",
                        },
                        new ButtonDetails(){
                            id = "windows_backup",
                            icon = "archive_arrow_back.svg",
                        },
                        new ButtonDetails(){
                            id = "other_users",
                            icon = "person_add.svg",
                        },
                        new ButtonDetails(){
                            id = "access_work_or_school",
                            icon = "briefcase.svg",
                        },
                        new ButtonDetails(){
                            id = "passkeys",
                            icon = "person_key.svg",
                        },
                    }
                },
                new ButtonListDetails(){
                    id="related_settings",
                    hasTitle = true,
                    buttons = new List<ButtonDetails>(){
                        new ButtonDetails(){
                            id = "account_privacy",
                            icon = "shield.svg",
                        },
                        new ButtonDetails(){
                            id = "subscriptions",
                            icon = "slide_text_person.svg",
                        },
                        new ButtonDetails(){
                            id = "payment_options",
                            icon = "credit_card_person.svg",
                        },
                        new ButtonDetails(){
                            id = "order_history",
                            icon = "history.svg",
                        },
                        new ButtonDetails(){
                            id = "account_and_billing_help",
                            icon = "question_circle.svg",
                        },
                    }
                }
            }
        },
        new NavMenuDetails() {
            id = "accessibility",
            icon = "accessibility_color.svg",
            items = new List<SettingComponent>(){
                new ButtonListDetails(){
                    id="vision",
                    hasTitle = true,
                    buttons = new List<ButtonDetails>(){
                        new ButtonDetails(){
                            id = "text_size",
                            icon = "text_font.svg",
                        },
                        new ButtonDetails(){
                            id = "visual_effects",
                            icon = "sparkle.svg",
                        },
                        new ButtonDetails(){
                            id = "mouse_pointer_and_touch",
                            icon = "cursor.svg",
                        },
                        new ButtonDetails(){
                            id = "text_cursor",
                            icon = "scan_type.svg",
                        },
                        new ButtonDetails(){
                            id = "magnifier",
                            icon = "zoom_in.svg",
                        },
                        new ButtonDetails(){
                            id = "color_filters",
                            icon = "color.svg",
                        },
                        new ButtonDetails(){
                            id = "contrast_themes",
                            icon = "contrast.svg",
                        },
                        new ButtonDetails(){
                            id = "narrator",
                            icon = "desktop_speaker.svg",
                        },
                    }
                },
                new ButtonListDetails(){
                    id="hearing",
                    hasTitle = true,
                    buttons = new List<ButtonDetails>(){
                        new ButtonDetails(){
                            id = "audio",
                            icon = "speaker.svg",
                        },
                        new ButtonDetails(){
                            id = "hearing_devices",
                            icon = "ear.svg",
                        },
                        new ButtonDetails(){
                            id = "captions",
                            icon = "closed_caption.svg",
                        },
                    }
                },
                new ButtonListDetails(){
                    id="interaction",
                    hasTitle = true,
                    buttons = new List<ButtonDetails>(){
                        new ButtonDetails(){
                            id = "speech",
                            icon = "mic.svg",
                        },
                        new ButtonDetails(){
                            id = "keyboard",
                            icon = "keyboard.svg",
                        },
                        new ButtonDetails(){
                            id = "mouse",
                            icon = "mouse.svg",
                        },
                        new ButtonDetails(){
                            id = "eye_control",
                            icon = "eye_tracking.svg",
                        },
                    }
                },
            }
        },
        new NavMenuDetails() {
            id = "privacy_and_security",
            icon = "shield_color.svg",
            items = new List<SettingComponent>(){
                new ButtonListDetails(){
                    id="security",
                    hasTitle = true,
                    buttons = new List<ButtonDetails>(){
                        new ButtonDetails(){
                            id = "windows_security",
                            icon = "shield.svg",
                        },
                        new ButtonDetails(){
                            id = "find_my_device",
                            icon = "locate_device.svg",
                        },
                    }
                },
                new ButtonListDetails(){
                    id="windows_permissions",
                    hasTitle = true,
                    buttons = new List<ButtonDetails>(){
                        new ButtonDetails(){
                            id = "recommendations_and_offers",
                            icon = "lock_closed.svg",
                        },
                        new ButtonDetails(){
                            id = "speech",
                            icon = "person_voice.svg",
                        },
                        new ButtonDetails(){
                            id = "inking_and_typing_personalization",
                            icon = "clipboard_task_list.svg",
                        },
                        new ButtonDetails(){
                            id = "diagnostics_and_feedback",
                            icon = "pulse_square.svg",
                        },
                        new ButtonDetails(){
                            id = "search",
                            icon = "search_square.svg",
                        },
                    }
                },
                new ButtonListDetails(){
                    id="app_permissions",
                    hasTitle = true,
                    buttons = new List<ButtonDetails>(){
                        new ButtonDetails(){
                            id = "location",
                            icon = "location_arrow.svg",
                            hasSubtitle = false,
                        },
                        new ButtonDetails(){
                            id = "camera",
                            icon = "camera.svg",
                            hasSubtitle = false,
                        },
                        new ButtonDetails(){
                            id = "microphone",
                            icon = "mic.svg",
                            hasSubtitle = false,
                        },
                        new ButtonDetails(){
                            id = "voice_activation",
                            icon = "mic_record.svg",
                            hasSubtitle = false,
                        },
                        new ButtonDetails(){
                            id = "notification",
                            icon = "alert.svg",
                            hasSubtitle = false,
                        },
                        new ButtonDetails(){
                            id = "contacts",
                            icon = "people.svg",
                            hasSubtitle = false,
                        },
                        new ButtonDetails(){
                            id = "calendar",
                            icon = "calendar.svg",
                            hasSubtitle = false,
                        },
                        new ButtonDetails(){
                            id = "phone_calls",
                            icon = "call.svg",
                            hasSubtitle = false,
                        },
                        new ButtonDetails(){
                            id = "call_history",
                            icon = "history.svg",
                            hasSubtitle = false,
                        },
                        new ButtonDetails(){
                            id = "email",
                            icon = "mail.svg",
                            hasSubtitle = false,
                        },
                        new ButtonDetails(){
                            id = "tasks",
                            icon = "clipboard_task.svg",
                            hasSubtitle = false,
                        },
                        new ButtonDetails(){
                            id = "messaging",
                            icon = "chat.svg",
                            hasSubtitle = false,
                        },
                        new ButtonDetails(){
                            id = "radios",
                            icon = "radio.svg",
                            hasSubtitle = false,
                        },
                        new ButtonDetails(){
                            id = "other_devices",
                            icon = "tablet_laptop.svg",
                            hasSubtitle = false,
                        },
                        new ButtonDetails(){
                            id = "app_diagnostics",
                            icon = "data_area.svg",
                            hasSubtitle = false,
                        },
                        new ButtonDetails(){
                            id = "automatic_file_downloads",
                            icon = "cloud.svg",
                            hasSubtitle = false,
                        },
                        new ButtonDetails(){
                            id = "documents",
                            icon = "folder_document.svg",
                            hasSubtitle = false,
                        },
                        new ButtonDetails(){
                            id = "downloads_folder",
                            icon = "drawer_arrow_download.svg",
                            hasSubtitle = false,
                        },
                        new ButtonDetails(){
                            id = "music_library",
                            icon = "music_note_play.svg",
                            hasSubtitle = false,
                        },
                        new ButtonDetails(){
                            id = "pictures",
                            icon = "image.svg",
                            hasSubtitle = false,
                        },
                        new ButtonDetails(){
                            id = "videos",
                            icon = "video_clip.svg",
                            hasSubtitle = false,
                        },
                        new ButtonDetails(){
                            id = "file_system",
                            icon = "document.svg",
                            hasSubtitle = false,
                        },
                        new ButtonDetails(){
                            id = "screenshot_borders",
                            icon = "image.svg",
                            hasSubtitle = false,
                        },
                        new ButtonDetails(){
                            id = "screenshots_and_screen_recording",
                            icon = "image_copy.svg",
                            hasSubtitle = false,
                        },
                        new ButtonDetails(){
                            id = "text_and_image_generation",
                            icon = "laptop.svg",
                            hasSubtitle = false,
                        },
                        new ButtonDetails(){
                            id = "passkeys",
                            icon = "person_key.svg",
                            hasSubtitle = false,
                        },
                    }
                },
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
        curNav = item;

    }

    private void changeLanguage(string langCode, int index){
        curLang = index;
        Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(langCode);
        this.Controls.Clear();
        InitializeComponentSelfManaged();
    }

}
