﻿using System;
using Eto.Forms;
using Eto.Drawing;

namespace GUI.Desktop
{
	class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			new Application(Eto.Platform.Detect).Run(new MainForm());
		}
	}
}