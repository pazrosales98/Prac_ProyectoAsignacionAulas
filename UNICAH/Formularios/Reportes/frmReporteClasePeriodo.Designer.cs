
namespace UNICAH.Formularios.Reportes
{
    partial class frmReporteClasePeriodo
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.ClasesPeriodosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DsReportes = new UNICAH.Formularios.Reportes.DsReportes();
            this.btnBuscarPeriodo = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPeriodo = new System.Windows.Forms.TextBox();
            this.clasesPeriodoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvClasesPorPeriodo = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ClasesPeriodosTableAdapter = new UNICAH.Formularios.Reportes.DsReportesTableAdapters.ClasesPeriodosTableAdapter();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ClasesPeriodosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsReportes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clasesPeriodoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ClasesPeriodosBindingSource
            // 
            this.ClasesPeriodosBindingSource.DataMember = "ClasesPeriodos";
            this.ClasesPeriodosBindingSource.DataSource = this.DsReportes;
            // 
            // DsReportes
            // 
            this.DsReportes.DataSetName = "DsReportes";
            this.DsReportes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnBuscarPeriodo
            // 
            this.btnBuscarPeriodo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnBuscarPeriodo.FlatAppearance.BorderSize = 0;
            this.btnBuscarPeriodo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarPeriodo.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarPeriodo.Image = global::UNICAH.Properties.Resources.magnify;
            this.btnBuscarPeriodo.Location = new System.Drawing.Point(195, 54);
            this.btnBuscarPeriodo.Name = "btnBuscarPeriodo";
            this.btnBuscarPeriodo.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnBuscarPeriodo.Size = new System.Drawing.Size(40, 30);
            this.btnBuscarPeriodo.TabIndex = 83;
            this.btnBuscarPeriodo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscarPeriodo.UseVisualStyleBackColor = false;
            this.btnBuscarPeriodo.Click += new System.EventHandler(this.btnBuscarPeriodo_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 17);
            this.label4.TabIndex = 82;
            this.label4.Text = "Periodo";
            // 
            // txtPeriodo
            // 
            this.txtPeriodo.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPeriodo.Location = new System.Drawing.Point(12, 58);
            this.txtPeriodo.Name = "txtPeriodo";
            this.txtPeriodo.ReadOnly = true;
            this.txtPeriodo.Size = new System.Drawing.Size(177, 23);
            this.txtPeriodo.TabIndex = 81;
            this.txtPeriodo.TextChanged += new System.EventHandler(this.txtPeriodo_TextChanged);
            // 
            // clasesPeriodoBindingSource
            // 
            this.clasesPeriodoBindingSource.DataMember = "ClasesPeriodo";
            // 
            // rpvClasesPorPeriodo
            // 
            this.rpvClasesPorPeriodo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rpvClasesPorPeriodo.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            reportDataSource1.Name = "ClasesPorPeriodo";
            reportDataSource1.Value = this.ClasesPeriodosBindingSource;
            this.rpvClasesPorPeriodo.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvClasesPorPeriodo.LocalReport.ReportEmbeddedResource = "UNICAH.Formularios.Reportes.rptClasesPeriodo.rdlc";
            this.rpvClasesPorPeriodo.Location = new System.Drawing.Point(12, 100);
            this.rpvClasesPorPeriodo.Name = "rpvClasesPorPeriodo";
            this.rpvClasesPorPeriodo.ServerReport.BearerToken = null;
            this.rpvClasesPorPeriodo.Size = new System.Drawing.Size(657, 539);
            this.rpvClasesPorPeriodo.TabIndex = 84;
            // 
            // ClasesPeriodosTableAdapter
            // 
            this.ClasesPeriodosTableAdapter.ClearBeforeFill = true;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(214, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(239, 19);
            this.label8.TabIndex = 85;
            this.label8.Text = "Reporte de Clases por Periodo";
            // 
            // frmReporteClasePeriodo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 651);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.rpvClasesPorPeriodo);
            this.Controls.Add(this.btnBuscarPeriodo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPeriodo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmReporteClasePeriodo";
            this.Text = "frmReporteClasePeriodo";
            this.Load += new System.EventHandler(this.frmReporteClasePeriodo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ClasesPeriodosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsReportes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clasesPeriodoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnBuscarPeriodo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPeriodo;
        private System.Windows.Forms.BindingSource clasesPeriodoBindingSource;
        //private DataSets.Unicah unicah;
        //private DataSets.UnicahTableAdapters.ClasesPeriodoTableAdapter clasesPeriodoTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer rpvClasesPorPeriodo;
        private System.Windows.Forms.BindingSource ClasesPeriodosBindingSource;
        private DsReportes DsReportes;
        private DsReportesTableAdapters.ClasesPeriodosTableAdapter ClasesPeriodosTableAdapter;
        private System.Windows.Forms.Label label8;
    }
}