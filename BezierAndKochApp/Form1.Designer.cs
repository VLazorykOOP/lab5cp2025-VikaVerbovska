namespace BezierAndKochApp
{
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonBezier = new Button();
            buttonKoch = new Button();
            SuspendLayout();
            // 
            // buttonBezier
            // 
            buttonBezier.Location = new Point(12, 12);
            buttonBezier.Name = "buttonBezier";
            buttonBezier.Size = new Size(167, 29);
            buttonBezier.TabIndex = 0;
            buttonBezier.Text = "Крива Без’є";
            buttonBezier.UseVisualStyleBackColor = true;
            // 
            // buttonKoch
            // 
            buttonKoch.Location = new Point(185, 12);
            buttonKoch.Name = "buttonKoch";
            buttonKoch.Size = new Size(169, 29);
            buttonKoch.TabIndex = 1;
            buttonKoch.Text = "Фрактал Коха";
            buttonKoch.UseVisualStyleBackColor = true;
            buttonKoch.Click += buttonKoch_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonKoch);
            Controls.Add(buttonBezier);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button buttonBezier;
        private Button buttonKoch;
    }
}
