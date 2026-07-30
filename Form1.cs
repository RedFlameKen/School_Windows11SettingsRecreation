namespace finals;

public partial class Form1 : Form
{

    int curNav = 0;
    int curLang = 0;

    private List<NavMenuDetails> nav_items
        = new List<NavMenuDetails>(){
        new NavMenuDetails() {
            id = "home",
            icon = "home_color.png",
            items = new List<SettingComponent>(){
                new SectionDetails(){
                    id = "recommended",
                    buttons = new List<ButtonDetails>(){
                        new ButtonDetails(){
                            id = "storage",
                            icon = "storage.png",
                        },
                        new ButtonDetails(){
                            id = "default_apps",
                            icon = "calendar_check.png",
                        },
                        new ButtonDetails(){
                            id="search",
                            icon = "search_square.png",
                        }
                    }
                },
                new DevicesSectionDetails(){
                    id = "devices",
                    buttons = new List<DeviceDetails>(){
                        new DeviceDetails(){
                            name = "AirPods Pro",
                            icon = "headset.png",
                        },
                        new DeviceDetails(){
                            name = "GamePadPlus V3",
                            icon = "controller.png",
                        },
                        new DeviceDetails(){
                            name = "soundcore R50i",
                            icon = "headset.png",
                        }
                    }
                }
            }
        },
        new NavMenuDetails() {
            id = "system",
            icon = "laptop_color.png",
            items = new List<SettingComponent>(){
                new ButtonListDetails(){
                    id="system",
                    buttons = new List<ButtonDetails>(){
                        new ButtonDetails(){
                            id = "display",
                            icon = "laptop.png",
                        },

                        new ButtonDetails(){
                            id = "sound",
                            icon = "speaker.png",
                        },

                        new ButtonDetails(){
                            id = "notifications",
                            icon = "alert.png",
                        },

                        new ButtonDetails(){
                            id = "focus",
                            icon = "target.png",
                        },

                        new ButtonDetails(){
                            id = "power_and_battery",
                            icon = "power.png",
                        },

                        new ButtonDetails(){
                            id = "storage",
                            icon = "storage.png",
                        },

                        new ButtonDetails(){
                            id = "nearby_sharing",
                            icon = "share.png",
                        },

                        new ButtonDetails(){
                            id = "multitasking",
                            icon = "panel_separate_window.png",
                        },

                        new ButtonDetails(){
                            id = "advanced",
                            icon = "wrench_screwdriver.png",
                        },

                        new ButtonDetails(){
                            id = "activation",
                            icon = "checkmark_circle.png",
                        },

                        new ButtonDetails(){
                            id = "troubleshooting",
                            icon = "wrench.png",
                        },

                        new ButtonDetails(){
                            id = "recovery",
                            icon = "reset.png",
                        },

                        new ButtonDetails(){
                            id = "projecting_to_this_pc",
                            icon = "laptop_multiple.png",
                        },

                        new ButtonDetails(){
                            id = "remote_desktop",
                            icon = "remote.png",
                        },

                        new ButtonDetails(){
                            id = "clipboard",
                            icon = "clipboard_paste.png",
                        },

                        new ButtonDetails(){
                            id = "system_components",
                            icon = "panel_right_gallery.png",
                        },

                        new ButtonDetails(){
                            id = "ai_components",
                            icon = "sparkle.png",
                        },

                        new ButtonDetails(){
                            id = "optional_features",
                            icon = "apps_add_in.png",
                        },

                        new ButtonDetails(){
                            id = "about",
                            icon = "info.png",
                        },

                    }
                }
            }
        },
        new NavMenuDetails() {
            id = "network_and_internet",
            icon = "wifi_color.png",
            items = new List<SettingComponent>(){
                new ButtonListDetails(){
                    id="network",
                    buttons = new List<ButtonDetails>(){
                        new ButtonDetails(){
                            id = "wifi",
                            icon = "wifi.png",
                        },
                        new ButtonDetails(){
                            id = "ethernet",
                            icon = "plug_connected.png",
                        },
                        new ButtonDetails(){
                            id = "vpn",
                            icon = "shield_keyhole.png",
                        },
                        new ButtonDetails(){
                            id = "mobile_hotspot",
                            icon = "hotspot.png",
                        },
                        new ButtonDetails(){
                            id = "airplane_mode",
                            icon = "airplane.png",
                        },
                        new ButtonDetails(){
                            id = "proxy",
                            icon = "server_link.png",
                        },
                        new ButtonDetails(){
                            id = "dial-up",
                            icon = "dialpad.png",
                        },
                        new ButtonDetails(){
                            id = "advanced_network_settings",
                            icon = "globe_desktop.png",
                        },
                    }
                }
            }
        },
        new NavMenuDetails() {
            id = "personalization",
            icon = "brush_color.png",
            items = new List<SettingComponent>(){
                new ButtonListDetails(){
                    id="personalization",
                    buttons = new List<ButtonDetails>(){
                        new ButtonDetails(){
                            id = "background",
                            icon = "image.png",
                        },
                        new ButtonDetails(){
                            id = "colors",
                            icon = "color.png",
                        },
                        new ButtonDetails(){
                            id = "themes",
                            icon = "paint_brush.png",
                        },
                        new ButtonDetails(){
                            id = "dynamic_lighting",
                            icon = "circle_highlight.png",
                        },
                        new ButtonDetails(){
                            id = "lock_screen",
                            icon = "calendar_lock.png",
                        },
                        new ButtonDetails(){
                            id = "text_input",
                            icon = "keyboard.png",
                        },
                        new ButtonDetails(){
                            id = "start",
                            icon = "app_folder.png",
                        },
                        new ButtonDetails(){
                            id = "taskbar",
                            icon = "taskbar.png",
                        },
                        new ButtonDetails(){
                            id = "fonts",
                            icon = "text_font.png",
                        },
                        new ButtonDetails(){
                            id = "device_usage",
                            icon = "laptop_checkmark.png",
                        },
                    }
                }
            }
        },
        new NavMenuDetails() {
            id = "apps",
            icon = "apps_color.png",
            items = new List<SettingComponent>(){
                new ButtonListDetails(){
                    id="apps",
                    buttons = new List<ButtonDetails>(){
                        new ButtonDetails(){
                            id = "installed_apps",
                            icon = "apps_list.png",
                        },
                        new ButtonDetails(){
                            id = "advanced_app_settings",
                            icon = "table_settings.png",
                        },
                        new ButtonDetails(){
                            id = "default_apps",
                            icon = "calendar_checkmark.png",
                        },
                        new ButtonDetails(){
                            id = "actions",
                            icon = "sparkle_circle.png",
                        },
                        new ButtonDetails(){
                            id = "offline_maps",
                            icon = "map.png",
                        },
                        new ButtonDetails(){
                            id = "apps_for_websites",
                            icon = "arrow_square_up_right.png",
                        },
                        new ButtonDetails(){
                            id = "video_playback",
                            icon = "video.png",
                        },
                        new ButtonDetails(){
                            id = "startup",
                            icon = "calendar_assistant.png",
                        },
                        new ButtonDetails(){
                            id = "resume",
                            icon = "phone_desktop.png",
                        },
                    }
                }
            }
        },
        new NavMenuDetails() {
            id = "accounts",
            icon = "person_color.png",
            items = new List<SettingComponent>(){
                new ButtonListDetails(){
                    id="account_settings",
                    hasTitle = true,
                    buttons = new List<ButtonDetails>(){
                        new ButtonDetails(){
                            id = "your_info",
                            icon = "person.png",
                        },
                        new ButtonDetails(){
                            id = "sign-in_options",
                            icon = "key.png",
                        },
                        new ButtonDetails(){
                            id = "linked_devices",
                            icon = "tablet_laptop.png",
                        },
                        new ButtonDetails(){
                            id = "your_accounts",
                            icon = "people_list.png",
                        },
                        new ButtonDetails(){
                            id = "family",
                            icon = "person_heart.png",
                        },
                        new ButtonDetails(){
                            id = "windows_backup",
                            icon = "archive_arrow_back.png",
                        },
                        new ButtonDetails(){
                            id = "other_users",
                            icon = "person_add.png",
                        },
                        new ButtonDetails(){
                            id = "access_work_or_school",
                            icon = "briefcase.png",
                        },
                        new ButtonDetails(){
                            id = "passkeys",
                            icon = "person_key.png",
                        },
                    }
                },
                new ButtonListDetails(){
                    id="related_settings",
                    hasTitle = true,
                    buttons = new List<ButtonDetails>(){
                        new ButtonDetails(){
                            id = "account_privacy",
                            icon = "shield.png",
                        },
                        new ButtonDetails(){
                            id = "subscriptions",
                            icon = "slide_text_person.png",
                        },
                        new ButtonDetails(){
                            id = "payment_options",
                            icon = "credit_card_person.png",
                        },
                        new ButtonDetails(){
                            id = "order_history",
                            icon = "history.png",
                        },
                        new ButtonDetails(){
                            id = "account_and_billing_help",
                            icon = "question_circle.png",
                        },
                    }
                }
            }
        },
        new NavMenuDetails() {
            id = "time_and_language",
            icon = "globe_clock_color.png",
            items = new List<SettingComponent>(){
                new ButtonListDetails(){
                    id="time_and_language",
                    buttons = new List<ButtonDetails>(){
                        new ButtonDetails(){
                            id = "date_and_time",
                            icon = "calendar_clock.png",
                        },
                        new ButtonDetails(){
                            id = "language_and_region",
                            icon = "local_language.png",
                        },
                        new ButtonDetails(){
                            id = "typing",
                            icon = "keyboard.png",
                        },
                        new ButtonDetails(){
                            id = "speech",
                            icon = "person_voice.png",
                        },
                    }
                },
            }
        },
        new NavMenuDetails() {
            id = "accessibility",
            icon = "accessibility_color.png",
            items = new List<SettingComponent>(){
                new ButtonListDetails(){
                    id="vision",
                    hasTitle = true,
                    buttons = new List<ButtonDetails>(){
                        new ButtonDetails(){
                            id = "text_size",
                            icon = "text_font.png",
                        },
                        new ButtonDetails(){
                            id = "visual_effects",
                            icon = "sparkle.png",
                        },
                        new ButtonDetails(){
                            id = "mouse_pointer_and_touch",
                            icon = "cursor.png",
                        },
                        new ButtonDetails(){
                            id = "text_cursor",
                            icon = "scan_type.png",
                        },
                        new ButtonDetails(){
                            id = "magnifier",
                            icon = "zoom_in.png",
                        },
                        new ButtonDetails(){
                            id = "color_filters",
                            icon = "color.png",
                        },
                        new ButtonDetails(){
                            id = "contrast_themes",
                            icon = "contrast.png",
                        },
                        new ButtonDetails(){
                            id = "narrator",
                            icon = "desktop_speaker.png",
                        },
                    }
                },
                new ButtonListDetails(){
                    id="hearing",
                    hasTitle = true,
                    buttons = new List<ButtonDetails>(){
                        new ButtonDetails(){
                            id = "audio",
                            icon = "speaker.png",
                        },
                        new ButtonDetails(){
                            id = "hearing_devices",
                            icon = "ear.png",
                        },
                        new ButtonDetails(){
                            id = "captions",
                            icon = "closed_caption.png",
                        },
                    }
                },
                new ButtonListDetails(){
                    id="interaction",
                    hasTitle = true,
                    buttons = new List<ButtonDetails>(){
                        new ButtonDetails(){
                            id = "speech",
                            icon = "mic.png",
                        },
                        new ButtonDetails(){
                            id = "keyboard",
                            icon = "keyboard.png",
                        },
                        new ButtonDetails(){
                            id = "mouse",
                            icon = "mouse.png",
                        },
                        new ButtonDetails(){
                            id = "eye_control",
                            icon = "eye_tracking.png",
                        },
                    }
                },
            }
        },
        new NavMenuDetails() {
            id = "privacy_and_security",
            icon = "shield_color.png",
            items = new List<SettingComponent>(){
                new ButtonListDetails(){
                    id="security",
                    hasTitle = true,
                    buttons = new List<ButtonDetails>(){
                        new ButtonDetails(){
                            id = "windows_security",
                            icon = "shield.png",
                        },
                        new ButtonDetails(){
                            id = "find_my_device",
                            icon = "locate_device.png",
                        },
                    }
                },
                new ButtonListDetails(){
                    id="windows_permissions",
                    hasTitle = true,
                    buttons = new List<ButtonDetails>(){
                        new ButtonDetails(){
                            id = "recommendations_and_offers",
                            icon = "lock_closed.png",
                        },
                        new ButtonDetails(){
                            id = "speech",
                            icon = "person_voice.png",
                        },
                        new ButtonDetails(){
                            id = "inking_and_typing_personalization",
                            icon = "clipboard_task_list.png",
                        },
                        new ButtonDetails(){
                            id = "diagnostics_and_feedback",
                            icon = "pulse_square.png",
                        },
                        new ButtonDetails(){
                            id = "search",
                            icon = "search_square.png",
                        },
                    }
                },
                new ButtonListDetails(){
                    id="app_permissions",
                    hasTitle = true,
                    buttons = new List<ButtonDetails>(){
                        new ButtonDetails(){
                            id = "location",
                            icon = "location_arrow.png",
                            hasSubtitle = false,
                        },
                        new ButtonDetails(){
                            id = "camera",
                            icon = "camera.png",
                            hasSubtitle = false,
                        },
                        new ButtonDetails(){
                            id = "microphone",
                            icon = "mic.png",
                            hasSubtitle = false,
                        },
                        new ButtonDetails(){
                            id = "voice_activation",
                            icon = "mic_record.png",
                            hasSubtitle = false,
                        },
                        new ButtonDetails(){
                            id = "notification",
                            icon = "alert.png",
                            hasSubtitle = false,
                        },
                        new ButtonDetails(){
                            id = "contacts",
                            icon = "people.png",
                            hasSubtitle = false,
                        },
                        new ButtonDetails(){
                            id = "calendar",
                            icon = "calendar.png",
                            hasSubtitle = false,
                        },
                        new ButtonDetails(){
                            id = "phone_calls",
                            icon = "call.png",
                            hasSubtitle = false,
                        },
                        new ButtonDetails(){
                            id = "call_history",
                            icon = "history.png",
                            hasSubtitle = false,
                        },
                        new ButtonDetails(){
                            id = "email",
                            icon = "mail.png",
                            hasSubtitle = false,
                        },
                        new ButtonDetails(){
                            id = "tasks",
                            icon = "clipboard_task.png",
                            hasSubtitle = false,
                        },
                        new ButtonDetails(){
                            id = "messaging",
                            icon = "chat.png",
                            hasSubtitle = false,
                        },
                        new ButtonDetails(){
                            id = "radios",
                            icon = "radio.png",
                            hasSubtitle = false,
                        },
                        new ButtonDetails(){
                            id = "other_devices",
                            icon = "tablet_laptop.png",
                            hasSubtitle = false,
                        },
                        new ButtonDetails(){
                            id = "app_diagnostics",
                            icon = "data_area.png",
                            hasSubtitle = false,
                        },
                        new ButtonDetails(){
                            id = "automatic_file_downloads",
                            icon = "cloud.png",
                            hasSubtitle = false,
                        },
                        new ButtonDetails(){
                            id = "documents",
                            icon = "folder_document.png",
                            hasSubtitle = false,
                        },
                        new ButtonDetails(){
                            id = "downloads_folder",
                            icon = "drawer_arrow_download.png",
                            hasSubtitle = false,
                        },
                        new ButtonDetails(){
                            id = "music_library",
                            icon = "music_note_play.png",
                            hasSubtitle = false,
                        },
                        new ButtonDetails(){
                            id = "pictures",
                            icon = "image.png",
                            hasSubtitle = false,
                        },
                        new ButtonDetails(){
                            id = "videos",
                            icon = "video_clip.png",
                            hasSubtitle = false,
                        },
                        new ButtonDetails(){
                            id = "file_system",
                            icon = "document.png",
                            hasSubtitle = false,
                        },
                        new ButtonDetails(){
                            id = "screenshot_borders",
                            icon = "image.png",
                            hasSubtitle = false,
                        },
                        new ButtonDetails(){
                            id = "screenshots_and_screen_recording",
                            icon = "image_copy.png",
                            hasSubtitle = false,
                        },
                        new ButtonDetails(){
                            id = "text_and_image_generation",
                            icon = "laptop.png",
                            hasSubtitle = false,
                        },
                        new ButtonDetails(){
                            id = "passkeys",
                            icon = "person_key.png",
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
