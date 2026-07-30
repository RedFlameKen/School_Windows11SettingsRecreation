namespace finals;

using System.ComponentModel;

static class Theme {
    public static readonly Color BG_COLOR = Color.FromArgb(0xFF, 0xFF, 0xFF);
    public static readonly Color BG2_COLOR = Color.FromArgb(0xEF, 0xF4, 0xF9);      // #EFF4F9
    public static readonly Color ACTIVE_COLOR = Color.FromArgb(0xE3, 0xE8, 0xEC);   // #E3E8EC
    public static readonly Color HOVER_COLOR = Color.FromArgb(0xF4, 0xF8, 0xFB);    // #F4F8FB
    public static readonly Color ACCENT_COLOR = Color.FromArgb(0x0B, 0x71, 0xC1);   // #0B71C1
    public static readonly Color FORE_MAIN_COLOR = Color.FromArgb(0x19, 0x1A, 0x1A);// #191A1A
    public static readonly Color FORE_SUB_COLOR = Color.FromArgb(0x9D, 0x9E, 0x9F);// #9D9E9F
}


class FocusableControl : UserControl {

    protected bool focusable;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public Action<bool> onActive {get; set;}

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public Action<bool> onHover {get; set;}

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public Action updateHover {get; set;}

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public Action actionEvent {get; set;}

    protected Color _backColor = Color.Transparent;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public Color backColor {
        get => _backColor; 
        set {
            BackColor = value;
            _backColor = value;
        }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public Color hoverColor {get; set;} = Theme.HOVER_COLOR;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public Color activeColor {get; set;} = Theme.ACTIVE_COLOR;

    public FocusableControl(bool focusable=true){
        this.focusable=focusable;
        BackColor = backColor;
        SetStyle(ControlStyles.Selectable, focusable);
        TabStop = focusable;

        actionEvent = () => {};

        onActive = (active) => {
            BackColor = active ? activeColor : backColor;
        };

        onHover = (hovered) => {
            BackColor = hovered ? hoverColor : backColor;
            // BackColor = Color.FromArgb(0xFF, 0xF3, 0xF3, 0xF3);
            Cursor    = hovered ? Cursors.Hand : Cursors.Default;
        };

        updateHover = () => {
            bool hovered = ClientRectangle.Contains(PointToClient(Cursor.Position));
            onHover(hovered);
        };

    }

    protected override void OnKeyDown(KeyEventArgs e){
        base.OnKeyDown(e);

        if (!focusable) {
            return;
        }

        if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space) {
            onActive(true);
        }

    }

    protected override void OnKeyUp(KeyEventArgs e){
        base.OnKeyUp(e);

        if (!focusable) {
            return;
        }

        if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space) {
            onActive(false);
            actionEvent();
        }

    }

    protected override void OnMouseEnter(EventArgs e){
        base.OnMouseEnter(e);
        if (!focusable) {
            return;
        }

        updateHover();
    }

    protected override void OnMouseLeave(EventArgs e){
        base.OnMouseLeave(e);
        if (!focusable) {
            return;
        }

        onHover(false);
    }

    protected override void OnGotFocus(EventArgs e){
        base.OnGotFocus(e);
        if (!focusable) {
            return;
        }

        onHover(true);
    }

    protected override void OnLostFocus(EventArgs e){
        base.OnLostFocus(e);
        if (!focusable) {
            return;
        }

        onHover(false);
    }

    protected override void OnMouseMove(MouseEventArgs e){
        base.OnMouseMove(e);
        if (!focusable) {
            return;
        }

        updateHover();
    }

    protected override void OnMouseUp(MouseEventArgs e){
        base.OnMouseUp(e);
        if (!focusable) {
            return;
        }

        onActive(false);
        bool hovered = ClientRectangle.Contains(PointToClient(Cursor.Position));
        if (hovered) actionEvent();
    }

    protected override void OnMouseDown(MouseEventArgs e){
        base.OnMouseDown(e);
        if (!focusable) {
            return;
        }

        onActive(true);
    }

    protected void forwardFocus(Control c){
        c.TabStop = false;

        c.MouseEnter += (o, e) => updateHover();
        c.MouseMove += (o, e) => updateHover();
        c.MouseLeave += (o, e) => onHover(false);

        c.MouseDown  += (_, e) => onActive(true);
        c.MouseUp    += (_, e) => {
            onActive(false);
            bool hovered = ClientRectangle.Contains(PointToClient(Cursor.Position));
            if (hovered) actionEvent();
        };

        foreach (Control child in c.Controls)
        {
            forwardFocus(child);
        }

    }

}

public class SearchBar : UserControl
{
    private PictureBox searchIcon;
    private TextBox input;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public string SearchText
    {
        get => input.Text;
        set => input.Text = value;
    }

    public SearchBar()
    {
        BackColor = Theme.BG_COLOR;
        BorderStyle = BorderStyle.FixedSingle;
        AutoSize = true;
        Margin = new Padding(3);


        TableLayoutPanel wrap = new TableLayoutPanel(){
            ColumnCount = 2,
            RowCount = 1,
            Dock = DockStyle.Fill,
            AutoSize = true
        };

        wrap.ColumnStyles.Clear();
        wrap.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
        wrap.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
        wrap.RowStyles.Add(new RowStyle(SizeType.AutoSize));

        searchIcon = new PictureBox(){
            SizeMode = PictureBoxSizeMode.AutoSize,
            Dock = DockStyle.Fill,
            Image = ImageLoader.loadImage("search.png"),
        };

        input = new TextBox() {
            PlaceholderText = ResourceManager.getString("search_placeholder"),
            Dock = DockStyle.Bottom,
            BackColor = Theme.BG_COLOR,
            BorderStyle = BorderStyle.None,
            TextAlign = HorizontalAlignment.Left,
        };

        wrap.Controls.Add(searchIcon);
        wrap.Controls.Add(input);

        Controls.Add(wrap);
    }

}


class IconButton : FocusableControl {

    private PictureBox pictureBox;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public Image? Icon {
        get => pictureBox.Image;
        set {
            pictureBox.Image = value;
        }
    }

    public IconButton(){
        BackColor = Color.Transparent;
        AutoSize = true;
        AutoSizeMode = AutoSizeMode.GrowAndShrink;
        Padding = new Padding(2);

        pictureBox = new PictureBox(){
            SizeMode = PictureBoxSizeMode.AutoSize,
            Dock = DockStyle.Fill,
        };

        forwardFocus(pictureBox);

        Controls.Add(pictureBox);
    }

}

class NavFocusBar : Panel {

    private TableLayoutPanel root;
    private Panel highlight;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public Color HighlightColor {
        get => highlight.BackColor;
        set {
            highlight.BackColor = value;
        }
    }

    public NavFocusBar(){
        AutoSize = true;

        root = new TableLayoutPanel(){
            ColumnCount = 1,
            RowCount = 3,
            Dock = DockStyle.Fill,
            AutoSize = true,
        };

        root.RowStyles.Clear();
        root.ColumnStyles.Clear();

        root.RowStyles.Add(new RowStyle(SizeType.Percent, 0.1f));
        root.RowStyles.Add(new RowStyle(SizeType.Percent, 0.8f));
        root.RowStyles.Add(new RowStyle(SizeType.Percent, 0.1f));

        highlight = new Panel(){
            BackColor = Color.Transparent,
            AutoSize = true,
            Dock = DockStyle.Fill,
        };

        root.Controls.Add(highlight, 0, 1);

        Controls.Add(root);

    }
}

class NavButton : FocusableControl {

    private TableLayoutPanel row;
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public NavFocusBar focusBar {get; set;}

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public Color HighlightColor {
        get => focusBar.HighlightColor;
        set {
            focusBar.HighlightColor = value;
        }
    }

    private bool _isActive = false;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public bool IsActive {
        get => _isActive;
        set {
            focusBar.HighlightColor = value ? Theme.ACCENT_COLOR : Color.Transparent;
            row.BackColor = value ? Theme.ACTIVE_COLOR : Color.Transparent;
            _isActive = value;
        }
    }

    public NavButton(NavMenuDetails navItem, bool focusable=true) : base(focusable){
        Name = "Nav Button";
        row = new TableLayoutPanel(){
            ColumnCount = 2,
            RowCount = 1,
            Dock = DockStyle.Top,
            AutoSize = true,
        };

        row.ColumnStyles.Clear();

        row.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 14));
        row.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));

        focusBar = new NavFocusBar(){
            Dock = DockStyle.Fill
        };

        ImageButton nb = new ImageButton(false){
            Icon = ImageLoader.loadImage((navItem.icon == null ? "more.png" :
                        navItem.icon)),
            Label = ResourceManager.getString(navItem.id),
            Dock = DockStyle.Top,
            onActive = this.onActive,
            onHover = this.onHover,
            updateHover = this.updateHover,
        };


        row.Controls.Add(focusBar);
        row.Controls.Add(nb);

        forwardFocus(focusBar);
        forwardFocus(nb);

        Controls.Add(row);
    }

}

class NavBar : TableLayoutPanel {

    private Dictionary<int, NavButton> navButtons;

    private int _activeItem = 0;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public int ActiveItem {
        get => _activeItem;
        set {
            setNavItemActive(_activeItem, false);
            _activeItem = value;
            setNavItemActive(value, true);
        }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public Action<int>? onNavChange {get; set;}

    public NavBar(List<NavMenuDetails> navItems, int curNav){
        _activeItem = curNav;
        navButtons = new Dictionary<int, NavButton>();
        
        ColumnCount = 1;
        RowCount = navItems.Count();

        RowStyles.Clear();

        float rowHeightRatio = 1f/navItems.Count();
        for (int i = 0; i < navItems.Count(); i++)
        {
            int pos = i;
            RowStyles.Add(new RowStyle(SizeType.Percent, rowHeightRatio));

            NavButton navButton = new NavButton(navItems[pos]){
                Dock = DockStyle.Top,
                AutoSize = true,
                actionEvent = () => {
                    ActiveItem = pos;
                }
            };

            navButton.Click += (_, _) => {
                ActiveItem = pos;
            };

            navButtons.Add(pos, navButton);

            Controls.Add(navButton);
        }

        setNavItemActive(curNav, true);
    }

    private void setNavItemActive(int item, bool active){
        var bar = navButtons[item];
        if (bar == null) {
            return;
        }
        bar.IsActive = active;
        if (onNavChange != null) onNavChange(item);
    }

}

class ImageButton : FocusableControl
{

    private Label nameLabel;
    private PictureBox pictureBox;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public Image? Icon {
        get => pictureBox.Image;
        set {
            pictureBox.Image = value;
        }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public string Label {
        get => nameLabel.Text;
        set {
            nameLabel.Text = value;
        }
    }

    public ImageButton(bool focusable=true) : base(focusable) {
        AutoSize = true;
        AutoSizeMode = AutoSizeMode.GrowAndShrink;
        Padding = new Padding(2);

        TableLayoutPanel wrap = new TableLayoutPanel(){
            ColumnCount = 2,
            Dock = DockStyle.Fill,
            AutoSize = true,
            AutoSizeMode = AutoSizeMode.GrowAndShrink
        };
        BackColor = Color.Transparent;
        Cursor = Cursors.Hand;

        wrap.ColumnStyles.Clear();
        wrap.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
        wrap.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));

        pictureBox = new PictureBox() {
            SizeMode = PictureBoxSizeMode.AutoSize,
            Anchor = (AnchorStyles.Left),
        };

        nameLabel = new Label() {
            Font = new Font("Segoe UI Variable", 11),
            AutoSize = true,
            Anchor = (AnchorStyles.Left),
            ForeColor = Theme.FORE_MAIN_COLOR,
        };

        wrap.Controls.Add(pictureBox);
        wrap.Controls.Add(nameLabel);

        Controls.Add(wrap);

        if (!focusable) {
            return;
        }

        forwardFocus(wrap);
        forwardFocus(pictureBox);
        forwardFocus(nameLabel);

    }

}

class ImageButtonSubtitled : FocusableControl
{

    private Label titleLabel;
    private Label subtitleLabel;
    private PictureBox pictureBox;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public Image? Icon {
        get => pictureBox.Image;
        set {
            pictureBox.Image = value;
        }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public string Title {
        get => titleLabel.Text;
        set {
            titleLabel.Text = value;
        }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public string Subtitle {
        get => subtitleLabel.Text;
        set {
            subtitleLabel.Text = value;
        }
    }

    public ImageButtonSubtitled(bool focusable=true) : base(focusable) {
        AutoSize = true;
        AutoSizeMode = AutoSizeMode.GrowAndShrink;
        Padding = new Padding(2);

        TableLayoutPanel wrap = new TableLayoutPanel(){
            ColumnCount = 2,
            Dock = DockStyle.Fill,
            AutoSize = true,
            AutoSizeMode = AutoSizeMode.GrowAndShrink
        };

        wrap.ColumnStyles.Clear();
        wrap.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
        wrap.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));

        pictureBox = new PictureBox() {
            SizeMode = PictureBoxSizeMode.AutoSize,
            Anchor = (AnchorStyles.Top | AnchorStyles.Left),
        };

        var textWrap = new TableLayoutPanel(){
            RowCount = 2,
            Dock = DockStyle.Fill,
            // AutoSize = true,
            // AutoSizeMode = AutoSizeMode.GrowAndShrink
        };

        textWrap.ColumnStyles.Clear();
        textWrap.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
        textWrap.RowStyles.Clear();
        textWrap.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        textWrap.RowStyles.Add(new RowStyle(SizeType.AutoSize));

        titleLabel = new Label() {
            Font = new Font("Segoe UI Variable", 11),
            AutoSize = true,
            Dock = DockStyle.Fill,
            Anchor = (AnchorStyles.Left | AnchorStyles.Bottom),
            ForeColor = Theme.FORE_MAIN_COLOR,
        };

        subtitleLabel = new Label() {
            Font = new Font("Segoe UI Variable", 11),
            // AutoSize = true,
            // Anchor = (AnchorStyles.Left),
            Dock = DockStyle.Fill,
            ForeColor = Theme.FORE_SUB_COLOR,
        };

        textWrap.Controls.Add(titleLabel);
        textWrap.Controls.Add(subtitleLabel);

        wrap.Controls.Add(pictureBox);
        wrap.Controls.Add(textWrap);

        Controls.Add(wrap);

        if (!focusable) {
            return;
        }

        forwardFocus(wrap);
        forwardFocus(pictureBox);
        forwardFocus(titleLabel);

    }

}

class Dashboard : UserControl {

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public Action<int>? onNavChange {get; set;}

    public Dashboard(List<NavMenuDetails> navItems){
        var wrap = new TableLayoutPanel(){
            Dock = DockStyle.Fill,
            ColumnCount = 3,
            RowCount = 3
        };

        wrap.RowStyles.Clear();
        wrap.ColumnStyles.Clear();

        wrap.RowStyles.Add(new RowStyle(SizeType.Percent, 1f/3f));
        wrap.RowStyles.Add(new RowStyle(SizeType.Percent, 1f/3f));
        wrap.RowStyles.Add(new RowStyle(SizeType.Percent, 1f/3f));

        wrap.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1f/3f));
        wrap.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1f/3f));
        wrap.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1f/3f));

        for (int i = 0; i < navItems.Count(); i++)
        {
            int pos = i;
            var navItem = navItems[pos];
            if (navItem.id == "home") {
                continue;
            }
            var imageButton = new ImageButtonSubtitled(){
                Title = ResourceManager.getString(navItem.id),
                Subtitle = ResourceManager.getString($"{navItem.id}.subtitle"),
                Icon = ImageLoader.loadImage(navItem.icon!),
                AutoSize = true,
                actionEvent = () => {
                    Console.WriteLine($"clicky clicky bitch onNavChange is null: {onNavChange == null}");
                    if (onNavChange != null)
                        onNavChange(pos);
                }
            };

            wrap.Controls.Add(imageButton);
        }

        Controls.Add(wrap);
    }

}

class SectionPanel : UserControl {

    private Label titleLabel;
    private Label subtitleLabel;
    private TableLayoutPanel buttonsColumn;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public string Title {
        get => titleLabel.Text;
        set {
            titleLabel.Text = value;
        }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public string Subtitle {
        get => subtitleLabel.Text;
        set {
            subtitleLabel.Text = value;
        }
    }

    public SectionPanel(List<ButtonDetails>? buttons){
        int buttonCount = (buttons == null ? 0 : buttons.Count());
        Margin = new Padding(10);
        BackColor = Theme.BG_COLOR;
        AutoSize = true;

        var headerPanel = new FlowLayoutPanel(){
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.TopDown,
            WrapContents = false,
            Padding = new Padding(
                top: 24,
                bottom: 0,
                left: 5,
                right: 5
            ),
        };

        titleLabel = new Label(){
            Font = new Font("Segoe UI Variable", 14, FontStyle.Bold),
            AutoSize = true,
            Anchor = (AnchorStyles.Left | AnchorStyles.Right),
            TextAlign = ContentAlignment.MiddleLeft,
            ForeColor = Theme.FORE_MAIN_COLOR,
        };

        subtitleLabel = new Label(){
            Font = new Font("Segoe UI Variable", 11),
            AutoSize = true,
            ForeColor = Theme.FORE_SUB_COLOR,
            Anchor = (AnchorStyles.Left | AnchorStyles.Right),
            TextAlign = ContentAlignment.MiddleLeft,
        };

        headerPanel.Controls.Add(titleLabel);
        headerPanel.Controls.Add(subtitleLabel);

        buttonsColumn = new TableLayoutPanel(){
            ColumnCount = 1,
            RowCount = buttonCount,
            AutoSize = true,
            Dock = DockStyle.Fill,
        };

        buttonsColumn.ColumnStyles.Clear();
        buttonsColumn.RowStyles.Clear();

        buttonsColumn.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));

        if (buttons != null)
            for (int i = 0; i < buttonCount; i++)
            {
                int pos = i;
                buttonsColumn.RowStyles.Add(new RowStyle(SizeType.AutoSize));

                RouteButton routeButton = new RouteButton(){
                    Icon = ImageLoader.loadImage(buttons[pos].icon),
                    Label = ResourceManager.getString($"{buttons[pos].id}"),
                    Dock = DockStyle.Fill,
                };

                buttonsColumn.Controls.Add(routeButton);

            }

        TableLayoutPanel wrap = new TableLayoutPanel(){
            ColumnCount = 1,
            RowCount = 2,
            Dock = DockStyle.Fill,
            AutoSize = true,
        };

        wrap.RowStyles.Clear();

        wrap.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        wrap.RowStyles.Add(new RowStyle(SizeType.AutoSize));

        wrap.Controls.Add(headerPanel);
        wrap.Controls.Add(buttonsColumn);

        Controls.Add(wrap);
    }

}

class DevicesPanel : UserControl {

    private Label titleLabel;
    private Label subtitleLabel;
    private TableLayoutPanel buttonsColumn;


    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public string Title {
        get => titleLabel.Text;
        set {
            titleLabel.Text = value;
        }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public string Subtitle {
        get => subtitleLabel.Text;
        set {
            subtitleLabel.Text = value;
        }
    }

    public DevicesPanel(List<DeviceDetails>? buttons){
        int buttonCount = 2 + (buttons == null ? 0 : buttons.Count());
        Margin = new Padding(10);
        BackColor = Theme.BG_COLOR;
        AutoSize = true;

        var headerPanel = new FlowLayoutPanel(){
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.TopDown,
            WrapContents = false,
            Padding = new Padding(
                top: 24,
                bottom: 0,
                left: 5,
                right: 5
            ),
        };

        titleLabel = new Label(){
            Font = new Font("Segoe UI Variable", 14, FontStyle.Bold),
            AutoSize = true,
            Anchor = (AnchorStyles.Left | AnchorStyles.Right),
            TextAlign = ContentAlignment.MiddleLeft,
            ForeColor = Theme.FORE_MAIN_COLOR,
        };

        subtitleLabel = new Label(){
            Font = new Font("Segoe UI Variable", 11),
            AutoSize = true,
            Anchor = (AnchorStyles.Left | AnchorStyles.Right),
            TextAlign = ContentAlignment.MiddleLeft,
            ForeColor = Theme.FORE_SUB_COLOR,
        };

        headerPanel.Controls.Add(titleLabel);
        headerPanel.Controls.Add(subtitleLabel);

        buttonsColumn = new TableLayoutPanel(){
            ColumnCount = 1,
            RowCount = buttonCount,
            AutoSize = true,
            Dock = DockStyle.Fill,
        };

        buttonsColumn.ColumnStyles.Clear();
        buttonsColumn.RowStyles.Clear();

        buttonsColumn.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));

        buttonsColumn.RowStyles.Add(new RowStyle(SizeType.AutoSize));


        if (buttons != null)
            for (int i = 0; i < buttonCount - 2; i++)
            {
                int pos = i;
                buttonsColumn.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                string icon = buttons[pos].icon;
                string label = buttons[pos].name;

                DeviceRow deviceRow = new DeviceRow(){
                    Icon = ImageLoader.loadImage(icon),
                    Label = label,
                    Dock = DockStyle.Fill,
                };

                buttonsColumn.Controls.Add(deviceRow);

            }

        TableLayoutPanel wrap = new TableLayoutPanel(){
            ColumnCount = 1,
            RowCount = 2,
            Dock = DockStyle.Fill,
            AutoSize = true,
        };

        wrap.RowStyles.Clear();

        wrap.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        wrap.RowStyles.Add(new RowStyle(SizeType.AutoSize));

        wrap.Controls.Add(headerPanel);
        wrap.Controls.Add(buttonsColumn);

        Controls.Add(wrap);
    }

}

class TextButton : FocusableControl {

    private Label label;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public string? Label {
        get => label.Text;
        set {
            label.Text = value;
        }
    }

    public TextButton(){
        backColor = Theme.BG2_COLOR;
        AutoSize = true;
        AutoSizeMode = AutoSizeMode.GrowAndShrink;
        Padding = new Padding(2);

        label = new Label(){
            AutoSize = true,
            Dock = DockStyle.Fill,
            ForeColor = Theme.FORE_MAIN_COLOR,
        };

        forwardFocus(label);

        Controls.Add(label);
    }


}

class DeviceRow : UserControl {

    private Label nameLabel;
    private Label connectedLabel;
    private PictureBox pictureBox;
    private IconButton moreBox;
    private TextButton connectButton;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public Image? Icon {
        get => pictureBox.Image;
        set {
            pictureBox.Image = value;
        }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public string Label {
        get => nameLabel.Text;
        set {
            nameLabel.Text = value;
        }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public bool connected {get; set;} = false;

    public DeviceRow() {
        AutoSize = true;
        AutoSizeMode = AutoSizeMode.GrowAndShrink;
        Padding = new Padding(2);

        TableLayoutPanel wrap = new TableLayoutPanel(){
            ColumnCount = 4,
            Dock = DockStyle.Fill,
            AutoSize = true,
            AutoSizeMode = AutoSizeMode.GrowAndShrink
        };
        BackColor = Color.Transparent;

        wrap.ColumnStyles.Clear();
        wrap.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
        wrap.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
        wrap.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
        wrap.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));

        pictureBox = new PictureBox() {
            SizeMode = PictureBoxSizeMode.AutoSize,
            Anchor = (AnchorStyles.Left),
        };

        var namePanel = new FlowLayoutPanel(){
            AutoSize = true,
            Anchor = (AnchorStyles.Left),
            FlowDirection = FlowDirection.TopDown,
            WrapContents = false,
        };

        nameLabel = new Label() {
            Font = new Font("Segoe UI Variable", 11),
            AutoSize = true,
            ForeColor = Theme.FORE_MAIN_COLOR,
        };

        connectedLabel = new Label(){
            Font = new Font("Segoe UI Variable", 11),
            Text = (connected ? 
                ResourceManager.getString("connected") : 
                ResourceManager.getString("not_connected")
            ),
            AutoSize = true,
            ForeColor = Theme.FORE_SUB_COLOR,
        };

        namePanel.Controls.Add(nameLabel);
        namePanel.Controls.Add(connectedLabel);

        connectButton = new TextButton(){
            Label = "Connect",
            AutoSize = true,
            Anchor = (AnchorStyles.Right),
        };

        moreBox = new IconButton(){
            Icon = ImageLoader.loadImage("more.png"),
            AutoSize = true,
            Anchor = (AnchorStyles.Right),
        };

        wrap.Controls.Add(pictureBox, 0, 0);
        wrap.Controls.Add(moreBox, 3, 0);
        wrap.Controls.Add(connectButton, 2, 0);
        wrap.Controls.Add(namePanel, 1, 0);

        Controls.Add(wrap);

    }

}

class RouteButton : FocusableControl {

    private Label nameLabel;
    private PictureBox pictureBox;
    private PictureBox chevronBox;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public Image? Icon {
        get => pictureBox.Image;
        set {
            pictureBox.Image = value;
        }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public string Label {
        get => nameLabel.Text;
        set {
            nameLabel.Text = value;
        }
    }

    public RouteButton(bool focusable=true) : base(focusable){
        AutoSize = true;
        AutoSizeMode = AutoSizeMode.GrowAndShrink;
        Padding = new Padding(2);

        TableLayoutPanel wrap = new TableLayoutPanel(){
            ColumnCount = 3,
            Dock = DockStyle.Fill,
            AutoSize = true,
            AutoSizeMode = AutoSizeMode.GrowAndShrink
        };
        BackColor = Color.Transparent;
        Cursor = Cursors.Hand;

        wrap.ColumnStyles.Clear();
        wrap.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
        wrap.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
        wrap.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));

        pictureBox = new PictureBox() {
            SizeMode = PictureBoxSizeMode.AutoSize,
            Anchor = (AnchorStyles.Left),
        };

        nameLabel = new Label() {
            Font = new Font("Segoe UI Variable", 11),
            AutoSize = true,
            Anchor = (AnchorStyles.Left),
            ForeColor = Theme.FORE_MAIN_COLOR,
        };

        chevronBox = new PictureBox() {
            SizeMode = PictureBoxSizeMode.AutoSize,
            Anchor = (AnchorStyles.Right),
            Image = ImageLoader.loadImage("chevron_right.png"),
        };

        wrap.Controls.Add(pictureBox, 0, 0);
        wrap.Controls.Add(chevronBox, 2, 0);
        wrap.Controls.Add(nameLabel, 1, 0);

        Controls.Add(wrap);

        if (!focusable) {
            return;
        }

        forwardFocus(wrap);
        forwardFocus(pictureBox);
        forwardFocus(nameLabel);
        forwardFocus(chevronBox);

    }

}

class RouteButtonSubtitled : FocusableControl {

    private Label titleLabel;
    private Label subtitleLabel;
    private PictureBox pictureBox;
    private PictureBox chevronBox;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public Image? Icon {
        get => pictureBox.Image;
        set {
            pictureBox.Image = value;
        }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public string Title {
        get => titleLabel.Text;
        set {
            titleLabel.Text = value;
        }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public string Subtitle {
        get => subtitleLabel.Text;
        set {
            subtitleLabel.Text = value;
        }
    }

    public RouteButtonSubtitled(bool focusable=true) : base(focusable){
        AutoSize = true;
        AutoSizeMode = AutoSizeMode.GrowAndShrink;
        Padding = new Padding(2);
        Margin = new Padding(2);

        TableLayoutPanel wrap = new TableLayoutPanel(){
            ColumnCount = 3,
            Dock = DockStyle.Fill,
            AutoSize = true,
            AutoSizeMode = AutoSizeMode.GrowAndShrink
        };

        wrap.ColumnStyles.Clear();
        wrap.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
        wrap.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
        wrap.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));

        pictureBox = new PictureBox() {
            SizeMode = PictureBoxSizeMode.AutoSize,
            Anchor = (AnchorStyles.Left),
        };

        var titlePanel = new TableLayoutPanel(){
            AutoSize = true,
            Dock = DockStyle.Fill,
            ColumnCount = 1,
            RowCount = 2,
            // Anchor = (AnchorStyles.Left | AnchorStyles.Right),
        };

        titlePanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        titlePanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        titlePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));

        titleLabel = new Label() {
            Font = new Font("Segoe UI Variable", 11),
            AutoSize = true,
            Anchor = (AnchorStyles.Left | AnchorStyles.Right),
            ForeColor = Theme.FORE_MAIN_COLOR,
        };

        subtitleLabel = new Label(){
            Font = new Font("Segoe UI Variable", 11),
            // AutoSize = false,
            AutoEllipsis = true,
            Anchor = (AnchorStyles.Left | AnchorStyles.Right),
            ForeColor = Theme.FORE_SUB_COLOR,
        };

        titlePanel.Controls.Add(titleLabel);
        titlePanel.Controls.Add(subtitleLabel);

        chevronBox = new PictureBox() {
            SizeMode = PictureBoxSizeMode.AutoSize,
            Anchor = (AnchorStyles.Right),
            Image = ImageLoader.loadImage("chevron_right.png"),
        };

        wrap.Controls.Add(pictureBox, 0, 0);
        wrap.Controls.Add(chevronBox, 2, 0);
        wrap.Controls.Add(titlePanel, 1, 0);

        Controls.Add(wrap);

        if (!focusable) {
            return;
        }

        forwardFocus(wrap);
        forwardFocus(pictureBox);
        forwardFocus(titleLabel);
        forwardFocus(chevronBox);

    }

}

class ButtonListPanel : UserControl {

    private TableLayoutPanel column;

    public ButtonListPanel(ButtonListDetails details, string parentId){
        AutoSize = true;
        int titleOffset = (details.hasTitle ? 1 : 0);
        int rowCount = titleOffset + 
            (details.buttons == null ? 0 : details.buttons.Count());

        column = new TableLayoutPanel(){
            ColumnCount = 1,
            RowCount = rowCount,
            AutoSize = true,
            Dock = DockStyle.Fill,
        };

        if (details.hasTitle){
            Label titleLabel = new Label(){
                Font = new Font("Segoe UI Variable", 11, FontStyle.Bold),
                AutoSize = true,
                Anchor = AnchorStyles.Left,
                Text = ResourceManager.getString($"{parentId}.{details.id}"),
                ForeColor = Theme.FORE_MAIN_COLOR,
            };

            column.Controls.Add(titleLabel);
        }

        if (details.buttons != null)
            for (int i = 0; i < rowCount - titleOffset; i++)
            {
                int pos = i;

                if (details.buttons[pos].hasSubtitle) {
                    var subbedRb = new RouteButtonSubtitled(){
                        Icon = ImageLoader.loadImage(details.buttons[pos].icon),
                        Title = ResourceManager.getString(
                                $"{parentId}.{details.id}.{details.buttons[pos].id}.title"
                                ),
                        Subtitle = ResourceManager.getString(
                                $"{parentId}.{details.id}.{details.buttons[pos].id}.subtitle"
                                ),
                        Dock = DockStyle.Fill,
                        backColor = Theme.BG_COLOR,
                    };

                    column.Controls.Add(subbedRb);
                    continue;
                } 
                var routeButton = new RouteButton(){
                    Icon = ImageLoader.loadImage(details.buttons[pos].icon),
                    Label = ResourceManager.getString(
                            $"{parentId}.{details.id}.{details.buttons[pos].id}.title"
                            ),
                    Dock = DockStyle.Fill,
                    backColor = Theme.BG_COLOR,
                };

                column.Controls.Add(routeButton);
            }

        Controls.Add(column);
    }
}


class SettingMenu : UserControl
{

    private Label nameLabel;

    private TableLayoutPanel compColumn;
    private NavMenuDetails details;
    private List<NavMenuDetails> detailList;
    private NavBar navBar;

    public SettingMenu(List<NavMenuDetails> detailList, int item, NavBar navBar) {
        this.navBar = navBar;
        this.detailList = detailList;
        this.details = detailList[item];

        int rowCount = 1 + (details.items == null ? 0 : details.items.Count());

        DockStyle dock = DockStyle.Top;
        bool autoSize = true;
        if (item == 0) {
            autoSize = false;
            dock = DockStyle.Fill;
        } 


        nameLabel = new Label(){
            Text = ResourceManager.getString(details.id),
            Font = new Font("Segoe UI Variable", 18),
            AutoSize = true,
            ForeColor = Theme.FORE_MAIN_COLOR,
        };

        compColumn = new TableLayoutPanel(){
            RowCount = rowCount,
            ColumnCount = 1,
            Dock = dock,
            AutoSize = autoSize,
        };

        compColumn.Controls.Add(nameLabel);

        if (details.items != null)
            for (int i = 0; i < rowCount - 1; i++)
            {
                compColumn.Controls.Add(createMenuControl(details.items![i]));
            }

        Controls.Add(compColumn);

    }

    private Control createMenuControl(SettingComponent component){
        switch (component.getType())
        {
            case SettingComponentType.SECTION:
                return createSectionComponent(component as SectionDetails);
            case SettingComponentType.DEVICES_SECTION:
                return createDevicesSectionComponent(component as DevicesSectionDetails);
            case SettingComponentType.BUTTON_LIST:
                return createButtonListComponent(component as ButtonListDetails);
            case SettingComponentType.DASHBOARD:
                return createDashboardComponent(component as DashboardDetails);
            default:
                return new Panel(){
                    Dock = DockStyle.Fill,
                };
        }
    }

    private Control createSectionComponent(SectionDetails? details){
        if (details == null) 
            return new Panel(){
                Dock = DockStyle.Fill,
            };
        return new SectionPanel(details.buttons){
            Title = ResourceManager.getString($"{this.details.id}.{details.id}.title"),
            Subtitle = ResourceManager.getString($"{this.details.id}.{details.id}.subtitle"),
            Dock = DockStyle.Fill,
        };
    }
    
    private Control createDevicesSectionComponent(DevicesSectionDetails? details){
        if (details == null)
            return new Panel(){
                Dock = DockStyle.Fill,
            };
        return new DevicesPanel(details.buttons){
            Title = ResourceManager.getString($"{this.details.id}.{details.id}.title"),
            Subtitle = ResourceManager.getString($"{this.details.id}.{details.id}.subtitle"),
            Dock = DockStyle.Fill,
        };
    }
    
    private Control createButtonListComponent(ButtonListDetails? details){
        if (details == null) 
            return new Panel(){
                Dock = DockStyle.Fill,
            };
        return new ButtonListPanel(details, this.details.id){
            Dock = DockStyle.Fill,
        };
    }

    private Control createDashboardComponent(DashboardDetails? details){
        if (details == null) 
            return new Panel(){
                Dock = DockStyle.Fill,
            };
        return new Dashboard(detailList){
            Dock = DockStyle.Fill,
            onNavChange = (i) => {
                navBar.ActiveItem = i;
            },
        };
    }

}

