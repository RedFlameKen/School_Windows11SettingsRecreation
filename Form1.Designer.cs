namespace finals;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponentSelfManaged(){
        IconButton backButton = new IconButton(){
            Icon = ImageLoader.loadImage("arrow_left.svg"),
            Anchor = AnchorStyles.None
        };

        Label windowTitle = new Label() {
            Text = ResourceManager.getString("setting_label"),
            Anchor = AnchorStyles.None
        };

        TableLayoutPanel topBarLeft = new TableLayoutPanel(){
            Dock = DockStyle.Left,
            ColumnCount = 2,
            RowCount = 1,
            AutoSize = true,
        };

        topBarLeft.ColumnStyles.Clear();

        for (int i = 0; i < topBarLeft.ColumnCount; i++)
        {
            topBarLeft.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
        }

        topBarLeft.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));

        topBarLeft.Controls.Add(backButton);
        topBarLeft.Controls.Add(windowTitle);

        Panel topBarCenter = new Panel(){
            Dock = DockStyle.Fill,
        };

        SearchBar search = new SearchBar() {
            Dock = DockStyle.Fill,
            // Margin = new Padding(20)
        };

        topBarCenter.Controls.Add(search);

        Panel topBarRight = new FlowLayoutPanel(){
            Dock = DockStyle.Right,
            WrapContents = false,
            FlowDirection = FlowDirection.RightToLeft,
        };

        Label languageLabel = new Label(){
            Text = ResourceManager.getString("languageText"),
            TextAlign = ContentAlignment.MiddleRight,
            Anchor = (AnchorStyles.Top | AnchorStyles.Bottom),
            AutoSize = true,
        };

        languageBox = new ComboBox(){
            AutoSize = true,
            Anchor = (AnchorStyles.Top | AnchorStyles.Bottom),
        };


        languageBox.Items.AddRange(new object[] {
            ResourceManager.getString("englishLang"),
            ResourceManager.getString("filipinoLang"),
        });

        languageBox.SelectedIndex = curLang;

        languageBox.SelectedValueChanged += (_, _) => {
            switch (languageBox.SelectedIndex)
            {
                case 1:
                    changeLanguage("fil-PH", 1);
                    break;
                default:
                case 0:
                    changeLanguage("en", 0);
                    break;
            }
        };

        topBarRight.Controls.Add(languageBox);
        topBarRight.Controls.Add(languageLabel);


        topBar = new Panel() {
            Dock = DockStyle.Top,
            Height = 35
        };

        topBar.Controls.Add(topBarCenter);
        topBar.Controls.Add(topBarLeft);
        topBar.Controls.Add(topBarRight);

        navBarPanel = new Panel(){
            Dock = DockStyle.Left,
        };

        Action<int> navChanged = (i) => {
            setSettingMenu(i);
        };

        navBar = new NavBar(nav_items, curNav) {
            Width = 200,
            AutoSize = true,
            Anchor = (AnchorStyles.Top | AnchorStyles.Left),
            onNavChange = navChanged
        };

        navBarPanel.Controls.Add(navBar);

        mainPanel = new Panel(){
            Dock = DockStyle.Fill,
            AutoScroll = true,
        };

        setSettingMenu(curNav);

        Controls.Add(mainPanel);
        Controls.Add(navBarPanel);
        Controls.Add(topBar);

    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Text = "Form1";
        Icon = ImageLoader.loadIcon("app.ico");

        InitializeComponentSelfManaged();
    }

    Panel topBar;
    Panel navBarPanel;
    Panel mainPanel;
    NavBar navBar;
    ComboBox languageBox;

    #endregion
}
