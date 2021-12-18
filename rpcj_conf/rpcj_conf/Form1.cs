using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Media;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace rpcj_conf
{
    public partial class Form1 : Form
    {
        [DllImport("winmm.dll")]
        public static extern int waveOutSetVolume(IntPtr hwo, uint dwVolume);

        //Files
        const string filename = "config.ini";
        const string gamefile = "RPCJ.exe";
        const string regkey = @"SOFTWARE\\Kurtis\\RPCJ";
        const string regval = "UnityGraphicsQuality_h1669003810";

        //Vars
        FileConfigManager.FCM config = new FileConfigManager.FCM();
        string[] data, value;
        bool tmp_bool;
        double tmp_dword;
        char[] copyr = {'t','u','K','r','s','i'};
        StreamWriter sw;
        SoundPlayer snd = new SoundPlayer(Properties.Resources.test_snd);
        int NewVolume;
        uint NewVolumeAllChannels;

        public Form1()
        {
            InitializeComponent();
            if (!File.Exists(filename))
            {
                sw = new StreamWriter(filename,false,Encoding.Default);
                sw.Write(Properties.Resources.config);
                sw.Close();
            }
                
            //Load data
            config.ReadAllData(filename, out data, out value);
            cb_graphics.SelectedIndex = 0;
            gfx_texture.SelectedIndex = 0;
            gfx_aniso.SelectedIndex = 0;
            gfx_aa.SelectedIndex = 0;
            gfx_bone.SelectedIndex = 0;
            gfx_vsync.SelectedIndex = 0;
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == "MouseSens")
                {
                    double.TryParse(value[i].Replace(".",","), out tmp_dword);
                    ch_invmouse.Checked = tmp_dword < 0;
                    tmp_dword = Math.Abs(tmp_dword);
                    if (tmp_dword < (double)nm_mousesens.Minimum ||
                        tmp_dword > (double)nm_mousesens.Maximum)
                        tmp_dword = (double)nm_mousesens.Minimum;
                    nm_mousesens.Value = (decimal)tmp_dword;
                }
                else if (data[i] == "ScopeSens")
                {
                    double.TryParse(value[i].Replace(".", ","), out tmp_dword);
                    ch_invmouse.Checked = tmp_dword < 0;
                    tmp_dword = Math.Abs(tmp_dword);
                    if (tmp_dword < (double)nm_mousesens.Minimum ||
                        tmp_dword > (double)nm_mousesens.Maximum)
                        tmp_dword = (double)nm_mousesens.Minimum;
                    nm_scopesens.Value = (decimal)tmp_dword;
                }
                else if (data[i] == "Volume")
                {
                    double.TryParse(value[i].Replace(".", ","), out tmp_dword);
                    tb_vol.Value = (int)(tmp_dword * 100);
                    NewVolume = ((ushort.MaxValue / 100) * tb_vol.Value);
                    // Set the same volume for both the left and the right channels
                    NewVolumeAllChannels = (((uint)NewVolume & 0x0000ffff) | ((uint)NewVolume << 16));
                    // Set the volume
                    waveOutSetVolume(IntPtr.Zero, NewVolumeAllChannels);
                }
                else if (data[i] == "OverrideGfx")
                {
                    bool.TryParse(value[i], out tmp_bool);
                    ch_gover.Checked = tmp_bool;
                    if (!tmp_bool)
                        EnableOVRD(false);
                }
                else if (data[i] == "PixelLights")
                {
                    double.TryParse(value[i], out tmp_dword);
                    gfx_pixel.Value = (decimal)tmp_dword;
                }
                else if (data[i] == "Texture")
                {
                    double.TryParse(value[i], out tmp_dword);
                    if (tmp_dword < 0 || tmp_dword > gfx_texture.Items.Count - 1)
                        tmp_dword = 0;
                    gfx_texture.SelectedIndex = (int)tmp_dword;
                }
                else if (data[i] == "Aniso")
                {
                    double.TryParse(value[i], out tmp_dword);
                    if (tmp_dword < 0 || tmp_dword > gfx_aniso.Items.Count - 1)
                        tmp_dword = 0;
                    gfx_aniso.SelectedIndex = (int)tmp_dword;
                }
                else if (data[i] == "AALevel")
                {
                    double.TryParse(value[i], out tmp_dword);
                    if (tmp_dword < 0 || tmp_dword > gfx_aa.Items.Count - 1)
                        tmp_dword = 0;
                    gfx_aa.SelectedIndex = (int)tmp_dword;
                }
                /*else if (data[i] == "Particles")
                {
                    bool.TryParse(value[i], out tmp_bool);
                    gfx_part.Checked = tmp_bool;
                }*/
                else if (data[i] == "BoneQuality")
                {
                    double.TryParse(value[i], out tmp_dword);
                    if (tmp_dword < 0 || tmp_dword > gfx_bone.Items.Count - 1)
                        tmp_dword = 0;
                    gfx_bone.SelectedIndex = (int)tmp_dword;
                }
                else if (data[i] == "Vsync")
                {
                    double.TryParse(value[i], out tmp_dword);
                    if (tmp_dword < 0 || tmp_dword > gfx_vsync.Items.Count - 1)
                        tmp_dword = 0;
                    gfx_vsync.SelectedIndex = (int)tmp_dword;
                }
            }

            RegistryKey reg = Registry.CurrentUser.OpenSubKey(regkey);
            if (reg == null)
            {
                reg = Registry.CurrentUser;
                reg.CreateSubKey(regkey);
                reg = Registry.CurrentUser.OpenSubKey(regkey, true);
            }
            object tmp = reg.GetValue(regval);

            if (tmp != null)
            {
                double.TryParse(tmp.ToString(), out tmp_dword);
                cb_graphics.SelectedIndex = (int)tmp_dword;
            }
            else
            {
                reg.SetValue(regval, 3, RegistryValueKind.DWord);
                cb_graphics.SelectedIndex = 3;
            }
            tmp_bool = default(bool);
            tmp_dword = default(double);
            reg.Close();
            tmp = null;
        }

        private void EnableOVRD(bool input)
        {
            gfx_aa.Enabled = input;
            gfx_aniso.Enabled = input;
            gfx_bone.Enabled = input;
            //gfx_part.Enabled = input;
            gfx_pixel.Enabled = input;
            gfx_texture.Enabled = input;
            gfx_vsync.Enabled = input;
        }

        private void ch_gover_CheckedChanged(object sender, EventArgs e)
        {
            EnableOVRD(ch_gover.Checked);
        }

        private void bt_launch_Click(object sender, EventArgs e)
        {
            if (File.Exists(gamefile))
            {
                System.Diagnostics.Process.Start(gamefile);
                Application.Exit();
            }
            else
                MessageBox.Show("A játék indítója nem található!", "Hiba",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void bt_save_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == "MouseSens")
                    value[i] = (ch_invmouse.Checked ? "-" : null) + nm_mousesens.Value.ToString("0.0").Replace(",", ".");
                else if (data[i] == "ScopeSens")
                    value[i] = (ch_invmouse.Checked ? "-" : null) + nm_scopesens.Value.ToString("0.0").Replace(",", ".");
                else if (data[i] == "Volume")
                    value[i] = ((float)tb_vol.Value/100).ToString("0.0").Replace(",", ".");
                else if (data[i] == "OverrideGfx")
                    value[i] = ch_gover.Checked.ToString();
                else if (data[i] == "PixelLights")
                    value[i] = gfx_pixel.Value.ToString();
                else if (data[i] == "Texture")
                    value[i] = gfx_texture.SelectedIndex.ToString();
                else if (data[i] == "Aniso")
                    value[i] = gfx_aniso.SelectedIndex.ToString();
                else if (data[i] == "AALevel")
                    value[i] = gfx_aa.SelectedIndex.ToString();
                /*else if (data[i] == "Particles")
                    value[i] = gfx_part.Checked.ToString();*/
                else if (data[i] == "BoneQuality")
                    value[i] = gfx_bone.SelectedIndex.ToString();
                else if (data[i] == "Vsync")
                    value[i] = gfx_vsync.SelectedIndex.ToString();
            }
            config.ChangeAllData(filename, data, value);
            //Registry
            RegistryKey reg = Registry.CurrentUser.OpenSubKey(regkey, true);
            if (reg == null)
            {
                reg = Registry.CurrentUser;
                reg.CreateSubKey(regkey);
                reg = Registry.CurrentUser.OpenSubKey(regkey, true);
            }
            reg.SetValue(regval, cb_graphics.SelectedIndex, RegistryValueKind.DWord);
            reg = null;
            MessageBox.Show("Adatok elmentve.","Info",
                MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void bt_about_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "A programot " +
                copyr[2] + copyr[1] + copyr[3] + copyr[0] + copyr[5] + copyr[4] +
                " készítette (2014),\n" +
                "C# 2008 Express Edition-ban íródott.",
                "Rossz PC Játékok Sorozat Konfiguráció",
                MessageBoxButtons.OK,MessageBoxIcon.Information
                );
        }

        private void bt_test_Click(object sender, EventArgs e)
        {
            snd.Play();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            NewVolume = ((ushort.MaxValue / 100) * tb_vol.Value);
            // Set the same volume for both the left and the right channels
            NewVolumeAllChannels = (((uint)NewVolume & 0x0000ffff) | ((uint)NewVolume << 16));
            // Set the volume
            waveOutSetVolume(IntPtr.Zero, NewVolumeAllChannels);
        }
    }
}