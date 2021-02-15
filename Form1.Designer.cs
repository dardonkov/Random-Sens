
namespace WindowsFormsApp1
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
            this.start_Btn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // start_Btn
            // 
            this.start_Btn.Location = new System.Drawing.Point(238, 368);
            this.start_Btn.Name = "start_Btn";
            this.start_Btn.Size = new System.Drawing.Size(75, 23);
            this.start_Btn.TabIndex = 0;
            this.start_Btn.Text = "Start";
            this.start_Btn.UseVisualStyleBackColor = true;
            this.start_Btn.Click += new System.EventHandler(this.start_Btn_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(60, 368);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 422);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.start_Btn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button start_Btn;
        private System.Windows.Forms.Button button2;
    }
}

