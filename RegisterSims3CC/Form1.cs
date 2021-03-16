using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace RegisterSims3CC
{

    public partial class mainUI : Form
    {
        public mainUI()
        {
            InitializeComponent();
        }
        
        private void Reg_Click(object sender, EventArgs e)
        {
            //check if the game folder path is set first.
            //string gamefolder = gamepath.Text.Replace(@"\", @"\\");
            string gamefolder = gamepath.Text;
            if (string.IsNullOrEmpty(gamefolder))
            {
                string title = "No Folder Selected";
                string message = "Please select The Sims 3 Complete Collection folder.";
                MessageBox.Show(message, title);
            }
            else
            {
                /*
                string message = "The Selected folder is " + gamefolder + ".";
                MessageBox.Show(message);
                */

                RegistryKey SimsKey;

                //check the architecture of the OS
                if (Environment.Is64BitOperatingSystem)
                {
                    //check if registered keys exist
                    if ((Registry.LocalMachine.OpenSubKey("SOFTWARE\\WOW6432Node\\Electronic Arts\\Sims(Steam)")) != null)
                    {
                        Registry.LocalMachine.DeleteSubKeyTree("SOFTWARE\\WOW6432Node\\Electronic Arts\\Sims(Steam)");
                    }

                    if ((Registry.LocalMachine.OpenSubKey("SOFTWARE\\WOW6432Node\\Sims(Steam)")) != null)
                    {
                        Registry.LocalMachine.DeleteSubKeyTree("SOFTWARE\\WOW6432Node\\Sims(Steam)");
                    }

                    //register the base game sims 3
                    SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Electronic Arts");
                    SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Electronic Arts\\Sims(Steam)");
                    SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Electronic Arts\\Sims(Steam)\\The Sims 3");
                    SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Electronic Arts\\Sims(Steam)\\The Sims 3\\ergc");
                    SimsKey.SetValue("", "F8HH-YBIW-TGIR-BLRE-PACK");
                    SimsKey.Close();

                    SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Sims(Steam)");
                    SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Sims(Steam)\\The Sims 3");
                    SimsKey.SetValue("locale", "en-US");
                    SimsKey.SetValue("country", "US");
                    SimsKey.SetValue("displayname", "The Sims 3");
                    SimsKey.SetValue("exepath", gamefolder + "\\Game\\Bin\\TS3.exe");
                    SimsKey.SetValue("install dir", gamefolder);
                    SimsKey.SetValue("productid", 00001001, RegistryValueKind.DWord);
                    SimsKey.SetValue("sku", 00000007, RegistryValueKind.DWord);
                    SimsKey.SetValue("telemetry", 00000000, RegistryValueKind.DWord);
                    SimsKey.Close();


                    if ((Registry.ClassesRoot.OpenSubKey(".Sims3Pack")) == null)
                    {
                        //register .sims3pack file extension
                        SimsKey = Registry.ClassesRoot.CreateSubKey(".Sims3Pack");
                        SimsKey.SetValue("", "Sims3Pack");
                        SimsKey.Close();

                    }

                    if ((Registry.ClassesRoot.OpenSubKey("Sims3Pack")) == null)
                    {
                        //register .sims3pack file extension properties
                        SimsKey = Registry.ClassesRoot.CreateSubKey("Sims3Pack");
                        SimsKey.SetValue("", "The Sims 3 Custom Content");
                        SimsKey.Close();

                        SimsKey = Registry.ClassesRoot.CreateSubKey("Sims3Pack\\DefaultIcon");
                        SimsKey.SetValue("", gamefolder + "\\Game\\Bin\\Sims3LauncherW.exe,0");
                        SimsKey.Close();

                        SimsKey = Registry.ClassesRoot.CreateSubKey("Sims3Pack\\Shell");
                        SimsKey = Registry.ClassesRoot.CreateSubKey("Sims3Pack\\Shell\\Open");
                        SimsKey = Registry.ClassesRoot.CreateSubKey("Sims3Pack\\Shell\\Open\\Command");
                        SimsKey.SetValue("", "\"" + gamefolder + "\\Game\\Bin\\Sims3LauncherW.exe\" -file:\"%1\"");
                        SimsKey.Close();
                    }
                    
                    var selectedEPs = new List<string>();
                    var selectedSPs = new List<string>();

                    //World Adventures
                    if (EP1.Checked == true)
                    {
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Electronic Arts\\Sims(Steam)\\The Sims 3 World Adventures");
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Electronic Arts\\Sims(Steam)\\The Sims 3 World Adventures\\ergc");
                        SimsKey.SetValue("", "FP99-LAIJ-TGIR-MLRE-PACK");
                        SimsKey.Close();

                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Sims(Steam)\\The Sims 3 World Adventures");
                        SimsKey.SetValue("locale", "en-US");
                        SimsKey.SetValue("country", "US");
                        SimsKey.SetValue("displayname", "The Sims 3 World Adventures");
                        SimsKey.SetValue("exepath", gamefolder + "\\EP1\\Game\\Bin\\TS3EP01.exe");
                        SimsKey.SetValue("install dir", gamefolder + "\\EP1");
                        SimsKey.SetValue("productid", 00000002, RegistryValueKind.DWord);
                        SimsKey.SetValue("sku", 00000007, RegistryValueKind.DWord);
                        SimsKey.SetValue("telemetry", 00000000, RegistryValueKind.DWord);
                        SimsKey.Close();

                        selectedEPs.Add("The Sims 3 World Adventures");
                    }
                    //Ambitions
                    if (EP2.Checked == true)
                    {
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Electronic Arts\\Sims(Steam)\\The Sims 3 Ambitions");
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Electronic Arts\\Sims(Steam)\\The Sims 3 Ambitions\\ergc");
                        SimsKey.SetValue("", "F9PP-JAIA-TGIR-RLRE-PACK");
                        SimsKey.Close();

                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Sims(Steam)\\The Sims 3 Ambitions");
                        SimsKey.SetValue("locale", "en-US");
                        SimsKey.SetValue("contentid", "sims3_ep02_sku7");
                        SimsKey.SetValue("country", "US");
                        SimsKey.SetValue("displayname", "The Sims 3 Ambitions");
                        SimsKey.SetValue("ergcregpath", "Electronic Arts\\Sims(Steam)\\The Sims 3 Ambitions\\ergc");
                        SimsKey.SetValue("exepath", gamefolder + "\\EP2\\Game\\Bin\\TS3EP02.exe");
                        SimsKey.SetValue("install dir", gamefolder + "\\EP2");
                        SimsKey.SetValue("productid", 00000004, RegistryValueKind.DWord);
                        SimsKey.SetValue("sku", 00000007, RegistryValueKind.DWord);
                        SimsKey.SetValue("telemetry", 00000000, RegistryValueKind.DWord);
                        SimsKey.Close();

                        selectedEPs.Add("The Sims 3 Ambitions");
                    }

                    //Late Night
                    if (EP3.Checked == true)
                    {
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Electronic Arts\\Sims(Steam)\\The Sims 3 Late Night");
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Electronic Arts\\Sims(Steam)\\The Sims 3 Late Night\\ergc");
                        SimsKey.SetValue("", "F2LU-NAI4-TGIR-3LRE-PACK");
                        SimsKey.Close();

                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Sims(Steam)\\The Sims 3 Late Night");
                        SimsKey.SetValue("locale", "en-US");
                        SimsKey.SetValue("contentid", "sims3_ep03_sku7");
                        SimsKey.SetValue("country", "US");
                        SimsKey.SetValue("displayname", "The Sims 3 Late Night");
                        SimsKey.SetValue("ergcregpath", "Electronic Arts\\Sims(Steam)\\The Sims 3 Late Night\\ergc");
                        SimsKey.SetValue("exepath", gamefolder + "\\EP3\\Game\\Bin\\TS3EP03.exe");
                        SimsKey.SetValue("install dir", gamefolder + "\\EP3");
                        SimsKey.SetValue("productid", 00000006, RegistryValueKind.DWord);
                        SimsKey.SetValue("sku", 00000007, RegistryValueKind.DWord);
                        SimsKey.SetValue("telemetry", 00000000, RegistryValueKind.DWord);
                        SimsKey.Close();

                        selectedEPs.Add("The Sims 3 Late Night");
                    }

                    //Generations
                    if (EP4.Checked == true)
                    {
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Electronic Arts\\Sims(Steam)\\The Sims 3 Generations");
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Electronic Arts\\Sims(Steam)\\The Sims 3 Generations\\ergc");
                        SimsKey.SetValue("", "I4VV-MT0S-0ANA-DIUS-PACK");
                        SimsKey.Close();

                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Sims(Steam)\\The Sims 3 Generations");
                        SimsKey.SetValue("locale", "en-US");
                        SimsKey.SetValue("contentid", "sims3_ep04_dd");
                        SimsKey.SetValue("country", "US");
                        SimsKey.SetValue("displayname", "The Sims 3 Generations");
                        SimsKey.SetValue("ergcregpath", "Electronic Arts\\Sims(Steam)\\The Sims 3 Generations\\ergc");
                        SimsKey.SetValue("exepath", gamefolder + "\\EP4\\Game\\Bin\\TS3EP04.exe");
                        SimsKey.SetValue("install dir", gamefolder + "\\EP4");
                        SimsKey.SetValue("productid", 00000008, RegistryValueKind.DWord);
                        SimsKey.SetValue("sku", 00000007, RegistryValueKind.DWord);
                        SimsKey.SetValue("telemetry", 00000000, RegistryValueKind.DWord);
                        SimsKey.Close();

                        selectedEPs.Add("The Sims 3 Generations");
                    }

                    //Pets
                    if (EP5.Checked == true)
                    {
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Electronic Arts\\Sims(Steam)\\The Sims 3 Pets");
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Electronic Arts\\Sims(Steam)\\The Sims 3 Pets\\ergc");
                        SimsKey.SetValue("", "583B-UM0W-0ANA-DIUS-PACK");
                        SimsKey.Close();

                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Sims(Steam)\\The Sims 3 Pets");
                        SimsKey.SetValue("locale", "en-US");
                        SimsKey.SetValue("contentid", "sims3_ep05_dd");
                        SimsKey.SetValue("country", "US");
                        SimsKey.SetValue("displayname", "The Sims 3 Pets");
                        SimsKey.SetValue("ergcregpath", "Electronic Arts\\Sims(Steam)\\The Sims 3 Pets\\ergc");
                        SimsKey.SetValue("exepath", gamefolder + "\\EP5\\Game\\Bin\\TS3EP05.exe");
                        SimsKey.SetValue("install dir", gamefolder + "\\EP5");
                        SimsKey.SetValue("productid", 00000010, RegistryValueKind.DWord);
                        SimsKey.SetValue("sku", 00000007, RegistryValueKind.DWord);
                        SimsKey.SetValue("telemetry", 00000000, RegistryValueKind.DWord);
                        SimsKey.Close();

                        selectedEPs.Add("The Sims 3 Pets");
                    }

                    //Showtime
                    if (EP6.Checked == true)
                    {
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Electronic Arts\\Sims(Steam)\\The Sims 3 Showtime");
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Electronic Arts\\Sims(Steam)\\The Sims 3 Showtime\\ergc");
                        SimsKey.SetValue("", "FLR9-TZ1Q-0ANA-DIUS-PACK");
                        SimsKey.Close();

                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Sims(Steam)\\The Sims 3 Showtime");
                        SimsKey.SetValue("locale", "en-US");
                        SimsKey.SetValue("contentid", "sims3_ep06_dd");
                        SimsKey.SetValue("country", "US");
                        SimsKey.SetValue("displayname", "The Sims 3 Showtime");
                        SimsKey.SetValue("ergcregpath", "Electronic Arts\\Sims(Steam)\\The Sims 3 Showtime\\ergc");
                        SimsKey.SetValue("exepath", gamefolder + "\\EP6\\Game\\Bin\\TS3EP06.exe");
                        SimsKey.SetValue("install dir", gamefolder + "\\EP6");
                        SimsKey.SetValue("productid", 00000012, RegistryValueKind.DWord);
                        SimsKey.SetValue("sku", 00000007, RegistryValueKind.DWord);
                        SimsKey.SetValue("telemetry", 00000000, RegistryValueKind.DWord);
                        SimsKey.Close();

                        selectedEPs.Add("The Sims 3 Showtime");
                    }

                    //Supernatural
                    if (EP7.Checked == true)
                    {
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Electronic Arts\\Sims(Steam)\\The Sims 3 Supernatural");
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Electronic Arts\\Sims(Steam)\\The Sims 3 Supernatural\\ergc");
                        SimsKey.SetValue("", "UTHH-TE0G-0ANA-DIUS-PACK");
                        SimsKey.Close();

                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Sims(Steam)\\The Sims 3 Supernatural");
                        SimsKey.SetValue("locale", "en-US");
                        SimsKey.SetValue("contentid", "sims3_ep07_sku7");
                        SimsKey.SetValue("country", "US");
                        SimsKey.SetValue("displayname", "The Sims 3 Supernatural");
                        SimsKey.SetValue("ergcregpath", "Electronic Arts\\Sims(Steam)\\The Sims 3 Supernatural\\ergc");
                        SimsKey.SetValue("exepath", gamefolder + "\\EP7\\Game\\Bin\\TS3EP07.exe");
                        SimsKey.SetValue("install dir", gamefolder + "\\EP7");
                        SimsKey.SetValue("productid", 00000015, RegistryValueKind.DWord);
                        SimsKey.SetValue("sku", 00000007, RegistryValueKind.DWord);                        
                        SimsKey.SetValue("telemetry", 00000000, RegistryValueKind.DWord);
                        SimsKey.Close();

                        selectedEPs.Add("The Sims 3 Supernatural");
                    }

                    //Seasons
                    if (EP8.Checked == true)
                    {
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Electronic Arts\\Sims(Steam)\\The Sims 3 Seasons");
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Electronic Arts\\Sims(Steam)\\The Sims 3 Seasons\\ergc");
                        SimsKey.SetValue("", "03D5-D803-0ANA-DIUS-PACK");
                        SimsKey.Close();

                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Sims(Steam)\\The Sims 3 Seasons");
                        SimsKey.SetValue("locale", "en-US");
                        SimsKey.SetValue("contentid", "sims3_ep08_sku7");
                        SimsKey.SetValue("country", "US");
                        SimsKey.SetValue("displayname", "The Sims 3 Seasons");
                        SimsKey.SetValue("ergcregpath", "Electronic Arts\\Sims(Steam)\\The Sims 3 Seasons\\ergc");
                        SimsKey.SetValue("exepath", gamefolder + "\\EP8\\Game\\Bin\\TS3EP08.exe");
                        SimsKey.SetValue("install dir", gamefolder + "\\EP8");
                        SimsKey.SetValue("productid", 00000016, RegistryValueKind.DWord);
                        SimsKey.SetValue("sku", 00000007, RegistryValueKind.DWord);
                        SimsKey.SetValue("telemetry", 00000000, RegistryValueKind.DWord);
                        SimsKey.Close();

                        selectedEPs.Add("The Sims 3 Seasons");
                    }

                    //University Life
                    if (EP9.Checked == true)
                    {
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Electronic Arts\\Sims(Steam)\\The Sims 3 University Life");
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Electronic Arts\\Sims(Steam)\\The Sims 3 University Life\\ergc");
                        SimsKey.SetValue("", "8C6N-DM0L-0ANA-DIUS-PACK");
                        SimsKey.Close();

                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Sims(Steam)\\The Sims 3 University Life");
                        SimsKey.SetValue("locale", "en-US");
                        SimsKey.SetValue("contentid", "sims3_ep09_sku7");
                        SimsKey.SetValue("country", "US");
                        SimsKey.SetValue("displayname", "The Sims 3 University Life");
                        SimsKey.SetValue("ergcregpath", "Electronic Arts\\Sims(Steam)\\The Sims 3 University Life\\ergc");
                        SimsKey.SetValue("exepath", gamefolder + "\\EP9\\Game\\Bin\\TS3EP09.exe");
                        SimsKey.SetValue("install dir", gamefolder + "\\EP9");
                        SimsKey.SetValue("productid", 00000018, RegistryValueKind.DWord);
                        SimsKey.SetValue("sku", 00000007, RegistryValueKind.DWord);
                        SimsKey.SetValue("telemetry", 00000000, RegistryValueKind.DWord);
                        SimsKey.Close();

                        selectedEPs.Add("The Sims 3 University Life");
                    }

                    //Island Paradise
                    if (EP10.Checked == true)
                    {
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Electronic Arts\\Sims(Steam)\\The Sims 3 Island Paradise");
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Electronic Arts\\Sims(Steam)\\The Sims 3 Island Paradise\\ergc");
                        SimsKey.SetValue("", "EU4C-6R0E-0ANA-DIUS-PACK");
                        SimsKey.Close();

                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Sims(Steam)\\The Sims 3 Island Paradise");
                        SimsKey.SetValue("locale", "en-US");
                        SimsKey.SetValue("contentid", "sims3_Ep10_sku7");
                        SimsKey.SetValue("country", "US");
                        SimsKey.SetValue("displayname", "The Sims 3 Island Paradise");
                        SimsKey.SetValue("ergcregpath", "Electronic Arts\\Sims(Steam)\\The Sims 3 Island Paradise\\ergc");
                        SimsKey.SetValue("exepath", gamefolder + "\\EP10\\Game\\Bin\\TS3EP10.exe");
                        SimsKey.SetValue("install dir", gamefolder + "\\EP10");
                        SimsKey.SetValue("productid", 00000019, RegistryValueKind.DWord);
                        SimsKey.SetValue("sku", 00000007, RegistryValueKind.DWord);
                        SimsKey.SetValue("telemetry", 00000000, RegistryValueKind.DWord);
                        SimsKey.Close();

                        selectedEPs.Add("The Sims 3 Island Paradise");
                    }

                    //Into The Future
                    if (EP11.Checked == true)
                    {
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Electronic Arts\\Sims(Steam)\\The Sims 3 Into The Future");
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Electronic Arts\\Sims(Steam)\\The Sims 3 Into The Future\\ergc");
                        SimsKey.SetValue("", "W79R-4D0T-0ANA-DIUS-PACK");
                        SimsKey.Close();

                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Sims(Steam)\\The Sims 3 Into The Future");
                        SimsKey.SetValue("locale", "en-US");
                        SimsKey.SetValue("contentid", "sims3_ep11_sku7");
                        SimsKey.SetValue("country", "US");
                        SimsKey.SetValue("displayname", "The Sims 3 Into The Future");
                        SimsKey.SetValue("ergcregpath", "Electronic Arts\\Sims(Steam)\\The Sims 3 Into The Future\\ergc");
                        SimsKey.SetValue("exepath", gamefolder + "\\EP11\\Game\\Bin\\TS3EP11.exe");
                        SimsKey.SetValue("install dir", gamefolder + "\\EP11");
                        SimsKey.SetValue("productid", 00000021, RegistryValueKind.DWord);
                        SimsKey.SetValue("sku", 00000007, RegistryValueKind.DWord);
                        SimsKey.SetValue("telemetry", 00000000, RegistryValueKind.DWord);
                        SimsKey.Close();

                        selectedEPs.Add("The Sims 3 Into the Future");
                    }

                    //High-End Loft Stuff
                    if (SP1.Checked == true)
                    {
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Electronic Arts\\Sims(Steam)\\The Sims 3 High-End Loft Stuff");
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Electronic Arts\\Sims(Steam)\\The Sims 3 High-End Loft Stuff\\ergc");
                        SimsKey.SetValue("", "FGMD-HRI3-TGIR-VLRE-PACK");
                        SimsKey.Close();

                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Sims(Steam)\\The Sims 3 High-End Loft Stuff");
                        SimsKey.SetValue("locale", "en-US");
                        SimsKey.SetValue("contentid", "sims3_sp01_sku7");
                        SimsKey.SetValue("country", "US");
                        SimsKey.SetValue("displayname", "The Sims 3 High-End Loft Stuff");
                        SimsKey.SetValue("ergcregpath", "Electronic Arts\\Sims(Steam)\\The Sims 3 High-End Loft Stuff\\ergc");
                        SimsKey.SetValue("exepath", gamefolder + "\\SP1\\Game\\Bin\\TS3SP01.exe");
                        SimsKey.SetValue("install dir", gamefolder + "\\SP1");
                        SimsKey.SetValue("productid", 00000003, RegistryValueKind.DWord);
                        SimsKey.SetValue("sku", 00000007, RegistryValueKind.DWord);
                        SimsKey.SetValue("telemetry", 00000000, RegistryValueKind.DWord);
                        SimsKey.Close();

                        selectedSPs.Add("The Sims 3 High-End Loft Stuff");
                    }

                    //Fast Lane Stuff
                    if (SP2.Checked == true)
                    {
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Electronic Arts\\Sims(Steam)\\The Sims 3 Fast Lane Stuff");
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Electronic Arts\\Sims(Steam)\\The Sims 3 Fast Lane Stuff\\ergc");
                        SimsKey.SetValue("", "F6P7-YUIR-TGIR-BLRE-PACK");
                        SimsKey.Close();

                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Sims(Steam)\\The Sims 3 Fast Lane Stuff");
                        SimsKey.SetValue("locale", "en-US");
                        SimsKey.SetValue("contentid", "sims3_sp02_sku7");
                        SimsKey.SetValue("country", "US");
                        SimsKey.SetValue("displayname", "The Sims 3 Fast Lane Stuff");
                        SimsKey.SetValue("ergcregpath", "Electronic Arts\\Sims(Steam)\\The Sims 3 Fast Lane Stuff\\ergc");
                        SimsKey.SetValue("exepath", gamefolder + "\\SP2\\Game\\Bin\\TS3SP02.exe");
                        SimsKey.SetValue("install dir", gamefolder + "\\SP2");
                        SimsKey.SetValue("productid", 00000005, RegistryValueKind.DWord);
                        SimsKey.SetValue("sku", 00000007, RegistryValueKind.DWord);
                        SimsKey.SetValue("telemetry", 00000000, RegistryValueKind.DWord);
                        SimsKey.Close();

                        selectedSPs.Add("The Sims 3 Fast Lane Stuff");
                    }

                    //Outdoor Living Stuff
                    if (SP3.Checked == true)
                    {
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Electronic Arts\\Sims(Steam)\\The Sims 3 Outdoor Living Stuff");
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Electronic Arts\\Sims(Steam)\\The Sims 3 Outdoor Living Stuff\\ergc");
                        SimsKey.SetValue("", "OP7F-2A0D-0ANA-DIUS-PACK");
                        SimsKey.Close();

                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Sims(Steam)\\The Sims 3 Outdoor Living Stuff");
                        SimsKey.SetValue("locale", "en-US");
                        SimsKey.SetValue("contentid", "sims3_sp03_dd");
                        SimsKey.SetValue("country", "US");
                        SimsKey.SetValue("displayname", "The Sims 3 Outdoor Living Stuff");
                        SimsKey.SetValue("ergcregpath", "Electronic Arts\\Sims(Steam)\\The Sims 3 Outdoor Living Stuff\\ergc");
                        SimsKey.SetValue("exepath", gamefolder + "\\SP3\\Game\\Bin\\TS3SP03.exe");
                        SimsKey.SetValue("install dir", gamefolder + "\\SP3");
                        SimsKey.SetValue("productid", 00000007, RegistryValueKind.DWord);
                        SimsKey.SetValue("sku", 00000007, RegistryValueKind.DWord);
                        SimsKey.SetValue("telemetry", 00000000, RegistryValueKind.DWord);
                        SimsKey.Close();

                        selectedSPs.Add("The Sims 3 Outdoor Living Stuff");
                    }

                    //Town Life Stuff
                    if (SP4.Checked == true)
                    {
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Electronic Arts\\Sims(Steam)\\The Sims 3 Town Life Stuff");
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Electronic Arts\\Sims(Steam)\\The Sims 3 Town Life Stuff\\ergc");
                        SimsKey.SetValue("", "1N22-WU3J-0ANA-DIUS-PACK");
                        SimsKey.Close();

                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Sims(Steam)\\The Sims 3 Town Life Stuff");
                        SimsKey.SetValue("locale", "en-US");
                        SimsKey.SetValue("contentid", "sims3_sp04_dd");
                        SimsKey.SetValue("country", "US");
                        SimsKey.SetValue("displayname", "The Sims 3 Town Life Stuff");
                        SimsKey.SetValue("ergcregpath", "Electronic Arts\\Sims(Steam)\\The Sims 3 Town Life Stuff\\ergc");
                        SimsKey.SetValue("exepath", gamefolder + "\\SP4\\Game\\Bin\\TS3SP04.exe");
                        SimsKey.SetValue("install dir", gamefolder + "\\SP4");
                        SimsKey.SetValue("productid", 00000009, RegistryValueKind.DWord);
                        SimsKey.SetValue("sku", 00000007, RegistryValueKind.DWord);
                        SimsKey.SetValue("telemetry", 00000000, RegistryValueKind.DWord);
                        SimsKey.Close();

                        selectedSPs.Add("The Sims 3 Town Life Stuff");
                    }

                    //Master Suite Stuff
                    if (SP5.Checked == true)
                    {
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Electronic Arts\\Sims(Steam)\\The Sims 3 Master Suite Stuff");
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Electronic Arts\\Sims(Steam)\\The Sims 3 Master Suite Stuff\\ergc");
                        SimsKey.SetValue("", "FFVM-ZF1J-0ANA-DIUS-PACK");
                        SimsKey.Close();

                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Sims(Steam)\\The Sims 3 Master Suite Stuff");
                        SimsKey.SetValue("locale", "en-US");
                        SimsKey.SetValue("contentid", "sims3_sp05_dd");
                        SimsKey.SetValue("country", "US");
                        SimsKey.SetValue("displayname", "The Sims 3 Master Suite Stuff");
                        SimsKey.SetValue("ergcregpath", "Electronic Arts\\Sims(Steam)\\The Sims 3 Master Suite Stuff\\ergc");
                        SimsKey.SetValue("exepath", gamefolder + "\\SP5\\Game\\Bin\\TS3SP05.exe");
                        SimsKey.SetValue("install dir", gamefolder + "\\SP5");
                        SimsKey.SetValue("productid", 00000011, RegistryValueKind.DWord);
                        SimsKey.SetValue("sku", 00000007, RegistryValueKind.DWord);
                        SimsKey.SetValue("telemetry", 00000000, RegistryValueKind.DWord);
                        SimsKey.Close();

                        selectedSPs.Add("The Sims 3 Master Suite Stuff");
                    }

                    //Katy Perry's Sweet Treats
                    if (SP6.Checked == true)
                    {
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Electronic Arts\\Sims(Steam)\\The Sims 3 Katy Perry Sweet Treats");
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Electronic Arts\\Sims(Steam)\\The Sims 3 Katy Perry Sweet Treats\\ergc");
                        SimsKey.SetValue("", "7UZZ-C31D-0ANA-DIUS-PACK");
                        SimsKey.Close();

                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Sims(Steam)\\The Sims 3 Katy Perry Sweet Treats");
                        SimsKey.SetValue("locale", "en-US");
                        SimsKey.SetValue("contentid", "sims3_sp06_sku7");
                        SimsKey.SetValue("country", "US");
                        SimsKey.SetValue("displayname", "The Sims 3 Katy Perry's Sweet Treats");
                        SimsKey.SetValue("ergcregpath", "Electronic Arts\\Sims(Steam)\\The Sims 3 Katy Perry Sweet Treats\\ergc");
                        SimsKey.SetValue("exepath", gamefolder + "\\SP6\\Game\\Bin\\TS3SP06.exe");
                        SimsKey.SetValue("install dir", gamefolder + "\\SP6");
                        SimsKey.SetValue("productid", 00000013, RegistryValueKind.DWord);
                        SimsKey.SetValue("sku", 00000007, RegistryValueKind.DWord);
                        SimsKey.SetValue("telemetry", 00000000, RegistryValueKind.DWord);
                        SimsKey.Close();

                        selectedSPs.Add("The Sims 3 Katy Perry's Sweet Treats");
                    }

                    //Diesel Stuff
                    if (SP7.Checked == true)
                    {
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Electronic Arts\\Sims(Steam)\\The Sims 3 Diesel Stuff");
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Electronic Arts\\Sims(Steam)\\The Sims 3 Diesel Stuff\\ergc");
                        SimsKey.SetValue("", "T4PX-8N0J-0ANA-DIUS-PACK");
                        SimsKey.Close();

                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Sims(Steam)\\The Sims 3 Diesel Stuff");
                        SimsKey.SetValue("locale", "en-US");
                        SimsKey.SetValue("contentid", "sims3_sp07_sku7");
                        SimsKey.SetValue("country", "US");
                        SimsKey.SetValue("displayname", "The Sims 3 Diesel Stuff");
                        SimsKey.SetValue("ergcregpath", "Electronic Arts\\Sims(Steam)\\The Sims 3 Diesel Stuff\\ergc");
                        SimsKey.SetValue("exepath", gamefolder + "\\SP7\\Game\\Bin\\TS3SP07.exe");
                        SimsKey.SetValue("install dir", gamefolder + "\\SP7");
                        SimsKey.SetValue("productid", 00000014, RegistryValueKind.DWord);
                        SimsKey.SetValue("sku", 00000007, RegistryValueKind.DWord);
                        SimsKey.SetValue("telemetry", 00000000, RegistryValueKind.DWord);
                        SimsKey.Close();

                        selectedSPs.Add("The Sims 3 Diesel Stuff");
                    }

                    //70s, 80s, & 90s Stuff
                    if (SP8.Checked == true)
                    {
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Electronic Arts\\Sims(Steam)\\The Sims 3 70s, 80s, & 90s Stuff");
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Electronic Arts\\Sims(Steam)\\The Sims 3 70s, 80s, & 90s Stuff\\ergc");
                        SimsKey.SetValue("", "17QG-UL0H-0ANA-DIUS-PACK");
                        SimsKey.Close();

                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Sims(Steam)\\The Sims 3 70s 80s & 90s Stuff");
                        SimsKey.SetValue("locale", "en-US");
                        SimsKey.SetValue("contentid", "sims3_Sp08_sku7");
                        SimsKey.SetValue("country", "US");
                        SimsKey.SetValue("displayname", "The Sims 3 70s, 80s, & 90s Stuff");
                        SimsKey.SetValue("ergcregpath", "Electronic Arts\\Sims(Steam)\\The Sims 3 70s, 80s, & 90s Stuff\\ergc");
                        SimsKey.SetValue("exepath", gamefolder + "\\SP8\\Game\\Bin\\TS3SP08.exe");
                        SimsKey.SetValue("install dir", gamefolder + "\\SP8");
                        SimsKey.SetValue("productid", 00000017, RegistryValueKind.DWord);
                        SimsKey.SetValue("sku", 00000007, RegistryValueKind.DWord);
                        SimsKey.SetValue("telemetry", 00000000, RegistryValueKind.DWord);
                        SimsKey.Close();

                        selectedSPs.Add("The Sims 3 70s, 80s, and 90s Stuff");
                    }

                    //Movie Stuff
                    if (SP9.Checked == true)
                    {
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Electronic Arts\\Sims(Steam)\\The Sims 3 Movie Stuff");
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Electronic Arts\\Sims(Steam)\\The Sims 3 Movie Stuff\\ergc");
                        SimsKey.SetValue("", "ALXX-2S09-0ANA-DIUS-PACK");
                        SimsKey.Close();

                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Sims(Steam)\\The Sims 3 Movie Stuff");
                        SimsKey.SetValue("locale", "en-US");
                        SimsKey.SetValue("contentid", "sims3_sp09_sku7");
                        SimsKey.SetValue("country", "US");
                        SimsKey.SetValue("displayname", "The Sims 3 Movie Stuff");
                        SimsKey.SetValue("ergcregpath", "Electronic Arts\\Sims(Steam)\\The Sims 3 Movie Stuff\\ergc");
                        SimsKey.SetValue("exepath", gamefolder + "\\SP9\\Game\\Bin\\TS3SP09.exe");
                        SimsKey.SetValue("install dir", gamefolder + "\\SP9");
                        SimsKey.SetValue("productid", 00000020, RegistryValueKind.DWord);
                        SimsKey.SetValue("sku", 00000007, RegistryValueKind.DWord);
                        SimsKey.SetValue("telemetry", 00000000, RegistryValueKind.DWord);
                        SimsKey.Close();

                        selectedSPs.Add("The Sims 3 Movie Stuff");
                    }
                    
                    //let's display the registered pack/s via MessageBox
                    string title = "The Sims 3 Registration";
                    
                    if (selectedEPs.Count == 0 && selectedSPs.Count == 0)
                    {
                        string message = "No Expansion Packs or Stuff Packs selected. Furthermore, The Sims 3 Base Game has been registered.";
                        MessageBox.Show(message, title);
                    }
                    else if (selectedEPs.Count > 0 || selectedSPs.Count > 0)
                    {
                        string toDisplayEPs = string.Join(Environment.NewLine, selectedEPs);
                        string toDisplaySPs = string.Join(Environment.NewLine, selectedSPs);
                        
                        string message =
                            "The following pack/s has been registered:" +
                            System.Environment.NewLine +
                            System.Environment.NewLine +
                            toDisplayEPs +
                            System.Environment.NewLine +
                            toDisplaySPs;
                        MessageBox.Show(message, title);
                    }
                    
                }
                else //else if architecture is 32 bit
                {
                    //check if registered keys exist
                    if ((Registry.LocalMachine.OpenSubKey("SOFTWARE\\Electronic Arts\\Sims(Steam)")) != null)
                    {
                        Registry.LocalMachine.DeleteSubKeyTree("SOFTWARE\\Electronic Arts\\Sims(Steam)");
                    }

                    if ((Registry.LocalMachine.OpenSubKey("SOFTWARE\\Sims(Steam)")) != null)
                    {
                        Registry.LocalMachine.DeleteSubKeyTree("SOFTWARE\\Sims(Steam)");
                    }

                    //register the base game sims 3
                    SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Electronic Arts");
                    SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Electronic Arts\\Sims(Steam)");
                    SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Electronic Arts\\Sims(Steam)\\The Sims 3");
                    SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Electronic Arts\\Sims(Steam)\\The Sims 3\\ergc");
                    SimsKey.SetValue("", "F8HH-YBIW-TGIR-BLRE-PACK");
                    SimsKey.Close();

                    SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Sims(Steam)");
                    SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Sims(Steam)\\The Sims 3");
                    SimsKey.SetValue("locale", "en-US");
                    SimsKey.SetValue("country", "US");
                    SimsKey.SetValue("displayname", "The Sims 3");
                    SimsKey.SetValue("exepath", gamefolder + "\\Game\\Bin\\TS3.exe");
                    SimsKey.SetValue("install dir", gamefolder);
                    SimsKey.SetValue("productid", 00001001, RegistryValueKind.DWord);
                    SimsKey.SetValue("sku", 00000007, RegistryValueKind.DWord);
                    SimsKey.SetValue("telemetry", 00000000, RegistryValueKind.DWord);
                    SimsKey.Close();


                    if ((Registry.ClassesRoot.OpenSubKey(".Sims3Pack")) == null)
                    {
                        //register .sims3pack file extension
                        SimsKey = Registry.ClassesRoot.CreateSubKey(".Sims3Pack");
                        SimsKey.SetValue("", "Sims3Pack");
                        SimsKey.Close();

                    }

                    if ((Registry.ClassesRoot.OpenSubKey("Sims3Pack")) == null)
                    {
                        //register .sims3pack file extension properties
                        SimsKey = Registry.ClassesRoot.CreateSubKey("Sims3Pack");
                        SimsKey.SetValue("", "The Sims 3 Custom Content");
                        SimsKey.Close();

                        SimsKey = Registry.ClassesRoot.CreateSubKey("Sims3Pack\\DefaultIcon");
                        SimsKey.SetValue("", gamefolder + "\\Game\\Bin\\Sims3LauncherW.exe,0");
                        SimsKey.Close();

                        SimsKey = Registry.ClassesRoot.CreateSubKey("Sims3Pack\\Shell");
                        SimsKey = Registry.ClassesRoot.CreateSubKey("Sims3Pack\\Shell\\Open");
                        SimsKey = Registry.ClassesRoot.CreateSubKey("Sims3Pack\\Shell\\Open\\Command");
                        SimsKey.SetValue("", "\"" + gamefolder + "\\Game\\Bin\\Sims3LauncherW.exe\" -file:\"%1\"");
                        SimsKey.Close();
                    }

                    var selectedEPs = new List<string>();
                    var selectedSPs = new List<string>();

                    //World Adventures
                    if (EP1.Checked == true)
                    {
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Electronic Arts\\Sims(Steam)\\The Sims 3 World Adventures");
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Electronic Arts\\Sims(Steam)\\The Sims 3 World Adventures\\ergc");
                        SimsKey.SetValue("", "FP99-LAIJ-TGIR-MLRE-PACK");
                        SimsKey.Close();

                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Sims(Steam)\\The Sims 3 World Adventures");
                        SimsKey.SetValue("locale", "en-US");
                        SimsKey.SetValue("country", "US");
                        SimsKey.SetValue("displayname", "The Sims 3 World Adventures");
                        SimsKey.SetValue("exepath", gamefolder + "\\EP1\\Game\\Bin\\TS3EP01.exe");
                        SimsKey.SetValue("install dir", gamefolder + "\\EP1");
                        SimsKey.SetValue("productid", 00000002, RegistryValueKind.DWord);
                        SimsKey.SetValue("sku", 00000007, RegistryValueKind.DWord);
                        SimsKey.SetValue("telemetry", 00000000, RegistryValueKind.DWord);
                        SimsKey.Close();

                        selectedEPs.Add("The Sims 3 World Adventures");
                    }
                    //Ambitions
                    if (EP2.Checked == true)
                    {
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Electronic Arts\\Sims(Steam)\\The Sims 3 Ambitions");
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Electronic Arts\\Sims(Steam)\\The Sims 3 Ambitions\\ergc");
                        SimsKey.SetValue("", "F9PP-JAIA-TGIR-RLRE-PACK");
                        SimsKey.Close();

                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Sims(Steam)\\The Sims 3 Ambitions");
                        SimsKey.SetValue("locale", "en-US");
                        SimsKey.SetValue("contentid", "sims3_ep02_sku7");
                        SimsKey.SetValue("country", "US");
                        SimsKey.SetValue("displayname", "The Sims 3 Ambitions");
                        SimsKey.SetValue("ergcregpath", "Electronic Arts\\Sims(Steam)\\The Sims 3 Ambitions\\ergc");
                        SimsKey.SetValue("exepath", gamefolder + "\\EP2\\Game\\Bin\\TS3EP02.exe");
                        SimsKey.SetValue("install dir", gamefolder + "\\EP2");
                        SimsKey.SetValue("productid", 00000004, RegistryValueKind.DWord);
                        SimsKey.SetValue("sku", 00000007, RegistryValueKind.DWord);
                        SimsKey.SetValue("telemetry", 00000000, RegistryValueKind.DWord);
                        SimsKey.Close();

                        selectedEPs.Add("The Sims 3 Ambitions");
                    }

                    //Late Night
                    if (EP3.Checked == true)
                    {
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Electronic Arts\\Sims(Steam)\\The Sims 3 Late Night");
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Electronic Arts\\Sims(Steam)\\The Sims 3 Late Night\\ergc");
                        SimsKey.SetValue("", "F2LU-NAI4-TGIR-3LRE-PACK");
                        SimsKey.Close();

                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Sims(Steam)\\The Sims 3 Late Night");
                        SimsKey.SetValue("locale", "en-US");
                        SimsKey.SetValue("contentid", "sims3_ep03_sku7");
                        SimsKey.SetValue("country", "US");
                        SimsKey.SetValue("displayname", "The Sims 3 Late Night");
                        SimsKey.SetValue("ergcregpath", "Electronic Arts\\Sims(Steam)\\The Sims 3 Late Night\\ergc");
                        SimsKey.SetValue("exepath", gamefolder + "\\EP3\\Game\\Bin\\TS3EP03.exe");
                        SimsKey.SetValue("install dir", gamefolder + "\\EP3");
                        SimsKey.SetValue("productid", 00000006, RegistryValueKind.DWord);
                        SimsKey.SetValue("sku", 00000007, RegistryValueKind.DWord);
                        SimsKey.SetValue("telemetry", 00000000, RegistryValueKind.DWord);
                        SimsKey.Close();

                        selectedEPs.Add("The Sims 3 Late Night");
                    }

                    //Generations
                    if (EP4.Checked == true)
                    {
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Electronic Arts\\Sims(Steam)\\The Sims 3 Generations");
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Electronic Arts\\Sims(Steam)\\The Sims 3 Generations\\ergc");
                        SimsKey.SetValue("", "I4VV-MT0S-0ANA-DIUS-PACK");
                        SimsKey.Close();

                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Sims(Steam)\\The Sims 3 Generations");
                        SimsKey.SetValue("locale", "en-US");
                        SimsKey.SetValue("contentid", "sims3_ep04_dd");
                        SimsKey.SetValue("country", "US");
                        SimsKey.SetValue("displayname", "The Sims 3 Generations");
                        SimsKey.SetValue("ergcregpath", "Electronic Arts\\Sims(Steam)\\The Sims 3 Generations\\ergc");
                        SimsKey.SetValue("exepath", gamefolder + "\\EP4\\Game\\Bin\\TS3EP04.exe");
                        SimsKey.SetValue("install dir", gamefolder + "\\EP4");
                        SimsKey.SetValue("productid", 00000008, RegistryValueKind.DWord);
                        SimsKey.SetValue("sku", 00000007, RegistryValueKind.DWord);
                        SimsKey.SetValue("telemetry", 00000000, RegistryValueKind.DWord);
                        SimsKey.Close();

                        selectedEPs.Add("The Sims 3 Generations");
                    }

                    //Pets
                    if (EP5.Checked == true)
                    {
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Electronic Arts\\Sims(Steam)\\The Sims 3 Pets");
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Electronic Arts\\Sims(Steam)\\The Sims 3 Pets\\ergc");
                        SimsKey.SetValue("", "583B-UM0W-0ANA-DIUS-PACK");
                        SimsKey.Close();

                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Sims(Steam)\\The Sims 3 Pets");
                        SimsKey.SetValue("locale", "en-US");
                        SimsKey.SetValue("contentid", "sims3_ep05_dd");
                        SimsKey.SetValue("country", "US");
                        SimsKey.SetValue("displayname", "The Sims 3 Pets");
                        SimsKey.SetValue("ergcregpath", "Electronic Arts\\Sims(Steam)\\The Sims 3 Pets\\ergc");
                        SimsKey.SetValue("exepath", gamefolder + "\\EP5\\Game\\Bin\\TS3EP05.exe");
                        SimsKey.SetValue("install dir", gamefolder + "\\EP5");
                        SimsKey.SetValue("productid", 00000010, RegistryValueKind.DWord);
                        SimsKey.SetValue("sku", 00000007, RegistryValueKind.DWord);
                        SimsKey.SetValue("telemetry", 00000000, RegistryValueKind.DWord);
                        SimsKey.Close();

                        selectedEPs.Add("The Sims 3 Pets");
                    }

                    //Showtime
                    if (EP6.Checked == true)
                    {
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Electronic Arts\\Sims(Steam)\\The Sims 3 Showtime");
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Electronic Arts\\Sims(Steam)\\The Sims 3 Showtime\\ergc");
                        SimsKey.SetValue("", "FLR9-TZ1Q-0ANA-DIUS-PACK");
                        SimsKey.Close();

                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Sims(Steam)\\The Sims 3 Showtime");
                        SimsKey.SetValue("locale", "en-US");
                        SimsKey.SetValue("contentid", "sims3_ep06_dd");
                        SimsKey.SetValue("country", "US");
                        SimsKey.SetValue("displayname", "The Sims 3 Showtime");
                        SimsKey.SetValue("ergcregpath", "Electronic Arts\\Sims(Steam)\\The Sims 3 Showtime\\ergc");
                        SimsKey.SetValue("exepath", gamefolder + "\\EP6\\Game\\Bin\\TS3EP06.exe");
                        SimsKey.SetValue("install dir", gamefolder + "\\EP6");
                        SimsKey.SetValue("productid", 00000012, RegistryValueKind.DWord);
                        SimsKey.SetValue("sku", 00000007, RegistryValueKind.DWord);
                        SimsKey.SetValue("telemetry", 00000000, RegistryValueKind.DWord);
                        SimsKey.Close();

                        selectedEPs.Add("The Sims 3 Showtime");
                    }

                    //Supernatural
                    if (EP7.Checked == true)
                    {
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Electronic Arts\\Sims(Steam)\\The Sims 3 Supernatural");
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Electronic Arts\\Sims(Steam)\\The Sims 3 Supernatural\\ergc");
                        SimsKey.SetValue("", "UTHH-TE0G-0ANA-DIUS-PACK");
                        SimsKey.Close();

                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Sims(Steam)\\The Sims 3 Supernatural");
                        SimsKey.SetValue("locale", "en-US");
                        SimsKey.SetValue("contentid", "sims3_ep07_sku7");
                        SimsKey.SetValue("country", "US");
                        SimsKey.SetValue("displayname", "The Sims 3 Supernatural");
                        SimsKey.SetValue("ergcregpath", "Electronic Arts\\Sims(Steam)\\The Sims 3 Supernatural\\ergc");
                        SimsKey.SetValue("exepath", gamefolder + "\\EP7\\Game\\Bin\\TS3EP07.exe");
                        SimsKey.SetValue("install dir", gamefolder + "\\EP7");
                        SimsKey.SetValue("productid", 00000015, RegistryValueKind.DWord);
                        SimsKey.SetValue("sku", 00000007, RegistryValueKind.DWord);
                        SimsKey.SetValue("telemetry", 00000000, RegistryValueKind.DWord);
                        SimsKey.Close();

                        selectedEPs.Add("The Sims 3 Supernatural");
                    }

                    //Seasons
                    if (EP8.Checked == true)
                    {
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Electronic Arts\\Sims(Steam)\\The Sims 3 Seasons");
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Electronic Arts\\Sims(Steam)\\The Sims 3 Seasons\\ergc");
                        SimsKey.SetValue("", "03D5-D803-0ANA-DIUS-PACK");
                        SimsKey.Close();

                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Sims(Steam)\\The Sims 3 Seasons");
                        SimsKey.SetValue("locale", "en-US");
                        SimsKey.SetValue("contentid", "sims3_ep08_sku7");
                        SimsKey.SetValue("country", "US");
                        SimsKey.SetValue("displayname", "The Sims 3 Seasons");
                        SimsKey.SetValue("ergcregpath", "Electronic Arts\\Sims(Steam)\\The Sims 3 Seasons\\ergc");
                        SimsKey.SetValue("exepath", gamefolder + "\\EP8\\Game\\Bin\\TS3EP08.exe");
                        SimsKey.SetValue("install dir", gamefolder + "\\EP8");
                        SimsKey.SetValue("productid", 00000016, RegistryValueKind.DWord);
                        SimsKey.SetValue("sku", 00000007, RegistryValueKind.DWord);
                        SimsKey.SetValue("telemetry", 00000000, RegistryValueKind.DWord);
                        SimsKey.Close();

                        selectedEPs.Add("The Sims 3 Seasons");
                    }

                    //University Life
                    if (EP9.Checked == true)
                    {
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Electronic Arts\\Sims(Steam)\\The Sims 3 University Life");
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Electronic Arts\\Sims(Steam)\\The Sims 3 University Life\\ergc");
                        SimsKey.SetValue("", "8C6N-DM0L-0ANA-DIUS-PACK");
                        SimsKey.Close();

                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Sims(Steam)\\The Sims 3 University Life");
                        SimsKey.SetValue("locale", "en-US");
                        SimsKey.SetValue("contentid", "sims3_ep09_sku7");
                        SimsKey.SetValue("country", "US");
                        SimsKey.SetValue("displayname", "The Sims 3 University Life");
                        SimsKey.SetValue("ergcregpath", "Electronic Arts\\Sims(Steam)\\The Sims 3 University Life\\ergc");
                        SimsKey.SetValue("exepath", gamefolder + "\\EP9\\Game\\Bin\\TS3EP09.exe");
                        SimsKey.SetValue("install dir", gamefolder + "\\EP9");
                        SimsKey.SetValue("productid", 00000018, RegistryValueKind.DWord);
                        SimsKey.SetValue("sku", 00000007, RegistryValueKind.DWord);
                        SimsKey.SetValue("telemetry", 00000000, RegistryValueKind.DWord);
                        SimsKey.Close();

                        selectedEPs.Add("The Sims 3 University Life");
                    }

                    //Island Paradise
                    if (EP10.Checked == true)
                    {
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Electronic Arts\\Sims(Steam)\\The Sims 3 Island Paradise");
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Electronic Arts\\Sims(Steam)\\The Sims 3 Island Paradise\\ergc");
                        SimsKey.SetValue("", "EU4C-6R0E-0ANA-DIUS-PACK");
                        SimsKey.Close();

                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Sims(Steam)\\The Sims 3 Island Paradise");
                        SimsKey.SetValue("locale", "en-US");
                        SimsKey.SetValue("contentid", "sims3_Ep10_sku7");
                        SimsKey.SetValue("country", "US");
                        SimsKey.SetValue("displayname", "The Sims 3 Island Paradise");
                        SimsKey.SetValue("ergcregpath", "Electronic Arts\\Sims(Steam)\\The Sims 3 Island Paradise\\ergc");
                        SimsKey.SetValue("exepath", gamefolder + "\\EP10\\Game\\Bin\\TS3EP10.exe");
                        SimsKey.SetValue("install dir", gamefolder + "\\EP10");
                        SimsKey.SetValue("productid", 00000019, RegistryValueKind.DWord);
                        SimsKey.SetValue("sku", 00000007, RegistryValueKind.DWord);
                        SimsKey.SetValue("telemetry", 00000000, RegistryValueKind.DWord);
                        SimsKey.Close();

                        selectedEPs.Add("The Sims 3 Island Paradise");
                    }

                    //Into The Future
                    if (EP11.Checked == true)
                    {
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Electronic Arts\\Sims(Steam)\\The Sims 3 Into The Future");
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Electronic Arts\\Sims(Steam)\\The Sims 3 Into The Future\\ergc");
                        SimsKey.SetValue("", "W79R-4D0T-0ANA-DIUS-PACK");
                        SimsKey.Close();

                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Sims(Steam)\\The Sims 3 Into The Future");
                        SimsKey.SetValue("locale", "en-US");
                        SimsKey.SetValue("contentid", "sims3_ep11_sku7");
                        SimsKey.SetValue("country", "US");
                        SimsKey.SetValue("displayname", "The Sims 3 Into The Future");
                        SimsKey.SetValue("ergcregpath", "Electronic Arts\\Sims(Steam)\\The Sims 3 Into The Future\\ergc");
                        SimsKey.SetValue("exepath", gamefolder + "\\EP11\\Game\\Bin\\TS3EP11.exe");
                        SimsKey.SetValue("install dir", gamefolder + "\\EP11");
                        SimsKey.SetValue("productid", 00000021, RegistryValueKind.DWord);
                        SimsKey.SetValue("sku", 00000007, RegistryValueKind.DWord);
                        SimsKey.SetValue("telemetry", 00000000, RegistryValueKind.DWord);
                        SimsKey.Close();

                        selectedEPs.Add("The Sims 3 Into the Future");
                    }

                    //High-End Loft Stuff
                    if (SP1.Checked == true)
                    {
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Electronic Arts\\Sims(Steam)\\The Sims 3 High-End Loft Stuff");
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Electronic Arts\\Sims(Steam)\\The Sims 3 High-End Loft Stuff\\ergc");
                        SimsKey.SetValue("", "FGMD-HRI3-TGIR-VLRE-PACK");
                        SimsKey.Close();

                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Sims(Steam)\\The Sims 3 High-End Loft Stuff");
                        SimsKey.SetValue("locale", "en-US");
                        SimsKey.SetValue("contentid", "sims3_sp01_sku7");
                        SimsKey.SetValue("country", "US");
                        SimsKey.SetValue("displayname", "The Sims 3 High-End Loft Stuff");
                        SimsKey.SetValue("ergcregpath", "Electronic Arts\\Sims(Steam)\\The Sims 3 High-End Loft Stuff\\ergc");
                        SimsKey.SetValue("exepath", gamefolder + "\\SP1\\Game\\Bin\\TS3SP01.exe");
                        SimsKey.SetValue("install dir", gamefolder + "\\SP1");
                        SimsKey.SetValue("productid", 00000003, RegistryValueKind.DWord);
                        SimsKey.SetValue("sku", 00000007, RegistryValueKind.DWord);
                        SimsKey.SetValue("telemetry", 00000000, RegistryValueKind.DWord);
                        SimsKey.Close();

                        selectedSPs.Add("The Sims 3 High-End Loft Stuff");
                    }

                    //Fast Lane Stuff
                    if (SP2.Checked == true)
                    {
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Electronic Arts\\Sims(Steam)\\The Sims 3 Fast Lane Stuff");
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Electronic Arts\\Sims(Steam)\\The Sims 3 Fast Lane Stuff\\ergc");
                        SimsKey.SetValue("", "F6P7-YUIR-TGIR-BLRE-PACK");
                        SimsKey.Close();

                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Sims(Steam)\\The Sims 3 Fast Lane Stuff");
                        SimsKey.SetValue("locale", "en-US");
                        SimsKey.SetValue("contentid", "sims3_sp02_sku7");
                        SimsKey.SetValue("country", "US");
                        SimsKey.SetValue("displayname", "The Sims 3 Fast Lane Stuff");
                        SimsKey.SetValue("ergcregpath", "Electronic Arts\\Sims(Steam)\\The Sims 3 Fast Lane Stuff\\ergc");
                        SimsKey.SetValue("exepath", gamefolder + "\\SP2\\Game\\Bin\\TS3SP02.exe");
                        SimsKey.SetValue("install dir", gamefolder + "\\SP2");
                        SimsKey.SetValue("productid", 00000005, RegistryValueKind.DWord);
                        SimsKey.SetValue("sku", 00000007, RegistryValueKind.DWord);
                        SimsKey.SetValue("telemetry", 00000000, RegistryValueKind.DWord);
                        SimsKey.Close();

                        selectedSPs.Add("The Sims 3 Fast Lane Stuff");
                    }

                    //Outdoor Living Stuff
                    if (SP3.Checked == true)
                    {
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Electronic Arts\\Sims(Steam)\\The Sims 3 Outdoor Living Stuff");
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Electronic Arts\\Sims(Steam)\\The Sims 3 Outdoor Living Stuff\\ergc");
                        SimsKey.SetValue("", "OP7F-2A0D-0ANA-DIUS-PACK");
                        SimsKey.Close();

                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Sims(Steam)\\The Sims 3 Outdoor Living Stuff");
                        SimsKey.SetValue("locale", "en-US");
                        SimsKey.SetValue("contentid", "sims3_sp03_dd");
                        SimsKey.SetValue("country", "US");
                        SimsKey.SetValue("displayname", "The Sims 3 Outdoor Living Stuff");
                        SimsKey.SetValue("ergcregpath", "Electronic Arts\\Sims(Steam)\\The Sims 3 Outdoor Living Stuff\\ergc");
                        SimsKey.SetValue("exepath", gamefolder + "\\SP3\\Game\\Bin\\TS3SP03.exe");
                        SimsKey.SetValue("install dir", gamefolder + "\\SP3");
                        SimsKey.SetValue("productid", 00000007, RegistryValueKind.DWord);
                        SimsKey.SetValue("sku", 00000007, RegistryValueKind.DWord);
                        SimsKey.SetValue("telemetry", 00000000, RegistryValueKind.DWord);
                        SimsKey.Close();

                        selectedSPs.Add("The Sims 3 Outdoor Living Stuff");
                    }

                    //Town Life Stuff
                    if (SP4.Checked == true)
                    {
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Electronic Arts\\Sims(Steam)\\The Sims 3 Town Life Stuff");
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Electronic Arts\\Sims(Steam)\\The Sims 3 Town Life Stuff\\ergc");
                        SimsKey.SetValue("", "1N22-WU3J-0ANA-DIUS-PACK");
                        SimsKey.Close();

                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Sims(Steam)\\The Sims 3 Town Life Stuff");
                        SimsKey.SetValue("locale", "en-US");
                        SimsKey.SetValue("contentid", "sims3_sp04_dd");
                        SimsKey.SetValue("country", "US");
                        SimsKey.SetValue("displayname", "The Sims 3 Town Life Stuff");
                        SimsKey.SetValue("ergcregpath", "Electronic Arts\\Sims(Steam)\\The Sims 3 Town Life Stuff\\ergc");
                        SimsKey.SetValue("exepath", gamefolder + "\\SP4\\Game\\Bin\\TS3SP04.exe");
                        SimsKey.SetValue("install dir", gamefolder + "\\SP4");
                        SimsKey.SetValue("productid", 00000009, RegistryValueKind.DWord);
                        SimsKey.SetValue("sku", 00000007, RegistryValueKind.DWord);
                        SimsKey.SetValue("telemetry", 00000000, RegistryValueKind.DWord);
                        SimsKey.Close();

                        selectedSPs.Add("The Sims 3 Town Life Stuff");
                    }

                    //Master Suite Stuff
                    if (SP5.Checked == true)
                    {
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Electronic Arts\\Sims(Steam)\\The Sims 3 Master Suite Stuff");
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Electronic Arts\\Sims(Steam)\\The Sims 3 Master Suite Stuff\\ergc");
                        SimsKey.SetValue("", "FFVM-ZF1J-0ANA-DIUS-PACK");
                        SimsKey.Close();

                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Sims(Steam)\\The Sims 3 Master Suite Stuff");
                        SimsKey.SetValue("locale", "en-US");
                        SimsKey.SetValue("contentid", "sims3_sp05_dd");
                        SimsKey.SetValue("country", "US");
                        SimsKey.SetValue("displayname", "The Sims 3 Master Suite Stuff");
                        SimsKey.SetValue("ergcregpath", "Electronic Arts\\Sims(Steam)\\The Sims 3 Master Suite Stuff\\ergc");
                        SimsKey.SetValue("exepath", gamefolder + "\\SP5\\Game\\Bin\\TS3SP05.exe");
                        SimsKey.SetValue("install dir", gamefolder + "\\SP5");
                        SimsKey.SetValue("productid", 00000011, RegistryValueKind.DWord);
                        SimsKey.SetValue("sku", 00000007, RegistryValueKind.DWord);
                        SimsKey.SetValue("telemetry", 00000000, RegistryValueKind.DWord);
                        SimsKey.Close();

                        selectedSPs.Add("The Sims 3 Master Suite Stuff");
                    }

                    //Katy Perry's Sweet Treats
                    if (SP6.Checked == true)
                    {
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Electronic Arts\\Sims(Steam)\\The Sims 3 Katy Perry Sweet Treats");
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Electronic Arts\\Sims(Steam)\\The Sims 3 Katy Perry Sweet Treats\\ergc");
                        SimsKey.SetValue("", "7UZZ-C31D-0ANA-DIUS-PACK");
                        SimsKey.Close();

                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Sims(Steam)\\The Sims 3 Katy Perry Sweet Treats");
                        SimsKey.SetValue("locale", "en-US");
                        SimsKey.SetValue("contentid", "sims3_sp06_sku7");
                        SimsKey.SetValue("country", "US");
                        SimsKey.SetValue("displayname", "The Sims 3 Katy Perry's Sweet Treats");
                        SimsKey.SetValue("ergcregpath", "Electronic Arts\\Sims(Steam)\\The Sims 3 Katy Perry Sweet Treats\\ergc");
                        SimsKey.SetValue("exepath", gamefolder + "\\SP6\\Game\\Bin\\TS3SP06.exe");
                        SimsKey.SetValue("install dir", gamefolder + "\\SP6");
                        SimsKey.SetValue("productid", 00000013, RegistryValueKind.DWord);
                        SimsKey.SetValue("sku", 00000007, RegistryValueKind.DWord);
                        SimsKey.SetValue("telemetry", 00000000, RegistryValueKind.DWord);
                        SimsKey.Close();

                        selectedSPs.Add("The Sims 3 Katy Perry's Sweet Treats");
                    }

                    //Diesel Stuff
                    if (SP7.Checked == true)
                    {
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Electronic Arts\\Sims(Steam)\\The Sims 3 Diesel Stuff");
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Electronic Arts\\Sims(Steam)\\The Sims 3 Diesel Stuff\\ergc");
                        SimsKey.SetValue("", "T4PX-8N0J-0ANA-DIUS-PACK");
                        SimsKey.Close();

                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Sims(Steam)\\The Sims 3 Diesel Stuff");
                        SimsKey.SetValue("locale", "en-US");
                        SimsKey.SetValue("contentid", "sims3_sp07_sku7");
                        SimsKey.SetValue("country", "US");
                        SimsKey.SetValue("displayname", "The Sims 3 Diesel Stuff");
                        SimsKey.SetValue("ergcregpath", "Electronic Arts\\Sims(Steam)\\The Sims 3 Diesel Stuff\\ergc");
                        SimsKey.SetValue("exepath", gamefolder + "\\SP7\\Game\\Bin\\TS3SP07.exe");
                        SimsKey.SetValue("install dir", gamefolder + "\\SP7");
                        SimsKey.SetValue("productid", 00000014, RegistryValueKind.DWord);
                        SimsKey.SetValue("sku", 00000007, RegistryValueKind.DWord);
                        SimsKey.SetValue("telemetry", 00000000, RegistryValueKind.DWord);
                        SimsKey.Close();

                        selectedSPs.Add("The Sims 3 Diesel Stuff");
                    }

                    //70s, 80s, & 90s Stuff
                    if (SP8.Checked == true)
                    {
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Electronic Arts\\Sims(Steam)\\The Sims 3 70s, 80s, & 90s Stuff");
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Electronic Arts\\Sims(Steam)\\The Sims 3 70s, 80s, & 90s Stuff\\ergc");
                        SimsKey.SetValue("", "17QG-UL0H-0ANA-DIUS-PACK");
                        SimsKey.Close();

                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Sims(Steam)\\The Sims 3 70s 80s & 90s Stuff");
                        SimsKey.SetValue("locale", "en-US");
                        SimsKey.SetValue("contentid", "sims3_Sp08_sku7");
                        SimsKey.SetValue("country", "US");
                        SimsKey.SetValue("displayname", "The Sims 3 70s, 80s, & 90s Stuff");
                        SimsKey.SetValue("ergcregpath", "Electronic Arts\\Sims(Steam)\\The Sims 3 70s, 80s, & 90s Stuff\\ergc");
                        SimsKey.SetValue("exepath", gamefolder + "\\SP8\\Game\\Bin\\TS3SP08.exe");
                        SimsKey.SetValue("install dir", gamefolder + "\\SP8");
                        SimsKey.SetValue("productid", 00000017, RegistryValueKind.DWord);
                        SimsKey.SetValue("sku", 00000007, RegistryValueKind.DWord);
                        SimsKey.SetValue("telemetry", 00000000, RegistryValueKind.DWord);
                        SimsKey.Close();

                        selectedSPs.Add("The Sims 3 70s, 80s, and 90s Stuff");
                    }

                    //Movie Stuff
                    if (SP9.Checked == true)
                    {
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Electronic Arts\\Sims(Steam)\\The Sims 3 Movie Stuff");
                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Electronic Arts\\Sims(Steam)\\The Sims 3 Movie Stuff\\ergc");
                        SimsKey.SetValue("", "ALXX-2S09-0ANA-DIUS-PACK");
                        SimsKey.Close();

                        SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Sims(Steam)\\The Sims 3 Movie Stuff");
                        SimsKey.SetValue("locale", "en-US");
                        SimsKey.SetValue("contentid", "sims3_sp09_sku7");
                        SimsKey.SetValue("country", "US");
                        SimsKey.SetValue("displayname", "The Sims 3 Movie Stuff");
                        SimsKey.SetValue("ergcregpath", "Electronic Arts\\Sims(Steam)\\The Sims 3 Movie Stuff\\ergc");
                        SimsKey.SetValue("exepath", gamefolder + "\\SP9\\Game\\Bin\\TS3SP09.exe");
                        SimsKey.SetValue("install dir", gamefolder + "\\SP9");
                        SimsKey.SetValue("productid", 00000020, RegistryValueKind.DWord);
                        SimsKey.SetValue("sku", 00000007, RegistryValueKind.DWord);
                        SimsKey.SetValue("telemetry", 00000000, RegistryValueKind.DWord);
                        SimsKey.Close();

                        selectedSPs.Add("The Sims 3 Movie Stuff");
                    }

                    //let's display the registered pack/s via MessageBox
                    string title = "The Sims 3 Registration";

                    if (selectedEPs.Count == 0 && selectedSPs.Count == 0)
                    {
                        string message = "No Expansion Packs or Stuff Packs selected. Furthermore, The Sims 3 Base Game has been registered.";
                        MessageBox.Show(message, title);
                    }
                    else if (selectedEPs.Count > 0 || selectedSPs.Count > 0)
                    {
                        string toDisplayEPs = string.Join(Environment.NewLine, selectedEPs);
                        string toDisplaySPs = string.Join(Environment.NewLine, selectedSPs);

                        string message =
                            "The following pack/s has been registered:" +
                            System.Environment.NewLine +
                            System.Environment.NewLine +
                            toDisplayEPs +
                            System.Environment.NewLine +
                            toDisplaySPs;
                        MessageBox.Show(message, title);
                    }
                }


            }
        }

        private void EP0_CheckedChanged_1(object sender, EventArgs e)
        {
            if (EP0.Checked == true)
            {
                EP1.Checked = true;
                EP2.Checked = true;
                EP3.Checked = true;
                EP4.Checked = true;
                EP5.Checked = true;
                EP6.Checked = true;
                EP7.Checked = true;
                EP8.Checked = true;
                EP9.Checked = true;
                EP10.Checked = true;
                EP11.Checked = true;
            }
            else if (EP0.Checked == false)
            {
                EP1.Checked = false;
                EP2.Checked = false;
                EP3.Checked = false;
                EP4.Checked = false;
                EP5.Checked = false;
                EP6.Checked = false;
                EP7.Checked = false;
                EP8.Checked = false;
                EP9.Checked = false;
                EP10.Checked = false;
                EP11.Checked = false;
            }
        }

        private void EP1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void EP2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void EP3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void EP4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void EP5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void EP6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void EP7_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void EP8_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void EP9_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void EP10_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void EP11_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void SP0_CheckedChanged(object sender, EventArgs e)
        {
            if (SP0.Checked == true)
            {
                SP1.Checked = true;
                SP2.Checked = true;
                SP3.Checked = true;
                SP4.Checked = true;
                SP5.Checked = true;
                SP6.Checked = true;
                SP7.Checked = true;
                SP8.Checked = true;
                SP9.Checked = true;
            }
            else if (SP0.Checked == false)
            {
                SP1.Checked = false;
                SP2.Checked = false;
                SP3.Checked = false;
                SP4.Checked = false;
                SP5.Checked = false;
                SP6.Checked = false;
                SP7.Checked = false;
                SP8.Checked = false;
                SP9.Checked = false;
            }
        }

        private void SP1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void SP2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void SP3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void SP4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void SP5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void SP6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void SP7_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void SP8_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void SP9_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void gamepath_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void EPGroup_Enter(object sender, EventArgs e)
        {

        }

        private void SPGroup_Enter(object sender, EventArgs e)
        {

        }

        private void selfolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog selectpath = new FolderBrowserDialog();
            selectpath.Description = "Select the game folder of the Sims 3 Complete Collection:";

            if (selectpath.ShowDialog() == DialogResult.OK)
            {
                gamepath.Text = selectpath.SelectedPath;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Unreg_Click(object sender, EventArgs e)
        {
            DialogResult confirmUnregister = MessageBox.Show("This will remove all registered Expansion Packs and/or Stuff Packs in this computer. Are you sure you want to proceed?", "Remove The Sims 3 CC", MessageBoxButtons.YesNo);
            if (confirmUnregister == DialogResult.Yes)
            {
                //check the architecture of the OS
                if (Environment.Is64BitOperatingSystem)
                {    
                    if((Registry.LocalMachine.OpenSubKey("SOFTWARE\\WOW6432Node\\Electronic Arts\\Sims(Steam)")) != null)
                    {
                        Registry.LocalMachine.DeleteSubKeyTree("SOFTWARE\\WOW6432Node\\Electronic Arts\\Sims(Steam)");
                    }    
                    
                    if((Registry.LocalMachine.OpenSubKey("SOFTWARE\\WOW6432Node\\Sims(Steam)")) != null)
                    {
                        Registry.LocalMachine.DeleteSubKeyTree("SOFTWARE\\WOW6432Node\\Sims(Steam)");
                    }

                    if ((Registry.ClassesRoot.OpenSubKey(".Sims3Pack")) != null)
                    {
                        Registry.ClassesRoot.DeleteSubKeyTree(".Sims3Pack");
                    }

                    if ((Registry.ClassesRoot.OpenSubKey("Sims3Pack")) != null)
                    {
                        Registry.ClassesRoot.DeleteSubKeyTree("Sims3Pack");
                    }

                    string title = "Remove The Sims 3 CC";
                    string message = "The Sims 3 Complete Collection has been removed.";
                    MessageBox.Show(message, title);
                }
                else //else if architecture is 32bit
                {
                    if ((Registry.LocalMachine.OpenSubKey("SOFTWARE\\Electronic Arts\\Sims(Steam)")) != null)
                    {
                        Registry.LocalMachine.DeleteSubKeyTree("SOFTWARE\\Electronic Arts\\Sims(Steam)");
                    }

                    if ((Registry.LocalMachine.OpenSubKey("SOFTWARE\\Sims(Steam)")) != null)
                    {
                        Registry.LocalMachine.DeleteSubKeyTree("SOFTWARE\\Sims(Steam)");
                    }

                    if ((Registry.ClassesRoot.OpenSubKey(".Sims3Pack")) != null)
                    {
                        Registry.ClassesRoot.DeleteSubKeyTree(".Sims3Pack");
                    }

                    if ((Registry.ClassesRoot.OpenSubKey("Sims3Pack")) != null)
                    {
                        Registry.ClassesRoot.DeleteSubKeyTree("Sims3Pack");
                    }

                    string title = "Remove The Sims 3 CC";
                    string message = "The Sims 3 Complete Collection has been removed.";
                    MessageBox.Show(message, title);
                }
            }
        }

        private void aboutme_Click(object sender, EventArgs e)
        {
            string title = "Behind the Scenes";
            string message =
                "Sul Sul! Welcome to Register the Sims 3 Complete Collection (Portable)." +
                System.Environment.NewLine +
                System.Environment.NewLine +
                "This is for personal use only. Select the expansion packs and the stuff packs of your favorite, and you're ready to play." +
                System.Environment.NewLine +
                System.Environment.NewLine +
                "Note: Do not modify the files and folders inside the Sims 3 Complete Collection folder. Also, please make sure that system requirements for this game are met as well, along with the required software prerequisites in order to play." +
                System.Environment.NewLine +
                System.Environment.NewLine +
                "Credits to Electronic Arts and The Sims Team for developing this game and rld for enabling the game to run." +
                System.Environment.NewLine +
                System.Environment.NewLine +
                "Story behind this development:" +
                System.Environment.NewLine +
                "I'm just a simmer, and since I'm an avid fan of the Sims, I have decided to learn C# for the first time and built this app where players can select any of the Sims 3 expansion packs and/or stuff packs that they want to include in the Sims 3, specify the location of the Sims 3 Complete Collection folder and registers the Sims 3 along with the selected pack/s to the Windows Registry. Furthermore, my purpose on building this app is to make this game portable and be played on any Windows PC without undergoing such installation processes. I did not modify nor edit any of the codes inside the Sims 3 game itself." +
                System.Environment.NewLine +
                System.Environment.NewLine +
                "I hope this tool may become useful to you. Moreover, if you enjoy playing the Sims 3, please support the developers by purchasing their products." +
                System.Environment.NewLine +
                System.Environment.NewLine +
                "Thank you and enjoy playing the Sims 3 with LIFE. Dag Dag!" +
                System.Environment.NewLine +
                System.Environment.NewLine +
                "- ash10ben10";
            MessageBox.Show(message, title);   
        }
        
        private void mainUI_Load(object sender, EventArgs e)
        {

        }

        //this enables draging the window somewhere in the screen
        private void mainUI_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
        Point lastPoint;
        private void mainUI_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

    }
}
