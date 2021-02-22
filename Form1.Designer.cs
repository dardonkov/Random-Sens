
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title4 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.btn_Start = new System.Windows.Forms.Button();
            this.btn_Pause = new System.Windows.Forms.Button();
            this.box_BaseSens = new System.Windows.Forms.TextBox();
            this.box_Max_Sens = new System.Windows.Forms.TextBox();
            this.box_Min_Sens = new System.Windows.Forms.TextBox();
            this.box_Timestep = new System.Windows.Forms.TextBox();
            this.box_Spread = new System.Windows.Forms.TextBox();
            this.label_Type = new System.Windows.Forms.Label();
            this.label_basesens = new System.Windows.Forms.Label();
            this.label_maxsens = new System.Windows.Forms.Label();
            this.label_minsens = new System.Windows.Forms.Label();
            this.label_timestep = new System.Windows.Forms.Label();
            this.label_spread = new System.Windows.Forms.Label();
            this.cbox_Type = new System.Windows.Forms.ComboBox();
            this.label_smoothing = new System.Windows.Forms.Label();
            this.box_Smoothing = new System.Windows.Forms.TextBox();
            this.btn_Regen_Curve = new System.Windows.Forms.Button();
            this.sensCurveChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label_mean = new System.Windows.Forms.Label();
            this.label_std = new System.Windows.Forms.Label();
            this.label_sensmultiplier = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.sensCurveChart)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Start
            // 
            this.btn_Start.Location = new System.Drawing.Point(24, 324);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(75, 50);
            this.btn_Start.TabIndex = 0;
            this.btn_Start.Text = "Start";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // btn_Pause
            // 
            this.btn_Pause.Location = new System.Drawing.Point(105, 324);
            this.btn_Pause.Name = "btn_Pause";
            this.btn_Pause.Size = new System.Drawing.Size(75, 50);
            this.btn_Pause.TabIndex = 1;
            this.btn_Pause.Text = "Pause";
            this.btn_Pause.UseVisualStyleBackColor = true;
            // 
            // box_BaseSens
            // 
            this.box_BaseSens.Location = new System.Drawing.Point(186, 58);
            this.box_BaseSens.Name = "box_BaseSens";
            this.box_BaseSens.Size = new System.Drawing.Size(75, 20);
            this.box_BaseSens.TabIndex = 3;
            this.box_BaseSens.Validating += new System.ComponentModel.CancelEventHandler(this.box_double_Validating);
            this.box_BaseSens.Validated += new System.EventHandler(this.box_Validated);
            // 
            // box_Max_Sens
            // 
            this.box_Max_Sens.Location = new System.Drawing.Point(186, 84);
            this.box_Max_Sens.Name = "box_Max_Sens";
            this.box_Max_Sens.Size = new System.Drawing.Size(75, 20);
            this.box_Max_Sens.TabIndex = 4;
            // 
            // box_Min_Sens
            // 
            this.box_Min_Sens.Location = new System.Drawing.Point(186, 110);
            this.box_Min_Sens.Name = "box_Min_Sens";
            this.box_Min_Sens.Size = new System.Drawing.Size(75, 20);
            this.box_Min_Sens.TabIndex = 5;
            // 
            // box_Timestep
            // 
            this.box_Timestep.Location = new System.Drawing.Point(186, 136);
            this.box_Timestep.Name = "box_Timestep";
            this.box_Timestep.Size = new System.Drawing.Size(75, 20);
            this.box_Timestep.TabIndex = 6;
            // 
            // box_Spread
            // 
            this.box_Spread.Location = new System.Drawing.Point(186, 162);
            this.box_Spread.Name = "box_Spread";
            this.box_Spread.Size = new System.Drawing.Size(75, 20);
            this.box_Spread.TabIndex = 7;
            // 
            // label_Type
            // 
            this.label_Type.AutoSize = true;
            this.label_Type.Location = new System.Drawing.Point(21, 32);
            this.label_Type.Name = "label_Type";
            this.label_Type.Size = new System.Drawing.Size(31, 13);
            this.label_Type.TabIndex = 8;
            this.label_Type.Text = "Type";
            // 
            // label_basesens
            // 
            this.label_basesens.AutoSize = true;
            this.label_basesens.Location = new System.Drawing.Point(21, 58);
            this.label_basesens.Name = "label_basesens";
            this.label_basesens.Size = new System.Drawing.Size(81, 13);
            this.label_basesens.TabIndex = 9;
            this.label_basesens.Text = "Base Sensitivity";
            // 
            // label_maxsens
            // 
            this.label_maxsens.AutoSize = true;
            this.label_maxsens.Location = new System.Drawing.Point(21, 84);
            this.label_maxsens.Name = "label_maxsens";
            this.label_maxsens.Size = new System.Drawing.Size(121, 13);
            this.label_maxsens.TabIndex = 10;
            this.label_maxsens.Text = "Max Sensitivity Multiplier";
            // 
            // label_minsens
            // 
            this.label_minsens.AutoSize = true;
            this.label_minsens.Location = new System.Drawing.Point(21, 110);
            this.label_minsens.Name = "label_minsens";
            this.label_minsens.Size = new System.Drawing.Size(118, 13);
            this.label_minsens.TabIndex = 11;
            this.label_minsens.Text = "Min Sensitivity Multiplier";
            // 
            // label_timestep
            // 
            this.label_timestep.AutoSize = true;
            this.label_timestep.Location = new System.Drawing.Point(21, 136);
            this.label_timestep.Name = "label_timestep";
            this.label_timestep.Size = new System.Drawing.Size(50, 13);
            this.label_timestep.TabIndex = 12;
            this.label_timestep.Text = "Timestep";
            // 
            // label_spread
            // 
            this.label_spread.AutoSize = true;
            this.label_spread.Location = new System.Drawing.Point(21, 162);
            this.label_spread.Name = "label_spread";
            this.label_spread.Size = new System.Drawing.Size(41, 13);
            this.label_spread.TabIndex = 13;
            this.label_spread.Text = "Spread";
            // 
            // cbox_Type
            // 
            this.cbox_Type.FormattingEnabled = true;
            this.cbox_Type.Items.AddRange(new object[] {
            "Aggressive Curve",
            "Log Normal Curve"});
            this.cbox_Type.Location = new System.Drawing.Point(105, 32);
            this.cbox_Type.Name = "cbox_Type";
            this.cbox_Type.Size = new System.Drawing.Size(156, 21);
            this.cbox_Type.TabIndex = 14;
            this.cbox_Type.SelectedIndexChanged += new System.EventHandler(this.cbox_Type_SelectedIndexChanged);
            // 
            // label_smoothing
            // 
            this.label_smoothing.AutoSize = true;
            this.label_smoothing.Location = new System.Drawing.Point(21, 188);
            this.label_smoothing.Name = "label_smoothing";
            this.label_smoothing.Size = new System.Drawing.Size(57, 13);
            this.label_smoothing.TabIndex = 16;
            this.label_smoothing.Text = "Smoothing";
            // 
            // box_Smoothing
            // 
            this.box_Smoothing.Location = new System.Drawing.Point(186, 188);
            this.box_Smoothing.Name = "box_Smoothing";
            this.box_Smoothing.Size = new System.Drawing.Size(75, 20);
            this.box_Smoothing.TabIndex = 15;
            // 
            // btn_Regen_Curve
            // 
            this.btn_Regen_Curve.Location = new System.Drawing.Point(186, 324);
            this.btn_Regen_Curve.Name = "btn_Regen_Curve";
            this.btn_Regen_Curve.Size = new System.Drawing.Size(75, 50);
            this.btn_Regen_Curve.TabIndex = 17;
            this.btn_Regen_Curve.Text = "Regenerate Curve";
            this.btn_Regen_Curve.UseVisualStyleBackColor = true;
            this.btn_Regen_Curve.Click += new System.EventHandler(this.btn_Regen_Curve_Click);
            // 
            // sensCurveChart
            // 
            chartArea4.AxisX.IsMarginVisible = false;
            chartArea4.AxisX.Title = "Time";
            chartArea4.AxisX2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea4.AxisY.IsMarginVisible = false;
            chartArea4.AxisY.Title = "Sensitivity multiplier";
            chartArea4.AxisY2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea4.Name = "ChartArea1";
            this.sensCurveChart.ChartAreas.Add(chartArea4);
            legend4.Enabled = false;
            legend4.Name = "Legend1";
            this.sensCurveChart.Legends.Add(legend4);
            this.sensCurveChart.Location = new System.Drawing.Point(298, 32);
            this.sensCurveChart.Name = "sensCurveChart";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.sensCurveChart.Series.Add(series4);
            this.sensCurveChart.Size = new System.Drawing.Size(641, 342);
            this.sensCurveChart.TabIndex = 18;
            this.sensCurveChart.Text = "Sensitivity Curve";
            title4.Name = "Title1";
            title4.Text = "Sensitivity Curve";
            this.sensCurveChart.Titles.Add(title4);
            // 
            // label_mean
            // 
            this.label_mean.AutoSize = true;
            this.label_mean.Location = new System.Drawing.Point(21, 244);
            this.label_mean.Name = "label_mean";
            this.label_mean.Size = new System.Drawing.Size(67, 13);
            this.label_mean.TabIndex = 19;
            this.label_mean.Text = "Curve mean:";
            // 
            // label_std
            // 
            this.label_std.AutoSize = true;
            this.label_std.Location = new System.Drawing.Point(21, 271);
            this.label_std.Name = "label_std";
            this.label_std.Size = new System.Drawing.Size(29, 13);
            this.label_std.TabIndex = 20;
            this.label_std.Text = "Std: ";
            // 
            // label_sensmultiplier
            // 
            this.label_sensmultiplier.AutoSize = true;
            this.label_sensmultiplier.Location = new System.Drawing.Point(21, 296);
            this.label_sensmultiplier.Name = "label_sensmultiplier";
            this.label_sensmultiplier.Size = new System.Drawing.Size(112, 13);
            this.label_sensmultiplier.TabIndex = 21;
            this.label_sensmultiplier.Text = "Current sens multiplier:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 397);
            this.Controls.Add(this.label_sensmultiplier);
            this.Controls.Add(this.label_std);
            this.Controls.Add(this.label_mean);
            this.Controls.Add(this.sensCurveChart);
            this.Controls.Add(this.btn_Regen_Curve);
            this.Controls.Add(this.label_smoothing);
            this.Controls.Add(this.box_Smoothing);
            this.Controls.Add(this.cbox_Type);
            this.Controls.Add(this.label_spread);
            this.Controls.Add(this.label_timestep);
            this.Controls.Add(this.label_minsens);
            this.Controls.Add(this.label_maxsens);
            this.Controls.Add(this.label_basesens);
            this.Controls.Add(this.label_Type);
            this.Controls.Add(this.box_Spread);
            this.Controls.Add(this.box_Timestep);
            this.Controls.Add(this.box_Min_Sens);
            this.Controls.Add(this.box_Max_Sens);
            this.Controls.Add(this.box_BaseSens);
            this.Controls.Add(this.btn_Pause);
            this.Controls.Add(this.btn_Start);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sensCurveChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.Button btn_Pause;
        private System.Windows.Forms.TextBox box_BaseSens;
        private System.Windows.Forms.TextBox box_Max_Sens;
        private System.Windows.Forms.TextBox box_Min_Sens;
        private System.Windows.Forms.TextBox box_Timestep;
        private System.Windows.Forms.TextBox box_Spread;
        private System.Windows.Forms.Label label_Type;
        private System.Windows.Forms.Label label_basesens;
        private System.Windows.Forms.Label label_maxsens;
        private System.Windows.Forms.Label label_minsens;
        private System.Windows.Forms.Label label_timestep;
        private System.Windows.Forms.Label label_spread;
        private System.Windows.Forms.ComboBox cbox_Type;
        private System.Windows.Forms.Label label_smoothing;
        private System.Windows.Forms.TextBox box_Smoothing;
        private System.Windows.Forms.Button btn_Regen_Curve;
        private System.Windows.Forms.DataVisualization.Charting.Chart sensCurveChart;
        private System.Windows.Forms.Label label_mean;
        private System.Windows.Forms.Label label_std;
        private System.Windows.Forms.Label label_sensmultiplier;
    }
}

