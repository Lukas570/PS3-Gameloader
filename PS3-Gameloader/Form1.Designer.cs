partial class MainForm
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.TextBox searchTextBox;
    private System.Windows.Forms.ListBox resultsListBox;
    private System.Windows.Forms.Button downloadButton;
    private System.Windows.Forms.TextBox filePathTextBox;
    private System.Windows.Forms.Button browseButton;
    private System.Windows.Forms.ProgressBar downloadProgressBar;
    private System.Windows.Forms.Label downloadProgressLabel;
    private System.Windows.Forms.Button cancelButton; // Hinzufügen des Abbrechen-Buttons
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.resultsListBox = new System.Windows.Forms.ListBox();
            this.downloadButton = new System.Windows.Forms.Button();
            this.filePathTextBox = new System.Windows.Forms.TextBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.downloadProgressBar = new System.Windows.Forms.ProgressBar();
            this.downloadProgressLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(18, 58);
            this.searchTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(1162, 26);
            this.searchTextBox.TabIndex = 0;
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            // 
            // resultsListBox
            // 
            this.resultsListBox.FormattingEnabled = true;
            this.resultsListBox.ItemHeight = 20;
            this.resultsListBox.Location = new System.Drawing.Point(18, 98);
            this.resultsListBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.resultsListBox.Name = "resultsListBox";
            this.resultsListBox.Size = new System.Drawing.Size(1162, 524);
            this.resultsListBox.TabIndex = 1;
            this.resultsListBox.SelectedIndexChanged += new System.EventHandler(this.resultsListBox_SelectedIndexChanged);
            // 
            // downloadButton
            // 
            this.downloadButton.Location = new System.Drawing.Point(1070, 634);
            this.downloadButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(112, 35);
            this.downloadButton.TabIndex = 2;
            this.downloadButton.Text = "Download";
            this.downloadButton.UseVisualStyleBackColor = true;
            this.downloadButton.Click += new System.EventHandler(this.downloadButton_Click);
            // 
            // filePathTextBox
            // 
            this.filePathTextBox.Location = new System.Drawing.Point(18, 18);
            this.filePathTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.filePathTextBox.Name = "filePathTextBox";
            this.filePathTextBox.Size = new System.Drawing.Size(1040, 26);
            this.filePathTextBox.TabIndex = 3;
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(1070, 15);
            this.browseButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(112, 35);
            this.browseButton.TabIndex = 4;
            this.browseButton.Text = "Add .CSV";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // downloadProgressBar
            // 
            this.downloadProgressBar.Location = new System.Drawing.Point(18, 634);
            this.downloadProgressBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.downloadProgressBar.Name = "downloadProgressBar";
            this.downloadProgressBar.Size = new System.Drawing.Size(1042, 35);
            this.downloadProgressBar.TabIndex = 5;
            // 
            // downloadProgressLabel
            // 
            this.downloadProgressLabel.AutoSize = true;
            this.downloadProgressLabel.Location = new System.Drawing.Point(18, 678);
            this.downloadProgressLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.downloadProgressLabel.Name = "downloadProgressLabel";
            this.downloadProgressLabel.Size = new System.Drawing.Size(0, 20);
            this.downloadProgressLabel.TabIndex = 6;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(471, 675);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(115, 33);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Visible = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 720);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.downloadProgressLabel);
            this.Controls.Add(this.downloadProgressBar);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.filePathTextBox);
            this.Controls.Add(this.downloadButton);
            this.Controls.Add(this.resultsListBox);
            this.Controls.Add(this.searchTextBox);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.Text = "PS3 Gameloader";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

    }
}