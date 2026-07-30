namespace finals;

using System.ComponentModel;

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

    public FocusableControl(bool focusable=true){
        this.focusable=focusable;
        SetStyle(ControlStyles.Selectable, focusable);
        TabStop = focusable;

        actionEvent = () => {};

        onActive = (active) => {
            BackColor = active ? Color.DimGray : Color.Transparent;
        };

        onHover = (hovered) => {
            BackColor = hovered ? Color.White : Color.Transparent;
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

        // c.MouseEnter += (e, o) => OnMouseEnter();
        // c.MouseMove  += (_, _) => updateHover();
        // c.MouseLeave += (_, _) => updateHover();
        //
        // c.MouseDown  += (_, e) => onActive(true);
        // c.MouseUp    += (_, e) => onActive(false);

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

    // protected void passOverFocus(FocusableControl c){
    //     c.TabStop = false;
    //
    //     c.OnMouseEnter = (_, _) => updateHover();
    //     c.OnMouseMove = (_, _) => updateHover();
    //     c.OnMouseLeave = (_, _) => updateHover();
    //
    //     c.OnGotFocus = (_, _) => onHover(true);
    //     c.OnLostFocus = (_, _) => onHover(false);
    //
    //     c.OnMouseDown = (_, _) => onActive(true);
    //     c.OnMouseUp = (_, _) => onActive(false);
    // }


}

public class SearchBar : UserControl
{
    private TextBox input;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public string SearchText
    {
        get => input.Text;
        set => input.Text = value;
    }

    public SearchBar()
    {

        AutoSize = true;

        input = new TextBox() {
            PlaceholderText = "Find a setting",
            Dock = DockStyle.Fill,

        };

        Controls.Add(input);
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
            focusBar.HighlightColor = value ? Color.DodgerBlue : Color.Transparent;
            row.BackColor = value ? Color.DimGray : Color.Transparent;
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
            Icon = ImageLoader.loadImage((navItem.icon == null ? "more.svg" :
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

    public NavBar(List<NavMenuDetails> navItems){

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

        setNavItemActive(0, true);
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
        BackColor = Color.White;
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
        };

        subtitleLabel = new Label(){
            Font = new Font("Segoe UI Variable", 11),
            AutoSize = true,
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
        BackColor = Color.White;
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
        };

        subtitleLabel = new Label(){
            Font = new Font("Segoe UI Variable", 11),
            AutoSize = true,
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
        BackColor = Color.Transparent;
        AutoSize = true;
        AutoSizeMode = AutoSizeMode.GrowAndShrink;
        Padding = new Padding(2);

        label = new Label(){
            AutoSize = true,
            Dock = DockStyle.Fill,
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
            Font = new Font("Segoe UI Variable", 11, FontStyle.Bold),
            AutoSize = true,
        };

        connectedLabel = new Label(){
            Font = new Font("Segoe UI Variable", 11),
            Text = (connected ? 
                ResourceManager.getString("connected") : 
                ResourceManager.getString("not_connected")
            ),
            AutoSize = true,
        };

        namePanel.Controls.Add(nameLabel);
        namePanel.Controls.Add(connectedLabel);

        connectButton = new TextButton(){
            Label = "Connect",
            AutoSize = true,
            Anchor = (AnchorStyles.Right),
        };

        moreBox = new IconButton(){
            Icon = ImageLoader.loadImage("more.svg"),
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
        };

        chevronBox = new PictureBox() {
            SizeMode = PictureBoxSizeMode.AutoSize,
            Anchor = (AnchorStyles.Right),
            Image = ImageLoader.loadImage("chevron_right.svg"),
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

        var titlePanel = new FlowLayoutPanel(){
            AutoSize = true,
            Anchor = (AnchorStyles.Left),
            FlowDirection = FlowDirection.TopDown,
            WrapContents = false,
        };

        titleLabel = new Label() {
            Font = new Font("Segoe UI Variable", 11, FontStyle.Bold),
            AutoSize = true,
            Anchor = (AnchorStyles.Left),
        };

        subtitleLabel = new Label(){
            Font = new Font("Segoe UI Variable", 11),
            AutoSize = true,
        };

        titlePanel.Controls.Add(titleLabel);
        titlePanel.Controls.Add(subtitleLabel);

        chevronBox = new PictureBox() {
            SizeMode = PictureBoxSizeMode.AutoSize,
            Anchor = (AnchorStyles.Right),
            Image = ImageLoader.loadImage("chevron_right.svg"),
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
            };

            column.Controls.Add(titleLabel);
        }

        if (details.buttons != null)
            for (int i = 0; i < rowCount - titleOffset; i++)
            {
                int pos = i;

                if (details.buttons[pos].hasSubtitile) {
                    var subbedRb = new RouteButtonSubtitled(){
                        Icon = ImageLoader.loadImage(details.buttons[pos].icon),
                        Title = ResourceManager.getString(
                                $"{parentId}.{details.id}.{details.buttons[pos].id}.title"
                                ),
                        Subtitle = ResourceManager.getString(
                                $"{parentId}.{details.id}.{details.buttons[pos].id}.subtitle"
                                ),
                        Dock = DockStyle.Fill,
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
    private NavMenuDetails navDetails;

    public SettingMenu(NavMenuDetails details) {
        this.navDetails = details;

        int rowCount = 1 + (details.items == null ? 0 : details.items.Count());


        nameLabel = new Label(){
            Text = ResourceManager.getString(details.id),
            Font = new Font("Segoe UI Variable", 18),
            AutoSize = true,
        };

        compColumn = new TableLayoutPanel(){
            RowCount = rowCount,
            ColumnCount = 1,
            Dock = DockStyle.Top,
            AutoSize = true,
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
            Title = ResourceManager.getString($"{navDetails.id}.{details.id}.title"),
            Subtitle = ResourceManager.getString($"{navDetails.id}.{details.id}.subtitle"),
            Dock = DockStyle.Fill,
        };
    }
    
    private Control createDevicesSectionComponent(DevicesSectionDetails? details){
        if (details == null)
            return new Panel(){
                Dock = DockStyle.Fill,
            };
        return new DevicesPanel(details.buttons){
            Title = ResourceManager.getString($"{navDetails.id}.{details.id}.title"),
            Subtitle = ResourceManager.getString($"{navDetails.id}.{details.id}.subtitle"),
            Dock = DockStyle.Fill,
        };
    }
    
    private Control createButtonListComponent(ButtonListDetails? details){
        if (details == null) 
            return new Panel(){
                Dock = DockStyle.Fill,
            };
        return new ButtonListPanel(details, navDetails.id){
            Dock = DockStyle.Fill,
        };
    }
}

class HomepageButton : Panel
{
    private Label mainLabel;
    private Label descriptionLabel;

    public HomepageButton(Image icon, string mainText, string descriptionText){
        // Size = new Size(340, 90);
        BackColor = Color.White;
        Cursor = Cursors.Hand;

        PictureBox pictureBox = new PictureBox() {
            Image = icon,
            SizeMode = PictureBoxSizeMode.Zoom,
            Size = new Size(40, 40),
            Location = new Point(16, 25),
        };

        mainLabel = new Label() {
            Text = mainText,
            Font = new Font("Segoe UI Variable", 12, FontStyle.Bold),
            Location = new Point(72, 16),
            AutoSize = true
        };

        descriptionLabel = new Label() {
            Text = descriptionText,
            Font = new Font("Segoe UI Variable", 9),
            ForeColor = Color.Gray,
            MaximumSize = new Size(240, 0),
            AutoSize = true,
            Location = new Point(72, 42),
        };

        Controls.Add(pictureBox);
        Controls.Add(mainLabel);
        Controls.Add(descriptionLabel);

        MouseEnter += (_, _) => BackColor = Color.FromArgb(0xFF, 0xF3, 0xF3, 0xF3);
        MouseLeave += (_, _) => BackColor = Color.White;
    }

}


