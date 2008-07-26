//=================================================================
// fwcCalForm.cs
//=================================================================
// PowerSDR is a C# implementation of a Software Defined Radio.
// Copyright (C) 2004-2008  FlexRadio Systems
//
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.
//
// You may contact us via email at: sales@flex-radio.com.
// Paper mail may be sent to: 
//    FlexRadio Systems
//    8900 Marybank Dr.
//    Austin, TX 78750
//    USA
//=================================================================

using System;
using System.Diagnostics;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

namespace PowerSDR
{
	public class FWCCalForm : System.Windows.Forms.Form
	{
		#region Variable Declaration

		private Console console;
		private System.Windows.Forms.ButtonTS btnSaveToEEPROM;
		private System.Windows.Forms.ButtonTS btnRestoreFromEEPROM;
		private System.ComponentModel.Container components = null;

		#endregion

		#region Constructor and Destructor

		public FWCCalForm(Console c)
		{
			InitializeComponent();
			console = c;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FWCCalForm));
			this.btnSaveToEEPROM = new System.Windows.Forms.ButtonTS();
			this.btnRestoreFromEEPROM = new System.Windows.Forms.ButtonTS();
			this.SuspendLayout();
			// 
			// btnSaveToEEPROM
			// 
			this.btnSaveToEEPROM.Image = null;
			this.btnSaveToEEPROM.Location = new System.Drawing.Point(144, 16);
			this.btnSaveToEEPROM.Name = "btnSaveToEEPROM";
			this.btnSaveToEEPROM.Size = new System.Drawing.Size(112, 48);
			this.btnSaveToEEPROM.TabIndex = 0;
			this.btnSaveToEEPROM.Text = "Save Calibration Data To EEPROM";
			this.btnSaveToEEPROM.Click += new System.EventHandler(this.btnSaveToEEPROM_Click);
			// 
			// btnRestoreFromEEPROM
			// 
			this.btnRestoreFromEEPROM.Image = null;
			this.btnRestoreFromEEPROM.Location = new System.Drawing.Point(16, 16);
			this.btnRestoreFromEEPROM.Name = "btnRestoreFromEEPROM";
			this.btnRestoreFromEEPROM.Size = new System.Drawing.Size(112, 48);
			this.btnRestoreFromEEPROM.TabIndex = 15;
			this.btnRestoreFromEEPROM.Text = "Restore Calibration Data To Database from EEPROM";
			this.btnRestoreFromEEPROM.Click += new System.EventHandler(this.btnRestoreFromEEPROM_Click);
			// 
			// FWCCalForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(272, 78);
			this.Controls.Add(this.btnRestoreFromEEPROM);
			this.Controls.Add(this.btnSaveToEEPROM);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FWCCalForm";
			this.Text = "FLEX-5000 EEPROM";
			this.ResumeLayout(false);

		}
		#endregion

		#region Event Handlers

		private void btnSaveToEEPROM_Click(object sender, System.EventArgs e)
		{
			DialogResult dr = MessageBox.Show("Are you sure you want to write the current database calibration values to the EEPROM?",
				"Overwrite EEPROM?",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question);
			if(dr == DialogResult.No) return;
			
			btnSaveToEEPROM.BackColor = console.ButtonSelectedColor;
			btnSaveToEEPROM.Enabled = false;
			Thread t = new Thread(new ThreadStart(WriteToEEPROM));
			t.Name = "Write To EEPROM Thread";
			t.IsBackground = true;
			t.Priority = ThreadPriority.Normal;
			t.Start();
		}

		private void WriteToEEPROM()
		{
			console.FLEX5000WriteCalData();
			btnSaveToEEPROM.BackColor = SystemColors.Control;
			btnSaveToEEPROM.Enabled = true;
		}

		private void btnRestoreFromEEPROM_Click(object sender, System.EventArgs e)
		{
			DialogResult dr = MessageBox.Show("Are you sure you want to read the current EEPROM data into\n"+
				"the database overwriting any current values?",
				"Overwrite database?",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question);
			if(dr == DialogResult.No) return;
			
			btnRestoreFromEEPROM.BackColor = console.ButtonSelectedColor;
			btnRestoreFromEEPROM.Enabled = false;
			Thread t = new Thread(new ThreadStart(RestoreFromEEPROM));
			t.Name = "Write To EEPROM Thread";
			t.IsBackground = true;
			t.Priority = ThreadPriority.Normal;
			t.Start();
		}

		private void RestoreFromEEPROM()
		{
			console.FLEX5000RestoreCalData();
			btnRestoreFromEEPROM.BackColor = SystemColors.Control;
			btnRestoreFromEEPROM.Enabled = true;
		}

		#endregion
	}
}
