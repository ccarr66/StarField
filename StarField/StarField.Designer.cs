namespace StarField
{
    partial class StarField
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
            this.btn_DragRegion = new System.Windows.Forms.Button();
            this.btn_ResetImage = new System.Windows.Forms.Button();
            this.btn_Play = new System.Windows.Forms.Button();
            this.btn_Maximize = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.pctBx_Display = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pctBx_Display)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_DragRegion
            // 
            this.btn_DragRegion.FlatAppearance.BorderSize = 0;
            this.btn_DragRegion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btn_DragRegion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btn_DragRegion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DragRegion.Location = new System.Drawing.Point(0, 0);
            this.btn_DragRegion.Name = "btn_DragRegion";
            this.btn_DragRegion.Size = new System.Drawing.Size(783, 20);
            this.btn_DragRegion.TabIndex = 0;
            this.btn_DragRegion.TabStop = false;
            this.btn_DragRegion.UseVisualStyleBackColor = true;
            this.btn_DragRegion.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_DragRegion_MouseDown);
            this.btn_DragRegion.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btn_DragRegion_MouseMove);
            this.btn_DragRegion.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_DragRegion_MouseUp);
            // 
            // btn_ResetImage
            // 
            this.btn_ResetImage.BackgroundImage = global::StarField.Properties.Resources.reset;
            this.btn_ResetImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_ResetImage.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_ResetImage.FlatAppearance.BorderSize = 0;
            this.btn_ResetImage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btn_ResetImage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btn_ResetImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ResetImage.ForeColor = System.Drawing.Color.Gray;
            this.btn_ResetImage.Location = new System.Drawing.Point(792, 633);
            this.btn_ResetImage.Name = "btn_ResetImage";
            this.btn_ResetImage.Size = new System.Drawing.Size(20, 20);
            this.btn_ResetImage.TabIndex = 0;
            this.btn_ResetImage.TabStop = false;
            this.btn_ResetImage.UseVisualStyleBackColor = false;
            this.btn_ResetImage.Click += new System.EventHandler(this.btn_ResetImage_Click);
            // 
            // btn_Play
            // 
            this.btn_Play.BackgroundImage = global::StarField.Properties.Resources.Play_Button;
            this.btn_Play.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_Play.FlatAppearance.BorderSize = 0;
            this.btn_Play.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btn_Play.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btn_Play.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Play.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_Play.Location = new System.Drawing.Point(12, 633);
            this.btn_Play.Name = "btn_Play";
            this.btn_Play.Size = new System.Drawing.Size(20, 20);
            this.btn_Play.TabIndex = 0;
            this.btn_Play.TabStop = false;
            this.btn_Play.UseVisualStyleBackColor = true;
            this.btn_Play.Click += new System.EventHandler(this.btn_Play_Click);
            // 
            // btn_Maximize
            // 
            this.btn_Maximize.BackgroundImage = global::StarField.Properties.Resources.MaxButton;
            this.btn_Maximize.FlatAppearance.BorderSize = 0;
            this.btn_Maximize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btn_Maximize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btn_Maximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Maximize.Location = new System.Drawing.Point(783, 0);
            this.btn_Maximize.Name = "btn_Maximize";
            this.btn_Maximize.Size = new System.Drawing.Size(20, 20);
            this.btn_Maximize.TabIndex = 0;
            this.btn_Maximize.TabStop = false;
            this.btn_Maximize.UseVisualStyleBackColor = true;
            this.btn_Maximize.Click += new System.EventHandler(this.btn_maximize_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.BackgroundImage = global::StarField.Properties.Resources.X_button;
            this.btn_Close.FlatAppearance.BorderSize = 0;
            this.btn_Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btn_Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Location = new System.Drawing.Point(803, 0);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(20, 20);
            this.btn_Close.TabIndex = 0;
            this.btn_Close.TabStop = false;
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // pctBx_Display
            // 
            this.pctBx_Display.BackColor = System.Drawing.Color.White;
            this.pctBx_Display.Location = new System.Drawing.Point(12, 26);
            this.pctBx_Display.Name = "pctBx_Display";
            this.pctBx_Display.Size = new System.Drawing.Size(800, 600);
            this.pctBx_Display.TabIndex = 0;
            this.pctBx_Display.TabStop = false;
            // 
            // StarField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(824, 660);
            this.Controls.Add(this.btn_ResetImage);
            this.Controls.Add(this.btn_Play);
            this.Controls.Add(this.btn_Maximize);
            this.Controls.Add(this.btn_DragRegion);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.pctBx_Display);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(824, 660);
            this.Name = "StarField";
            this.ResizeEnd += new System.EventHandler(this.StarField_ResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.pctBx_Display)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pctBx_Display;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_DragRegion;
        private System.Windows.Forms.Button btn_Maximize;
        private System.Windows.Forms.Button btn_Play;
        private System.Windows.Forms.Button btn_ResetImage;
    }
}

