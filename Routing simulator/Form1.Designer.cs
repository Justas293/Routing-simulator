﻿namespace Routing_simulator
{
    partial class Form1
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
            this.graphPanel = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuRouter = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuEdge = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonAddEdge = new System.Windows.Forms.Button();
            this.contextMenuStrip3 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.edgeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debudBox = new System.Windows.Forms.RichTextBox();
            this.startButton = new System.Windows.Forms.Button();
            this.RoutingTableView = new System.Windows.Forms.DataGridView();
            this.timerLabel = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.contextMenuStrip3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RoutingTableView)).BeginInit();
            this.SuspendLayout();
            // 
            // graphPanel
            // 
            this.graphPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.graphPanel.BackColor = System.Drawing.Color.DimGray;
            this.graphPanel.ContextMenuStrip = this.contextMenuStrip1;
            this.graphPanel.Location = new System.Drawing.Point(373, 0);
            this.graphPanel.Name = "graphPanel";
            this.graphPanel.Size = new System.Drawing.Size(654, 519);
            this.graphPanel.TabIndex = 0;
            this.graphPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.graphPanel_Paint);
            this.graphPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.graphPanel_MouseClick);
            this.graphPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.graphPanel_MouseMove);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuRouter});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(132, 26);
            // 
            // toolStripMenuRouter
            // 
            this.toolStripMenuRouter.Name = "toolStripMenuRouter";
            this.toolStripMenuRouter.Size = new System.Drawing.Size(131, 22);
            this.toolStripMenuRouter.Text = "Add router";
            this.toolStripMenuRouter.Click += new System.EventHandler(this.toolStripMenuRouter_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuEdge,
            this.toolStripMenuRemove});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(126, 48);
            // 
            // toolStripMenuEdge
            // 
            this.toolStripMenuEdge.Name = "toolStripMenuEdge";
            this.toolStripMenuEdge.Size = new System.Drawing.Size(125, 22);
            this.toolStripMenuEdge.Text = "Add edge";
            // 
            // toolStripMenuRemove
            // 
            this.toolStripMenuRemove.Name = "toolStripMenuRemove";
            this.toolStripMenuRemove.Size = new System.Drawing.Size(125, 22);
            this.toolStripMenuRemove.Text = "Remove";
            // 
            // buttonAddEdge
            // 
            this.buttonAddEdge.Location = new System.Drawing.Point(55, 19);
            this.buttonAddEdge.Name = "buttonAddEdge";
            this.buttonAddEdge.Size = new System.Drawing.Size(105, 36);
            this.buttonAddEdge.TabIndex = 2;
            this.buttonAddEdge.Text = "Add edge";
            this.buttonAddEdge.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip3
            // 
            this.contextMenuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.edgeToolStripMenuItem});
            this.contextMenuStrip3.Name = "contextMenuStrip3";
            this.contextMenuStrip3.Size = new System.Drawing.Size(147, 26);
            // 
            // edgeToolStripMenuItem
            // 
            this.edgeToolStripMenuItem.Name = "edgeToolStripMenuItem";
            this.edgeToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.edgeToolStripMenuItem.Text = "Remove edge";
            // 
            // debudBox
            // 
            this.debudBox.Location = new System.Drawing.Point(21, 128);
            this.debudBox.Name = "debudBox";
            this.debudBox.ReadOnly = true;
            this.debudBox.Size = new System.Drawing.Size(346, 148);
            this.debudBox.TabIndex = 3;
            this.debudBox.Text = "";
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(55, 61);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(105, 34);
            this.startButton.TabIndex = 4;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // RoutingTableView
            // 
            this.RoutingTableView.AllowUserToAddRows = false;
            this.RoutingTableView.AllowUserToDeleteRows = false;
            this.RoutingTableView.AllowUserToResizeColumns = false;
            this.RoutingTableView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RoutingTableView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RoutingTableView.Location = new System.Drawing.Point(21, 355);
            this.RoutingTableView.Name = "RoutingTableView";
            this.RoutingTableView.ReadOnly = true;
            this.RoutingTableView.Size = new System.Drawing.Size(346, 164);
            this.RoutingTableView.TabIndex = 5;
            // 
            // timerLabel
            // 
            this.timerLabel.AutoSize = true;
            this.timerLabel.Location = new System.Drawing.Point(272, 333);
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(10, 13);
            this.timerLabel.TabIndex = 6;
            this.timerLabel.Text = " ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 531);
            this.Controls.Add(this.timerLabel);
            this.Controls.Add(this.RoutingTableView);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.debudBox);
            this.Controls.Add(this.buttonAddEdge);
            this.Controls.Add(this.graphPanel);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.contextMenuStrip3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RoutingTableView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel graphPanel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuRouter;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuEdge;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuRemove;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.Button buttonAddEdge;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip3;
        private System.Windows.Forms.ToolStripMenuItem edgeToolStripMenuItem;
        private System.Windows.Forms.RichTextBox debudBox;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.DataGridView RoutingTableView;
        private System.Windows.Forms.Label timerLabel;
    }
}

