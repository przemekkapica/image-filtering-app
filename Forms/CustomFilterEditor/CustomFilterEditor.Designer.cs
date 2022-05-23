﻿namespace image_filtering_app
{
    partial class CustomFilterEditor
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.NUDAnchorRow = new System.Windows.Forms.NumericUpDown();
            this.NUDAnchorCol = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.NUDOffset = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CBFilterType = new System.Windows.Forms.ComboBox();
            this.buttonRedraw = new System.Windows.Forms.Button();
            this.NUDKernelRow = new System.Windows.Forms.NumericUpDown();
            this.NUDKernelColumn = new System.Windows.Forms.NumericUpDown();
            this.NUDDivisor = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDAnchorRow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDAnchorCol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDKernelRow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDKernelColumn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDDivisor)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label9);
            this.splitContainer1.Panel1.Controls.Add(this.label8);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.NUDAnchorRow);
            this.splitContainer1.Panel1.Controls.Add(this.NUDAnchorCol);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.NUDOffset);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.CBFilterType);
            this.splitContainer1.Panel1.Controls.Add(this.buttonRedraw);
            this.splitContainer1.Panel1.Controls.Add(this.NUDKernelRow);
            this.splitContainer1.Panel1.Controls.Add(this.NUDKernelColumn);
            this.splitContainer1.Panel1.Controls.Add(this.NUDDivisor);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.button2);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 238;
            this.splitContainer1.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Location = new System.Drawing.Point(32, 201);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(170, 2);
            this.label9.TabIndex = 21;
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(126, 308);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Row";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(33, 308);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Column";
            // 
            // NUDAnchorRow
            // 
            this.NUDAnchorRow.Location = new System.Drawing.Point(129, 324);
            this.NUDAnchorRow.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.NUDAnchorRow.Name = "NUDAnchorRow";
            this.NUDAnchorRow.Size = new System.Drawing.Size(78, 20);
            this.NUDAnchorRow.TabIndex = 18;
            // 
            // NUDAnchorCol
            // 
            this.NUDAnchorCol.Location = new System.Drawing.Point(33, 324);
            this.NUDAnchorCol.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.NUDAnchorCol.Name = "NUDAnchorCol";
            this.NUDAnchorCol.Size = new System.Drawing.Size(76, 20);
            this.NUDAnchorCol.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 286);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Anchor position";
            // 
            // NUDOffset
            // 
            this.NUDOffset.Location = new System.Drawing.Point(126, 246);
            this.NUDOffset.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.NUDOffset.Minimum = new decimal(new int[] {
            255,
            0,
            0,
            -2147483648});
            this.NUDOffset.Name = "NUDOffset";
            this.NUDOffset.Size = new System.Drawing.Size(78, 20);
            this.NUDOffset.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(126, 229);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Offset";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Kernel type";
            // 
            // CBFilterType
            // 
            this.CBFilterType.FormattingEnabled = true;
            this.CBFilterType.Location = new System.Drawing.Point(31, 41);
            this.CBFilterType.Name = "CBFilterType";
            this.CBFilterType.Size = new System.Drawing.Size(172, 21);
            this.CBFilterType.TabIndex = 12;
            this.CBFilterType.Text = "Select built-in kernel";
            // 
            // buttonRedraw
            // 
            this.buttonRedraw.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.buttonRedraw.Location = new System.Drawing.Point(31, 139);
            this.buttonRedraw.Name = "buttonRedraw";
            this.buttonRedraw.Size = new System.Drawing.Size(172, 30);
            this.buttonRedraw.TabIndex = 11;
            this.buttonRedraw.Text = "Redraw";
            this.buttonRedraw.UseVisualStyleBackColor = true;
            this.buttonRedraw.Click += new System.EventHandler(this.Redraw_Click);
            // 
            // NUDKernelRow
            // 
            this.NUDKernelRow.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.NUDKernelRow.Location = new System.Drawing.Point(128, 97);
            this.NUDKernelRow.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.NUDKernelRow.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUDKernelRow.Name = "NUDKernelRow";
            this.NUDKernelRow.Size = new System.Drawing.Size(75, 20);
            this.NUDKernelRow.TabIndex = 10;
            this.NUDKernelRow.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUDKernelRow.ValueChanged += new System.EventHandler(this.RowCol_OnValueChanged);
            // 
            // NUDKernelColumn
            // 
            this.NUDKernelColumn.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.NUDKernelColumn.Location = new System.Drawing.Point(32, 97);
            this.NUDKernelColumn.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.NUDKernelColumn.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUDKernelColumn.Name = "NUDKernelColumn";
            this.NUDKernelColumn.Size = new System.Drawing.Size(73, 20);
            this.NUDKernelColumn.TabIndex = 9;
            this.NUDKernelColumn.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUDKernelColumn.ValueChanged += new System.EventHandler(this.RowCol_OnValueChanged);
            // 
            // NUDDivisor
            // 
            this.NUDDivisor.Location = new System.Drawing.Point(33, 246);
            this.NUDDivisor.Name = "NUDDivisor";
            this.NUDDivisor.Size = new System.Drawing.Size(73, 20);
            this.NUDDivisor.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 229);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Divisor";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.button2.Location = new System.Drawing.Point(33, 408);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(173, 30);
            this.button2.TabIndex = 5;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.button1.Location = new System.Drawing.Point(33, 372);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(174, 30);
            this.button1.TabIndex = 4;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(125, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Rows";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Columns";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(558, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // CustomFilterEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "CustomFilterEditor";
            this.Text = "Custom Filter Editor";
            this.Load += new System.EventHandler(this.KernelEditor_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NUDAnchorRow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDAnchorCol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDKernelRow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDKernelColumn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDDivisor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown NUDDivisor;
        private System.Windows.Forms.NumericUpDown NUDKernelRow;
        private System.Windows.Forms.NumericUpDown NUDKernelColumn;
        private System.Windows.Forms.Button buttonRedraw;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CBFilterType;
        private System.Windows.Forms.NumericUpDown NUDAnchorCol;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown NUDOffset;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown NUDAnchorRow;
        private System.Windows.Forms.Label label9;
    }
}