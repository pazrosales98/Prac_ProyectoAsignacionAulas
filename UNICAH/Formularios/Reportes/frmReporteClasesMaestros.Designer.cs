
namespace UNICAH.Formularios.Reportes
{
    partial class frmReporteClasesMaestros
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
            this.label8 = new System.Windows.Forms.Label();
            this.txtMaestro = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPeriodo = new System.Windows.Forms.TextBox();
            this.btnBuscarAula = new System.Windows.Forms.Button();
            this.btnBuscarPeriodo = new System.Windows.Forms.Button();
            this.rptClasesMaestros = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ClasesMaestroTableAdapter = new UNICAH.Formularios.Reportes.DsReportesTableAdapters.ClasesMaestroTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ClasesPeriodosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsReportes)).BeginInit();
            this.SuspendLayout();
            // 
            // ClasesPeriodosBindingSource
            // 
            this.ClasesPeriodosBindingSource.DataMember = "ClasesMaestro";
            this.ClasesPeriodosBindingSource.DataSource = this.DsReportes;
            // 
            // DsReportes
            // 
            this.DsReportes.DataSetName = "DsReportes";
            this.DsReportes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(256, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 17);
            this.label8.TabIndex = 96;
            this.label8.Text = "Maestro";
            // 
            // txtMaestro
            // 
            this.txtMaestro.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaestro.Location = new System.Drawing.Point(259, 67);
            this.txtMaestro.Name = "txtMaestro";
            this.txtMaestro.ReadOnly = true;
            this.txtMaestro.Size = new System.Drawing.Size(177, 23);
            this.txtMaestro.TabIndex = 95;
            this.txtMaestro.TextChanged += new System.EventHandler(this.txtMaestro_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 17);
            this.label4.TabIndex = 93;
            this.label4.Text = "Periodo";
            // 
            // txtPeriodo
            // 
            this.txtPeriodo.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPeriodo.Location = new System.Drawing.Point(12, 67);
            this.txtPeriodo.Name = "txtPeriodo";
            this.txtPeriodo.ReadOnly = true;
            this.txtPeriodo.Size = new System.Drawing.Size(177, 23);
            this.txtPeriodo.TabIndex = 92;
            this.txtPeriodo.TextChanged += new System.EventHandler(this.txtPeriodo_TextChanged);
            // 
            // btnBuscarAula
            // 
            this.btnBuscarAula.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnBuscarAula.FlatAppearance.BorderSize = 0;
            this.btnBuscarAula.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarAula.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarAula.Image = global::UNICAH.Properties.Resources.magnify;
            this.btnBuscarAula.Location = new System.Drawing.Point(442, 63);
            this.btnBuscarAula.Name = "btnBuscarAula";
            this.btnBuscarAula.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnBuscarAula.Size = new System.Drawing.Size(40, 30);
            this.btnBuscarAula.TabIndex = 97;
            this.btnBuscarAula.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscarAula.UseVisualStyleBackColor = false;
            this.btnBuscarAula.Click += new System.EventHandler(this.btnBuscarAula_Click);
            // 
            // btnBuscarPeriodo
            // 
            this.btnBuscarPeriodo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnBuscarPeriodo.FlatAppearance.BorderSize = 0;
            this.btnBuscarPeriodo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarPeriodo.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarPeriodo.Image = global::UNICAH.Properties.Resources.magnify;
            this.btnBuscarPeriodo.Location = new System.Drawing.Point(195, 63);
            this.btnBuscarPeriodo.Name = "btnBuscarPeriodo";
            this.btnBuscarPeriodo.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnBuscarPeriodo.Size = new System.Drawing.Size(40, 30);
            this.btnBuscarPeriodo.TabIndex = 94;
            this.btnBuscarPeriodo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscarPeriodo.UseVisualStyleBackColor = false;
            this.btnBuscarPeriodo.Click += new System.EventHandler(this.btnBuscarPeriodo_Click);
            // 
            // rptClasesMaestros
            // 
            reportDataSource1.Name = "ClasesMaestro";
            reportDataSource1.Value = this.ClasesPeriodosBindingSource;
            this.rptClasesMaestros.LocalReport.DataSources.Add(reportDataSource1);
            this.rptClasesMaestros.LocalReport.ReportEmbeddedResource = "UNICAH.Formularios.Reportes.rptClasesMaestro.rdlc";
            this.rptClasesMaestros.Location = new System.Drawing.Point(12, 119);
            this.rptClasesMaestros.Name = "rptClasesMaestros";
            this.rptClasesMaestros.ServerReport.BearerToken = null;
            this.rptClasesMaestros.Size = new System.Drawing.Size(657, 520);
            this.rptClasesMaestros.TabIndex = 98;
            // 
            // ClasesMaestroTableAdapter
            // 
            this.ClasesMaestroTableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(208, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 19);
            this.label1.TabIndex = 99;
            this.label1.Text = "Reporte de Clases por Maestro";
            // 
            // frmReporteClasesMaestros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 651);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rptClasesMaestros);
            this.Controls.Add(this.btnBuscarAula);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtMaestro);
            this.Controls.Add(this.btnBuscarPeriodo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPeriodo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmReporteClasesMaestros";
            this.Text = "frmReporteClasesMaestros";
            this.Load += new System.EventHandler(this.frmReporteClasesMaestros_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ClasesPeriodosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsReportes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBuscarAula;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMaestro;
        private System.Windows.Forms.Button btnBuscarPeriodo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPeriodo;
        private Microsoft.Reporting.WinForms.ReportViewer rptClasesMaestros;
        private System.Windows.Forms.BindingSource ClasesPeriodosBindingSource;
        private DsReportes DsReportes;
        private DsReportesTableAdapters.ClasesMaestroTableAdapter ClasesMaestroTableAdapter;
        private System.Windows.Forms.Label label1;
    }
}