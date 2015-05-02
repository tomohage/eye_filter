using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Eyetribe_project.Models;
using Eyetribe_project.Views;

namespace Eyetribe_project {
    class Program {
        [STAThread]
        static void Main (string[] args) {
            EyeFilterSetting eye_filter_setting = new EyeFilterSetting();
            Application.EnableVisualStyles();
            Application.Run(eye_filter_setting);
            Console.WriteLine("end");

        }
    }
}
