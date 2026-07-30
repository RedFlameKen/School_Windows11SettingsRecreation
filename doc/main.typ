#set page(
   paper: "us-letter",
   margin:  (x: 1in, y: 1in),
)

#set text(
   font: "arial",
   size: 11pt
)

*Kenneth Lacaba* \
*SEG31* \
*CSELEC13* \

#set par(
   first-line-indent: (
       amount: 1em,
       all: false,
   ),
   justify: true
)

#align(center)[= Finals Project: Windows 11 Recreation in Winforms]

This project makes use of images files for aesthetics. Images can be fetched at
#link("https://github.com/RedFlameKen/School_Windows11SettingsRecreation.git")
in the `assets/` directory. The following will be instructions on setting up
the project. But as per requirement, source code will also be included.

== Instructions

First, clone the project.
```bash
git clone https://github.com/RedFlameKen/School_Windows11SettingsRecreation.git
cd School_Windows11SettingsRecreation
```

You may either then open the project in _Visual Studio_, or build the project
using the dotnet framework. If you are building the project using _Visual
Studio_, the `Building with dotnet` section may be disregarded.


=== Building with dotnet
First, ensure that dotnet `10.0` or higher is installed.

Once you are in the project directory, run the following command to build the
project:
```bash
dotnet build
```

The build executable file should be found in `bin/Debug/net10.0-windows`. If
not, you might want to check how you compile the project.

If you are using `make`, you may simply run the `make` command to build and run
the project.


== Screenshots

=== English

==== Home
#align(center)[
  #image("res/home.png")
]

==== System
#align(center)[
  #image("res/system_1.png")
]

#align(center)[
  #image("res/system_2.png")
]

==== Network & internet
#align(center)[
  #image("res/network.png")
]

==== Personalization
#align(center)[
  #image("res/personalization.png")
]

==== Apps
#align(center)[
  #image("res/apps.png")
]

==== Accounts
#align(center)[
  #image("res/accounts_1.png")
]

#align(center)[
  #image("res/accounts_2.png")
]

==== Time & language
#align(center)[
  #image("res/time.png")
]

==== Accessibility
#align(center)[
  #image("res/accessibility_1.png")
]

#align(center)[
  #image("res/accessibility_2.png")
]

==== Privacy & Security
#align(center)[
  #image("res/privacy_1.png")
]

#align(center)[
  #image("res/privacy_2.png")
]

#align(center)[
  #image("res/privacy_3.png")
]

=== Filipino

==== Home
#align(center)[
  #image("res/ph_home.png")
]

==== System
#align(center)[
  #image("res/ph_system_1.png")
]

#align(center)[
  #image("res/ph_system_2.png")
]

==== Network & internet
#align(center)[
  #image("res/ph_network.png")
]

==== Personalization
#align(center)[
  #image("res/ph_personalization.png")
]

==== Apps
#align(center)[
  #image("res/ph_apps.png")
]

==== Accounts
#align(center)[
  #image("res/ph_accounts_1.png")
]

#align(center)[
  #image("res/ph_accounts_2.png")
]

==== Time & language
#align(center)[
  #image("res/ph_time.png")
]

==== Accessibility
#align(center)[
  #image("res/ph_accessibility_1.png")
]

#align(center)[
  #image("res/ph_accessibility_2.png")
]

==== Privacy & Security
#align(center)[
  #image("res/ph_privacy_1.png")
]

#align(center)[
  #image("res/ph_privacy_2.png")
]

#align(center)[
  #image("res/ph_privacy_3.png")
]

== Source Code
=== ImageLoader.cs
#let image_loader = read("../ImageLoader.cs")
#raw(image_loader, block: true, lang: "cs")

=== Form1.Designer.cs
#let form1_Designer = read("../Form1.Designer.cs")
#raw(form1_Designer, block: true, lang: "cs")

=== ResourceManager.cs
#let resource_manager = read("../ResourceManager.cs")
#raw(resource_manager, block: true, lang: "cs")

=== Models.cs
#let models = read("../Models.cs")
#raw(models, block: true, lang: "cs")

=== Components.cs
#let components = read("../Components.cs")
#raw(components, block: true, lang: "cs")

=== Form1.cs
#let form1 = read("../Form1.cs")
#raw(form1, block: true, lang: "cs")

=== Program.cs
#let program = read("../Program.cs")
#raw(program, block: true, lang: "cs")

=== Form1.resx
#let form1_resx = read("../Form1.resx")
#raw(form1_resx, block: true, lang: "xml")

=== Form1.fil-PH.resx
#let form1_fil-ph = read("../Form1.fil-PH.resx")
#raw(form1_fil-ph, block: true, lang: "xml")

=== Makefile
#let makefile = read("../Makefile")
#raw(makefile, block: true, lang: "make")
