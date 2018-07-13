namespace R423.GUILinesInfoBuilder
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.fIleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveLinesInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFilesInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.savePathStatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadPathStatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSignalPathsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadSignalPathsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBoxImage = new System.Windows.Forms.PictureBox();
            this.panelLinesList = new System.Windows.Forms.Panel();
            this.listBoxLinesInfo = new System.Windows.Forms.ListBox();
            this.panelSignalPath = new System.Windows.Forms.Panel();
            this.buttonSelectStateLineColor = new System.Windows.Forms.Button();
            this.listBoxSignalPath = new System.Windows.Forms.ListBox();
            this.buttonAddPath = new System.Windows.Forms.Button();
            this.buttonSavePath = new System.Windows.Forms.Button();
            this.buttonDeletePath = new System.Windows.Forms.Button();
            this.labelPathStates = new System.Windows.Forms.Label();
            this.textBoxPathStates = new System.Windows.Forms.TextBox();
            this.labelNumberPath = new System.Windows.Forms.Label();
            this.textBoxNumberPath = new System.Windows.Forms.TextBox();
            this.buttonReverse = new System.Windows.Forms.Button();
            this.labelIndex = new System.Windows.Forms.Label();
            this.buttonSaveIndex = new System.Windows.Forms.Button();
            this.textBoxLineIndex = new System.Windows.Forms.TextBox();
            this.buttonDeleteLinesInfo = new System.Windows.Forms.Button();
            this.buttonAddState = new System.Windows.Forms.Button();
            this.buttonSaveState = new System.Windows.Forms.Button();
            this.buttonDeleteState = new System.Windows.Forms.Button();
            this.labelDrawableLines = new System.Windows.Forms.Label();
            this.textBoxDrawableLines = new System.Windows.Forms.TextBox();
            this.labelNumberState = new System.Windows.Forms.Label();
            this.textBoxNumberState = new System.Windows.Forms.TextBox();
            this.listBoxSignalPathState = new System.Windows.Forms.ListBox();
            this.colorDialogStateColor = new System.Windows.Forms.ColorDialog();
            this.lineStatesControllerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panelImageContainer = new System.Windows.Forms.Panel();
            this.menuMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
            this.panelLinesList.SuspendLayout();
            this.panelSignalPath.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lineStatesControllerBindingSource)).BeginInit();
            this.panelImageContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuMain
            // 
            this.menuMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fIleToolStripMenuItem});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuMain.Size = new System.Drawing.Size(1000, 24);
            this.menuMain.TabIndex = 0;
            this.menuMain.Text = "menuMain";
            // 
            // fIleToolStripMenuItem
            // 
            this.fIleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadImageToolStripMenuItem,
            this.saveLinesInfoToolStripMenuItem,
            this.loadFilesInfoToolStripMenuItem,
            this.savePathStatesToolStripMenuItem,
            this.loadPathStatesToolStripMenuItem,
            this.saveSignalPathsToolStripMenuItem,
            this.loadSignalPathsToolStripMenuItem});
            this.fIleToolStripMenuItem.Name = "fIleToolStripMenuItem";
            this.fIleToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fIleToolStripMenuItem.Text = "File";
            // 
            // loadImageToolStripMenuItem
            // 
            this.loadImageToolStripMenuItem.Name = "loadImageToolStripMenuItem";
            this.loadImageToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.loadImageToolStripMenuItem.Text = "Load image";
            // 
            // saveLinesInfoToolStripMenuItem
            // 
            this.saveLinesInfoToolStripMenuItem.Name = "saveLinesInfoToolStripMenuItem";
            this.saveLinesInfoToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.saveLinesInfoToolStripMenuItem.Text = "Save lines info";
            this.saveLinesInfoToolStripMenuItem.Click += new System.EventHandler(this.saveLinesInfoToolStripMenuItem_Click);
            // 
            // loadFilesInfoToolStripMenuItem
            // 
            this.loadFilesInfoToolStripMenuItem.Name = "loadFilesInfoToolStripMenuItem";
            this.loadFilesInfoToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.loadFilesInfoToolStripMenuItem.Text = "Load lines info";
            this.loadFilesInfoToolStripMenuItem.Click += new System.EventHandler(this.loadFilesInfoToolStripMenuItem_Click);
            // 
            // savePathStatesToolStripMenuItem
            // 
            this.savePathStatesToolStripMenuItem.Name = "savePathStatesToolStripMenuItem";
            this.savePathStatesToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.savePathStatesToolStripMenuItem.Text = "Save path states";
            this.savePathStatesToolStripMenuItem.Click += new System.EventHandler(this.savePathStatesToolStripMenuItem_Click);
            // 
            // loadPathStatesToolStripMenuItem
            // 
            this.loadPathStatesToolStripMenuItem.Name = "loadPathStatesToolStripMenuItem";
            this.loadPathStatesToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.loadPathStatesToolStripMenuItem.Text = "Load path states";
            this.loadPathStatesToolStripMenuItem.Click += new System.EventHandler(this.loadPathStatesToolStripMenuItem_Click);
            // 
            // saveSignalPathsToolStripMenuItem
            // 
            this.saveSignalPathsToolStripMenuItem.Name = "saveSignalPathsToolStripMenuItem";
            this.saveSignalPathsToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.saveSignalPathsToolStripMenuItem.Text = "Save signal paths";
            this.saveSignalPathsToolStripMenuItem.Click += new System.EventHandler(this.saveSignalPathsToolStripMenuItem_Click);
            // 
            // loadSignalPathsToolStripMenuItem
            // 
            this.loadSignalPathsToolStripMenuItem.Name = "loadSignalPathsToolStripMenuItem";
            this.loadSignalPathsToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.loadSignalPathsToolStripMenuItem.Text = "Load signal paths";
            this.loadSignalPathsToolStripMenuItem.Click += new System.EventHandler(this.loadSignalPathsToolStripMenuItem_Click);
            // 
            // pictureBoxImage
            // 
            this.pictureBoxImage.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pictureBoxImage.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxImage.Image")));
            this.pictureBoxImage.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxImage.InitialImage")));
            this.pictureBoxImage.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxImage.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.pictureBoxImage.Size = new System.Drawing.Size(4102, 2298);
            this.pictureBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxImage.TabIndex = 1;
            this.pictureBoxImage.TabStop = false;
            this.pictureBoxImage.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxImage_MouseClick);
            this.pictureBoxImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxImage_MouseMove);
            // 
            // panelLinesList
            // 
            this.panelLinesList.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelLinesList.Controls.Add(this.listBoxLinesInfo);
            this.panelLinesList.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelLinesList.Location = new System.Drawing.Point(711, 24);
            this.panelLinesList.Margin = new System.Windows.Forms.Padding(2);
            this.panelLinesList.Name = "panelLinesList";
            this.panelLinesList.Size = new System.Drawing.Size(289, 576);
            this.panelLinesList.TabIndex = 2;
            // 
            // listBoxLinesInfo
            // 
            this.listBoxLinesInfo.Dock = System.Windows.Forms.DockStyle.Right;
            this.listBoxLinesInfo.FormattingEnabled = true;
            this.listBoxLinesInfo.Location = new System.Drawing.Point(-1, 0);
            this.listBoxLinesInfo.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxLinesInfo.Name = "listBoxLinesInfo";
            this.listBoxLinesInfo.Size = new System.Drawing.Size(290, 576);
            this.listBoxLinesInfo.TabIndex = 0;
            this.listBoxLinesInfo.SelectedIndexChanged += new System.EventHandler(this.listBoxLinesInfo_SelectedIndexChanged);
            // 
            // panelSignalPath
            // 
            this.panelSignalPath.Controls.Add(this.buttonSelectStateLineColor);
            this.panelSignalPath.Controls.Add(this.listBoxSignalPath);
            this.panelSignalPath.Controls.Add(this.buttonAddPath);
            this.panelSignalPath.Controls.Add(this.buttonSavePath);
            this.panelSignalPath.Controls.Add(this.buttonDeletePath);
            this.panelSignalPath.Controls.Add(this.labelPathStates);
            this.panelSignalPath.Controls.Add(this.textBoxPathStates);
            this.panelSignalPath.Controls.Add(this.labelNumberPath);
            this.panelSignalPath.Controls.Add(this.textBoxNumberPath);
            this.panelSignalPath.Controls.Add(this.buttonReverse);
            this.panelSignalPath.Controls.Add(this.labelIndex);
            this.panelSignalPath.Controls.Add(this.buttonSaveIndex);
            this.panelSignalPath.Controls.Add(this.textBoxLineIndex);
            this.panelSignalPath.Controls.Add(this.buttonDeleteLinesInfo);
            this.panelSignalPath.Controls.Add(this.buttonAddState);
            this.panelSignalPath.Controls.Add(this.buttonSaveState);
            this.panelSignalPath.Controls.Add(this.buttonDeleteState);
            this.panelSignalPath.Controls.Add(this.labelDrawableLines);
            this.panelSignalPath.Controls.Add(this.textBoxDrawableLines);
            this.panelSignalPath.Controls.Add(this.labelNumberState);
            this.panelSignalPath.Controls.Add(this.textBoxNumberState);
            this.panelSignalPath.Controls.Add(this.listBoxSignalPathState);
            this.panelSignalPath.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelSignalPath.Location = new System.Drawing.Point(0, 456);
            this.panelSignalPath.Margin = new System.Windows.Forms.Padding(2);
            this.panelSignalPath.Name = "panelSignalPath";
            this.panelSignalPath.Size = new System.Drawing.Size(711, 144);
            this.panelSignalPath.TabIndex = 3;
            // 
            // buttonSelectStateLineColor
            // 
            this.buttonSelectStateLineColor.Location = new System.Drawing.Point(595, 25);
            this.buttonSelectStateLineColor.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSelectStateLineColor.Name = "buttonSelectStateLineColor";
            this.buttonSelectStateLineColor.Size = new System.Drawing.Size(87, 19);
            this.buttonSelectStateLineColor.TabIndex = 21;
            this.buttonSelectStateLineColor.Text = "State color";
            this.buttonSelectStateLineColor.UseVisualStyleBackColor = true;
            this.buttonSelectStateLineColor.Click += new System.EventHandler(this.buttonSelectStateLineColor_Click);
            // 
            // listBoxSignalPath
            // 
            this.listBoxSignalPath.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listBoxSignalPath.FormattingEnabled = true;
            this.listBoxSignalPath.Location = new System.Drawing.Point(398, 101);
            this.listBoxSignalPath.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxSignalPath.Name = "listBoxSignalPath";
            this.listBoxSignalPath.Size = new System.Drawing.Size(313, 43);
            this.listBoxSignalPath.TabIndex = 20;
            this.listBoxSignalPath.SelectedIndexChanged += new System.EventHandler(this.listBoxSignalPath_SelectedIndexChanged);
            // 
            // buttonAddPath
            // 
            this.buttonAddPath.Location = new System.Drawing.Point(525, 76);
            this.buttonAddPath.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddPath.Name = "buttonAddPath";
            this.buttonAddPath.Size = new System.Drawing.Size(56, 19);
            this.buttonAddPath.TabIndex = 19;
            this.buttonAddPath.Text = "Add";
            this.buttonAddPath.UseVisualStyleBackColor = true;
            this.buttonAddPath.Click += new System.EventHandler(this.buttonAddPath_Click);
            // 
            // buttonSavePath
            // 
            this.buttonSavePath.Location = new System.Drawing.Point(464, 76);
            this.buttonSavePath.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSavePath.Name = "buttonSavePath";
            this.buttonSavePath.Size = new System.Drawing.Size(56, 19);
            this.buttonSavePath.TabIndex = 18;
            this.buttonSavePath.Text = "Save";
            this.buttonSavePath.UseVisualStyleBackColor = true;
            this.buttonSavePath.Click += new System.EventHandler(this.buttonSavePath_Click);
            // 
            // buttonDeletePath
            // 
            this.buttonDeletePath.Location = new System.Drawing.Point(404, 76);
            this.buttonDeletePath.Margin = new System.Windows.Forms.Padding(2);
            this.buttonDeletePath.Name = "buttonDeletePath";
            this.buttonDeletePath.Size = new System.Drawing.Size(56, 19);
            this.buttonDeletePath.TabIndex = 17;
            this.buttonDeletePath.Text = "delete";
            this.buttonDeletePath.UseVisualStyleBackColor = true;
            this.buttonDeletePath.Click += new System.EventHandler(this.buttonDeletePath_Click);
            // 
            // labelPathStates
            // 
            this.labelPathStates.AutoSize = true;
            this.labelPathStates.Location = new System.Drawing.Point(453, 56);
            this.labelPathStates.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPathStates.Name = "labelPathStates";
            this.labelPathStates.Size = new System.Drawing.Size(63, 13);
            this.labelPathStates.TabIndex = 16;
            this.labelPathStates.Text = "Path states:";
            // 
            // textBoxPathStates
            // 
            this.textBoxPathStates.Location = new System.Drawing.Point(536, 54);
            this.textBoxPathStates.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxPathStates.Name = "textBoxPathStates";
            this.textBoxPathStates.Size = new System.Drawing.Size(356, 20);
            this.textBoxPathStates.TabIndex = 15;
            // 
            // labelNumberPath
            // 
            this.labelNumberPath.AutoSize = true;
            this.labelNumberPath.Location = new System.Drawing.Point(401, 56);
            this.labelNumberPath.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelNumberPath.Name = "labelNumberPath";
            this.labelNumberPath.Size = new System.Drawing.Size(18, 13);
            this.labelNumberPath.TabIndex = 14;
            this.labelNumberPath.Text = "N:";
            // 
            // textBoxNumberPath
            // 
            this.textBoxNumberPath.Location = new System.Drawing.Point(422, 54);
            this.textBoxNumberPath.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxNumberPath.Name = "textBoxNumberPath";
            this.textBoxNumberPath.Size = new System.Drawing.Size(27, 20);
            this.textBoxNumberPath.TabIndex = 13;
            // 
            // buttonReverse
            // 
            this.buttonReverse.Location = new System.Drawing.Point(916, 75);
            this.buttonReverse.Margin = new System.Windows.Forms.Padding(2);
            this.buttonReverse.Name = "buttonReverse";
            this.buttonReverse.Size = new System.Drawing.Size(94, 19);
            this.buttonReverse.TabIndex = 12;
            this.buttonReverse.Text = "Reverse in state";
            this.buttonReverse.UseVisualStyleBackColor = true;
            this.buttonReverse.Click += new System.EventHandler(this.buttonReverse_Click);
            // 
            // labelIndex
            // 
            this.labelIndex.AutoSize = true;
            this.labelIndex.Location = new System.Drawing.Point(878, 28);
            this.labelIndex.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelIndex.Name = "labelIndex";
            this.labelIndex.Size = new System.Drawing.Size(36, 13);
            this.labelIndex.TabIndex = 11;
            this.labelIndex.Text = "Index:";
            // 
            // buttonSaveIndex
            // 
            this.buttonSaveIndex.Location = new System.Drawing.Point(916, 51);
            this.buttonSaveIndex.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSaveIndex.Name = "buttonSaveIndex";
            this.buttonSaveIndex.Size = new System.Drawing.Size(94, 19);
            this.buttonSaveIndex.TabIndex = 10;
            this.buttonSaveIndex.Text = "Save index";
            this.buttonSaveIndex.UseVisualStyleBackColor = true;
            this.buttonSaveIndex.Click += new System.EventHandler(this.buttonSaveIndex_Click);
            // 
            // textBoxLineIndex
            // 
            this.textBoxLineIndex.Location = new System.Drawing.Point(916, 28);
            this.textBoxLineIndex.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxLineIndex.Name = "textBoxLineIndex";
            this.textBoxLineIndex.Size = new System.Drawing.Size(96, 20);
            this.textBoxLineIndex.TabIndex = 9;
            // 
            // buttonDeleteLinesInfo
            // 
            this.buttonDeleteLinesInfo.Location = new System.Drawing.Point(916, 5);
            this.buttonDeleteLinesInfo.Margin = new System.Windows.Forms.Padding(2);
            this.buttonDeleteLinesInfo.Name = "buttonDeleteLinesInfo";
            this.buttonDeleteLinesInfo.Size = new System.Drawing.Size(94, 19);
            this.buttonDeleteLinesInfo.TabIndex = 8;
            this.buttonDeleteLinesInfo.Text = "Delete line info";
            this.buttonDeleteLinesInfo.UseVisualStyleBackColor = true;
            this.buttonDeleteLinesInfo.Click += new System.EventHandler(this.buttonDeleteLinesInfo_Click);
            // 
            // buttonAddState
            // 
            this.buttonAddState.Location = new System.Drawing.Point(525, 25);
            this.buttonAddState.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddState.Name = "buttonAddState";
            this.buttonAddState.Size = new System.Drawing.Size(56, 19);
            this.buttonAddState.TabIndex = 7;
            this.buttonAddState.Text = "Add";
            this.buttonAddState.UseVisualStyleBackColor = true;
            this.buttonAddState.Click += new System.EventHandler(this.buttonAddState_Click);
            // 
            // buttonSaveState
            // 
            this.buttonSaveState.Location = new System.Drawing.Point(464, 25);
            this.buttonSaveState.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSaveState.Name = "buttonSaveState";
            this.buttonSaveState.Size = new System.Drawing.Size(56, 19);
            this.buttonSaveState.TabIndex = 6;
            this.buttonSaveState.Text = "Save";
            this.buttonSaveState.UseVisualStyleBackColor = true;
            this.buttonSaveState.Click += new System.EventHandler(this.buttonSaveState_Click);
            // 
            // buttonDeleteState
            // 
            this.buttonDeleteState.Location = new System.Drawing.Point(404, 25);
            this.buttonDeleteState.Margin = new System.Windows.Forms.Padding(2);
            this.buttonDeleteState.Name = "buttonDeleteState";
            this.buttonDeleteState.Size = new System.Drawing.Size(56, 19);
            this.buttonDeleteState.TabIndex = 5;
            this.buttonDeleteState.Text = "delete";
            this.buttonDeleteState.UseVisualStyleBackColor = true;
            this.buttonDeleteState.Click += new System.EventHandler(this.buttonDeleteState_Click);
            // 
            // labelDrawableLines
            // 
            this.labelDrawableLines.AutoSize = true;
            this.labelDrawableLines.Location = new System.Drawing.Point(453, 5);
            this.labelDrawableLines.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDrawableLines.Name = "labelDrawableLines";
            this.labelDrawableLines.Size = new System.Drawing.Size(79, 13);
            this.labelDrawableLines.TabIndex = 4;
            this.labelDrawableLines.Text = "Drawable lines:";
            // 
            // textBoxDrawableLines
            // 
            this.textBoxDrawableLines.Location = new System.Drawing.Point(536, 2);
            this.textBoxDrawableLines.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxDrawableLines.Name = "textBoxDrawableLines";
            this.textBoxDrawableLines.Size = new System.Drawing.Size(356, 20);
            this.textBoxDrawableLines.TabIndex = 3;
            this.textBoxDrawableLines.TextChanged += new System.EventHandler(this.textBoxDrawableLines_TextChanged);
            // 
            // labelNumberState
            // 
            this.labelNumberState.AutoSize = true;
            this.labelNumberState.Location = new System.Drawing.Point(401, 5);
            this.labelNumberState.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelNumberState.Name = "labelNumberState";
            this.labelNumberState.Size = new System.Drawing.Size(18, 13);
            this.labelNumberState.TabIndex = 2;
            this.labelNumberState.Text = "N:";
            // 
            // textBoxNumberState
            // 
            this.textBoxNumberState.Location = new System.Drawing.Point(422, 2);
            this.textBoxNumberState.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxNumberState.Name = "textBoxNumberState";
            this.textBoxNumberState.Size = new System.Drawing.Size(27, 20);
            this.textBoxNumberState.TabIndex = 1;
            // 
            // listBoxSignalPathState
            // 
            this.listBoxSignalPathState.Dock = System.Windows.Forms.DockStyle.Left;
            this.listBoxSignalPathState.FormattingEnabled = true;
            this.listBoxSignalPathState.HorizontalScrollbar = true;
            this.listBoxSignalPathState.Location = new System.Drawing.Point(0, 0);
            this.listBoxSignalPathState.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxSignalPathState.Name = "listBoxSignalPathState";
            this.listBoxSignalPathState.Size = new System.Drawing.Size(398, 144);
            this.listBoxSignalPathState.TabIndex = 0;
            this.listBoxSignalPathState.SelectedIndexChanged += new System.EventHandler(this.listBoxSignalPathState_SelectedIndexChanged);
            // 
            // lineStatesControllerBindingSource
            // 
            this.lineStatesControllerBindingSource.DataSource = typeof(StatesDataLibrary.Classes.Controllers.LineStatesController);
            // 
            // panelImageContainer
            // 
            this.panelImageContainer.AutoScroll = true;
            this.panelImageContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelImageContainer.Controls.Add(this.pictureBoxImage);
            //this.panelImageContainer.Scroll += panelImageContainer_Scroll;
            this.panelImageContainer.Location = new System.Drawing.Point(2, 22);
            this.panelImageContainer.Margin = new System.Windows.Forms.Padding(2);
            this.panelImageContainer.Name = "panelImageContainer";
            this.panelImageContainer.Size = new System.Drawing.Size(700, 400);
            this.panelImageContainer.TabIndex = 4;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.panelImageContainer);
            this.Controls.Add(this.panelSignalPath);
            this.Controls.Add(this.panelLinesList);
            this.Controls.Add(this.menuMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuMain;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormMain";
            this.Text = "LinesInfoBuilder";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
            this.panelLinesList.ResumeLayout(false);
            this.panelSignalPath.ResumeLayout(false);
            this.panelSignalPath.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lineStatesControllerBindingSource)).EndInit();
            this.panelImageContainer.ResumeLayout(false);
            this.panelImageContainer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem fIleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveLinesInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadFilesInfoToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBoxImage;
        private System.Windows.Forms.Panel panelLinesList;
        private System.Windows.Forms.BindingSource lineStatesControllerBindingSource;
        private System.Windows.Forms.ListBox listBoxLinesInfo;
        private System.Windows.Forms.Panel panelSignalPath;
        private System.Windows.Forms.Label labelIndex;
        private System.Windows.Forms.Button buttonSaveIndex;
        private System.Windows.Forms.TextBox textBoxLineIndex;
        private System.Windows.Forms.Button buttonDeleteLinesInfo;
        private System.Windows.Forms.Button buttonAddState;
        private System.Windows.Forms.Button buttonSaveState;
        private System.Windows.Forms.Button buttonDeleteState;
        private System.Windows.Forms.Label labelDrawableLines;
        private System.Windows.Forms.TextBox textBoxDrawableLines;
        private System.Windows.Forms.Label labelNumberState;
        private System.Windows.Forms.TextBox textBoxNumberState;
        private System.Windows.Forms.ListBox listBoxSignalPathState;
        private System.Windows.Forms.Button buttonReverse;
        private System.Windows.Forms.Button buttonAddPath;
        private System.Windows.Forms.Button buttonSavePath;
        private System.Windows.Forms.Button buttonDeletePath;
        private System.Windows.Forms.Label labelPathStates;
        private System.Windows.Forms.TextBox textBoxPathStates;
        private System.Windows.Forms.Label labelNumberPath;
        private System.Windows.Forms.TextBox textBoxNumberPath;
        private System.Windows.Forms.ListBox listBoxSignalPath;
        private System.Windows.Forms.ToolStripMenuItem savePathStatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadPathStatesToolStripMenuItem;
        private System.Windows.Forms.Button buttonSelectStateLineColor;
        private System.Windows.Forms.ColorDialog colorDialogStateColor;
        private System.Windows.Forms.ToolStripMenuItem saveSignalPathsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadSignalPathsToolStripMenuItem;
        private System.Windows.Forms.Panel panelImageContainer;
    }
}

