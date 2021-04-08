namespace SkylandersManagerUI
{
    public class Figures
    {
        // This handles all the Figure data
        public static string Var;
        public static string Fig;
        public static short MyAddress;
        public static byte[] CharacterID = new byte[2];
        public static byte[] CharacterVariant = new byte[2];

        static void Area0orArea1()
        {
            // "Use Area 0" Marker 0x089
            // "Use Area 1" Marker 0x249
            Area0 = WholeFile[0x89];
            Area1 = WholeFile[0x249];
        }

        static void SetArea0AndArea1()
        {
            if (Area0 != 0xFF)
            {
                Area0 += 0x1;
            }
            else
            {
                Area0 = 0x0;
            }
            if (Area1 != 0xFF)
            {
                Area1 += 0x1;
            }
            else
            {
                Area1 = 0x0;
            }
            // Debug Code
            // Area0 = 0x0
            // Area1 = 0x1
            WholeFile[0x89] = Area0;
            WholeFile[0x249] = Area1;
            WholeFile[0x112] = Area0;
            WholeFile[0x2D2] = Area1;
        }

        static bool blnNoCode = false;
        static void DetermineWrite()
        {
            if (blnNoCode)
            {
                DisableWrite();
            }
            else
            {
                EnableWrite();
            }
        }

        static bool blnBottomFigure = false;
        static void BottomFigure()
        {
            if (blnBottomFigure)
            {

            }
        }

        static void DisableWrite()
        {
            frmMain.SaldeStatus.Text = "Error.  Character ID and Variant ID Unavailable.";
            frmMain.Save_Enc_ToolStripMenuItem.Enabled = false;
            frmMain.Save_Dec_ToolStripMenuItem.Enabled = false;
            frmMain.WriteSkylanderToolStripMenuItem.Enabled = false;
            frmMain.WriteSecondFigureToolStripMenuItem.Enabled = false;
        }

        static void EnableWrite()
        {
            frmMain.SaldeStatus.Text = "Ready";
            frmMain.Save_Enc_ToolStripMenuItem.Enabled = true;
            frmMain.Save_Dec_ToolStripMenuItem.Enabled = true;
            if (Portal.blnPortal)
            {
                frmMain.WriteSkylanderToolStripMenuItem.Enabled = true;
                frmMain.WriteSecondFigureToolStripMenuItem.Enabled = true;
            }
        }
        #region " Write Methods "
        static void EditCharacterIDVariant()
        {
            // MessageBox.Show("CharID0: " & CharacterID[0])
            // MessageBox.Show("CharID1: " & CharacterID[1])
            // MessageBox.Show("CharVar0: " & CharacterVariant[0])
            // MessageBox.Show("CharVar1: " & CharacterVariant[1])
            // Character ID
            WholeFile[0x10] = CharacterID[0];
            WholeFile[0x11] = CharacterID[1];

            // Variant ID
            WholeFile[0x1C] = CharacterVariant[0];
            WholeFile[0x1D] = CharacterVariant[1];
        }

    static void Fixing_Bytes()
        {
            // This is Special Byte Writing Stuff.
            var Counter = 0;

            // Set the Header Bytes to Read Only
            WholeFile[0x36] = 0xF;
            WholeFile[0x37] = 0xF;
            WholeFile[0x38] = 0xF;
            WholeFile[0x39] = 0x69;
            // First Read/Write Block
            WholeFile[0x76] = 0x7F;
            WholeFile[0x77] = 0xF;
            WholeFile[0x78] = 0x8;
            WholeFile[0x79] = 0x69;

            // Second Read/Write Block
            WholeFile[0xB6] = 0x7F;
            WholeFile[0xB7] = 0xF;
            WholeFile[0xB8] = 0x8;
            WholeFile[0xB9] = 0x69;

            // Third Read/Write Block
            WholeFile[0xF6] = 0x7F;
            WholeFile[0xF7] = 0xF;
            WholeFile[0xF8] = 0x8;
            WholeFile[0xF9] = 0x69;

            // Foruth Read/Write Block
            WholeFile[0x136] = 0x7F;
            WholeFile[0x137] = 0xF;
            WholeFile[0x138] = 0x8;
            WholeFile[0x139] = 0x69;

            // Fifth Read/Write Block
            WholeFile[0x176] = 0x7F;
            WholeFile[0x177] = 0xF;
            WholeFile[0x178] = 0x8;
            WholeFile[0x179] = 0x69;

            // Sixth Read/Write Block
            WholeFile[0x1B6] = 0x7F;
            WholeFile[0x1B7] = 0xF;
            WholeFile[0x1B8] = 0x8;
            WholeFile[0x1B9] = 0x69;

            // Seventh Read/Write Block
            WholeFile[0x1F6] = 0x7F;
            WholeFile[0x1F7] = 0xF;
            WholeFile[0x1F8] = 0x8;
            WholeFile[0x1F9] = 0x69;

            // Eigth Read/Write Block
            WholeFile[0x236] = 0x7F;
            WholeFile[0x237] = 0xF;
            WholeFile[0x238] = 0x8;
            WholeFile[0x239] = 0x69;

            // Nineth Read/Write Block
            WholeFile[0x276] = 0x7F;
            WholeFile[0x277] = 0xF;
            WholeFile[0x278] = 0x8;
            WholeFile[0x279] = 0x69;

            // Tenth Read/Write Block
            WholeFile[0x2B6] = 0x7F;
            WholeFile[0x2B7] = 0xF;
            WholeFile[0x2B8] = 0x8;
            WholeFile[0x2B9] = 0x69;

            // Eleventh Read/Write Block
            WholeFile[0x2F6] = 0x7F;
            WholeFile[0x2F7] = 0xF;
            WholeFile[0x2F8] = 0x8;
            WholeFile[0x2F9] = 0x69;

            // Twelth Read/Write Block
            WholeFile[0x336] = 0x7F;
            WholeFile[0x337] = 0xF;
            WholeFile[0x338] = 0x8;
            WholeFile[0x339] = 0x69;

            // Thireenth Read/Write Block
            WholeFile[0x376] = 0x7F;
            WholeFile[0x377] = 0xF;
            WholeFile[0x378] = 0x8;
            WholeFile[0x379] = 0x69;

            // Fourteenth Read/Write Block
            WholeFile[0x3B6] = 0x7F;
            WholeFile[0x3B7] = 0xF;
            WholeFile[0x3B8] = 0x8;
            WholeFile[0x3B9] = 0x69;

            // Fifteenth Read/Write Block
            WholeFile[0x3F6] = 0x7F;
            WholeFile[0x3F7] = 0xF;
            WholeFile[0x3F8] = 0x8;
            WholeFile[0x3F9] = 0x69;

        // Read/Write Bytes
        // 7F0F0869
    }

    static void SelectFigure()
        {
            blnNoCode = false;
            // MessageBox.Show("Var: " & Figures.Var)
            // MessageBox.Show("Fig: " & Figures.Fig)
            // Exit void
            // frmMain.SaldeStatus.Text = ""
            switch (frmMain.cmbGame.SelectedIndex)
            {
                case 0:
                    // Adventures
                    // All Adventures characters should have their Variant ID set to 0000 Except for Legendary Figures
                    // 0000

                    CharacterVariant[0] = 0x0;
                    CharacterVariant[1] = 0x0;
                    CharacterID[1] = 0x0;
                    if (frmMain.lstCharacters.SelectedItem == "Bash")
                    {
                        // 0400
                        CharacterID[0] = 0x4;

                    }
                    else if (frmMain.lstCharacters.SelectedItem == "Boomer")
                    {
                        // 1600
                        CharacterID[0] = 0x16;

                    }
                    else if (frmMain.lstCharacters.SelectedItem == "Camo")
                    {
                        // 1800
                        CharacterID[0] = 0x18;

                    }
                    else if (frmMain.lstCharacters.SelectedItem == "Chop Chop")
                    {
                        // 1E00
                        CharacterID[0] = 0x1E;

                    }
                    else if (frmMain.lstCharacters.SelectedItem == "Cynder")
                    {
                        // 2000
                        CharacterID[0] = 0x20;

                    }
                    else if (frmMain.lstCharacters.SelectedItem == "Dark Spyro")
                    {
                        // 1C00
                        CharacterID[0] = 0x1C;

                    }
                    else if (frmMain.lstCharacters.SelectedItem == "Dino-Rang")
                    {
                        // 0600
                        CharacterID[0] = 0x6;

                    }
                    else if (frmMain.lstCharacters.SelectedItem == "Double Trouble")
                    {
                        // 1200
                        CharacterID[0] = 0x12;

                    }
                    else if (frmMain.lstCharacters.SelectedItem == "Drill Sergeant")
                    {
                        // 1500
                        CharacterID[0] = 0x15;

                    }
                    else if (frmMain.lstCharacters.SelectedItem == "Drobot")
                    {
                        // 1400
                        CharacterID[0] = 0x14;

                    }
                    else if (frmMain.lstCharacters.SelectedItem == "Eruptor")
                    {
                        // 0900
                        CharacterID[0] = 0x9;

                    }
                    else if (frmMain.lstCharacters.SelectedItem == "Flameslinger")
                    {
                        // 0B00
                        CharacterID[0] = 0xB;

                    }
                    else if (frmMain.lstCharacters.SelectedItem == "Ghost Roaster")
                    {
                        // 1F00
                        CharacterID[0] = 0x1F;

                    }
                    else if (frmMain.lstCharacters.SelectedItem == "Gill Grunt")
                    {
                        // 0E00
                        CharacterID[0] = 0xE;

                    }
                    else if (frmMain.lstCharacters.SelectedItem == "Hex")
                    {
                        // 1D00
                        CharacterID[0] = 0x1D;

                    }
                    else if (frmMain.lstCharacters.SelectedItem == "Ignitor")
                    {
                        // 0A00
                        CharacterID[0] = 0xA;

                    }
                    else if (frmMain.lstCharacters.SelectedItem == "Legendary Bash")
                    {
                        // 9401
                        CharacterID[0] = 0x94;
                        CharacterID[1] = 0x1;

                    }
                    else if (frmMain.lstCharacters.SelectedItem == "Legendary Chop Chop")
                    {
                        // AE01
                        CharacterID[0] = 0xAE;
                        CharacterID[1] = 0x1;

                    }
                    else if (frmMain.lstCharacters.SelectedItem == "Legendary Spyro")
                    {
                        // A001
                        CharacterID[0] = 0xA0;
                        CharacterID[1] = 0x1;

                    }
                    else if (frmMain.lstCharacters.SelectedItem == "Legendary Trigger Happy")
                    {
                        // A301
                        CharacterID[0] = 0xA3;
                        CharacterID[1] = 0x1;

                    }
                    else if (frmMain.lstCharacters.SelectedItem == "Lightning Rod")
                    {
                        // 0300
                        CharacterID[0] = 0x3;


                    }
                    else if (frmMain.lstCharacters.SelectedItem == "Prism Break")
                    {
                        // 0700
                        CharacterID[0] = 0x7;

                    }
                    else if (frmMain.lstCharacters.SelectedItem == "Slam Bam")
                    {
                        // 0F00
                        CharacterID[0] = 0xF;

                    }
                    else if (frmMain.lstCharacters.SelectedItem == "Sonic Boom")
                    {
                        // 0100
                        CharacterID[0] = 0x1;

                    }
                    else if (frmMain.lstCharacters.SelectedItem == "Spyro")
                    {
                        // 1000
                        CharacterID[0] = 0x10;

                    }
                    else if (frmMain.lstCharacters.SelectedItem == "Stealth Elf")
                    {
                        // 1A00
                        CharacterID[0] = 0x1A;

                    }
                    else if (frmMain.lstCharacters.SelectedItem == "Stump Smash")
                    {
                        // 1B00
                        CharacterID[0] = 0x1B;

                    }
                    else if (frmMain.lstCharacters.SelectedItem == "Sunburn")
                    {
                        // 0800
                        CharacterID[0] = 0x8;

                    }
                    else if (frmMain.lstCharacters.SelectedItem == "Terrafin")
                    {
                        // 0500
                        CharacterID[0] = 0x5;

                    }
                    else if (frmMain.lstCharacters.SelectedItem == "Trigger Happy")
                    {
                        // 1300
                        CharacterID[0] = 0x13;

                    }
                    else if (frmMain.lstCharacters.SelectedItem == "Voodood")
                    {
                        // 1100
                        CharacterID[0] = 0x11;

                    }
                    else if (frmMain.lstCharacters.SelectedItem == "Warnado")
                    {
                        // 0200
                        CharacterID[0] = 0x2;

                    }
                    else if (frmMain.lstCharacters.SelectedItem == "Wham-Shell")
                    {
                        // 0D00
                        CharacterID[0] = 0xD;


                    }
                    else if (frmMain.lstCharacters.SelectedItem == "Whirlwind")
                    {
                        // 0000
                        CharacterID[0] = 0x0;

                    }
                    else if (frmMain.lstCharacters.SelectedItem == "Wrecking Ball")
                    {
                        // 1700
                        CharacterID[0] = 0x17;

                    }
                    else if (frmMain.lstCharacters.SelectedItem == "Zap")
                    {
                        // 0C00
                        CharacterID[0] = 0xC;

                    }
                    else if (frmMain.lstCharacters.SelectedItem == "Zook")
                    {
                        // 1900
                        CharacterID[0] = 0x19;
                    }
                    break;
                case 1:
                    // Giants
                    if (frmMain.lstCharacters.SelectedItem == "Bouncer")
                    {
                        // 6E00
                        // 0612
                        CharacterID[0] = 0x6E;
                        CharacterID[1] = 0x0;
                        CharacterVariant[0] = 0x6;
                        CharacterVariant[1] = 0x12;

                    } else if (frmMain.lstCharacters.SelectedItem == "Chill")
                    {
                        // 6A00
                        // 0010
                        CharacterID[0] = 0x6A;
                        CharacterID[1] = 0x0;
                        CharacterVariant[0] = 0x0;
                        CharacterVariant[1] = 0x10;

                    } else if (frmMain.lstCharacters.SelectedItem == "Crusher")
                    {
                        // 6600
                        // 0612
                        CharacterID[0] = 0x66;
                        CharacterID[1] = 0x0;
                        CharacterVariant[0] = 0x6;
                        CharacterVariant[1] = 0x12;

                    } else if (frmMain.lstCharacters.SelectedItem == "Eye-Brawl") {
                        // 7200
                        // 0612
                        CharacterID[0] = 0x72;
                        CharacterID[1] = 0x0;
                        CharacterVariant[0] = 0x6;
                        CharacterVariant[1] = 0x12;

                    } else if (frmMain.lstCharacters.SelectedItem == "Flashwing") {
                        // 6700
                        // 0010
                        CharacterID[0] = 0x67;
                        CharacterID[1] = 0x0;
                        CharacterVariant[0] = 0x0;
                        CharacterVariant[1] = 0x10;

                    } else if (frmMain.lstCharacters.SelectedItem == "Fright Rider") {
                        // 7300
                        // 0010
                        CharacterID[0] = 0x73;
                        CharacterID[1] = 0x0;
                        CharacterVariant[0] = 0x0;
                        CharacterVariant[1] = 0x10;

                    } else if (frmMain.lstCharacters.SelectedItem == "Gnarly Tree Rex") {
                        // 7000
                        // 0216
                        CharacterID[0] = 0x70;
                        CharacterID[1] = 0x0;
                        CharacterVariant[0] = 0x2;
                        CharacterVariant[1] = 0x16;

                    } else if (frmMain.lstCharacters.SelectedItem == "Granite Crusher") {
                        // 6600
                        // 0216
                        CharacterID[0] = 0x66;
                        CharacterID[1] = 0x0;
                        CharacterVariant[0] = 0x2;
                        CharacterVariant[1] = 0x16;

                    } else if (frmMain.lstCharacters.SelectedItem == "Hot Dog") {
                        // 6900
                        // 0010
                        CharacterID[0] = 0x69;
                        CharacterID[1] = 0x0;
                        CharacterVariant[0] = 0x0;
                        CharacterVariant[1] = 0x10;

                    } else if (frmMain.lstCharacters.SelectedItem == "Hot Head") {
                        // 6800
                        // 0612
                        CharacterID[0] = 0x68;
                        CharacterID[1] = 0x0;
                        CharacterVariant[0] = 0x6;
                        CharacterVariant[1] = 0x12;

                    } else if (frmMain.lstCharacters.SelectedItem == "Jade Flashwing") {
                        // 6700
                        // 0214
                        CharacterID[0] = 0x67;
                        CharacterID[1] = 0x0;
                        CharacterVariant[0] = 0x2;
                        CharacterVariant[1] = 0x14;
                    }
                    else if (frmMain.lstCharacters.SelectedItem == "Jet-Vac") {
                        // 6400
                        // 0010
                        CharacterID[0] = 0x64;
                        CharacterID[1] = 0x0;
                        CharacterVariant[0] = 0x0;
                        CharacterVariant[1] = 0x10;
                    }
                    else if (frmMain.lstCharacters.SelectedItem == "Legendary Bouncer") {
                        // 6E00
                        // 0316
                        CharacterID[0] = 0x6E;
                        CharacterID[1] = 0x0;
                        CharacterVariant[0] = 0x3;
                        CharacterVariant[1] = 0x16;
                    }
                    else if (frmMain.lstCharacters.SelectedItem == "Legendary Chill") {
                        // 6A00
                        // 0316
                        CharacterID[0] = 0x6A;
                        CharacterID[1] = 0x0;
                        CharacterVariant[0] = 0x3;
                        CharacterVariant[1] = 0x16;
                    }
                    else if (frmMain.lstCharacters.SelectedItem == "Legendary Ignitor") {
                        // 0A00
                        // 0316
                        CharacterID[0] = 0xA;
                        CharacterID[1] = 0x0;
                        CharacterVariant[0] = 0x3;
                        CharacterVariant[1] = 0x16;
                    }
                    else if (frmMain.lstCharacters.SelectedItem == "Legendary Jet-Vac") {
                        // 6400
                        // 0314
                        CharacterID[0] = 0x64;
                        CharacterID[1] = 0x0;
                        CharacterVariant[0] = 0x3;
                        CharacterVariant[1] = 0x14;
                    } else if (frmMain.lstCharacters.SelectedItem == "Legendary Slam Bam") {
                        // 0F00
                        // 031C
                        CharacterID[0] = 0xF;
                        CharacterID[1] = 0x0;
                        CharacterVariant[0] = 0x3;
                        CharacterVariant[1] = 0x1C;
                    }
                    else if (frmMain.lstCharacters.SelectedItem == "Legendary Stealth Elf") {
                        // 1A00
                        // 031C
                        CharacterID[0] = 0x1A;
                        CharacterID[1] = 0x0;
                        CharacterVariant[0] = 0x3;
                        CharacterVariant[1] = 0x1C;
                    }
                    else if (frmMain.lstCharacters.SelectedItem == "LightCore Chill") {
                        // 6A00
                        // 0612
                        CharacterID[0] = 0x6A;
                        CharacterID[1] = 0x0;
                        CharacterVariant[0] = 0x6;
                        CharacterVariant[1] = 0x12;
                    }
                    else if (frmMain.lstCharacters.SelectedItem == "LightCore Drobot") {
                        // 1400
                        // 0612
                        CharacterID[0] = 0x14;
                        CharacterID[1] = 0x0;
                        CharacterVariant[0] = 0x6;
                        CharacterVariant[1] = 0x12;
                    }
                    else if (frmMain.lstCharacters.SelectedItem == "LightCore Eruptor") {
                        // 0900
                        // 0612
                        CharacterID[0] = 0x9;
                        CharacterID[1] = 0x0;
                        CharacterVariant[0] = 0x6;
                        CharacterVariant[1] = 0x12;
                    }
                    else if (frmMain.lstCharacters.SelectedItem == "LightCore Hex") {
                        // 1D00
                        // 0612
                        CharacterID[0] = 0x1D;
                        CharacterID[1] = 0x0;
                        CharacterVariant[0] = 0x6;
                        CharacterVariant[1] = 0x12;
                    }
                    else if (frmMain.lstCharacters.SelectedItem == "LightCore Jet-Vac") {
                        // 6400
                        // 0612
                        CharacterID[0] = 0x64;
                        CharacterID[1] = 0x0;
                        CharacterVariant[0] = 0x6;
                        CharacterVariant[1] = 0x12;
                    }
                    else if (frmMain.lstCharacters.SelectedItem == "LightCore Pop Fizz") {
                        // 6C00
                        // 0612
                        CharacterID[0] = 0x6C;
                        CharacterID[1] = 0x0;
                        CharacterVariant[0] = 0x6;
                        CharacterVariant[1] = 0x12;
                    }
                    else if (frmMain.lstCharacters.SelectedItem == "LightCore Prism Break") {
                        // 0700
                        // 0612
                        CharacterID[0] = 0x7;
                        CharacterID[1] = 0x0;
                        CharacterVariant[0] = 0x6;
                        CharacterVariant[1] = 0x12;
                    }
                    else if (frmMain.lstCharacters.SelectedItem == "LightCore Shroomboom") {
                        // 7100
                        // 0612
                        CharacterID[0] = 0x71;
                        CharacterID[1] = 0x0;
                        CharacterVariant[0] = 0x6;
                        CharacterVariant[1] = 0x12;
                    }
                    else if (frmMain.lstCharacters.SelectedItem == "Molten Hot Dog") {
                        // 6900
                        // 0214
                        CharacterID[0] = 0x69;
                        CharacterID[1] = 0x0;
                        CharacterVariant[0] = 0x2;
                        CharacterVariant[1] = 0x14;
                    }
                    else if (frmMain.lstCharacters.SelectedItem == "Ninjini") {
                        // 6D00
                        // 0612
                        CharacterID[0] = 0x6D;
                        CharacterID[1] = 0x0;
                        CharacterVariant[0] = 0x6;
                        CharacterVariant[1] = 0x12;
                    }
                    else if (frmMain.lstCharacters.SelectedItem == "Polar Whirlwind") {
                        // 0000
                        // 0216
                        CharacterID[0] = 0x0;
                        CharacterID[1] = 0x0;
                        CharacterVariant[0] = 0x2;
                        CharacterVariant[1] = 0x16;
                    }
                    else if (frmMain.lstCharacters.SelectedItem == "Pop Fizz") {
                        // 6C00
                        // 0010
                        CharacterID[0] = 0x6C;
                        CharacterID[1] = 0x0;
                        CharacterVariant[0] = 0x0;
                        CharacterVariant[1] = 0x10;
                    }
                    else if (frmMain.lstCharacters.SelectedItem == "Punch Pop Fizz") {
                        // 6C00
                        // 0214
                        CharacterID[0] = 0x6C;
                        CharacterID[1] = 0x0;
                        CharacterVariant[0] = 0x2;
                        CharacterVariant[1] = 0x14;
                    }
                    else if (frmMain.lstCharacters.SelectedItem == "Royal Double Trouble") {
                        // 1200
                        // 021C
                        CharacterID[0] = 0x12;
                        CharacterID[1] = 0x0;
                        CharacterVariant[0] = 0x2;
                        CharacterVariant[1] = 0x1C;
                } else if (frmMain.lstCharacters.SelectedItem == "Scarlet Ninjini") {
                        // 6D00
                        // 0216
                        CharacterID[0] = 0x6D
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x2
                    CharacterVariant[1] = 0x16
                } else if (frmMain.lstCharacters.SelectedItem == "Series 2 Bash") {
                        // 0400
                        // 0118
                        CharacterID[0] = 0x4
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x1
                    CharacterVariant[1] = 0x18
                } else if (frmMain.lstCharacters.SelectedItem == "Series 2 Chop Chop") {
                        // 1E00
                        // 0118
                        CharacterID[0] = 0x1E
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x1
                    CharacterVariant[1] = 0x18
                } else if (frmMain.lstCharacters.SelectedItem == "Series 2 Cynder") {
                        // 2000
                        // 0118
                        CharacterID[0] = 0x20
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x1
                    CharacterVariant[1] = 0x18
                } else if (frmMain.lstCharacters.SelectedItem == "Series 2 Double Trouble") {
                        // 1200
                        // 0118
                        CharacterID[0] = 0x12
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x1
                    CharacterVariant[1] = 0x18
                } else if (frmMain.lstCharacters.SelectedItem == "Series 2 Drill Sergeant") {
                        // 1500
                        // 0118
                        CharacterID[0] = 0x15
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x1
                    CharacterVariant[1] = 0x18
                } else if (frmMain.lstCharacters.SelectedItem == "Series 2 Drobot") {
                        // 1400
                        // 0118
                        CharacterID[0] = 0x14
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x1
                    CharacterVariant[1] = 0x18
                } else if (frmMain.lstCharacters.SelectedItem == "Series 2 Eruptor") {
                        // 0900
                        // 0118
                        CharacterID[0] = 0x9
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x1
                    CharacterVariant[1] = 0x18
                } else if (frmMain.lstCharacters.SelectedItem == "Series 2 Flameslinger") {
                        // 0B00
                        // 0118
                        CharacterID[0] = 0xB
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x1
                    CharacterVariant[1] = 0x18
                } else if (frmMain.lstCharacters.SelectedItem == "Series 2 Gill Grunt") {
                        // 0E00
                        // 0118
                        CharacterID[0] = 0xE
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x1
                    CharacterVariant[1] = 0x18
                } else if (frmMain.lstCharacters.SelectedItem == "Series 2 Hex") {
                        // 1D00
                        // 0118
                        CharacterID[0] = 0x1D
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x1
                    CharacterVariant[1] = 0x18
                } else if (frmMain.lstCharacters.SelectedItem == "Series 2 Ignitor") {
                        // 0A00
                        // 0118
                        CharacterID[0] = 0xA
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x1
                    CharacterVariant[1] = 0x18
                } else if (frmMain.lstCharacters.SelectedItem == "Series 2 Lightning Rod") {
                        // 0300
                        // 0118
                        CharacterID[0] = 0x3
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x1
                    CharacterVariant[1] = 0x18
                } else if (frmMain.lstCharacters.SelectedItem == "Series 2 Prism Break") {
                        // 0700
                        // 0118
                        CharacterID[0] = 0x7
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x1
                    CharacterVariant[1] = 0x18
                } else if (frmMain.lstCharacters.SelectedItem == "Series 2 Slam Bam") {
                        // 0F00
                        // 0118
                        CharacterID[0] = 0xF
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x1
                    CharacterVariant[1] = 0x18
                } else if (frmMain.lstCharacters.SelectedItem == "Series 2 Sonic Boom") {
                        // 0100
                        // 0118
                        CharacterID[0] = 0x1
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x1
                    CharacterVariant[1] = 0x18
                } else if (frmMain.lstCharacters.SelectedItem == "Series 2 Spyro") {
                        // 0100
                        // 0118
                        CharacterID[0] = 0x1
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x1
                    CharacterVariant[1] = 0x18
                } else if (frmMain.lstCharacters.SelectedItem == "Series 2 Stealth Elf") {
                        // 1A00
                        // 0118
                        CharacterID[0] = 0x1A
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x1
                    CharacterVariant[1] = 0x18
                } else if (frmMain.lstCharacters.SelectedItem == "Series 2 Stump Smash") {
                        // 1B00
                        // 0118
                        CharacterID[0] = 0x1B
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x1
                    CharacterVariant[1] = 0x18
                } else if (frmMain.lstCharacters.SelectedItem == "Series 2 Terrafin") {
                        // 0500
                        // 0118
                        CharacterID[0] = 0x5
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x1
                    CharacterVariant[1] = 0x18
                } else if (frmMain.lstCharacters.SelectedItem == "Series 2 Trigger Happy") {
                        // 1300
                        // 0118
                        CharacterID[0] = 0x13
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x1
                    CharacterVariant[1] = 0x18
                } else if (frmMain.lstCharacters.SelectedItem == "Series 2 Whirlwind") {
                        // 0000
                        // 0118
                        CharacterID[0] = 0x0
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x1
                    CharacterVariant[1] = 0x18
                } else if (frmMain.lstCharacters.SelectedItem == "Series 2 Wrecking Ball") {
                        // 1700
                        // 0118
                        CharacterID[0] = 0x17
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x1
                    CharacterVariant[1] = 0x18
                } else if (frmMain.lstCharacters.SelectedItem == "Series 2 Zap") {
                        // 0C00
                        // 0118
                        CharacterID[0] = 0xC
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x1
                    CharacterVariant[1] = 0x18
                } else if (frmMain.lstCharacters.SelectedItem == "Series 2 Zook") {
                        // 1900
                        // 0118
                        CharacterID[0] = 0x19
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x1
                    CharacterVariant[1] = 0x18
                } else if (frmMain.lstCharacters.SelectedItem == "Shroomboom") {
                        // 7100
                        // 0010
                        CharacterID[0] = 0x71
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x10
                } else if (frmMain.lstCharacters.SelectedItem == "Sprocket") {
                        // 6F00
                        // 0010
                        CharacterID[0] = 0x6F
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x10
                } else if (frmMain.lstCharacters.SelectedItem == "Swarm") {
                        // 6500
                        // 0612
                        CharacterID[0] = 0x65
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x6
                    CharacterVariant[1] = 0x12
                } else if (frmMain.lstCharacters.SelectedItem == "Thumpback") {
                        // 6B00
                        // 0612
                        CharacterID[0] = 0x6B
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x6
                    CharacterVariant[1] = 0x12
                } else if (frmMain.lstCharacters.SelectedItem == "Tree Rex") {
                        // 7000
                        // 0612
                        CharacterID[0] = 0x70
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x6
                    CharacterVariant[1] = 0x12
                End If
            Case 2
                // Swap Force
                If frmMain.lstCharacters.SelectedItem == "Anchors Away Gill Grunt") {
                            // 0E00
                            // 0528
                            CharacterID[0] = 0xE
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x5
                    CharacterVariant[1] = 0x28
                } else if (frmMain.lstCharacters.SelectedItem == "Big Bang Trigger Happy") {
                            // 1300
                            // 0528
                            CharacterID[0] = 0x13
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x5
                    CharacterVariant[1] = 0x28
                } else if (frmMain.lstCharacters.SelectedItem == "Blast Zone (Bottom)") {
                            // Swap Character
                            // EC03
                            // 0020
                            CharacterID[0] = 0xEC
                    CharacterID[1] = 0x3
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x20
                } else if (frmMain.lstCharacters.SelectedItem == "Blast Zone (Top)") {
                            // Swap Character
                            // D407
                            // 0020
                            CharacterID[0] = 0xD4
                    CharacterID[1] = 0x7
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x20
                } else if (frmMain.lstCharacters.SelectedItem == "Blizzard Chill") {
                            // 6A00
                            // 0528
                            CharacterID[0] = 0x6A
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x5
                    CharacterVariant[1] = 0x28
                } else if (frmMain.lstCharacters.SelectedItem == "Boom Jet (Bottom)") {
                            // Swap Character
                            // E803
                            // 0020
                            CharacterID[0] = 0xE8
                    CharacterID[1] = 0x3
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x20
                } else if (frmMain.lstCharacters.SelectedItem == "Boom Jet (Top)") {
                            // Swap Character
                            // D007
                            // 0020
                            CharacterID[0] = 0xD0
                    CharacterID[1] = 0x7
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x20
                } else if (frmMain.lstCharacters.SelectedItem == "Bumble Blast") {
                            // BE0B
                            // 0020
                            CharacterID[0] = 0xBE
                    CharacterID[1] = 0xB
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x20
                } else if (frmMain.lstCharacters.SelectedItem == "Countdown") {
                            // C20B
                            // 0020
                            CharacterID[0] = 0xC2
                    CharacterID[1] = 0xB
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x20
                } else if (frmMain.lstCharacters.SelectedItem == "Dark Blast Zone (Bottom)") {
                            // Swap Character
                            // EC03
                            // 0224
                            CharacterID[0] = 0xEC
                    CharacterID[1] = 0x3
                    CharacterVariant[0] = 0x2
                    CharacterVariant[1] = 0x24
                } else if (frmMain.lstCharacters.SelectedItem == "Dark Blast Zone (Top)") {
                            // Swap Character
                            // D407
                            // 0224
                            CharacterID[0] = 0xD4
                    CharacterID[1] = 0x7
                    CharacterVariant[0] = 0x2
                    CharacterVariant[1] = 0x24
                } else if (frmMain.lstCharacters.SelectedItem == "Dark Mega Ram Spyro") {
                            // 1000
                            // 0528
                            CharacterID[0] = 0x10
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x5
                    CharacterVariant[1] = 0x28
                } else if (frmMain.lstCharacters.SelectedItem == "Dark Slobber Tooth") {
                            // BA0B
                            // 0224
                            CharacterID[0] = 0xBA
                    CharacterID[1] = 0xB
                    CharacterVariant[0] = 0x2
                    CharacterVariant[1] = 0x24
                } else if (frmMain.lstCharacters.SelectedItem == "Dark Stealth Elf") {
                            // 1A00
                            // 022C
                            CharacterID[0] = 0x1A
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x2
                    CharacterVariant[1] = 0x2C
                } else if (frmMain.lstCharacters.SelectedItem == "Dark Wash Buckler (Bottom)") {
                            // Swap Character
                            // F703
                            // 0224
                            CharacterID[0] = 0xF7
                    CharacterID[1] = 0x3
                    CharacterVariant[0] = 0x2
                    CharacterVariant[1] = 0x24
                } else if (frmMain.lstCharacters.SelectedItem == "Dark Wash Buckler (Top)") {
                            // Swap Character
                            // DF07
                            // 0224
                            CharacterID[0] = 0xDF
                    CharacterID[1] = 0x7
                    CharacterVariant[0] = 0x2
                    CharacterVariant[1] = 0x24
                } else if (frmMain.lstCharacters.SelectedItem == "Doom Stone (Bottom)") {
                            // Swap Character
                            // EB03
                            // 0020
                            CharacterID[0] = 0xEB
                    CharacterID[1] = 0x3
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x20
                } else if (frmMain.lstCharacters.SelectedItem == "Doom Stone (Top)") {
                            // Swap Character
                            // D307
                            // 0020
                            CharacterID[0] = 0xD3
                    CharacterID[1] = 0x7
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x20
                } else if (frmMain.lstCharacters.SelectedItem == "Dune Bug") {
                            // C00B
                            // 0020
                            CharacterID[0] = 0xC0
                    CharacterID[1] = 0xB
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x20
                } else if (frmMain.lstCharacters.SelectedItem == "Enchanted Hoot Loop (Bottom)") {
                            // Swap Character
                            // F003
                            // 0224
                            CharacterID[0] = 0xF0
                    CharacterID[1] = 0x3
                    CharacterVariant[0] = 0x2
                    CharacterVariant[1] = 0x24
                } else if (frmMain.lstCharacters.SelectedItem == "Enchanted Hoot Loop (Top)") {
                            // Swap Character
                            // D807
                            // 0224
                            CharacterID[0] = 0xD8
                    CharacterID[1] = 0x7
                    CharacterVariant[0] = 0x2
                    CharacterVariant[1] = 0x24
                } else if (frmMain.lstCharacters.SelectedItem == "Enchanted Star Strike") {
                            // LightCore
                            // C10B
                            // 0226
                            CharacterID[0] = 0xC1
                    CharacterID[1] = 0xB
                    CharacterVariant[0] = 0x2
                    CharacterVariant[1] = 0x26
                } else if (frmMain.lstCharacters.SelectedItem == "Fire Bone Hot Dog") {
                            // 0069
                            // 0528
                            CharacterID[0] = 0x0
                    CharacterID[1] = 0x69
                    CharacterVariant[0] = 0x5
                    CharacterVariant[1] = 0x28
                } else if (frmMain.lstCharacters.SelectedItem == "Fire Kraken (Bottom)") {
                            // Swap Character
                            // ED03
                            // 0020
                            CharacterID[0] = 0xED
                    CharacterID[1] = 0x3
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x20
                } else if (frmMain.lstCharacters.SelectedItem == "Fire Kraken (Top)") {
                            // Swap Character
                            // D507
                            // 0020
                            CharacterID[0] = 0xD5
                    CharacterID[1] = 0x7
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x20
                } else if (frmMain.lstCharacters.SelectedItem == "Free Ranger (Bottom)") {
                            // Swap Character
                            // E903
                            // 0020
                            CharacterID[0] = 0xE9
                    CharacterID[1] = 0x3
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x20
                } else if (frmMain.lstCharacters.SelectedItem == "Free Ranger (Top)") {
                            // Swap Character
                            // D107
                            // 0020
                            CharacterID[0] = 0xD1
                    CharacterID[1] = 0x7
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x20
                } else if (frmMain.lstCharacters.SelectedItem == "Freeze Blade (Bottom)") {
                            // Swap Character
                            // F603
                            // 0020
                            CharacterID[0] = 0xF6
                    CharacterID[1] = 0x3
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x20
                } else if (frmMain.lstCharacters.SelectedItem == "Freeze Blade (Top)") {
                            // Swap Character
                            // DE07
                            // 0020
                            CharacterID[0] = 0xDE
                    CharacterID[1] = 0x7
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x20
                } else if (frmMain.lstCharacters.SelectedItem == "Fryno") {
                            // BC0B
                            // 0020
                            CharacterID[0] = 0xBC
                    CharacterID[1] = 0xB
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x20
                } else if (frmMain.lstCharacters.SelectedItem == "Grilla Drilla (Bottom)") {
                            // Swap Character
                            // EF03
                            // 0020
                            CharacterID[0] = 0xEF
                    CharacterID[1] = 0x3
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x20

                } else if (frmMain.lstCharacters.SelectedItem == "Grilla Drilla (Top)") {
                            // Swap Character
                            // D707
                            // 0020
                            CharacterID[0] = 0xD7
                    CharacterID[1] = 0x7
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x20
                } else if (frmMain.lstCharacters.SelectedItem == "Grim Creeper") {
                            // C50B
                            // 0020
                            CharacterID[0] = 0xC5
                    CharacterID[1] = 0xB
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x20
                } else if (frmMain.lstCharacters.SelectedItem == "Heavy Duty Sprocket") {
                            // 6F00
                            // 0528
                            CharacterID[0] = 0x6F
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x5
                    CharacterVariant[1] = 0x28
                } else if (frmMain.lstCharacters.SelectedItem == "Hoot Loop (Bottom)") {
                            // Swap Character
                            // F003
                            // 0020
                            CharacterID[0] = 0xF0
                    CharacterID[1] = 0x3
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x20
                } else if (frmMain.lstCharacters.SelectedItem == "Hoot Loop (Top)") {
                            // Swap Character
                            // D807
                            // 0020
                            CharacterID[0] = 0xD8
                    CharacterID[1] = 0x7
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x20
                } else if (frmMain.lstCharacters.SelectedItem == "Horn Blast Whirlwind") {
                            // 0000
                            // 0528
                            CharacterID[0] = 0x0
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x5
                    CharacterVariant[1] = 0x28
                } else if (frmMain.lstCharacters.SelectedItem == "Hyper Beam Prism Break") {
                            // 0700
                            // 0528
                            CharacterID[0] = 0x7
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x5
                    CharacterVariant[1] = 0x28
                } else if (frmMain.lstCharacters.SelectedItem == "Jade Fire Kraken (Bottom)") {
                            // Swap Character
                            // ED03
                            // 0224
                            CharacterID[0] = 0xED
                    CharacterID[1] = 0x3
                    CharacterVariant[0] = 0x2
                    CharacterVariant[1] = 0x24
                } else if (frmMain.lstCharacters.SelectedItem == "Jade Fire Kraken (Top)") {
                            // Swap Character
                            // D507
                            // 0224
                            CharacterID[0] = 0xD5
                    CharacterID[1] = 0x7
                    CharacterVariant[0] = 0x2
                    CharacterVariant[1] = 0x24
                } else if (frmMain.lstCharacters.SelectedItem == "Jolly Bumble Blast") {
                            // BE0B
                            // 0224
                            CharacterID[0] = 0xBE
                    CharacterID[1] = 0xB
                    CharacterVariant[0] = 0x2
                    CharacterVariant[1] = 0x24
                } else if (frmMain.lstCharacters.SelectedItem == "Kickoff Countdown") {
                            // C20B
                            // 0224
                            CharacterID[0] = 0xC2
                    CharacterID[1] = 0xB
                    CharacterVariant[0] = 0x2
                    CharacterVariant[1] = 0x24
                } else if (frmMain.lstCharacters.SelectedItem == "Knockout Terrafin") {
                            // 0500
                            // 0528
                            CharacterID[0] = 0x5
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x5
                    CharacterVariant[1] = 0x28
                } else if (frmMain.lstCharacters.SelectedItem == "Lava Barf Eruptor") {
                            // 0900
                            // 0528
                            CharacterID[0] = 0x9
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x5
                    CharacterVariant[1] = 0x28
                } else if (frmMain.lstCharacters.SelectedItem == "Legendary Free Ranger (Bottom)") {
                            // Swap Character
                            // E903
                            // 0324
                            CharacterID[0] = 0xE9
                    CharacterID[1] = 0x3
                    CharacterVariant[0] = 0x3
                    CharacterVariant[1] = 0x24
                } else if (frmMain.lstCharacters.SelectedItem == "Legendary Free Ranger (Top)") {
                            // Swap Character
                            // D1 07
                            // 03 24
                            CharacterID[0] = 0xD1
                    CharacterID[1] = 0x7
                    CharacterVariant[0] = 0x3
                    CharacterVariant[1] = 0x24
                } else if (frmMain.lstCharacters.SelectedItem == "Legendary Grim Creeper") {
                            // C50B
                            // 0326
                            CharacterID[0] = 0xC5
                    CharacterID[1] = 0xB
                    CharacterVariant[0] = 0x3
                    CharacterVariant[1] = 0x26
                } else if (frmMain.lstCharacters.SelectedItem == "Legendary Night Shift (Bottom)") {
                            // Swap Character
                            // F403
                            // 0304
                            CharacterID[0] = 0xF4
                    CharacterID[1] = 0x3
                    CharacterVariant[0] = 0x3
                    CharacterVariant[1] = 0x4
                } else if (frmMain.lstCharacters.SelectedItem == "Legendary Night Shift (Top)") {
                            // Swap Character
                            // DC07
                            // 0324
                            CharacterID[0] = 0xDC
                    CharacterID[1] = 0x7
                    CharacterVariant[0] = 0x3
                    CharacterVariant[1] = 0x24
                } else if (frmMain.lstCharacters.SelectedItem == "Legendary Zoo Lou") {
                            // BF0B
                            // 0324
                            CharacterID[0] = 0xBF
                    CharacterID[1] = 0xB
                    CharacterVariant[0] = 0x3
                    CharacterVariant[1] = 0x24
                } else if (frmMain.lstCharacters.SelectedItem == "LightCore Bumble Blast") {
                            // BE0B
                            // 0622
                            CharacterID[0] = 0xBE
                    CharacterID[1] = 0xB
                    CharacterVariant[0] = 0x6
                    CharacterVariant[1] = 0x22
                } else if (frmMain.lstCharacters.SelectedItem == "LightCore Countdown") {
                            // C20B
                            // 0622
                            CharacterID[0] = 0xC2
                    CharacterID[1] = 0xB
                    CharacterVariant[0] = 0x6
                    CharacterVariant[1] = 0x22
                } else if (frmMain.lstCharacters.SelectedItem == "LightCore Flashwing") {
                            // 6700
                            // 0622
                            CharacterID[0] = 0x67
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x6
                    CharacterVariant[1] = 0x22
                } else if (frmMain.lstCharacters.SelectedItem == "LightCore Grim Creeper") {
                            // C50B
                            // 0622
                            CharacterID[0] = 0xC5
                    CharacterID[1] = 0xB
                    CharacterVariant[0] = 0x6
                    CharacterVariant[1] = 0x22
                } else if (frmMain.lstCharacters.SelectedItem == "LightCore Smolderdash") {
                            // BD0B
                            // 0622
                            CharacterID[0] = 0xDB
                    CharacterID[1] = 0xB
                    CharacterVariant[0] = 0x6
                    CharacterVariant[1] = 0x22
                } else if (frmMain.lstCharacters.SelectedItem == "LightCore Star Strike") {
                            // C10B
                            // 0622
                            CharacterID[0] = 0xC1
                    CharacterID[1] = 0xB
                    CharacterVariant[0] = 0x6
                    CharacterVariant[1] = 0x22
                } else if (frmMain.lstCharacters.SelectedItem == "LightCore Warnado") {
                            // 0200
                            // 0622
                            CharacterID[0] = 0x2
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x6
                    CharacterVariant[1] = 0x22
                } else if (frmMain.lstCharacters.SelectedItem == "LightCore Wham-Shell") {
                            // 0D00
                            // 0622
                            CharacterID[0] = 0xD
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x6
                    CharacterVariant[1] = 0x22
                } else if (frmMain.lstCharacters.SelectedItem == "Magna Charge (Bottom)") {
                            // Swap Character
                            // F203
                            // 0020
                            CharacterID[0] = 0xF2
                    CharacterID[1] = 0x3
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x20
                } else if (frmMain.lstCharacters.SelectedItem == "Magna Charge (Top)") {
                            // Swap Character
                            // DA07
                            // 0020
                            CharacterID[0] = 0xDA
                    CharacterID[1] = 0x7
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x20
                } else if (frmMain.lstCharacters.SelectedItem == "Mega Ram Spyro") {
                            // 1000
                            // 0528
                            CharacterID[0] = 0x10
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x5
                    CharacterVariant[1] = 0x28
                } else if (frmMain.lstCharacters.SelectedItem == "Night Shift (Bottom)") {
                            // Swap Character
                            // F403
                            // 0020
                            CharacterID[0] = 0xF4
                    CharacterID[1] = 0x3
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x20
                } else if (frmMain.lstCharacters.SelectedItem == "Night Shift (Top)") {
                            // Swap Character
                            // DC07
                            // 0020
                            CharacterID[0] = 0xDC
                    CharacterID[1] = 0x7
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x20
                } else if (frmMain.lstCharacters.SelectedItem == "Ninja Stealth Elf") {
                            // 1A00
                            // 0528
                            CharacterID[0] = 0x1A
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x5
                    CharacterVariant[1] = 0x28
                } else if (frmMain.lstCharacters.SelectedItem == "Nitro Freeze Blade (Bottom)") {
                            // Swap Character
                            // F603
                            // 0224
                            CharacterID[0] = 0xF6
                    CharacterID[1] = 0x3
                    CharacterVariant[0] = 0x2
                    CharacterVariant[1] = 0x24
                } else if (frmMain.lstCharacters.SelectedItem == "Nitro Freeze Blade (Top)") {
                            // Swap Character
                            // DE07
                            // 0224
                            CharacterID[0] = 0xDE
                    CharacterID[1] = 0x7
                    CharacterVariant[0] = 0x2
                    CharacterVariant[1] = 0x24
                } else if (frmMain.lstCharacters.SelectedItem == "Nitro Magna Charge (Bottom)") {
                            // Swap Character
                            // F203
                            // 0224
                            CharacterID[0] = 0xF2
                    CharacterID[1] = 0x3
                    CharacterVariant[0] = 0x2
                    CharacterVariant[1] = 0x24
                } else if (frmMain.lstCharacters.SelectedItem == "Nitro Magna Charge (Top)") {
                            // Swap Character
                            // DA07
                            // 0224
                            CharacterID[0] = 0xDA
                    CharacterID[1] = 0x7
                    CharacterVariant[0] = 0x2
                    CharacterVariant[1] = 0x24
                } else if (frmMain.lstCharacters.SelectedItem == "Phantom Cynder") {
                            // 2000
                            // 0528
                            CharacterID[0] = 0x20
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x5
                    CharacterVariant[1] = 0x28
                } else if (frmMain.lstCharacters.SelectedItem == "Pop Thorn") {
                            // B90B
                            // 0020
                            CharacterID[0] = 0xB9
                    CharacterID[1] = 0xB
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x20
                } else if (frmMain.lstCharacters.SelectedItem == "Punk Shock") {
                            // C70B
                            // 0020
                            CharacterID[0] = 0xC7
                    CharacterID[1] = 0xB
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x20
                } else if (frmMain.lstCharacters.SelectedItem == "Quickdraw Rattle Shake (Bottom)") {
                            // Swap Character
                            // F5 03
                            // 02 24
                            CharacterID[0] = 0xF5
                    CharacterID[1] = 0x3
                    CharacterVariant[0] = 0x2
                    CharacterVariant[1] = 0x24
                } else if (frmMain.lstCharacters.SelectedItem == "Quickdraw Rattle Shake (Top)") {
                            // Swap Character
                            // DD07
                            // 0224
                            CharacterID[0] = 0xDD
                    CharacterID[1] = 0x7
                    CharacterVariant[0] = 0x2
                    CharacterVariant[1] = 0x24
                } else if (frmMain.lstCharacters.SelectedItem == "Rattle Shake (Bottom)") {
                            // Swap Character
                            // F503
                            // 0020
                            CharacterID[0] = 0xF5
                    CharacterID[1] = 0x3
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x20
                } else if (frmMain.lstCharacters.SelectedItem == "Rattle Shake (Top)") {
                            // Swap Character
                            // DD07
                            // 0020
                            CharacterID[0] = 0xDD
                    CharacterID[1] = 0x7
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x20
                } else if (frmMain.lstCharacters.SelectedItem == "Rip Tide") {
                            // 6C0B
                            // 0020
                            CharacterID[0] = 0x6C
                    CharacterID[1] = 0xB
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x20
                } else if (frmMain.lstCharacters.SelectedItem == "Roller Brawl") {
                            // C40B
                            // 0020
                            CharacterID[0] = 0xC4
                    CharacterID[1] = 0xB
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x20
                } else if (frmMain.lstCharacters.SelectedItem == "Rubble Rouser (Bottom)") {
                            // Swap Character
                            // EA03
                            // 0020
                            CharacterID[0] = 0xEA
                    CharacterID[1] = 0x3
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x20
                } else if (frmMain.lstCharacters.SelectedItem == "Rubble Rouser (Top)") {
                            // Swap Character
                            // D207
                            // 0020
                            CharacterID[0] = 0xD2
                    CharacterID[1] = 0x7
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x20
                } else if (frmMain.lstCharacters.SelectedItem == "Scorp") {
                            // BB0B
                            // 0020
                            CharacterID[0] = 0xBB
                    CharacterID[1] = 0xB
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x20
                } else if (frmMain.lstCharacters.SelectedItem == "Scratch") {
                            // B80B
                            // 0020
                            CharacterID[0] = 0xB8
                    CharacterID[1] = 0xB
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x20
                } else if (frmMain.lstCharacters.SelectedItem == "Slobber Tooth") {
                            // BA0B
                            // 0020
                            CharacterID[0] = 0xBA
                    CharacterID[1] = 0xB
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x20
                } else if (frmMain.lstCharacters.SelectedItem == "Smolderdash") {
                            // BD0B
                            // 0020
                            CharacterID[0] = 0xBD
                    CharacterID[1] = 0xB
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x20
                } else if (frmMain.lstCharacters.SelectedItem == "Springtime Trigger Happy") {
                            // 1300
                            // 022C
                            CharacterID[0] = 0x13
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x2
                    CharacterVariant[1] = 0x2C
                } else if (frmMain.lstCharacters.SelectedItem == "Spy Rise (Bottom)") {
                            // Swap Character
                            // F303
                            // 0020
                            CharacterID[0] = 0xF3
                    CharacterID[1] = 0x3
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x20
                } else if (frmMain.lstCharacters.SelectedItem == "Spy Rise (Top)") {
                            // Swap Character
                            // DB07
                            // 0020
                            CharacterID[0] = 0xDB
                    CharacterID[1] = 0x7
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x20
                } else if (frmMain.lstCharacters.SelectedItem == "Star Strike") {
                            // C10B
                            // 0020
                            CharacterID[0] = 0xC1
                    CharacterID[1] = 0xB
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x20
                } else if (frmMain.lstCharacters.SelectedItem == "Stink Bomb (Bottom)") {
                            // Swap Character
                            // EE03
                            // 0020
                            CharacterID[0] = 0xEE
                    CharacterID[1] = 0x3
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x20
                } else if (frmMain.lstCharacters.SelectedItem == "Stink Bomb (Top)") {
                            // Swap Character
                            // D607
                            // 0020
                            CharacterID[0] = 0xD6
                    CharacterID[1] = 0x7
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x20
                } else if (frmMain.lstCharacters.SelectedItem == "Super Gulp Pop Fizz") {
                            // 6C00
                            // 0528
                            CharacterID[0] = 0x6C
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x5
                    CharacterVariant[1] = 0x28
                } else if (frmMain.lstCharacters.SelectedItem == "Thorn Horn Camo") {
                            // 1800
                            // 0528
                            CharacterID[0] = 0x18
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x5
                    CharacterVariant[1] = 0x28
                } else if (frmMain.lstCharacters.SelectedItem == "Trap Shadow (Bottom)") {
                            // Swap Character
                            // F103
                            // 0020
                            CharacterID[0] = 0xF1
                    CharacterID[1] = 0x3
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x20
                } else if (frmMain.lstCharacters.SelectedItem == "Trap Shadow (Top)") {
                            // Swap Character
                            // D907
                            // 0020
                            CharacterID[0] = 0xD9
                    CharacterID[1] = 0x7
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x20
                } else if (frmMain.lstCharacters.SelectedItem == "Turbo Jet-Vac") {
                            // 6400
                            // 0528
                            CharacterID[0] = 0x64
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x5
                    CharacterVariant[1] = 0x28
                } else if (frmMain.lstCharacters.SelectedItem == "Twin Blade Chop Chop") {
                            // 1E00
                            // 0528
                            CharacterID[0] = 0x1E
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x5
                    CharacterVariant[1] = 0x28
                } else if (frmMain.lstCharacters.SelectedItem == "Volcanic Eruptor") {
                            // 0900
                            // 022C
                            CharacterID[0] = 0x9
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x2
                    CharacterVariant[1] = 0x2C
                } else if (frmMain.lstCharacters.SelectedItem == "Wash Buckler (Bottom)") {
                            // Swap Character
                            // F703
                            // 0020
                            CharacterID[0] = 0xF7
                    CharacterID[1] = 0x3
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x20
                } else if (frmMain.lstCharacters.SelectedItem == "Wash Buckler (Top)") {
                            // Swap Character
                            // DF07
                            // 0020
                            CharacterID[0] = 0xDF
                    CharacterID[1] = 0x7
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x20
                } else if (frmMain.lstCharacters.SelectedItem == "Wind-Up") {
                            // C30B
                            // 0020
                            CharacterID[0] = 0xC3
                    CharacterID[1] = 0xB
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x20
                } else if (frmMain.lstCharacters.SelectedItem == "Zoo Lou") {
                            // BF0B
                            // 0020
                            CharacterID[0] = 0xBF
                    CharacterID[1] = 0xB
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x20
                End If
            Case 3
                // Trap Team
                If frmMain.lstCharacters.SelectedItem == "Barkley") {
                                // 1C02
                                // 0030
                                CharacterID[0] = 0x1C
                    CharacterID[1] = 0x2
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Bat Spin") {
                                // E001
                                // 0030
                                CharacterID[0] = 0xE0
                    CharacterID[1] = 0x1
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Blackout") {
                                // E501
                                // 0030
                                CharacterID[0] = 0xE5
                    CharacterID[1] = 0x1
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Blades") {
                                // C501
                                // 0030
                                CharacterID[0] = 0xC5
                    CharacterID[1] = 0x1
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Blastermind") {
                                // D201
                                // 0030
                                CharacterID[0] = 0xD2
                    CharacterID[1] = 0x1
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Bop") {
                                // F601
                                // 0030
                                CharacterID[0] = 0xF6
                    CharacterID[1] = 0x1
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Breeze") {
                                // FA01
                                // 0030
                                CharacterID[0] = 0xFA
                    CharacterID[1] = 0x1
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Bushwhack") {
                                // DA01
                                // 0030
                                CharacterID[0] = 0xDA
                    CharacterID[1] = 0x1
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Chopper") {
                                // D801
                                // 0030
                                CharacterID[0] = 0xD8
                    CharacterID[1] = 0x1
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Clear Thunderbolt") {
                                // C301
                                // 1D30
                                CharacterID[0] = 0xC3
                    CharacterID[1] = 0x1
                    CharacterVariant[0] = 0x1D
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Cobra Cadabra") {
                                // D501
                                // 0030
                                CharacterID[0] = 0xD5
                    CharacterID[1] = 0x1
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Dark Food Fight") {
                                // DC01
                                // 0234
                                CharacterID[0] = 0xDC
                    CharacterID[1] = 0x1
                    CharacterVariant[0] = 0x2
                    CharacterVariant[1] = 0x34
                } else if (frmMain.lstCharacters.SelectedItem == "Dark Snap Shot") {
                                // CE01
                                // 0234
                                CharacterID[0] = 0xCE
                    CharacterID[1] = 0x1
                    CharacterVariant[0] = 0x2
                    CharacterVariant[1] = 0x34
                } else if (frmMain.lstCharacters.SelectedItem == "Dark Wildfire") {
                                // CA01
                                // 0234
                                CharacterID[0] = 0xCA
                    CharacterID[1] = 0x1
                    CharacterVariant[0] = 0x2
                    CharacterVariant[1] = 0x34
                } else if (frmMain.lstCharacters.SelectedItem == "Drobit") {
                                // FE01
                                // 0030
                                CharacterID[0] = 0xFE
                    CharacterID[1] = 0x1
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Déjà Vu") {
                                // D401
                                // 0030
                                CharacterID[0] = 0xD4
                    CharacterID[1] = 0x1
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Echo") {
                                // D101
                                // 0030
                                CharacterID[0] = 0xD1
                    CharacterID[1] = 0x1
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Eggsellent Weeruptor") {
                                // FB01
                                // 0234
                                CharacterID[0] = 0xFB
                    CharacterID[1] = 0x1
                    CharacterVariant[0] = 0x2
                    CharacterVariant[1] = 0x34
                } else if (frmMain.lstCharacters.SelectedItem == "Elite Chop Chop") {
                                // 1E00
                                // 1038
                                CharacterID[0] = 0x1E
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x10
                    CharacterVariant[1] = 0x38
                } else if (frmMain.lstCharacters.SelectedItem == "Elite Eruptor") {
                                // 0900
                                // 1038
                                CharacterID[0] = 0x9
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x10
                    CharacterVariant[1] = 0x38
                } else if (frmMain.lstCharacters.SelectedItem == "Elite Gill Grunt") {
                                // 0E00
                                // 1038
                                CharacterID[0] = 0xE
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x10
                    CharacterVariant[1] = 0x38
                } else if (frmMain.lstCharacters.SelectedItem == "Elite Spyro") {
                                // 1000
                                // 1038
                                CharacterID[0] = 0x10
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x10
                    CharacterVariant[1] = 0x38
                } else if (frmMain.lstCharacters.SelectedItem == "Elite Stealth Elf") {
                                // 1A00
                                // 1038
                                CharacterID[0] = 0x1A
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x10
                    CharacterVariant[1] = 0x38
                } else if (frmMain.lstCharacters.SelectedItem == "Elite Terrafin") {
                                // 0500
                                // 1038
                                CharacterID[0] = 0x5
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x10
                    CharacterVariant[1] = 0x38
                } else if (frmMain.lstCharacters.SelectedItem == "Elite Trigger Happy") {
                                // 1300
                                // 1038
                                CharacterID[0] = 0x13
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x10
                    CharacterVariant[1] = 0x38
                } else if (frmMain.lstCharacters.SelectedItem == "Elite Whirlwind") {
                                // 0000
                                // 1038
                                CharacterID[0] = 0x0
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x10
                    CharacterVariant[1] = 0x38
                } else if (frmMain.lstCharacters.SelectedItem == "Enigma") {
                                // D301
                                // 0030
                                CharacterID[0] = 0xD3
                    CharacterID[1] = 0x1
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Eye-Small") {
                                // 1F02
                                // 0030
                                CharacterID[0] = 0x1F
                    CharacterID[1] = 0x2
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Fist Bump") {
                                // C801
                                // 0030
                                CharacterID[0] = 0xC8
                    CharacterID[1] = 0x1
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Fizzy Frenzy Pop Fizz") {
                                // 6C00
                                // 0538
                                CharacterID[0] = 0x6C
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x5
                    CharacterVariant[1] = 0x38
                } else if (frmMain.lstCharacters.SelectedItem == "Fling Kong") {
                                // C401
                                // 0030
                                CharacterID[0] = 0xC4
                    CharacterID[1] = 0x1
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Flip Wreck") {
                                // D001
                                // 0030
                                CharacterID[0] = 0xD0
                    CharacterID[1] = 0x1
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Food Fight") {
                                // DC01
                                // 0030
                                CharacterID[0] = 0xDC
                    CharacterID[1] = 0x1
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Full Blast Jet-Vac") {
                                // 6400
                                // 0538
                                CharacterID[0] = 0x64
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x5
                    CharacterVariant[1] = 0x38
                } else if (frmMain.lstCharacters.SelectedItem == "Funny Bone") {
                                // E101
                                // 0030
                                CharacterID[0] = 0xE1
                    CharacterID[1] = 0x1
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Gearshift") {
                                // D701
                                // 0030
                                CharacterID[0] = 0xD7
                    CharacterID[1] = 0x1
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Gill Runt") {
                                // 0202
                                // 0030
                                CharacterID[0] = 0x2
                    CharacterID[1] = 0x2
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Gnarly Barkley") {
                                // 1C02
                                // 0234
                                CharacterID[0] = 0x1C
                    CharacterID[1] = 0x2
                    CharacterVariant[0] = 0x2
                    CharacterVariant[1] = 0x34
                } else if (frmMain.lstCharacters.SelectedItem == "Gusto") {
                                // C201
                                // 0030
                                CharacterID[0] = 0xC2
                    CharacterID[1] = 0x1
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Head Rush") {
                                // C701
                                // 0030
                                CharacterID[0] = 0xC7
                    CharacterID[1] = 0x1
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "High Five") {
                                // DD01
                                // 0030
                                CharacterID[0] = 0xDD
                    CharacterID[1] = 0x1
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Hijinx") {
                                // F801
                                // 0030
                                CharacterID[0] = 0xF8
                    CharacterID[1] = 0x1
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Hog Wild Fryno") {
                                // BC0B
                                // 0138
                                CharacterID[0] = 0xBC
                    CharacterID[1] = 0xB
                    CharacterVariant[0] = 0x1
                    CharacterVariant[1] = 0x38
                } else if (frmMain.lstCharacters.SelectedItem == "Instant Food Fight") {

                                blnNoCode = True
                } else if (frmMain.lstCharacters.SelectedItem == "Instant Snap Shot") {

                                blnNoCode = True
                } else if (frmMain.lstCharacters.SelectedItem == "Jawbreaker") {
                                // D601
                                // 0030
                                CharacterID[0] = 0xD6
                    CharacterID[1] = 0x1
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Ka-Boom") {
                                // CB01
                                // 0030
                                CharacterID[0] = 0xCB
                    CharacterID[1] = 0x1
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "King Cobra Cadabra") {
                                // D501
                                // 0234
                                CharacterID[0] = 0xD5
                    CharacterID[1] = 0x1
                    CharacterVariant[0] = 0x2
                    CharacterVariant[1] = 0x34
                } else if (frmMain.lstCharacters.SelectedItem == "Knight Light") {
                                // E201
                                // 0030
                                CharacterID[0] = 0xE2
                    CharacterID[1] = 0x1
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Knight Mare") {
                                // E401
                                // 0030
                                CharacterID[0] = 0xE4
                    CharacterID[1] = 0x1
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Krypt King") {
                                // DE01
                                // 0030
                                CharacterID[0] = 0xDE
                    CharacterID[1] = 0x1
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Legendary Blades") {
                                // C501
                                // 0334
                                CharacterID[0] = 0xC5
                    CharacterID[1] = 0x1
                    CharacterVariant[0] = 0x3
                    CharacterVariant[1] = 0x34
                } else if (frmMain.lstCharacters.SelectedItem == "Legendary Bushwhack") {
                                // DA01
                                // 0334
                                CharacterID[0] = 0xDA
                    CharacterID[1] = 0x1
                    CharacterVariant[0] = 0x3
                    CharacterVariant[1] = 0x34
                } else if (frmMain.lstCharacters.SelectedItem == "Legendary Déjà Vu") {
                                // D401
                                // 0334
                                CharacterID[0] = 0xD4
                    CharacterID[1] = 0x1
                    CharacterVariant[0] = 0x3
                    CharacterVariant[1] = 0x34
                } else if (frmMain.lstCharacters.SelectedItem == "Legendary Jawbreaker") {
                                // D601
                                // 0334
                                CharacterID[0] = 0xD6
                    CharacterID[1] = 0x1
                    CharacterVariant[0] = 0x3
                    CharacterVariant[1] = 0x34
                } else if (frmMain.lstCharacters.SelectedItem == "Lob-Star") {
                                // CF01
                                // 0030
                                CharacterID[0] = 0xCF
                    CharacterID[1] = 0x1
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Love Potion Pop Fizz") {
                                // 6C00
                                // 023C
                                CharacterID[0] = 0x6C
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x2
                    CharacterVariant[1] = 0x3C
                } else if (frmMain.lstCharacters.SelectedItem == "Mini-Jini") {
                                // 1E02
                                // 0030
                                CharacterID[0] = 0x1E
                    CharacterID[1] = 0x2
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Nitro Head Rush") {
                                // C701
                                // 0234
                                CharacterID[0] = 0xC7
                    CharacterID[1] = 0x1
                    CharacterVariant[0] = 0x2
                    CharacterVariant[1] = 0x34
                } else if (frmMain.lstCharacters.SelectedItem == "Nitro Krypt King") {
                                // DE01
                                // 0234
                                CharacterID[0] = 0xDE
                    CharacterID[1] = 0x1
                    CharacterVariant[0] = 0x2
                    CharacterVariant[1] = 0x34
                } else if (frmMain.lstCharacters.SelectedItem == "Pet-Vac") {
                                // FC01
                                // 0030
                                CharacterID[0] = 0xFC
                    CharacterID[1] = 0x1
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Power Punch Pet-Vac") {
                                // FC01
                                // 0234
                                CharacterID[0] = 0xFC
                    CharacterID[1] = 0x1
                    CharacterVariant[0] = 0x2
                    CharacterVariant[1] = 0x34
                } else if (frmMain.lstCharacters.SelectedItem == "Rocky Roll") {
                                // C901
                                // 0030
                                CharacterID[0] = 0xC9
                    CharacterID[1] = 0x1
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Short Cut") {
                                // DF01
                                // 0030
                                CharacterID[0] = 0xDF
                    CharacterID[1] = 0x1
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Small Fry") {
                                // FD01
                                // 0030
                                CharacterID[0] = 0xFD
                    CharacterID[1] = 0x1
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Snap Shot") {
                                // CE01
                                // 0030
                                CharacterID[0] = 0xCE
                    CharacterID[1] = 0x1
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Spotlight") {
                                // E301
                                // 0030
                                CharacterID[0] = 0xE3
                    CharacterID[1] = 0x1
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Spry") {
                                // F701
                                // 0030
                                CharacterID[0] = 0xF7
                    CharacterID[1] = 0x1
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Sure Shot Shroomboom") {
                                // 7100
                                // 0138
                                CharacterID[0] = 0x71
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x1
                    CharacterVariant[1] = 0x38
                } else if (frmMain.lstCharacters.SelectedItem == "Terrabite") {
                                // F901
                                // 0030
                                CharacterID[0] = 0xF9
                    CharacterID[1] = 0x1
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Thumpling") {
                                // 1D02
                                // 0030
                                CharacterID[0] = 0x1D
                    CharacterID[1] = 0x2
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Thunderbolt") {
                                // C301
                                // 0030
                                CharacterID[0] = 0xC3
                    CharacterID[1] = 0x1
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Tidal Wave Gill Grunt") {
                                // 0E00
                                // 0938
                                CharacterID[0] = 0xE
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x9
                    CharacterVariant[1] = 0x38
                } else if (frmMain.lstCharacters.SelectedItem == "Torch") {
                                // CD01
                                // 0030
                                CharacterID[0] = 0xCD
                    CharacterID[1] = 0x1
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Trail Blazer") {
                                // CC01
                                // 0030
                                CharacterID[0] = 0xCC
                    CharacterID[1] = 0x1
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Tread Head") {
                                // D901
                                // 0030
                                CharacterID[0] = 0xD9
                    CharacterID[1] = 0x1
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Trigger Snappy") {
                                // 0702
                                // 0030
                                CharacterID[0] = 0x7
                    CharacterID[1] = 0x2
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Tuff Luck") {
                                // DB01
                                // 0030
                                CharacterID[0] = 0xDB
                    CharacterID[1] = 0x1
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Wallop") {
                                // C601
                                // 0030
                                CharacterID[0] = 0xC6
                    CharacterID[1] = 0x1
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Weeruptor") {
                                // FB01
                                // 0030
                                CharacterID[0] = 0xFB
                    CharacterID[1] = 0x1
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Whisper Elf") {
                                // 0E02
                                // 0030
                                CharacterID[0] = 0xE
                    CharacterID[1] = 0x2
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Wildfire") {
                                // CA01
                                // 0030
                                CharacterID[0] = 0xCA
                    CharacterID[1] = 0x1
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Winterfest Lob-Star") {
                                // CF01
                                // 0234
                                CharacterID[0] = 0xCF
                    CharacterID[1] = 0x1
                    CharacterVariant[0] = 0x2
                    CharacterVariant[1] = 0x34
                End If
            Case 4
                // Superchargers
                If frmMain.lstCharacters.SelectedItem == "Astroblast") {
                                    // 620D
                                    // 0041
                                    CharacterID[0] = 0x62
                    CharacterID[1] = 0xD
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x41
                } else if (frmMain.lstCharacters.SelectedItem == "Barrel Blaster") {
                                    // A80C
                                    // 0040
                                    CharacterID[0] = 0xA8
                    CharacterID[1] = 0xC
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x40
                } else if (frmMain.lstCharacters.SelectedItem == "Big Bubble Pop Fizz") {
                                    // 5C0D
                                    // 0041
                                    CharacterID[0] = 0x5C
                    CharacterID[1] = 0xD
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x41
                } else if (frmMain.lstCharacters.SelectedItem == "Birthday Bash Big Bubble Pop Fizz") {
                                    // 5C0D
                                    // 0E45
                                    CharacterID[0] = 0x5C
                    CharacterID[1] = 0xD
                    CharacterVariant[0] = 0xE
                    CharacterVariant[1] = 0x45
                } else if (frmMain.lstCharacters.SelectedItem == "Bone Bash Roller Brawl") {
                                    // 590D
                                    // 0041
                                    CharacterID[0] = 0x59
                    CharacterID[1] = 0xD
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x41
                } else if (frmMain.lstCharacters.SelectedItem == "Burn-Cycle") {
                                    // 970C
                                    // 0040
                                    CharacterID[0] = 0x97
                    CharacterID[1] = 0xC
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x40
                } else if (frmMain.lstCharacters.SelectedItem == "Buzz Wing") {
                                    // A909
                                    // 0040
                                    CharacterID[0] = 0xA9
                    CharacterID[1] = 0x9
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x40
                } else if (frmMain.lstCharacters.SelectedItem == "Clown Cruiser") {
                                    // A10C
                                    // 0040
                                    CharacterID[0] = 0xA1
                    CharacterID[1] = 0xC
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x40
                } else if (frmMain.lstCharacters.SelectedItem == "Crypt Crusher") {
                                    // 9B0C
                                    // 0040
                                    CharacterID[0] = 0x9B
                    CharacterID[1] = 0xC
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x40
                } else if (frmMain.lstCharacters.SelectedItem == "Dark Barrel Blaster") {
                                    // A80C
                                    // 0244
                                    CharacterID[0] = 0xA8
                    CharacterID[1] = 0xC
                    CharacterVariant[0] = 0x2
                    CharacterVariant[1] = 0x44
                } else if (frmMain.lstCharacters.SelectedItem == "Dark Clown Cruiser") {
                                    // A10C
                                    // 0244
                                    CharacterID[0] = 0xA1
                    CharacterID[1] = 0xC
                    CharacterVariant[0] = 0x2
                    CharacterVariant[1] = 0x44
                } else if (frmMain.lstCharacters.SelectedItem == "Dark Hammer Slam Bowser") {
                                    // 600D
                                    // 0245
                                    CharacterID[0] = 0x60
                    CharacterID[1] = 0xD
                    CharacterVariant[0] = 0x2
                    CharacterVariant[1] = 0x45
                } else if (frmMain.lstCharacters.SelectedItem == "Dark Hot Streak") {
                                    // 980C
                                    // 0244
                                    CharacterID[0] = 0x98
                    CharacterID[1] = 0xC
                    CharacterVariant[0] = 0x2
                    CharacterVariant[1] = 0x44
                } else if (frmMain.lstCharacters.SelectedItem == "Dark Sea Shadow") {
                                    // A50C
                                    // 0244
                                    CharacterID[0] = 0xA5
                    CharacterID[1] = 0xC
                    CharacterVariant[0] = 0x2
                    CharacterVariant[1] = 0x44
                } else if (frmMain.lstCharacters.SelectedItem == "Dark Spitfire") {
                                    // 540D
                                    // 0245
                                    CharacterID[0] = 0x54
                    CharacterID[1] = 0xD
                    CharacterVariant[0] = 0x2
                    CharacterVariant[1] = 0x45
                } else if (frmMain.lstCharacters.SelectedItem == "Dark Super Shot Stealth Elf") {
                                    // 570D
                                    // 0245
                                    CharacterID[0] = 0x57
                    CharacterID[1] = 0xD
                    CharacterVariant[0] = 0x2
                    CharacterVariant[1] = 0x45
                } else if (frmMain.lstCharacters.SelectedItem == "Dark Turbo Charge Donkey Kong") {
                                    // 5F0D
                                    // 0245
                                    CharacterID[0] = 0x5F
                    CharacterID[1] = 0xD
                    CharacterVariant[0] = 0x2
                    CharacterVariant[1] = 0x45
                } else if (frmMain.lstCharacters.SelectedItem == "Deep Dive Gill Grunt") {
                                    // 5E0D
                                    // 0041
                                    CharacterID[0] = 0x5E
                    CharacterID[1] = 0xD
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x41
                } else if (frmMain.lstCharacters.SelectedItem == "Dive Bomber") {
                                    // 9F0C
                                    // 0040
                                    CharacterID[0] = 0x9F
                    CharacterID[1] = 0xC
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x40
                } else if (frmMain.lstCharacters.SelectedItem == "Dive-Clops") {
                                    // 610D
                                    // 0041
                                    CharacterID[0] = 0x61
                    CharacterID[1] = 0xD
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x41
                } else if (frmMain.lstCharacters.SelectedItem == "Double Dare Trigger Happy") {
                                    // 560D
                                    // 0041
                                    CharacterID[0] = 0x56
                    CharacterID[1] = 0xD
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x41
                } else if (frmMain.lstCharacters.SelectedItem == "E3 Hot Streak") {
                                    // 970C
                                    // 0440
                                    CharacterID[0] = 0x97
                    CharacterID[1] = 0xC
                    CharacterVariant[0] = 0x4
                    CharacterVariant[1] = 0x40
                } else if (frmMain.lstCharacters.SelectedItem == "Eggcited Thrillipede") {
                                    // 640D
                                    // 0D45
                                    CharacterID[0] = 0x64
                    CharacterID[1] = 0xD
                    CharacterVariant[0] = 0xD
                    CharacterVariant[1] = 0x45
                } else if (frmMain.lstCharacters.SelectedItem == "Elite Boomer") {
                                    // 1600
                                    // 1048
                                    CharacterID[0] = 0x16
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x10
                    CharacterVariant[1] = 0x48
                } else if (frmMain.lstCharacters.SelectedItem == "Elite Dino-Rang") {
                                    // 0600
                                    // 1048
                                    CharacterID[0] = 0x6
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x10
                    CharacterVariant[1] = 0x48
                } else if (frmMain.lstCharacters.SelectedItem == "Elite Ghost Roaster") {
                                    // 1F00
                                    // 1048
                                    CharacterID[0] = 0x1F
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x10
                    CharacterVariant[1] = 0x48
                } else if (frmMain.lstCharacters.SelectedItem == "Elite Slam Bam") {
                                    // 0f00
                                    // 1048
                                    CharacterID[0] = 0xF
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x10
                    CharacterVariant[1] = 0x48
                } else if (frmMain.lstCharacters.SelectedItem == "Elite Voodood") {
                                    // 1100
                                    // 1148
                                    CharacterID[0] = 0x11
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x11
                    CharacterVariant[1] = 0x48
                } else if (frmMain.lstCharacters.SelectedItem == "Elite Zook") {
                                    // 1900
                                    // 1048
                                    CharacterID[0] = 0x19
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x10
                    CharacterVariant[1] = 0x48
                } else if (frmMain.lstCharacters.SelectedItem == "Fiesta") {
                                    // 480D
                                    // 0041
                                    CharacterID[0] = 0x48
                    CharacterID[1] = 0xD
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x41
                } else if (frmMain.lstCharacters.SelectedItem == "Frightful Fiesta") {
                                    // 480D
                                    // 1545
                                    CharacterID[0] = 0x48
                    CharacterID[1] = 0xD
                    CharacterVariant[0] = 0x15
                    CharacterVariant[1] = 0x45
                } else if (frmMain.lstCharacters.SelectedItem == "Gold Rusher") {
                                    // A20C
                                    // 0040
                                    CharacterID[0] = 0xA2
                    CharacterID[1] = 0xC
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x40
                } else if (frmMain.lstCharacters.SelectedItem == "Golden Hot Streak") {
                                    // 980C
                                    // 1E44
                                    CharacterID[0] = 0x98
                    CharacterID[1] = 0xC
                    CharacterVariant[0] = 0x1E
                    CharacterVariant[1] = 0x44
                } else if (frmMain.lstCharacters.SelectedItem == "Hammer Slam Bowser") {
                                    // 600D
                                    // 0041
                                    CharacterID[0] = 0x60
                    CharacterID[1] = 0xD
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x41
                } else if (frmMain.lstCharacters.SelectedItem == "High Volt") {
                                    // 490D
                                    // 0041
                                    CharacterID[0] = 0x49
                    CharacterID[1] = 0xD
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x41
                } else if (frmMain.lstCharacters.SelectedItem == "Hot Streak") {
                                    // 980C
                                    // 0440
                                    CharacterID[0] = 0x98
                    CharacterID[1] = 0xC
                    CharacterVariant[0] = 0x4
                    CharacterVariant[1] = 0x40
                } else if (frmMain.lstCharacters.SelectedItem == "Hurricane Jet-Vac") {
                                    // 550D
                                    // 0041
                                    CharacterID[0] = 0x55
                    CharacterID[1] = 0xD
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x41
                } else if (frmMain.lstCharacters.SelectedItem == "Instant Dive Bomber") {

                                    blnNoCode = True
                } else if (frmMain.lstCharacters.SelectedItem == "Instant Dive-Clops") {

                                    blnNoCode = True
                } else if (frmMain.lstCharacters.SelectedItem == "Instant Hot Streak") {

                                    blnNoCode = True
                } else if (frmMain.lstCharacters.SelectedItem == "Instant Spitfire") {

                                    blnNoCode = True
                } else if (frmMain.lstCharacters.SelectedItem == "Instant Stealth Stinger") {

                                    blnNoCode = True
                } else if (frmMain.lstCharacters.SelectedItem == "Instant Super Shot Stealth Elf") {

                                    blnNoCode = True
                } else if (frmMain.lstCharacters.SelectedItem == "Jet Stream") {
                                    // 940C
                                    // 0040
                                    CharacterID[0] = 0x94
                    CharacterID[1] = 0xC
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x40
                } else if (frmMain.lstCharacters.SelectedItem == "Kaos Trophy") {
                                    // AF0D
                                    // 0040
                                    CharacterID[0] = 0xAF
                    CharacterID[1] = 0xD
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x40
                } else if (frmMain.lstCharacters.SelectedItem == "Land Trophy") {
                                    // AD0D
                                    // 0040
                                    CharacterID[0] = 0xAD
                    CharacterID[1] = 0xD
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x40
                } else if (frmMain.lstCharacters.SelectedItem == "Lava Lance Eruptor") {
                                    // 5D0D
                                    // 0041
                                    CharacterID[0] = 0x5D
                    CharacterID[1] = 0xD
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x41
                } else if (frmMain.lstCharacters.SelectedItem == "Legendary Astroblast") {
                                    // 620D
                                    // 0345
                                    CharacterID[0] = 0x62
                    CharacterID[1] = 0xD
                    CharacterVariant[0] = 0x3
                    CharacterVariant[1] = 0x45
                } else if (frmMain.lstCharacters.SelectedItem == "Legendary Bone Bash Roller Brawl") {
                                    // 590D
                                    // 0345
                                    CharacterID[0] = 0x59
                    CharacterID[1] = 0xD
                    CharacterVariant[0] = 0x3
                    CharacterVariant[1] = 0x45
                } else if (frmMain.lstCharacters.SelectedItem == "Legendary Hurricane Jet-Vac") {
                                    // 550D
                                    // 0345
                                    CharacterID[0] = 0x55
                    CharacterID[1] = 0xD
                    CharacterVariant[0] = 0x3
                    CharacterVariant[1] = 0x45
                } else if (frmMain.lstCharacters.SelectedItem == "Legendary Sun Runner") {
                                    // A40C
                                    // 0344
                                    CharacterID[0] = 0xA4
                    CharacterID[1] = 0xC
                    CharacterVariant[0] = 0x3
                    CharacterVariant[1] = 0x44
                } else if (frmMain.lstCharacters.SelectedItem == "Missile-Tow Dive-Clops") {
                                    // 610D
                                    // 0E45
                                    CharacterID[0] = 0x61
                    CharacterID[1] = 0xD
                    CharacterVariant[0] = 0xE
                    CharacterVariant[1] = 0x45
                } else if (frmMain.lstCharacters.SelectedItem == "Nightfall") {
                                    // 630D
                                    // 0041
                                    CharacterID[0] = 0x63
                    CharacterID[1] = 0xD
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x41
                } else if (frmMain.lstCharacters.SelectedItem == "Nitro Soda Skimmer") {
                                    // A70C
                                    // 0244
                                    CharacterID[0] = 0xA7
                    CharacterID[1] = 0xC
                    CharacterVariant[0] = 0x2
                    CharacterVariant[1] = 0x44
                } else if (frmMain.lstCharacters.SelectedItem == "Nitro Stealth Stinger") {
                                    // 9C0C
                                    // 0244
                                    CharacterID[0] = 0x9C
                    CharacterID[1] = 0xC
                    CharacterVariant[0] = 0x2
                    CharacterVariant[1] = 0x44
                } else if (frmMain.lstCharacters.SelectedItem == "Power Blue Gold Rusher") {
                                    // A20C
                                    // 0244
                                    CharacterID[0] = 0xA2
                    CharacterID[1] = 0xC
                    CharacterVariant[0] = 0x2
                    CharacterVariant[1] = 0x44
                } else if (frmMain.lstCharacters.SelectedItem == "Power Blue Splat") {
                                    // 4A0D
                                    // 0245
                                    CharacterID[0] = 0x4A
                    CharacterID[1] = 0xD
                    CharacterVariant[0] = 0x2
                    CharacterVariant[1] = 0x45
                } else if (frmMain.lstCharacters.SelectedItem == "Power Blue Splatter Splasher") {
                                    // A60C
                                    // 0244
                                    CharacterID[0] = 0xA6
                    CharacterID[1] = 0xC
                    CharacterVariant[0] = 0x2
                    CharacterVariant[1] = 0x44
                } else if (frmMain.lstCharacters.SelectedItem == "Power Blue Trigger Happy") {
                                    // 560D
                                    // 0245
                                    CharacterID[0] = 0x56
                    CharacterID[1] = 0xD
                    CharacterVariant[0] = 0x2
                    CharacterVariant[1] = 0x45
                } else if (frmMain.lstCharacters.SelectedItem == "Reef Ripper") {
                                    // 960C
                                    // 0040
                                    CharacterID[0] = 0x96
                    CharacterID[1] = 0xC
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x40
                } else if (frmMain.lstCharacters.SelectedItem == "Sea Shadow") {
                                    // A50C
                                    // 0040
                                    CharacterID[0] = 0xA5
                    CharacterID[1] = 0xC
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x40
                } else if (frmMain.lstCharacters.SelectedItem == "Sea Trophy") {
                                    // AE0D
                                    // 0040
                                    CharacterID[0] = 0xAE
                    CharacterID[1] = 0xD
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x40
                } else if (frmMain.lstCharacters.SelectedItem == "Shark Shooter Terrafin") {
                                    // 580D
                                    // 0041
                                    CharacterID[0] = 0x58
                    CharacterID[1] = 0xD
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x41
                } else if (frmMain.lstCharacters.SelectedItem == "Shark Tank") {
                                    // 990C
                                    // 0040
                                    CharacterID[0] = 0x99
                    CharacterID[1] = 0xC
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x40
                } else if (frmMain.lstCharacters.SelectedItem == "Shield Striker") {
                                    // A30C
                                    // 0040
                                    CharacterID[0] = 0xA3
                    CharacterID[1] = 0xC
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x40
                } else if (frmMain.lstCharacters.SelectedItem == "Sky Slicer") {
                                    // A00C
                                    // 0040
                                    CharacterID[0] = 0xA0
                    CharacterID[1] = 0xC
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x40
                } else if (frmMain.lstCharacters.SelectedItem == "Sky Trophy") {
                                    // AC0D
                                    // 0040
                                    CharacterID[0] = 0xAC
                    CharacterID[1] = 0xD
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x40
                } else if (frmMain.lstCharacters.SelectedItem == "Smash Hit") {
                                    // 530D
                                    // 0041
                                    CharacterID[0] = 0x53
                    CharacterID[1] = 0xD
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x41
                } else if (frmMain.lstCharacters.SelectedItem == "Soda Skimmer") {
                                    // A70C
                                    // 0040
                                    CharacterID[0] = 0xA7
                    CharacterID[1] = 0xC
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x40
                } else if (frmMain.lstCharacters.SelectedItem == "Spitfire") {
                                    // 540D
                                    // 0041
                                    CharacterID[0] = 0x54
                    CharacterID[1] = 0xD
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x41
                } else if (frmMain.lstCharacters.SelectedItem == "Splat") {
                                    // 4A0D
                                    // 0041
                                    CharacterID[0] = 0x4A
                    CharacterID[1] = 0xD
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x41
                } else if (frmMain.lstCharacters.SelectedItem == "Splatter Splasher") {
                                    // A60C
                                    // 0040
                                    CharacterID[0] = 0xA6
                    CharacterID[1] = 0xC
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x40
                } else if (frmMain.lstCharacters.SelectedItem == "Spring Ahead Dive Bomber") {
                                    // 9F0C
                                    // 0244
                                    CharacterID[0] = 0x9F
                    CharacterID[1] = 0xC
                    CharacterVariant[0] = 0x2
                    CharacterVariant[1] = 0x44
                } else if (frmMain.lstCharacters.SelectedItem == "Stealth Stinger") {
                                    // 9C0C
                                    // 0040
                                    CharacterID[0] = 0x9C
                    CharacterID[1] = 0xC
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x40
                } else if (frmMain.lstCharacters.SelectedItem == "Steel Plated Smash Hit") {
                                    // 530D
                                    // 0245
                                    CharacterID[0] = 0x53
                    CharacterID[1] = 0xD
                    CharacterVariant[0] = 0x2
                    CharacterVariant[1] = 0x45
                } else if (frmMain.lstCharacters.SelectedItem == "Stormblade") {
                                    // 4e0d
                                    // 0041
                                    CharacterID[0] = 0x4E
                    CharacterID[1] = 0xD
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x41
                } else if (frmMain.lstCharacters.SelectedItem == "Sun Runner") {
                                    // A40C
                                    // 0040
                                    CharacterID[0] = 0xA4
                    CharacterID[1] = 0xC
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x40
                } else if (frmMain.lstCharacters.SelectedItem == "Super Shot Stealth Elf") {
                                    // 570D
                                    // 0041
                                    CharacterID[0] = 0x57
                    CharacterID[1] = 0xD
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x41
                } else if (frmMain.lstCharacters.SelectedItem == "Thrillipede") {
                                    // 640D
                                    // 0041
                                    CharacterID[0] = 0x64
                    CharacterID[1] = 0xD
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x41
                } else if (frmMain.lstCharacters.SelectedItem == "Thump Truck") {
                                    // 9A0C
                                    // 0040
                                    CharacterID[0] = 0x9A
                    CharacterID[1] = 0xC
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x40
                } else if (frmMain.lstCharacters.SelectedItem == "Tomb Buggy") {
                                    // 950C
                                    // 0040
                                    CharacterID[0] = 0x95
                    CharacterID[1] = 0xC
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x40
                } else if (frmMain.lstCharacters.SelectedItem == "Turbo Charge Donkey Kong") {
                                    // 5F0D
                                    // 0041
                                    CharacterID[0] = 0x5F
                    CharacterID[1] = 0xD
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x41
                End If
            Case 5
                // Imaginators
                CharacterVariant[0] = 0x0
                CharacterVariant[1] = 0x50
                If frmMain.lstCharacters.SelectedItem == "Air Strike") {
                                        // 5F02
                                        CharacterID[0] = 0x5F
                    CharacterID[1] = 0x2
                } else if (frmMain.lstCharacters.SelectedItem == "Ambush") {
                                        // 6102
                                        CharacterID[0] = 0x61
                    CharacterID[1] = 0x2
                } else if (frmMain.lstCharacters.SelectedItem == "Aurora") {
                                        // 6B02
                                        // Aurora
                                        CharacterID[0] = 0x6B
                    CharacterID[1] = 0x2
                } else if (frmMain.lstCharacters.SelectedItem == "Bad Juju") {
                                        // 6E02
                                        // Bad Juju
                                        CharacterID[0] = 0x6E
                    CharacterID[1] = 0x2
                } else if (frmMain.lstCharacters.SelectedItem == "Barbella") {
                                        // Barbella
                                        // 5E02
                                        CharacterID[0] = 0x5E
                    CharacterID[1] = 0x2
                } else if (frmMain.lstCharacters.SelectedItem == "Blaster-Tron") {
                                        // 7002
                                        // Blaster-Tron
                                        CharacterID[0] = 0x70
                    CharacterID[1] = 0x2
                } else if (frmMain.lstCharacters.SelectedItem == "Boom Bloom") {
                                        // 5C02
                                        // Boom Bloom
                                        CharacterID[0] = 0x5C
                    CharacterID[1] = 0x2
                } else if (frmMain.lstCharacters.SelectedItem == "Buckshot") {
                                        // 6A02
                                        // Buckshot
                                        CharacterID[0] = 0x6A
                    CharacterID[1] = 0x2
                } else if (frmMain.lstCharacters.SelectedItem == "Candy-Coated Chopscotch") {
                                        // 5B02
                                        CharacterVariant[0] = 0x15
                    CharacterVariant[1] = 0x54
                    CharacterID[0] = 0x5B
                    CharacterID[1] = 0x2
                } else if (frmMain.lstCharacters.SelectedItem == "Chain Reaction") {
                                        // 7202
                                        // Chain Reaction
                                        CharacterID[0] = 0x72
                    CharacterID[1] = 0x2
                } else if (frmMain.lstCharacters.SelectedItem == "Chompy Mage") {
                                        // 6D02
                                        // Chompy Mage
                                        CharacterID[0] = 0x6D
                    CharacterID[1] = 0x2
                } else if (frmMain.lstCharacters.SelectedItem == "Chopscotch") {
                                        // 5B02
                                        // Chopscotch
                                        CharacterID[0] = 0x5B
                    CharacterID[1] = 0x2
                } else if (frmMain.lstCharacters.SelectedItem == "Crash Bandicoot") {
                                        // 7602
                                        // Crash Bandicoot
                                        CharacterID[0] = 0x76
                    CharacterID[1] = 0x2
                } else if (frmMain.lstCharacters.SelectedItem == "Dark Golden Queen") {
                                        CharacterVariant[0] = 0x2
                    CharacterVariant[1] = 0x54
                    CharacterID[0] = 0x65
                    CharacterID[1] = 0x2
                } else if (frmMain.lstCharacters.SelectedItem == "Dark King Pen") {
                                        CharacterVariant[0] = 0x2
                    CharacterVariant[1] = 0x54
                    CharacterID[0] = 0x59
                    CharacterID[1] = 0x2
                } else if (frmMain.lstCharacters.SelectedItem == "Dark Wolfgang") {
                                        CharacterVariant[0] = 0x2
                    CharacterVariant[1] = 0x54
                    CharacterID[0] = 0x66
                    CharacterID[1] = 0x2
                } else if (frmMain.lstCharacters.SelectedItem == "Dr. Krankcase") {
                                        // 6202
                                        // Dr.Krankcase
                                        CharacterID[0] = 0x62
                    CharacterID[1] = 0x2
                } else if (frmMain.lstCharacters.SelectedItem == "Dr. Neo Cortex") {
                                        // 7702
                                        // Dr.Neo Cortex
                                        CharacterID[0] = 0x77
                    CharacterID[1] = 0x2
                } else if (frmMain.lstCharacters.SelectedItem == "Egg Bomber Air Strike") {
                                        CharacterVariant[0] = 0xD
                    CharacterVariant[1] = 0x54
                    CharacterID[0] = 0x5F
                    CharacterID[1] = 0x2
                } else if (frmMain.lstCharacters.SelectedItem == "Ember") {
                                        // 6002
                                        // Ember
                                        CharacterID[0] = 0x60
                    CharacterID[1] = 0x2
                } else if (frmMain.lstCharacters.SelectedItem == "Flare Wolf") {
                                        // 6C02
                                        // Flarewolf
                                        CharacterID[0] = 0x6C
                    CharacterID[1] = 0x2
                } else if (frmMain.lstCharacters.SelectedItem == "Golden Queen") {
                                        // 6502
                                        // Golden Queen
                                        CharacterID[0] = 0x65
                    CharacterID[1] = 0x2
                } else if (frmMain.lstCharacters.SelectedItem == "Grave Clobber") {
                                        // 6F02
                                        // Grave Clobber
                                        CharacterID[0] = 0x6F
                    CharacterID[1] = 0x2
                } else if (frmMain.lstCharacters.SelectedItem == "Hard-Boiled Flare Wolf") {
                                        CharacterVariant[0] = 0xD
                    CharacterVariant[1] = 0x54
                    CharacterID[0] = 0x6C
                    CharacterID[1] = 0x2
                } else if (frmMain.lstCharacters.SelectedItem == "Heartbreaker Buckshot") {
                                        CharacterVariant[0] = 0xD
                    CharacterVariant[1] = 0x54
                    CharacterID[0] = 0x6A
                    CharacterID[1] = 0x2
                    frmMain.SaldeStatus.Text = "WARNING: Expermential"
                } else if (frmMain.lstCharacters.SelectedItem == "Hood Sickle") {
                                        // 6302
                                        // Hood Sickle
                                        CharacterID[0] = 0x63
                    CharacterID[1] = 0x2
                } else if (frmMain.lstCharacters.SelectedItem == "Jingle Bell Chompy Mage") {
                                        CharacterVariant[0] = 0xE
                    CharacterVariant[1] = 0x54
                    CharacterID[0] = 0x6D
                    CharacterID[1] = 0x2
                } else if (frmMain.lstCharacters.SelectedItem == "Kaos") {
                                        // 7302
                                        CharacterID[0] = 0x73
                    CharacterID[0] = 0x2
                } else if (frmMain.lstCharacters.SelectedItem == "King Pen") {
                                        // 5902
                                        // King Pen
                                        CharacterID[0] = 0x59
                    CharacterID[1] = 0x2
                } else if (frmMain.lstCharacters.SelectedItem == "Legendary Pit Boss") {
                                        CharacterVariant[0] = 0x3
                    CharacterVariant[1] = 0x54
                    CharacterID[0] = 0xD
                    CharacterID[1] = 0x25
                } else if (frmMain.lstCharacters.SelectedItem == "Legendary Tri-Tip") {
                                        CharacterVariant[0] = 0x3
                    CharacterVariant[1] = 0x54
                    CharacterID[0] = 0x5A
                    CharacterID[1] = 0x2
                } else if (frmMain.lstCharacters.SelectedItem == "Mystical Bad Juju") {
                                        CharacterVariant[0] = 0x2
                    CharacterVariant[1] = 0x54
                    CharacterID[0] = 0x6E
                    CharacterID[1] = 0x2
                } else if (frmMain.lstCharacters.SelectedItem == "Mystical Tae Kwon Crow") {
                                        CharacterVariant[0] = 0x2
                    CharacterVariant[1] = 0x54
                    CharacterID[0] = 0x64
                    CharacterID[1] = 0x2
                    // blnNoCode = True
                } else if (frmMain.lstCharacters.SelectedItem == "Mysticat") {
                                        // 6802
                                        // Mysticat
                                        CharacterID[0] = 0x68
                    CharacterID[1] = 0x2
                } else if (frmMain.lstCharacters.SelectedItem == "Pain-Yatta") {
                                        // 6702
                                        // Pain-Yatta
                                        CharacterID[0] = 0x67
                    CharacterID[1] = 0x2
                } else if (frmMain.lstCharacters.SelectedItem == "Pit Boss") {
                                        // 0D25
                                        CharacterID[0] = 0xD
                    CharacterID[1] = 0x25
                    blnNoCode = True
                } else if (frmMain.lstCharacters.SelectedItem == "Ro-Bow") {
                                        // 7102
                                        // Ro-Bow
                                        CharacterID[0] = 0x71
                    CharacterID[1] = 0x2
                } else if (frmMain.lstCharacters.SelectedItem == "Solar Flare Aurora") {
                                        CharacterVariant[0] = 0x2
                    CharacterVariant[1] = 0x54
                    CharacterID[0] = 0x6B
                    CharacterID[1] = 0x2
                } else if (frmMain.lstCharacters.SelectedItem == "Starcast") {
                                        // 6902
                                        // Starcast
                                        CharacterID[0] = 0x69
                    CharacterID[1] = 0x2
                } else if (frmMain.lstCharacters.SelectedItem == "Steel Plated Hood Sickle") {
                                        CharacterVariant[0] = 0x2
                    CharacterVariant[1] = 0x54
                    CharacterID[0] = 0x63
                    CharacterID[1] = 0x2
                } else if (frmMain.lstCharacters.SelectedItem == "Tae Kwon Crow") {
                                        // 6402
                                        // Tae Kwon Crow
                                        CharacterID[0] = 0x64
                    CharacterID[1] = 0x2
                } else if (frmMain.lstCharacters.SelectedItem == "Tidepool") {
                                        // 7502
                                        // Tidepool
                                        CharacterID[0] = 0x75
                    CharacterID[1] = 0x2
                } else if (frmMain.lstCharacters.SelectedItem == "Tri-Tip") {
                                        // 5A02
                                        // Tri-Tip
                                        CharacterID[0] = 0x5A
                    CharacterID[1] = 0x2
                } else if (frmMain.lstCharacters.SelectedItem == "Wild Storm") {
                                        // 7402
                                        CharacterID[0] = 0x74
                    CharacterID[1] = 0x2
                    // Wild Storm
                } else if (frmMain.lstCharacters.SelectedItem == "Wolfgang") {
                                        // 6602
                                        // Wolfgang
                                        CharacterID[0] = 0x66
                    CharacterID[1] = 0x2
                    // Chests
                End If
            Case 6
                // Items
                If frmMain.lstCharacters.SelectedItem == "Anvil Rain") {
                                            // C800
                                            // 0020
                                            CharacterID[0] = 0xC8
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x20
                } else if (frmMain.lstCharacters.SelectedItem == "Arkeyan Crossbow") {
                                            // E70C
                                            // 0622
                                            CharacterID[0] = 0xE7
                    CharacterID[1] = 0xC
                    CharacterVariant[0] = 0x6
                    CharacterVariant[1] = 0x22
                } else if (frmMain.lstCharacters.SelectedItem == "Battle Hammer") {
                                            // 800C
                                            // 0020
                                            CharacterID[0] = 0x80
                    CharacterID[1] = 0xC
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x20
                } else if (frmMain.lstCharacters.SelectedItem == "Dragonfire Cannon") {
                                            // D000
                                            // 0612
                                            CharacterID[0] = 0xD0
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x6
                    CharacterVariant[1] = 0x12
                } else if (frmMain.lstCharacters.SelectedItem == "Golden Dragonfire Cannon") {
                                            // D000
                                            // 0216
                                            CharacterID[0] = 0xD0
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x2
                    CharacterVariant[1] = 0x16
                } else if (frmMain.lstCharacters.SelectedItem == "Ghost Pirate Swords") {
                                            // CB00
                                            // 0020
                                            CharacterID[0] = 0xCB
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x20
                } else if (frmMain.lstCharacters.SelectedItem == "Groove Machine") {
                                            // 830C
                                            // 0020
                                            CharacterID[0] = 0x83
                    CharacterID[1] = 0xC
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x20
                } else if (frmMain.lstCharacters.SelectedItem == "Hand of Fate") {
                                            // E600
                                            // 0000
                                            CharacterID[0] = 0xE6
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x0
                } else if (frmMain.lstCharacters.SelectedItem == "Legendary Hand of Fate") {
                                            // E600
                                            // 0334
                                            CharacterID[0] = 0xE6
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x3
                    CharacterVariant[1] = 0x34
                } else if (frmMain.lstCharacters.SelectedItem == "Healing Elixir") {
                                            // CA00
                                            // 0000
                                            CharacterID[0] = 0xCA
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x0
                } else if (frmMain.lstCharacters.SelectedItem == "Hidden Treasure") {
                                            // C900
                                            // 0020
                                            CharacterID[0] = 0xC9
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x20
                } else if (frmMain.lstCharacters.SelectedItem == "Platinum Hidden Treasure") {
                                            // C900
                                            // 0000
                                            CharacterID[0] = 0xC9
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x0
                } else if (frmMain.lstCharacters.SelectedItem == "Blue Imaginite Mystery Chest") {
                                            // Figure: EB00
                                            // Variant: 1750
                                            // Blue Mystery Chest
                                            CharacterID[0] = 0xEB
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x17
                    CharacterVariant[1] = 0x50
                } else if (frmMain.lstCharacters.SelectedItem == "Bronze Imaginite Mystery Chest") {
                                            // Figure: EB00
                                            // Variant: 0150
                                            // Blue Mystery Chest
                                            CharacterID[0] = 0xEB
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x1
                    CharacterVariant[1] = 0x50
                } else if (frmMain.lstCharacters.SelectedItem == "Gold Imaginite Mystery Chest") {
                                            // Figure: EB00
                                            // Variant: 0350
                                            // Blue Mystery Chest
                                            CharacterID[0] = 0xEB
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x3
                    CharacterVariant[1] = 0x50
                } else if (frmMain.lstCharacters.SelectedItem == "Silver Imaginite Mystery Chest") {
                                            // Figure: EB00
                                            // Variant: 0250
                                            // Blue Mystery Chest
                                            CharacterID[0] = 0xEB
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x2
                    CharacterVariant[1] = 0x50
                } else if (frmMain.lstCharacters.SelectedItem == "Platnium Imaginite Mystery Chest") {
                                            // Figure: EB00
                                            // Variant: 1950
                                            // Blue Mystery Chest
                                            CharacterID[0] = 0xEB
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x19
                    CharacterVariant[1] = 0x50
                } else if (frmMain.lstCharacters.SelectedItem == "Kaos Trophy") {
                                            // AF0D
                                            // 0040
                                            CharacterID[0] = 0xAF
                    CharacterID[1] = 0xD
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x40
                } else if (frmMain.lstCharacters.SelectedItem == "Land Trophy") {
                                            // AD0D
                                            // 0040
                                            CharacterID[0] = 0xAD
                    CharacterID[1] = 0xD
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x40
                } else if (frmMain.lstCharacters.SelectedItem == "Piggy Bank") {
                                            // E700
                                            // 0000
                                            CharacterID[0] = 0xE7
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x0
                } else if (frmMain.lstCharacters.SelectedItem == "Platinum Sheep") {
                                            // 820C
                                            // 0020
                                            CharacterID[0] = 0x82
                    CharacterID[1] = 0xC
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x20
                } else if (frmMain.lstCharacters.SelectedItem == "Rocket Ram") {
                                            // E800
                                            // 0000
                                            CharacterID[0] = 0xE8
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x0
                } else if (frmMain.lstCharacters.SelectedItem == "Scorpion Striker") {
                                            // D100
                                            // 0612
                                            CharacterID[0] = 0xD1
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x6
                    CharacterVariant[1] = 0x12
                } else if (frmMain.lstCharacters.SelectedItem == "Sea Trophy") {
                                            // AE0D
                                            // 0040
                                            CharacterID[0] = 0xAE
                    CharacterID[1] = 0xD
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x40
                } else if (frmMain.lstCharacters.SelectedItem == "Sky Diamond") {
                                            // 810C
                                            // 0020
                                            CharacterID[0] = 0x81
                    CharacterID[1] = 0xC
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x20
                } else if (frmMain.lstCharacters.SelectedItem == "Sky Trophy") {
                                            // AC0D
                                            // 0040
                                            CharacterID[0] = 0xAC
                    CharacterID[1] = 0xD
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x40
                } else if (frmMain.lstCharacters.SelectedItem == "Sky-Iron Shield") {
                                            // CD00
                                            // 0020
                                            CharacterID[0] = 0xCD
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x20
                } else if (frmMain.lstCharacters.SelectedItem == "Sparx the Dragonfly") {
                                            // CF00
                                            // 0000
                                            CharacterID[0] = 0xCF
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x0
                } else if (frmMain.lstCharacters.SelectedItem == "Tiki Speaky") {
                                            // E900
                                            // 0000
                                            CharacterID[0] = 0xE9
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x0
                } else if (frmMain.lstCharacters.SelectedItem == "Time Twister Hourglass") {
                                            // CC00
                                            // 0000
                                            CharacterID[0] = 0xCC
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x0
                } else if (frmMain.lstCharacters.SelectedItem == "UFO Hat") {
                                            // 840C
                                            CharacterID[0] = 0x84
                    CharacterID[1] = 0xC
                    // 0020
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x20
                } else if (frmMain.lstCharacters.SelectedItem == "Winged Boots") {
                                            // CE00
                                            // 0000
                                            CharacterID[0] = 0xCE
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x0
                End If
            Case 7
                // Traps
                // Not sure if these are the right Byte Values
                // CharacterID[1] = 0x0
                // CharacterVariant[1] = 0x30
                // --Air--
                                            If frmMain.lstCharacters.SelectedItem == "Breezy Bird (Toucan)") {
                                                // 0330
                                                // D400
                                                CharacterID[0] = 0xD4
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0xD4
                    CharacterVariant[1] = 0x0
                } else if (frmMain.lstCharacters.SelectedItem == "Cloudy Cobra (Snake)") {
                                                // 1030
                                                // D400
                                                CharacterID[0] = 0xD4
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x10
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Cyclone Sabre (Sword)") {
                                                // 1830
                                                // D400
                                                CharacterID[0] = 0xD4
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x18
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Drafty Decanter (Jughead)") {
                                                // 0630
                                                // D400
                                                CharacterID[0] = 0xD4
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x6
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Storm Warning (Screamer)") {
                                                // 1130
                                                // D400
                                                CharacterID[0] = 0xD4
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x11
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Tempest Timer (Hourglass)") {
                                                // 0E30
                                                // D400
                                                CharacterID[0] = 0xD4
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0xE
                    CharacterVariant[1] = 0x30

                    // --Dark--
                                            } else if (frmMain.lstCharacters.SelectedItem == "Dark Dagger (Sword)") {
                                                // 1830
                                                // DA00
                                                CharacterID[0] = 0xDA
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x18
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Ghastly Grimace (Handstand)") {
                                                // 1A30
                                                // DA00
                                                CharacterID[0] = 0xDA
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x1A
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Shadow Spider (Spider)") {
                                                // 1430
                                                // DA00
                                                CharacterID[0] = 0xDA
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x14
                    CharacterVariant[1] = 0x30

                    // --Earth--
                                            } else if (frmMain.lstCharacters.SelectedItem == "Banded Boulder (Orb)") {
                                                // 0430
                                                // D800
                                                CharacterID[0] = 0xD8
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x4
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Dust of Time (Hourglass)") {
                                                // 0E30
                                                // D800
                                                CharacterID[0] = 0xD8
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0xE
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Rock Hawk (Toucan)") {
                                                // 0330
                                                // D800
                                                CharacterID[0] = 0xD8
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x3
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Rubble Trouble (Handstand)") {
                                                // 1A30
                                                // D800
                                                CharacterID[0] = 0xD8
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x1A
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Slag Hammer (Hammer)") {
                                                // 0A30
                                                // D800
                                                CharacterID[0] = 0xD8
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0xA
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Spinning Sandstorm (Totem)") {
                                                // 1230
                                                // D800
                                                CharacterID[0] = 0xD8
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x12
                    CharacterVariant[1] = 0x30

                    // --Fire--
                                            } else if (frmMain.lstCharacters.SelectedItem == "Blazing Belch (Yawn)") {
                                                // 1B30
                                                // D700
                                                CharacterID[0] = 0xD7
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x1B
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Eternal Flame (Torch)") {
                                                // 0530
                                                // D700
                                                CharacterID[0] = 0xD7
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x5
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Fire Flower (Scepter)") {
                                                // 0130
                                                // D700                    
                                                CharacterID[0] = 0xD7
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x1
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Scorching Stopper (Screamer)") {
                                                // 1130
                                                // D700
                                                CharacterID[0] = 0xD7
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x11
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Searing Spinner (Totem)") {
                                                // 1230
                                                // D700
                                                CharacterID[0] = 0xD7
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x12
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Spark Spear (Captain// s Hat)") {
                                                // 1730
                                                // D700
                                                CharacterID[0] = 0xD7
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x17
                    CharacterVariant[1] = 0x30

                    // --Life--
                                            } else if (frmMain.lstCharacters.SelectedItem == "Emerald Energy (Torch)") {
                                                // 0530
                                                // D900
                                                CharacterID[0] = 0xD9
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x5
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Jade Blade (Sword)") {
                                                // 1830
                                                // D900
                                                CharacterID[0] = 0xD9
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x18
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Oak Eagle (Toucan)") {
                                                // 0330
                                                // D900
                                                CharacterID[0] = 0xD9
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x3
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Seed Serpent (Snake)") {
                                                // 1030
                                                // D900
                                                CharacterID[0] = 0xD9
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x10
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Shrub Shrieker (Yawn)") {
                                                // 1B30
                                                // D900
                                                CharacterID[0] = 0xD9
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x1B
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Weed Whacker (Hammer)") {
                                                // 0A30
                                                // D900
                                                CharacterID[0] = 0xD9
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0xA
                    CharacterVariant[1] = 0x30

                    // --Light--
                                            } else if (frmMain.lstCharacters.SelectedItem == "Beam Scream (Yawn)") {
                                                // 1B30
                                                // DB00
                                                CharacterID[0] = 0xDB
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x1B
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Heavenly Hawk (Hawk)") {
                                                // 0F30
                                                // DB00
                                                CharacterID[0] = 0xF
                    CharacterID[1] = 0x30
                    CharacterVariant[0] = 0xDB
                    CharacterVariant[1] = 0x0
                } else if (frmMain.lstCharacters.SelectedItem == "Shining Ship (Rocket)") {
                                                // 1530
                                                // DB00
                                                CharacterID[0] = 0xDB
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x15
                    CharacterVariant[1] = 0x30

                    // --Magic--
                                            } else if (frmMain.lstCharacters.SelectedItem == "Arcane Hourglass (Hourglass)") {
                                                // 0E30
                                                // D200                    
                                                CharacterID[0] = 0xD2
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0xE
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Axe of Illusion (Axe)") {
                                                // 0B30
                                                // D200
                                                CharacterID[0] = 0xD2
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0xB
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Biter// s Bane (Log Holder)") {
                                                // 0130
                                                // D200
                                                CharacterID[0] = 0xD2
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x1
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Rune Rocket (Rocket)") {
                                                // 1530
                                                // D200
                                                CharacterID[0] = 0xD2
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x15
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Sorcerous Skull (Skull)") {
                                                // 0830
                                                // D200
                                                CharacterID[0] = 0xD2
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x8
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Spell Slapper (Totem)") {
                                                // 1230
                                                // D100
                                                CharacterID[0] = 0xD1
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x12
                    CharacterVariant[1] = 0x30

                    // --Tech--
                                            } else if (frmMain.lstCharacters.SelectedItem == "Automatic Angel (Angel)") {
                                                // 0730
                                                // D600
                                                CharacterID[0] = 0xD6
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x7
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Factory Flower (Scepter)") {
                                                // 0930
                                                // D600
                                                CharacterID[0] = 0xD6
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x9
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Grabbing Gadget (Hand)") {
                                                // 0C30
                                                // D600
                                                CharacterID[0] = 0xD6
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0xC
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Makers Mana (Flying Helmet)") {
                                                // 1630
                                                // D600
                                                CharacterID[0] = 0xD6
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x16
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Tech Totem (Tiki)") {
                                                // 0130
                                                // D600
                                                CharacterID[0] = 0xD6
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x1
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Topsy Techy (Handstand)") {
                                                // 1A30
                                                // D600
                                                CharacterID[0] = 0xD6
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x1A
                    CharacterVariant[1] = 0x30

                    // --Undead--
                                            } else if (frmMain.lstCharacters.SelectedItem == "Dream Piercer (Captain// s Hat)") {
                                                // 1730
                                                // D500
                                                CharacterID[0] = 0xD5
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x17
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Grim Gripper (Hand)") {
                                                // 0C30
                                                // D600
                                                CharacterID[0] = 0xD5
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0xC
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Haunted Hatchet (Axe)") {
                                                // 0B30
                                                // D500
                                                CharacterID[0] = 0xD5
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0xB
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Spectral Skull (Skull)") {
                                                // 0830
                                                // D500
                                                CharacterID[0] = 0xD5
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x8
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Spirit Sphere (Orb)") {
                                                // 0430
                                                // D500
                                                CharacterID[0] = 0xD5
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x4
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Spooky Snake (Snake)") {
                                                // 1030
                                                // D500
                                                CharacterID[0] = 0xD5
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x10
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Legendary Spirit Sphere (Orb)") {
                                                // 0434
                                                // 0434
                                                CharacterID[0] = 0x4
                    CharacterID[1] = 0x34
                    CharacterVariant[0] = 0x4
                    CharacterVariant[1] = 0x34
                } else if (frmMain.lstCharacters.SelectedItem == "Legendary Spectral Skull (Skull)") {
                                                // 0834
                                                // D500
                                                CharacterID[0] = 0xD5
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x8
                    CharacterVariant[1] = 0x34

                    // --Water--
                                            } else if (frmMain.lstCharacters.SelectedItem == "Aqua Axe (Axe)") {
                                                // 0B30
                                                // D300
                                                CharacterID[0] = 0xD3
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0xB
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Flood Flask (Jughead)") {
                                                // 0630
                                                // D300
                                                CharacterID[0] = 0xD3
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x6
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Frost Helm (Flying Helmet)") {
                                                // 1630
                                                // D300
                                                CharacterID[0] = 0xD3
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x16
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Soaking Staff (Angel)") {
                                                // 0730
                                                // D300
                                                CharacterID[0] = 0xD3
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x7
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Tidal Tiki (Tiki)") {
                                                // 0130
                                                // D300
                                                CharacterID[0] = 0xD3
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x1
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Wet Walter (Log Holder)") {
                                                // 0230
                                                // D300
                                                CharacterID[0] = 0xD3
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x2
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Legendary Flood Flask (Jughead)") {
                                                // 0634
                                                // D300
                                                CharacterID[0] = 0xD3
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x6
                    CharacterVariant[1] = 0x34

                    // --Kaos--
                                            } else if (frmMain.lstCharacters.SelectedItem == "The Kaos Trap") {
                                                // 1E30
                                                // DC00
                                                CharacterID[0] = 0xDC
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x1E
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Ultimate Kaos Trap") {
                                                // 1F35
                                                // DC00
                                                CharacterID[0] = 0xDC
                    CharacterID[1] = 0x0
                    CharacterVariant[0] = 0x1F
                    CharacterVariant[1] = 0x35
                End If
            Case 8
                // Adventure Packs
                If frmMain.lstCharacters.SelectedItem == "Cursed Tiki Temple") {

                                                    blnNoCode = True
                } else if (frmMain.lstCharacters.SelectedItem == "Darklight Crypt") {
                                                    // 2F01
                                                    // 0000
                                                    CharacterID[0] = 0x2F
                    CharacterID[1] = 0x1
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x0
                } else if (frmMain.lstCharacters.SelectedItem == "Dragon// s Peak") {
                                                    // 2C01
                                                    // 0000
                                                    CharacterID[0] = 0x2C
                    CharacterID[1] = 0x1
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x0
                } else if (frmMain.lstCharacters.SelectedItem == "Empire of Ice") {
                                                    // 2D01
                                                    // 0020
                                                    CharacterID[0] = 0x2D
                    CharacterID[1] = 0x1
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x20
                } else if (frmMain.lstCharacters.SelectedItem == "Enchanted Elven Forest") {
                                                    CharacterID[0] = 0x37
                    CharacterID[1] = 0x1
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x50
                } else if (frmMain.lstCharacters.SelectedItem == "Fiery Forge") {
                                                    // E60C
                                                    // 0622
                                                    CharacterID[0] = 0xE6
                    CharacterID[1] = 0xC
                    CharacterVariant[0] = 0x6
                    CharacterVariant[1] = 0x22
                } else if (frmMain.lstCharacters.SelectedItem == "Gryphon Park Observatory") {
                                                    CharacterID[0] = 0x36
                    CharacterID[1] = 0x1
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x50
                } else if (frmMain.lstCharacters.SelectedItem == "Lost Imaginite Mines") {

                                                    blnNoCode = True
                } else if (frmMain.lstCharacters.SelectedItem == "Midnight Museum") {
                                                    // 3401
                                                    // 0030
                                                    // Alt Variant
                                                    // 0632
                                                    CharacterID[0] = 0x34
                    CharacterID[1] = 0x1
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Mirror of Mystery") {
                                                    // 3101
                                                    // 0030
                                                    CharacterID[0] = 0x31
                    CharacterID[1] = 0x1
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Nightmare Express") {
                                                    // 3201
                                                    // 0030
                                                    CharacterID[0] = 0x32
                    CharacterID[1] = 0x1
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x30
                } else if (frmMain.lstCharacters.SelectedItem == "Pirate Seas") {
                                                    // 2E01
                                                    // 0020
                                                    CharacterID[0] = 0x2E
                    CharacterID[1] = 0x1
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x20
                } else if (frmMain.lstCharacters.SelectedItem == "Sheep Wreck ==land") {
                                                    // E40C
                                                    // 0020
                                                    CharacterID[0] = 0xE4
                    CharacterID[1] = 0xC
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x20
                } else if (frmMain.lstCharacters.SelectedItem == "Sunscraper Spire") {
                                                    // 3301
                                                    // 0632
                                                    CharacterID[0] = 0x33
                    CharacterID[1] = 0x1
                    CharacterVariant[0] = 0x6
                    CharacterVariant[1] = 0x32
                } else if (frmMain.lstCharacters.SelectedItem == "Thumpin//  Wumpa ==lands") {
                                                    blnNoCode = True
                } else if (frmMain.lstCharacters.SelectedItem == "Tower of Time") {
                                                    // E50C
                                                    // 0020
                                                    CharacterID[0] = 0xE5
                    CharacterID[1] = 0xC
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x20
                } else if (frmMain.lstCharacters.SelectedItem == "Volcanic Vault") {
                                                    // 3001
                                                    // 0020
                                                    CharacterID[0] = 0x30
                    CharacterID[1] = 0x1
                    CharacterVariant[0] = 0x0
                    CharacterVariant[1] = 0x20
                End If
            Case Else
                blnNoCode = True
        End Select
        DetermineWrite()
    }
# End Region

# Region " Determine Figure// s ID and Variant"
                                                // Mostly Complete.  Missing Imaginators, Items, Traps and Adventure Packs

                                                public static void FigureItOut()
        // MessageBox.Show(Var & " " & Fig)
        If Var = "0000") {
                                                    frmMain.cmbGame.SelectedItem = "Spyro// s Adventure"
            // // Application.DoEvents()
            Select Case Fig
                Case "0400"
                    // Bash
                    frmMain.lstCharacters.SelectedIndex = 0
                Case "1600"
                    // Boomer
                    frmMain.lstCharacters.SelectedIndex = 1
                Case "1800"
                    // Camo
                    frmMain.lstCharacters.SelectedIndex = 2
                Case "1E00"
                    // Chop Chop
                    frmMain.lstCharacters.SelectedIndex = 3
                Case "2000"
                    // Cynder
                    frmMain.lstCharacters.SelectedIndex = 4
                Case "1C00"
                    // Dark Spyro
                    frmMain.lstCharacters.SelectedIndex = 5
                Case "0600"
                    // Dino-Rang
                    frmMain.lstCharacters.SelectedIndex = 6
                Case "1200"
                    // Double Trouble
                    frmMain.lstCharacters.SelectedIndex = 7
                Case "1500"
                    // Drill Sergeant
                    frmMain.lstCharacters.SelectedIndex = 8
                Case "1400"
                    // Drobot
                    frmMain.lstCharacters.SelectedIndex = 9
                Case "0900"
                    // Eruptor
                    frmMain.lstCharacters.SelectedIndex = 10
                Case "0B00"
                    // Flameslinger
                    frmMain.lstCharacters.SelectedIndex = 11
                Case "1F00"
                    // Ghost Roaster
                    frmMain.lstCharacters.SelectedIndex = 12
                Case "0E00"
                    // Gill Grunt
                    frmMain.lstCharacters.SelectedIndex = 13
                Case "1D00"
                    // Hex
                    frmMain.lstCharacters.SelectedIndex = 14
                Case "0A00"
                    // Ignitor
                    frmMain.lstCharacters.SelectedIndex = 15
                Case "9401"
                    // Legendary Bash
                    frmMain.lstCharacters.SelectedIndex = 16
                Case "AE01"
                    // Legendary Chop Chop
                    frmMain.lstCharacters.SelectedIndex = 17
                Case "A001"
                    // Legendary Spyro
                    frmMain.lstCharacters.SelectedIndex = 18
                Case "A301"
                    // Legendary Trigger Happy
                    frmMain.lstCharacters.SelectedIndex = 19
                Case "0300"
                    // Lightning Rod
                    frmMain.lstCharacters.SelectedIndex = 20
                Case "0700"
                    // Prism Break
                    frmMain.lstCharacters.SelectedIndex = 21
                Case "0F00"
                    // Slam Bam
                    frmMain.lstCharacters.SelectedIndex = 22
                Case "0100"
                    // Sonic Boom
                    frmMain.lstCharacters.SelectedIndex = 23
                Case "1000"
                    // Spyro
                    frmMain.lstCharacters.SelectedIndex = 24
                Case "1A00"
                    // Stealth Elf
                    frmMain.lstCharacters.SelectedIndex = 25
                Case "1B00"
                    // Stump Smash
                    frmMain.lstCharacters.SelectedIndex = 26
                Case "0800"
                    // Sunburn
                    frmMain.lstCharacters.SelectedIndex = 27
                Case "0500"
                    // Terrafin
                    frmMain.lstCharacters.SelectedIndex = 28
                Case "1300"
                    // Trigger Happy
                    frmMain.lstCharacters.SelectedIndex = 29
                Case "1100"
                    // Voodood
                    frmMain.lstCharacters.SelectedIndex = 30
                Case "0200"
                    // Warnado
                    frmMain.lstCharacters.SelectedIndex = 31
                Case "0D00"
                    // Wham-Shell
                    frmMain.lstCharacters.SelectedIndex = 32
                Case "0000"
                    // Whirlwind
                    frmMain.lstCharacters.SelectedIndex = 33
                Case "1700"
                    // Wrecking Ball
                    frmMain.lstCharacters.SelectedIndex = 34
                Case "0C00"
                    // Zap
                    frmMain.lstCharacters.SelectedIndex = 35
                Case "1900"
                    // Zook
                    frmMain.lstCharacters.SelectedIndex = 36
                Case "2F01"
                    frmMain.cmbGame.SelectedItem = "Adventure Packs"
                    // Darklight Crypt
                    frmMain.lstCharacters.SelectedItem = "Darklight Crypt"
                Case "2C01"
                    // Dragon// s Peak
                    frmMain.cmbGame.SelectedItem = "Adventure Packs"
                    frmMain.lstCharacters.SelectedItem = "Dragon// s Peak"
                Case "F901"
                    // Terrabite
                    frmMain.cmbGame.SelectedItem = "Trap Team"
                    frmMain.lstCharacters.SelectedItem = "Terrabite"
                Case "0E02"
                    // Whisper Elf
                    frmMain.cmbGame.SelectedItem = "Trap Team"
                    frmMain.lstCharacters.SelectedItem = "Whisper Elf"
                Case "0202"
                    // Gill Runt
                    frmMain.cmbGame.SelectedItem = "Trap Team"
                    frmMain.lstCharacters.SelectedItem = "Gill Runt"
                Case "0702"
                    // Trigger Snappy
                    frmMain.cmbGame.SelectedItem = "Trap Team"
                    frmMain.lstCharacters.SelectedItem = "Trigger Snappy"
                Case "E700"
                    // Piggy Bank
                    frmMain.cmbGame.SelectedItem = "Items"
                    frmMain.lstCharacters.SelectedItem = "Piggy Bank"
                Case "E800"
                    // Rocket Ram
                    frmMain.cmbGame.SelectedItem = "Items"
                    frmMain.lstCharacters.SelectedItem = "Rocket Ram"
                Case "E900"
                    // Tiki Speaky
                    frmMain.cmbGame.SelectedItem = "Items"
                    frmMain.lstCharacters.SelectedItem = "Tiki Speaky"
                Case "E600"
                    // Hand of Fate
                    frmMain.cmbGame.SelectedItem = "Items"
                    frmMain.lstCharacters.SelectedItem = "Hand of Fate"
                Case "C900"
                    // Hidden Treasure (Platinum)
                    frmMain.cmbGame.SelectedItem = "Items"
                    frmMain.lstCharacters.SelectedItem = "Platinum Hidden Treasure"
                Case "CE00"
                    // Winged Boots
                    frmMain.cmbGame.SelectedItem = "Items"
                    frmMain.lstCharacters.SelectedItem = "Winged Boots"
                Case "CA00"
                    // Healing Elixir
                    frmMain.cmbGame.SelectedItem = "Items"
                    frmMain.lstCharacters.SelectedItem = "Healing Elixir"
                Case "CF00"
                    // Sparks the Dragonfly
                    frmMain.cmbGame.SelectedItem = "Items"
                    frmMain.lstCharacters.SelectedItem = "Sparx the Dragonfly"
                Case "CC00"
                    // Time Twister
                    frmMain.cmbGame.SelectedItem = "Items"
                    frmMain.lstCharacters.SelectedItem = "Time Twister Hourglass"
            End Select
        } else if (Var = "0010") {
                                                    frmMain.cmbGame.SelectedItem = "Giants"
            Select Case Fig
                Case "1C02"
                    // Barkley
                    frmMain.cmbGame.SelectedItem = "Trap Team"
                    frmMain.lstCharacters.SelectedItem = "Barkley"
                Case "6A00"
                    // Chill
                    frmMain.lstCharacters.SelectedItem = "Chill"
                Case "6700"
                    // Flashwing
                    frmMain.lstCharacters.SelectedItem = "Flashwing"
                Case "7300"
                    // Fright Rider
                    frmMain.lstCharacters.SelectedItem = "Fright Rider"
                Case "6900"
                    // Hot Dog
                    frmMain.lstCharacters.SelectedItem = "Hot Dog"
                Case "6400"
                    // Jet-Vac
                    frmMain.lstCharacters.SelectedItem = "Jet-Vac"
                Case "6C00"
                    // Pop Fizz
                    frmMain.lstCharacters.SelectedItem = "Pop Fizz"
                Case "7100"
                    // Shroomboom
                    frmMain.lstCharacters.SelectedItem = "Shroomboom"
                Case "6F00"
                    // Sprocket
                    frmMain.lstCharacters.SelectedItem = "Sprocket"
            End Select
        } else if (Var = "0118") {
                                                    frmMain.cmbGame.SelectedItem = "Giants"
            Select Case Fig
                Case "0400"
                    // Series 2 Bash
                    frmMain.lstCharacters.SelectedItem = "Series 2 Bash"
                Case "1E00"
                    // Series 2 Chop Chop
                    frmMain.lstCharacters.SelectedItem = "Series 2 Chop Chop"
                Case "2000"
                    // Series 2 Cynder
                    frmMain.lstCharacters.SelectedItem = "Series 2 Cynder"
                Case "1200"
                    // Series 2 Double Trouble
                    frmMain.lstCharacters.SelectedItem = "Series 2 Double Trouble"
                Case "1500"
                    // Series 2 Drill Sergeant
                    frmMain.lstCharacters.SelectedItem = "Series 2 Drill Sergeant"
                Case "1400"
                    // Series 2 Drobot
                    frmMain.lstCharacters.SelectedItem = "Series 2 Drobot"
                Case "0900"
                    // Series 2 Eruptor
                    frmMain.lstCharacters.SelectedItem = "Series 2 Eruptor"
                Case "0B00"
                    // Series 2 Flameslinger
                    frmMain.lstCharacters.SelectedItem = "Series 2 Flameslinger"
                Case "0E00"
                    // Series 2 Gill Grunt
                    frmMain.lstCharacters.SelectedItem = "Series 2 Gill Grunt"
                Case "1D00"
                    // Series 2 Hex
                    frmMain.lstCharacters.SelectedItem = "Series 2 Hex"
                Case "0A00"
                    // Series 2 Ignitor
                    frmMain.lstCharacters.SelectedItem = "Series 2 Ignitor"
                Case "0300"
                    // Series 2 Lightning Rod
                    frmMain.lstCharacters.SelectedItem = "Series 2 Lightning Rod"
                Case "0700"
                    // Series 2 Prism Break
                    frmMain.lstCharacters.SelectedItem = "Series 2 Prism Break"
                Case "0F00"
                    // Series 2 Slam Bam
                    frmMain.lstCharacters.SelectedItem = "Series 2 Slam Bam"
                Case "0100"
                    // Series 2 Sonic Boom
                    frmMain.lstCharacters.SelectedItem = "Series 2 Sonic Boom"
                Case "1000"
                    // Series 2 Spyro
                    frmMain.lstCharacters.SelectedItem = "Series 2 Spyro"
                Case "1A00"
                    // Series 2 Stealth Elf
                    frmMain.lstCharacters.SelectedItem = "Series 2 Stealth Elf"
                Case "1B00"
                    // Series 2 Stump Smash
                    frmMain.lstCharacters.SelectedItem = "Series 2 Stump Smash"
                Case "0500"
                    // Series 2 Terrafin
                    frmMain.lstCharacters.SelectedItem = "Series 2 Terrafin"
                Case "1300"
                    // Series 2 Trigger Happy
                    frmMain.lstCharacters.SelectedItem = "Series 2 Trigger Happy"
                Case "0000"
                    // Series 2 Whirlwind
                    frmMain.lstCharacters.SelectedItem = "Series 2 Whirlwind"
                Case "1700"
                    // Series 2 Wrecking Ball
                    frmMain.lstCharacters.SelectedItem = "Series 2 Wrecking Ball"
                Case "0C00"
                    // Series 2 Zap
                    frmMain.lstCharacters.SelectedItem = "Series 2 Zap"
                Case "1900"
                    // Series 2 Zook
                    frmMain.lstCharacters.SelectedItem = "Series 2 Zook"
            End Select
        } else if (Var = "021C") {
                                                    frmMain.cmbGame.SelectedItem = "Giants"
            Select Case Fig
                Case "1200"
                    // Royal Double Trouble
                    frmMain.lstCharacters.SelectedItem = "Royal Double Trouble"
            End Select
        } else if (Var = "0214") {
                                                    frmMain.cmbGame.SelectedItem = "Giants"
            Select Case Fig
                Case "6700"
                    // Jade Flashwing
                    frmMain.lstCharacters.SelectedItem = "Jade Flashwing"
                Case "6900"
                    // Molten Hot Dog
                    frmMain.lstCharacters.SelectedItem = "Molten Hot Dog"
                Case "6C00"
                    // Punch Pop Fizz
                    frmMain.lstCharacters.SelectedItem = "Punch Pop Fizz"
            End Select
        } else if (Var = "0216") {
                                                    frmMain.cmbGame.SelectedItem = "Giants"
            Select Case Fig
                Case "7000"
                    // Gnarly Tree Rex
                    frmMain.lstCharacters.SelectedItem = "Gnarly Tree Rex"
                Case "6600"
                    // Granite Crusher
                    frmMain.lstCharacters.SelectedItem = "Granite Crusher"
                Case "0000"
                    // Polar Whirlwind
                    frmMain.lstCharacters.SelectedItem = "Polar Whirlwind"
                Case "6D00"
                    // Scarlet Ninjini
                    frmMain.lstCharacters.SelectedItem = "Scarlet Ninjini"
                Case "D000"
                    // Golden Dragonfire Cannon
                    frmMain.cmbGame.SelectedItem = "Items"
                    frmMain.lstCharacters.SelectedItem = "Golden Dragonfire Cannon"
            End Select
        } else if (Var = "0354") {
                                                    frmMain.cmbGame.SelectedItem = "Imaginators"
            Select Case Fig
                Case "5D02"
                    frmMain.lstCharacters.SelectedItem = "Legendary Pit Boss"
                Case "5A02"
                    frmMain.lstCharacters.SelectedItem = "Legendary Tri-Tip"
            End Select
        } else if (Var = "031C") {
                                                    frmMain.cmbGame.SelectedItem = "Giants"
            Select Case Fig
                Case "0F00"
                    // Legendary Slam Bam
                    frmMain.lstCharacters.SelectedItem = "Legendary Slam Bam"
                Case "1A00"
                    // Legendary Stealth Elf
                    frmMain.lstCharacters.SelectedItem = "Legendary Stealth Elf"
            End Select
        } else if (Var = "0314") {
                                                    frmMain.cmbGame.SelectedItem = "Giants"
            Select Case Fig
                Case "6400"
                    // Legendary Jet-Vac
                    frmMain.lstCharacters.SelectedItem = "Legendary Jet-Vac"
            End Select
        } else if (Var = "0316") {
                                                    frmMain.cmbGame.SelectedItem = "Giants"
            Select Case Fig
                Case "6E00"
                    // Legendary Bouncer
                    frmMain.lstCharacters.SelectedItem = "Legendary Bouncer"
                Case "6A00"
                    // Legendary Chill
                    frmMain.lstCharacters.SelectedItem = "Legendary Chill"
                Case "0A00"
                    // Legendary Ignitor
                    frmMain.lstCharacters.SelectedItem = "Legendary Ignitor"
            End Select
        } else if (Var = "0612") {
                                                    frmMain.cmbGame.SelectedItem = "Giants"
            Select Case Fig
                Case "D100"
                    // Scorpion Striker
                    frmMain.cmbGame.SelectedItem = "Items"
                    frmMain.lstCharacters.SelectedItem = "Scorpion Striker"
                Case "D000"
                    // Dragonfire Cannon
                    frmMain.cmbGame.SelectedItem = "Items"
                    frmMain.lstCharacters.SelectedItem = "Dragonfire Cannon"
                Case "6E00"
                    frmMain.lstCharacters.SelectedItem = "Bouncer"
                Case "6600"
                    // Crusher
                    frmMain.lstCharacters.SelectedItem = "Crusher"
                Case "7200"
                    // Eye-Brawl
                    frmMain.lstCharacters.SelectedItem = "Eye-Brawl"
                Case "6800"
                    // Hot Head
                    frmMain.lstCharacters.SelectedItem = "Hot Head"
                Case "6A00"
                    // LightCore Chill
                    frmMain.lstCharacters.SelectedItem = "LightCore Chill"
                Case "1400"
                    // LightCore Drobot
                    frmMain.lstCharacters.SelectedItem = "LightCore Drobot"
                Case "0900"
                    // LightCore Eruptor
                    frmMain.lstCharacters.SelectedItem = "LightCore Eruptor"
                Case "1D00"
                    // LightCore Hex
                    frmMain.lstCharacters.SelectedItem = "LightCore Hex"
                Case "6400"
                    // LightCore Jet-Vac
                    frmMain.lstCharacters.SelectedItem = "LightCore Jet-Vac"
                Case "6C00"
                    // LightCore Pop Fizz
                    frmMain.lstCharacters.SelectedItem = "LightCore Pop Fizz"
                Case "0700"
                    // LightCore Prism Break
                    frmMain.lstCharacters.SelectedItem = "LightCore Prism Break"
                Case "7100"
                    // LightCore Shroomboom
                    frmMain.lstCharacters.SelectedItem = "LightCore Shroomboom"
                Case "6D00"
                    // Ninjini
                    frmMain.lstCharacters.SelectedItem = "Ninjini"
                Case "6500"
                    // Swarm
                    frmMain.lstCharacters.SelectedItem = "Swarm"
                Case "6B00"
                    // Thumpback
                    frmMain.lstCharacters.SelectedItem = "Thumpback"
                Case "7000"
                    // Tree Rex
                    frmMain.lstCharacters.SelectedItem = "Tree Rex"
            End Select
        } else if (Var = "0020") {
                                                    frmMain.cmbGame.SelectedItem = "Swap Force"
            Select Case Fig
                Case "E40C"
                    // Sheep Wreck ==land
                    frmMain.cmbGame.SelectedItem = "Adventure Packs"
                    // Application.DoEvents()
                    frmMain.lstCharacters.SelectedItem = "Sheep Wreck ==land"
                Case "E50C"
                    // Tower of Time
                    frmMain.cmbGame.SelectedItem = "Adventure Packs"
                    // Application.DoEvents()
                    frmMain.lstCharacters.SelectedItem = "Tower of Time"
                Case "830C"
                    // Groove Machine
                    frmMain.cmbGame.SelectedItem = "Items"
                    // Application.DoEvents()
                    frmMain.lstCharacters.SelectedItem = "Groove Machine"
                Case "820C"
                    // Platinum Sheep
                    frmMain.cmbGame.SelectedItem = "Items"
                    // Application.DoEvents()
                    frmMain.lstCharacters.SelectedItem = "Platinum Sheep"
                Case "810C"
                    // Sky Diamond
                    frmMain.cmbGame.SelectedItem = "Items"
                    // Application.DoEvents()
                    frmMain.lstCharacters.SelectedItem = "Sky Diamond"
                Case "840C"
                    // UFO Hat
                    frmMain.cmbGame.SelectedItem = "Items"
                    // Application.DoEvents()
                    frmMain.lstCharacters.SelectedItem = "UFO Hat"
                Case "EC03"
                    // Blast Zone (Bottom)
                    frmMain.lstCharacters.SelectedItem = "Blast Zone (Bottom)"
                Case "D407"
                    // Blast Zone (Top)
                    frmMain.lstCharacters.SelectedItem = "Blast Zone (Top)"
                Case "E803"
                    // Boom Jet (Bottom)
                    frmMain.lstCharacters.SelectedItem = "Boom Jet (Bottom)"
                Case "D007"
                    // Boom Jet (Top)
                    frmMain.lstCharacters.SelectedItem = "Boom Jet (Top)"
                Case "BE0B"
                    // Bumble Blast
                    frmMain.lstCharacters.SelectedItem = "Bumble Blast"
                Case "C20B"
                    // Countdown
                    frmMain.lstCharacters.SelectedItem = "Countdown"
                Case "EB03"
                    // Doom Stone (Bottom)
                    frmMain.lstCharacters.SelectedItem = "Doom Stone (Bottom)"
                Case "D307"
                    // Doom Stone (Top)
                    frmMain.lstCharacters.SelectedItem = "Doom Stone (Top)"
                Case "C00B"
                    // Dune Bug
                    frmMain.lstCharacters.SelectedItem = "Dune Bug"
                Case "ED03"
                    // Fire Kraken (Bottom)
                    frmMain.lstCharacters.SelectedItem = "Fire Kraken (Bottom)"
                Case "D507"
                    // Fire Kraken (Top)
                    frmMain.lstCharacters.SelectedItem = "Fire Kraken (Top)"
                Case "E903"
                    // Free Ranger (Bottom)
                    frmMain.lstCharacters.SelectedItem = "Free Ranger (Bottom)"
                Case "D107"
                    // Free Ranger (Top)
                    frmMain.lstCharacters.SelectedItem = "Free Ranger (Top)"
                Case "F603"
                    // Freeze Blade (Bottom)
                    frmMain.lstCharacters.SelectedItem = "Freeze Blade (Bottom)"
                Case "DE07"
                    // Freeze Blade (Top)
                    frmMain.lstCharacters.SelectedItem = "Freeze Blade (Top)"
                Case "BC0B"
                    // Fryno
                    frmMain.lstCharacters.SelectedItem = "Fryno"
                Case "EF03"
                    // Grilla Drilla (Bottom)
                    frmMain.lstCharacters.SelectedItem = "Grilla Drilla (Bottom)"
                Case "D707"
                    // Grilla Drilla (Bottom)
                    frmMain.lstCharacters.SelectedItem = "Grilla Drilla (Top)"
                Case "C50B"
                    // Grim Creeper
                    frmMain.lstCharacters.SelectedItem = "Grim Creeper"
                Case "F003"
                    // Hoot Loop (Bottom)
                    frmMain.lstCharacters.SelectedItem = "Hoot Loop (Bottom)"
                Case "D807"
                    // Hoot Loop (Top)
                    frmMain.lstCharacters.SelectedItem = "Hoot Loop (Top)"
                Case "F203"
                    // Magna Charge (Bottom)
                    frmMain.lstCharacters.SelectedItem = "Magna Charge (Bottom)"
                Case "DA07"
                    // Magna Charge (Top)
                    frmMain.lstCharacters.SelectedItem = "Magna Charge (Top)"
                Case "F403"
                    // Night Shift (Bottom)
                    frmMain.lstCharacters.SelectedItem = "Night Shift (Bottom)"
                Case "DC07"
                    // Night Shift (Top)
                    frmMain.lstCharacters.SelectedItem = "Night Shift (Top)"
                Case "B90B"
                    // Pop Thorn
                    frmMain.lstCharacters.SelectedItem = "Pop Thorn"
                Case "C70B"
                    // Punk Shock
                    frmMain.lstCharacters.SelectedItem = "Punk Shock"
                Case "F503"
                    // Rattle Shake (Bottom)
                    frmMain.lstCharacters.SelectedItem = "Rattle Shake (Bottom)"
                Case "DD07"
                    // Rattle Shake (Top)
                    frmMain.lstCharacters.SelectedItem = "Rattle Shake (Top)"
                Case "6C0B"
                    // Rip Tide
                    frmMain.lstCharacters.SelectedItem = "Rip Tide"
                Case "C40B"
                    // Roller Brawl
                    frmMain.lstCharacters.SelectedItem = "Roller Brawl"
                Case "EA03"
                    // Rubble Rouser (Bottom)
                    frmMain.lstCharacters.SelectedItem = "Rubble Rouser (Bottom)"
                Case "D207"
                    // Rubble Rouser (Top)
                    frmMain.lstCharacters.SelectedItem = "Rubble Rouser (Top)"
                Case "BB0B"
                    // Scorp
                    frmMain.lstCharacters.SelectedItem = "Scorp"
                Case "B80B"
                    // Scratch
                    frmMain.lstCharacters.SelectedItem = "Scratch"
                Case "BA0B"
                    // Slobber Tooth
                    frmMain.lstCharacters.SelectedItem = "Slobber Tooth"
                Case "BD0B"
                    // Smolderdash
                    frmMain.lstCharacters.SelectedItem = "Smolderdash"
                Case "F303"
                    // Spy Rise (Bottom)
                    frmMain.lstCharacters.SelectedItem = "Spy Rise (Bottom)"
                Case "DB07"
                    // Spy Rise (Top)
                    frmMain.lstCharacters.SelectedItem = "Spy Rise (Top)"
                Case "C10B"
                    // Star Strike
                    frmMain.lstCharacters.SelectedItem = "Star Strike"
                Case "EE03"
                    // Stink Bomb (Bottom)
                    frmMain.lstCharacters.SelectedItem = "Stink Bomb (Bottom)"
                Case "D607"
                    // Stink Bomb (Top)
                    frmMain.lstCharacters.SelectedItem = "Stink Bomb (Top)"
                Case "F103"
                    // Trap Shadow (Bottom)
                    frmMain.lstCharacters.SelectedItem = "Trap Shadow (Bottom)"
                Case "D907"
                    // Trap Shadow (Top)
                    frmMain.lstCharacters.SelectedItem = "Trap Shadow (Top)"
                Case "F703"
                    // Wash Buckler (Bottom)
                    frmMain.lstCharacters.SelectedItem = "Wash Buckler (Bottom)"
                Case "DF07"
                    // Wash Buckler (Top)
                    frmMain.lstCharacters.SelectedItem = "Wash Buckler (Top)"
                Case "C30B"
                    // Wind-Up
                    frmMain.lstCharacters.SelectedItem = "Wind-Up"
                Case "BF0B"
                    // Zoo Lou
                    frmMain.lstCharacters.SelectedItem = "Zoo Lou"
                Case "2D01"
                    // Empire of Ice
                    frmMain.cmbGame.SelectedItem = "Adventure Packs"
                    frmMain.lstCharacters.SelectedItem = "Empire of Ice"
                Case "2E01"
                    // Pirate Seas
                    frmMain.cmbGame.SelectedItem = "Adventure Packs"
                    frmMain.lstCharacters.SelectedItem = "Pirate Seas"
                Case "C800"
                    // Anvil Rain
                    frmMain.cmbGame.SelectedItem = "Items"
                    frmMain.lstCharacters.SelectedItem = "Anvil Rain"
                Case "3001"
                    // Volcanic Vault
                    frmMain.cmbGame.SelectedItem = "Adventure Packs"
                    frmMain.lstCharacters.SelectedItem = "Volcanic Vault"
                Case "800C"
                    // Battle Hammer
                    frmMain.cmbGame.SelectedItem = "Items"
                    frmMain.lstCharacters.SelectedItem = "Battle Hammer"
                Case "C900"
                    // Hidden Treasure
                    frmMain.cmbGame.SelectedItem = "Items"
                    frmMain.lstCharacters.SelectedItem = "Hidden Treasure"
                Case "CB00"
                    // Ghost Swords
                    frmMain.cmbGame.SelectedItem = "Items"
                    frmMain.lstCharacters.SelectedItem = "Ghost Pirate Swords"
                Case "CD00"
                    // Sky Iron Shield
                    frmMain.cmbGame.SelectedItem = "Items"
                    frmMain.lstCharacters.SelectedItem = "Sky-Iron Shield"
            End Select
        } else if (Var = "022C") {
                                                    frmMain.cmbGame.SelectedItem = "Swap Force"
            Select Case Fig
                Case "1A00"
                    // Dark Stealth Elf
                    frmMain.lstCharacters.SelectedItem = "Dark Stealth Elf"
                Case "1300"
                    // Springtime Trigger Happy
                    frmMain.lstCharacters.SelectedItem = "Springtime Trigger Happy"
                Case "0900"
                    // Volcanic Eruptor
                    frmMain.lstCharacters.SelectedItem = "Volcanic Eruptor"
            End Select
        } else if (Var = "0224") {
                                                    frmMain.cmbGame.SelectedItem = "Swap Force"
            Select Case Fig
                Case "EC03"
                    // Dark Blast Zone (Bottom)
                    frmMain.lstCharacters.SelectedItem = "Dark Blast Zone (Bottom)"
                Case "D407"
                    // Dark Blast Zone (Top)
                    frmMain.lstCharacters.SelectedItem = "Dark Blast Zone (Top)"
                Case "BA0B"
                    // Dark Slobber Tooth
                    frmMain.lstCharacters.SelectedItem = "Dark Slobber Tooth"
                Case "F703"
                    // Dark Wash Buckler (Bottom)
                    frmMain.lstCharacters.SelectedItem = "Dark Wash Buckler (Bottom)"
                Case "DF07"
                    // Dark Wash Buckler (Top)
                    frmMain.lstCharacters.SelectedItem = "Dark Wash Buckler (Top)"
                Case "F003"
                    // Enchanted Hoot Loop (Bottom)
                    frmMain.lstCharacters.SelectedItem = "Enchanted Hoot Loop (Bottom)"
                Case "D807"
                    // Enchanted Hoot Loop (Top)
                    frmMain.lstCharacters.SelectedItem = "Enchanted Hoot Loop (Top)"
                Case "ED03"
                    // Jade Fire Kraken (Bottom)
                    frmMain.lstCharacters.SelectedItem = "Jade Fire Kraken (Bottom)"
                Case "D507"
                    // Jade Fire Kraken (Top)
                    frmMain.lstCharacters.SelectedItem = "Jade Fire Kraken (Top)"
                Case "BE0B"
                    // Jolly Bumble Blast
                    frmMain.lstCharacters.SelectedItem = "Jolly Bumble Blast"
                Case "C20B"
                    // Kickoff Countdown
                    frmMain.lstCharacters.SelectedItem = "Kickoff Countdown"
                Case "F603"
                    // Nitro Freeze Blade (Bottom)
                    frmMain.lstCharacters.SelectedItem = "Nitro Freeze Blade (Bottom)"
                Case "DE07"
                    // Nitro Freeze Blade (Top)
                    frmMain.lstCharacters.SelectedItem = "Nitro Freeze Blade (Top)"
                Case "F203"
                    // Nitro Magna Charge (Bottom)
                    frmMain.lstCharacters.SelectedItem = "Nitro Magna Charge (Bottom)"
                Case "DA07"
                    // Nitro Magna Charge (Top)
                    frmMain.lstCharacters.SelectedItem = "Nitro Magna Charge (Top)"
                Case "F503"
                    // Quickdraw Rattle Shake (Bottom)
                    frmMain.lstCharacters.SelectedItem = "Quickdraw Rattle Shake (Bottom)"
                Case "DD07"
                    // Quickdraw Rattle Shake (Top)
                    frmMain.lstCharacters.SelectedItem = "Quickdraw Rattle Shake (Top)"
            End Select
        } else if (Var = "0226") {
                                                    frmMain.cmbGame.SelectedItem = "Swap Force"
            Select Case Fig
                Case "C10B"
                    // Enchanted Star Strike
                    frmMain.lstCharacters.SelectedItem = "Enchanted Star Strike"
            End Select
        } else if (Var = "0324") {
                                                    frmMain.cmbGame.SelectedItem = "Swap Force"
            Select Case Fig
                Case "E903"
                    // Legendary Free Ranger (Bottom)
                    frmMain.lstCharacters.SelectedItem = "Legendary Free Ranger (Bottom)"
                Case "D107"
                    // Legendary Free Ranger (Top)
                    frmMain.lstCharacters.SelectedItem = "Legendary Free Ranger (Top)"
                Case "F403"
                    // Legendary Night Shift (Bottom)
                    frmMain.lstCharacters.SelectedItem = "Legendary Night Shift (Bottom)"
                Case "DC07"
                    // Legendary Night Shift (Top)
                    frmMain.lstCharacters.SelectedItem = "Legendary Night Shift (Top)"
                Case "BF0B"
                    // Legendary Zoo Lou
                    frmMain.lstCharacters.SelectedItem = "Legendary Zoo Lou"
            End Select
        } else if (Var = "0326") {
                                                    frmMain.cmbGame.SelectedItem = "Swap Force"
            Select Case Fig
                Case "C50B"
                    // Legendary Grim Creeper
                    frmMain.lstCharacters.SelectedItem = "Legendary Grim Creeper"
            End Select
        } else if (Var = "0528") {
                                                    frmMain.cmbGame.SelectedItem = "Swap Force"
            Select Case Fig
                Case "0E00"
                    // Anchors Away Gill Grunt
                    frmMain.lstCharacters.SelectedItem = "Anchors Away Gill Grunt"
                Case "1300"
                    // Big Bang Trigger Happy
                    frmMain.lstCharacters.SelectedItem = "Big Bang Trigger Happy"
                Case "6A00"
                    // Blizzard Chill
                    frmMain.lstCharacters.SelectedItem = "Blizzard Chill"
                Case "1000"
                    // Dark Mega Ram Spyro
                    frmMain.lstCharacters.SelectedItem = "Dark Mega Ram Spyro"
                Case "0069"
                    // Fire Bone Hot Dog
                    frmMain.lstCharacters.SelectedItem = "Fire Bone Hot Dog"
                Case "6F00"
                    // Heavy Duty Sprocket
                    frmMain.lstCharacters.SelectedItem = "Heavy Duty Sprocket"
                Case "0000"
                    // Horn Blast Whirlwind
                    frmMain.lstCharacters.SelectedItem = "Horn Blast Whirlwind"
                Case "0700"
                    // Hyper Beam Prism Break
                    frmMain.lstCharacters.SelectedItem = "Hyper Beam Prism Break"
                Case "0500"
                    // Knockout Terrafin
                    frmMain.lstCharacters.SelectedItem = "Knockout Terrafin"
                Case "0900"
                    // Lava Barf Eruptor
                    frmMain.lstCharacters.SelectedItem = "Lava Barf Eruptor"
                Case "1000"
                    // Mega Ram Spyro
                    frmMain.lstCharacters.SelectedItem = "Mega Ram Spyro"
                Case "1A00"
                    // Ninja Stealth Elf
                    frmMain.lstCharacters.SelectedItem = "Ninja Stealth Elf"
                Case "2000"
                    // Phantom Cynder
                    frmMain.lstCharacters.SelectedItem = "Phantom Cynder"
                Case "6C00"
                    // Super Gulp Pop Fizz
                    frmMain.lstCharacters.SelectedItem = "Super Gulp Pop Fizz"
                Case "1800"
                    // Thorn Horn Camo
                    frmMain.lstCharacters.SelectedItem = "Thorn Horn Camo"
                Case "6400"
                    // Turbo Jet-Vac
                    frmMain.lstCharacters.SelectedItem = "Turbo Jet-Vac"
                Case "1E00"
                    // Twin Blade Chop Chop
                    frmMain.lstCharacters.SelectedItem = "Twin Blade Chop Chop"
            End Select
        } else if (Var = "0622") {
                                                    frmMain.cmbGame.SelectedItem = "Swap Force"
            Select Case Fig
                Case "BE0B"
                    // LightCore Bumble Blast
                    frmMain.lstCharacters.SelectedItem = "LightCore Bumble Blast"
                Case "C20B"
                    // LightCore Countdown
                    frmMain.lstCharacters.SelectedItem = "LightCore Countdown"
                Case "6700"
                    // LightCore Flashwing
                    frmMain.lstCharacters.SelectedItem = "LightCore Flashwing"
                Case "C50B"
                    // LightCore Grim Creeper
                    frmMain.lstCharacters.SelectedItem = "LightCore Grim Creeper"
                Case "DB0B"
                    // LightCore Smolderdash
                    frmMain.lstCharacters.SelectedItem = "LightCore Smolderdash"
                Case "C10B"
                    // LightCore Star Strike
                    frmMain.lstCharacters.SelectedItem = "LightCore Star Strike"
                Case "0200"
                    // LightCore Warnado
                    frmMain.lstCharacters.SelectedItem = "LightCore Warnado"
                Case "0D00"
                    // LightCore Wham-Shell
                    frmMain.lstCharacters.SelectedItem = "LightCore Wham-Shell"
                Case "E70C"
                    // Arkeyan Crossbow
                    frmMain.cmbGame.SelectedItem = "Items"
                    frmMain.lstCharacters.SelectedItem = "Arkeyan Crossbow"
                Case "E60C"
                    // Fiery Forge
                    frmMain.cmbGame.SelectedItem = "Adventure Packs"
                    frmMain.lstCharacters.SelectedItem = "Fiery Forge"
            End Select
        } else if (Var = "0030") {
                                                    frmMain.cmbGame.SelectedItem = "Trap Team"
            Select Case Fig
                Case "1C02"
                    // Barkley
                    frmMain.lstCharacters.SelectedItem = "Barkley"
                Case "E001"
                    // Bat Spin
                    frmMain.lstCharacters.SelectedItem = "Bat Spin"
                Case "E501"
                    // Blackout
                    frmMain.lstCharacters.SelectedItem = "Blackout"
                Case "C501"
                    // Blades
                    frmMain.lstCharacters.SelectedItem = "Blades"
                Case "D201"
                    // Blastermind
                    frmMain.lstCharacters.SelectedItem = "Blastermind"
                Case "F601"
                    // Bop
                    frmMain.lstCharacters.SelectedItem = "Bop"
                Case "FA01"
                    // Breeze
                    frmMain.lstCharacters.SelectedItem = "Breeze"
                Case "DA01"
                    // Bushwhack
                    frmMain.lstCharacters.SelectedItem = "Bushwhack"
                Case "D801"
                    // Chopper
                    frmMain.lstCharacters.SelectedItem = "Chopper"
                Case "D501"
                    // Cobra Cadabra
                    frmMain.lstCharacters.SelectedItem = "Cobra Cadabra"
                Case "FE01"
                    // Drobit
                    frmMain.lstCharacters.SelectedItem = "Drobit"
                Case "D401"
                    // Déjà Vu
                    frmMain.lstCharacters.SelectedItem = "Déjà Vu"
                Case "D101"
                    // Echo
                    frmMain.lstCharacters.SelectedItem = "Echo"
                Case "D301"
                    // Enigma
                    frmMain.lstCharacters.SelectedItem = "Enigma"
                Case "1F02"
                    // Eye-Small
                    frmMain.lstCharacters.SelectedItem = "Eye-Small"
                Case "C801"
                    // Fist Bump
                    frmMain.lstCharacters.SelectedItem = "Fist Bump"
                Case "C401"
                    // Fling Kong
                    frmMain.lstCharacters.SelectedItem = "Fling Kong"
                Case "D001"
                    // Flip Wreck
                    frmMain.lstCharacters.SelectedItem = "Flip Wreck"
                Case "DC01"
                    // Food Fight
                    frmMain.lstCharacters.SelectedItem = "Food Fight"
                Case "E101"
                    // Funny Bone
                    frmMain.lstCharacters.SelectedItem = "Funny Bone"
                Case "D701"
                    // Gearshift
                    frmMain.lstCharacters.SelectedItem = "Gearshift"
                Case "0202"
                    // Gill Runt
                    frmMain.lstCharacters.SelectedItem = "Gill Runt"
                Case "C201"
                    // Gusto
                    frmMain.lstCharacters.SelectedItem = "Gusto"
                Case "C701"
                    // Head Rush
                    frmMain.lstCharacters.SelectedItem = "Head Rush"
                Case "DD01"
                    // High Five
                    frmMain.lstCharacters.SelectedItem = "High Five"
                Case "F801"
                    // Hijinx
                    frmMain.lstCharacters.SelectedItem = "Hijinx"
                Case "D601"
                    // Jawbreaker
                    frmMain.lstCharacters.SelectedItem = "Jawbreaker"
                Case "CB01"
                    // Ka-Boom
                    frmMain.lstCharacters.SelectedItem = "Ka-Boom"
                Case "E201"
                    // Knight Light
                    frmMain.lstCharacters.SelectedItem = "Knight Light"
                Case "E401"
                    // Knight Mare
                    frmMain.lstCharacters.SelectedItem = "Knight Mare"
                Case "DE01"
                    // Krypt King
                    frmMain.lstCharacters.SelectedItem = "Krypt King"
                Case "CF01"
                    // Lob-Star
                    frmMain.lstCharacters.SelectedItem = "Lob-Star"
                Case "1E02"
                    // Mini-Jini
                    frmMain.lstCharacters.SelectedItem = "Mini-Jini"
                Case "FC01"
                    // Pet-Vac
                    frmMain.lstCharacters.SelectedItem = "Pet-Vac"
                Case "C901"
                    // Rocky Roll
                    frmMain.lstCharacters.SelectedItem = "Rocky Roll"
                Case "DF01"
                    // Short Cut
                    frmMain.lstCharacters.SelectedItem = "Short Cut"
                Case "FD01"
                    // Small Fry
                    frmMain.lstCharacters.SelectedItem = "Small Fry"
                Case "CE01"
                    // Snap Shot
                    frmMain.lstCharacters.SelectedItem = "Snap Shot"
                Case "E301"
                    // Spotlight
                    frmMain.lstCharacters.SelectedItem = "Spotlight"
                Case "F701"
                    // Spry
                    frmMain.lstCharacters.SelectedItem = "Spry"
                Case "F901"
                    // Terrabite
                    frmMain.lstCharacters.SelectedItem = "Terrabite"
                Case "1D02"
                    // Thumpling
                    frmMain.lstCharacters.SelectedItem = "Thumpling"
                Case "C301"
                    // Thunderbolt
                    frmMain.lstCharacters.SelectedItem = "Thunderbolt"
                Case "CD01"
                    // Torch
                    frmMain.lstCharacters.SelectedItem = "Torch"
                Case "CC01"
                    // Trail Blazer
                    frmMain.lstCharacters.SelectedItem = "Trail Blazer"
                Case "D901"
                    // Tread Head
                    frmMain.lstCharacters.SelectedItem = "Tread Head"
                Case "0702"
                    // Trigger Snappy
                    frmMain.lstCharacters.SelectedItem = "Trigger Snappy"
                Case "DB01"
                    // Tuff Luck
                    frmMain.lstCharacters.SelectedItem = "Tuff Luck"
                Case "C601"
                    // Wallop
                    frmMain.lstCharacters.SelectedItem = "Wallop"
                Case "FB01"
                    // Weeruptor
                    frmMain.lstCharacters.SelectedItem = "Weeruptor"
                Case "0E02"
                    // Whisper Elf
                    frmMain.lstCharacters.SelectedItem = "Whisper Elf"
                Case "CA01"
                    // Wildfire
                    frmMain.lstCharacters.SelectedItem = "Wildfire"
                Case "3401"
                    frmMain.cmbGame.SelectedItem = "Adventure Packs"
                    frmMain.lstCharacters.SelectedItem = "Midnight Museum"
                Case "3101"
                    frmMain.cmbGame.SelectedItem = "Adventure Packs"
                    frmMain.lstCharacters.SelectedItem = "Mirror of Mystery"
                Case "3201"
                    frmMain.cmbGame.SelectedItem = "Adventure Packs"
                    frmMain.lstCharacters.SelectedItem = "Nightmare Express"
            End Select
        } else if (Var = "1D30") {
                                                    Select Case Fig
                                                        Case "C301"
                    // Clear Thunderbolt
                    frmMain.lstCharacters.SelectedItem = "Clear Thunderbolt"
            End Select
        } else if (Var = "0138") {
                                                    frmMain.cmbGame.SelectedItem = "Trap Team"
            Select Case Fig
                Case "BC0B"
                    // Hog Wild Fryno
                    frmMain.lstCharacters.SelectedItem = "Hog Wild Fryno"
                Case "7100"
                    // Sure Shot Shroomboom
                    frmMain.lstCharacters.SelectedItem = "Sure Shot Shroomboom"
            End Select
        } else if (Var = "023C") {
                                                    frmMain.cmbGame.SelectedItem = "Trap Team"
            Select Case Fig
                Case "6C00"
                    // Love Potion Pop Fizz
                    frmMain.lstCharacters.SelectedItem = "Love Potion Pop Fizz"
            End Select
        } else if (Var = "0234") {
                                                    frmMain.cmbGame.SelectedItem = "Trap Team"
            Select Case Fig
                Case "DC01"
                    // Dark Food Fight
                    frmMain.lstCharacters.SelectedItem = "Dark Food Fight"
                Case "CE01"
                    // Dark Snap Shot
                    frmMain.lstCharacters.SelectedItem = "Dark Snap Shot"
                Case "CA01"
                    // Dark Wildfire
                    frmMain.lstCharacters.SelectedItem = "Dark Wildfire"
                Case "FB01"
                    // Eggsellent Weeruptor
                    frmMain.lstCharacters.SelectedItem = "Eggsellent Weeruptor"
                Case "1C02"
                    // Gnarly Barkley
                    frmMain.lstCharacters.SelectedItem = "Gnarly Barkley"
                Case "D501"
                    // King Cobra Cadabra
                    frmMain.lstCharacters.SelectedItem = "King Cobra Cadabra"
                Case "C701"
                    // Nitro Head Rush
                    frmMain.lstCharacters.SelectedItem = "Nitro Head Rush"
                Case "DE01"
                    // Nitro Krypt King
                    frmMain.lstCharacters.SelectedItem = "Nitro Krypt King"
                Case "FC01"
                    // Power Punch Pet-Vac
                    frmMain.lstCharacters.SelectedItem = "Power Punch Pet-Vac"
                Case "CF01"
                    // Winterfest Lob-Star
                    frmMain.lstCharacters.SelectedItem = "Winterfest Lob-Star"
            End Select
        } else if (Var = "0334") {
                                                    frmMain.cmbGame.SelectedItem = "Trap Team"
            Select Case Fig
                Case "C501"
                    // Legendary Blades
                    frmMain.lstCharacters.SelectedItem = "Legendary Blades"
                Case "DA01"
                    // Legendary Bushwhack
                    frmMain.lstCharacters.SelectedItem = "Legendary Bushwhack"
                Case "D401"
                    // Legendary Déjà Vu
                    frmMain.lstCharacters.SelectedItem = "Legendary Déjà Vu"
                Case "D601"
                    // Legendary Jawbreaker
                    frmMain.lstCharacters.SelectedItem = "Legendary Jawbreaker"
                Case "E600"
                    //  MessageBox.Show("L. Hand")
                    // Legendary Hand of Fate
                                                    frmMain.cmbGame.SelectedItem = "Items"
                    frmMain.lstCharacters.SelectedItem = "Legendary Hand of Fate"
            End Select
        } else if (Var = "0538") {
                                                    frmMain.cmbGame.SelectedItem = "Trap Team"
            Select Case Fig
                Case "6C00"
                    // Fizzy Frenzy Pop Fizz
                    frmMain.lstCharacters.SelectedItem = "Fizzy Frenzy Pop Fizz"
                Case "6400"
                    // Full Blast Jet-Vac
                    frmMain.lstCharacters.SelectedItem = "Full Blast Jet-Vac"
            End Select
        } else if (Var = "0632") {
                                                    frmMain.cmbGame.SelectedItem = "Adventure Packs"
            Select Case Fig
                Case "3401"
                    // Midnight Museum (Proper?)
                    frmMain.lstCharacters.SelectedItem = "Midnight Museum"
                Case "3301"
                    // Sunscraper Spire
                    frmMain.lstCharacters.SelectedItem = "Sunscraper Spire"
            End Select
        } else if (Var = "0938") {
                                                    frmMain.cmbGame.SelectedItem = "Trap Team"
            Select Case Fig
                Case "0E00"
                    // Tidal Wave Gill Grunt
                    frmMain.lstCharacters.SelectedItem = "Tidal Wave Gill Grunt"
            End Select
        } else if (Var = "1038") {
                                                    frmMain.cmbGame.SelectedItem = "Trap Team"
            Select Case Fig
                Case "1E00"
                    // Elite Chop Chop
                    frmMain.lstCharacters.SelectedItem = "Elite Chop Chop"
                Case "0900"
                    // Elite Eruptor
                    frmMain.lstCharacters.SelectedItem = "Elite Eruptor"
                Case "0E00"
                    // Elite Gill Grunt
                    frmMain.lstCharacters.SelectedItem = "Elite Gill Grunt"
                Case "1000"
                    // Elite Spyro
                    frmMain.lstCharacters.SelectedItem = "Elite Spyro"
                Case "1A00"
                    // Elite Stealth Elf
                    frmMain.lstCharacters.SelectedItem = "Elite Stealth Elf"
                Case "0500"
                    // Elite Terrafin
                    frmMain.lstCharacters.SelectedItem = "Elite Terrafin"
                Case "1300"
                    // Elite Trigger Happy
                    frmMain.lstCharacters.SelectedItem = "Elite Trigger Happy"
                Case "0000"
                    // Elite Whirlwind
                    frmMain.lstCharacters.SelectedItem = "Elite Whirlwind"
            End Select
        } else if (Var = "0041") {
                                                    frmMain.cmbGame.SelectedItem = "SuperChargers"
            Select Case Fig
                Case "620D"
                    frmMain.lstCharacters.SelectedItem = "Astroblast"
                Case "5C0D"
                    frmMain.lstCharacters.SelectedItem = "Big Bubble Pop Fizz"
                Case "590D"
                    frmMain.lstCharacters.SelectedItem = "Bone Bash Roller Brawl"
                Case "5E0D"
                    frmMain.lstCharacters.SelectedItem = "Deep Dive Gill Grunt"
                Case "610D"
                    frmMain.lstCharacters.SelectedItem = "Dive-Clops"
                Case "560D"
                    frmMain.lstCharacters.SelectedItem = "Double Dare Trigger Happy"
                Case "480D"
                    frmMain.lstCharacters.SelectedItem = "Fiesta"
                Case "600D"
                    frmMain.lstCharacters.SelectedItem = "Hammer Slam Bowser"
                Case "490D"
                    frmMain.lstCharacters.SelectedItem = "High Volt"
                Case "550D"
                    frmMain.lstCharacters.SelectedItem = "Hurricane Jet-Vac"
                Case "5D0D"
                    frmMain.lstCharacters.SelectedItem = "Lava Lance Eruptor"
                Case "630D"
                    frmMain.lstCharacters.SelectedItem = "Nightfall"
                Case "580D"
                    frmMain.lstCharacters.SelectedItem = "Shark Shooter Terrafin"
                Case "530D"
                    frmMain.lstCharacters.SelectedItem = "Smash Hit"
                Case "540D"
                    frmMain.lstCharacters.SelectedItem = "Spitfire"
                Case "4A0D"
                    frmMain.lstCharacters.SelectedItem = "Splat"
                Case "4E0D"
                    frmMain.lstCharacters.SelectedItem = "Stormblade"
                Case "570D"
                    frmMain.lstCharacters.SelectedItem = "Super Shot Stealth Elf"
                Case "640D"
                    frmMain.lstCharacters.SelectedItem = "Thrillipede"
                Case "5F0D"
                    frmMain.lstCharacters.SelectedItem = "Turbo Charge Donkey Kong"
            End Select
        } else if (Var = "0040") {
                                                    frmMain.cmbGame.SelectedItem = "Vehicles"
            BlnVehicle = True
            Select Case Fig
                Case "A80C"
                    frmMain.lstCharacters.SelectedItem = "Barrel Blaster"
                Case "970C"
                    frmMain.lstCharacters.SelectedItem = "Burn-Cycle"
                Case "A909"
                    frmMain.lstCharacters.SelectedItem = "Buzz Wing"
                Case "A90C"
                    // Buzz Wing
                    frmMain.lstCharacters.SelectedItem = "Buzz Wing"
                Case "A10C"
                    frmMain.lstCharacters.SelectedItem = "Clown Cruiser"
                Case "9B0C"
                    frmMain.lstCharacters.SelectedItem = "Crypt Crusher"
                Case "9F0C"
                    frmMain.lstCharacters.SelectedItem = "Dive Bomber"
                Case "A20C"
                    frmMain.lstCharacters.SelectedItem = "Gold Rusher"
                Case "940C"
                    frmMain.lstCharacters.SelectedItem = "Jet Stream"
                Case "AF0D"
                    frmMain.lstCharacters.SelectedItem = "Kaos Trophy"
                Case "AD0D"
                    frmMain.lstCharacters.SelectedItem = "Land Trophy"
                Case "960C"
                    frmMain.lstCharacters.SelectedItem = "Reef Ripper"
                Case "A50C"
                    frmMain.lstCharacters.SelectedItem = "Sea Shadow"
                Case "AE0D"
                    frmMain.lstCharacters.SelectedItem = "Sea Trophy"
                Case "990C"
                    frmMain.lstCharacters.SelectedItem = "Shark Tank"
                Case "A30C"
                    frmMain.lstCharacters.SelectedItem = "Shield Striker"
                Case "A00C"
                    frmMain.lstCharacters.SelectedItem = "Sky Slicer"
                Case "AC0D"
                    frmMain.lstCharacters.SelectedItem = "Sky Trophy"
                Case "A70C"
                    frmMain.lstCharacters.SelectedItem = "Soda Skimmer"
                Case "A60C"
                    frmMain.lstCharacters.SelectedItem = "Splatter Splasher"
                Case "9C0C"
                    frmMain.lstCharacters.SelectedItem = "Stealth Stinger"
                Case "A40C"
                    frmMain.lstCharacters.SelectedItem = "Sun Runner"
                Case "9A0C"
                    frmMain.lstCharacters.SelectedItem = "Thump Truck"
                Case "950C"
                    frmMain.lstCharacters.SelectedItem = "Tomb Buggy"
            End Select
        } else if (Var = "0E45") {
                                                    frmMain.cmbGame.SelectedItem = "SuperChargers"
            Select Case Fig
                Case "5C0D"
                    frmMain.lstCharacters.SelectedItem = "Birthday Bash Big Bubble Pop Fizz"
                Case "610D"
                    frmMain.lstCharacters.SelectedItem = "Missile-Tow Dive-Clops"
            End Select
        } else if (Var = "0244") {
                                                    frmMain.cmbGame.SelectedItem = "SuperChargers"
            BlnVehicle = True
            Select Case Fig
                Case "A80C"
                    frmMain.lstCharacters.SelectedItem = "Dark Barrel Blaster"
                Case "A10C"
                    frmMain.lstCharacters.SelectedItem = "Dark Clown Cruiser"
                Case "980C"
                    frmMain.lstCharacters.SelectedItem = "Dark Hot Streak"
                Case "A50C"
                    frmMain.lstCharacters.SelectedItem = "Dark Sea Shadow"
                Case "A70C"
                    frmMain.lstCharacters.SelectedItem = "Nitro Soda Skimmer"
                Case "9C0C"
                    frmMain.lstCharacters.SelectedItem = "Nitro Stealth Stinger"
                Case "A20C"
                    frmMain.lstCharacters.SelectedItem = "Power Blue Gold Rusher"
                Case "A60C"
                    frmMain.lstCharacters.SelectedItem = "Power Blue Splatter Splasher"
                Case "9F0C"
                    frmMain.lstCharacters.SelectedItem = "Spring Ahead Dive Bomber"
            End Select
        } else if (Var = "0245") {
                                                    frmMain.cmbGame.SelectedItem = "SuperChargers"
            Select Case Fig
                Case "600D"
                    frmMain.lstCharacters.SelectedItem = "Dark Hammer Slam Bowser"
                Case "540D"
                    frmMain.lstCharacters.SelectedItem = "Dark Spitfire"
                Case "570D"
                    frmMain.lstCharacters.SelectedItem = "Dark Super Shot Stealth Elf"
                Case "5F0D"
                    frmMain.lstCharacters.SelectedItem = "Dark Turbo Charge Donkey Kong"
                Case "4A0D"
                    frmMain.lstCharacters.SelectedItem = "Power Blue Splat"
                Case "560D"
                    frmMain.lstCharacters.SelectedItem = "Power Blue Trigger Happy"
                Case "530D"
                    frmMain.lstCharacters.SelectedItem = "Steel Plated Smash Hit"
            End Select
        } else if (Var = "0440") {
                                                    frmMain.cmbGame.SelectedItem = "SuperChargers"
            BlnVehicle = True
            Select Case Fig
                Case "970C"
                    frmMain.lstCharacters.SelectedItem = "E3 Hot Streak"
                Case "980C"
                    frmMain.lstCharacters.SelectedItem = "Hot Streak"
            End Select
        } else if (Var = "0D45") {
                                                    frmMain.cmbGame.SelectedItem = "SuperChargers"
            Select Case Fig
                Case "640D"
                    frmMain.lstCharacters.SelectedItem = "Eggcited Thrillipede"
            End Select
        } else if (Var = "1048") {
                                                    frmMain.cmbGame.SelectedItem = "SuperChargers"
            Select Case Fig
                Case "1600"
                    frmMain.lstCharacters.SelectedItem = "Elite Boomer"
                Case "0600"
                    frmMain.lstCharacters.SelectedItem = "Elite Dino-Rang"
                Case "1F00"
                    frmMain.lstCharacters.SelectedItem = "Elite Ghost Roaster"
                Case "0F00"
                    frmMain.lstCharacters.SelectedItem = "Elite Slam Bam"
                Case "1900"
                    frmMain.lstCharacters.SelectedItem = "Elite Zook"
            End Select
        } else if (Var = "1138") {
                                                    frmMain.cmbGame.SelectedItem = "SuperChargers"
            Select Case Fig
                Case "1100"
                    frmMain.lstCharacters.SelectedItem = "Elite Voodood"
            End Select
        } else if (Var = "1545") {
                                                    frmMain.cmbGame.SelectedItem = "SuperChargers"
            Select Case Fig
                Case "480D"
                    frmMain.lstCharacters.SelectedItem = "Frightful Fiesta"
            End Select
        } else if (Var = "1E44") {
                                                    frmMain.cmbGame.SelectedItem = "Vehicle"
            BlnVehicle = True
            Select Case Fig
                Case "980C"
                    frmMain.lstCharacters.SelectedItem = "Golden Hot Streak"
            End Select
        } else if (Var = "0345") {
                                                    frmMain.cmbGame.SelectedItem = "SuperChargers"
            Select Case Fig
                Case "620D"
                    frmMain.lstCharacters.SelectedItem = "Legendary Astroblast"
                Case "590D"
                    frmMain.lstCharacters.SelectedItem = "Legendary Bone Bash Roller Brawl"
                Case "550D"
                    frmMain.lstCharacters.SelectedItem = "Legendary Hurricane Jet-Vac"
            End Select
        } else if (Var = "0344") {
                                                    frmMain.cmbGame.SelectedItem = "Vehicle"
            BlnVehicle = True
            Select Case Fig
                Case "A40C"
                    frmMain.lstCharacters.SelectedItem = "Legendary Sun Runner"
            End Select
            // Imaginators
        } else if (Var = "0050") {
                                                    frmMain.cmbGame.SelectedItem = "Imaginators"
            Select Case Fig
                Case "5F02"
                    frmMain.lstCharacters.SelectedItem = "Air Strike"
                Case "6102"
                    frmMain.lstCharacters.SelectedItem = "Ambush"
                Case "6B02"
                    frmMain.lstCharacters.SelectedItem = "Aurora"
                Case "6E02"
                    frmMain.lstCharacters.SelectedItem = "Bad Juju"
                Case "5E02"
                    frmMain.lstCharacters.SelectedItem = "Barbella"
                Case "7002"
                    frmMain.lstCharacters.SelectedItem = "Blaster-Tron"
                Case "5C02"
                    frmMain.lstCharacters.SelectedItem = "Boom Bloom"
                Case "6A02"
                    frmMain.lstCharacters.SelectedItem = "Buckshot"
                    // Case ""
                    // frmMain.lstCharacters.SelectedItem = "Candy-Coated Chopscotch"
                                                    Case "7202"
                    frmMain.lstCharacters.SelectedItem = "Chain Reaction"
                Case "6D02"
                    frmMain.lstCharacters.SelectedItem = "Chompy Mage"
                Case "5B02"
                    frmMain.lstCharacters.SelectedItem = "Chopscotch"
                    // Case ""
                    // frmMain.lstCharacters.SelectedItem = "Clear Starcast"
                                                    Case "7602"
                    frmMain.lstCharacters.SelectedItem = "Crash Bandicoot"
                    // Case ""
                    // frmMain.lstCharacters.SelectedItem = "Dark Golden Queen"
                    // Case ""
                    // frmMain.lstCharacters.SelectedItem = "Dark King Pen"
                    // Case ""
                    // frmMain.lstCharacters.SelectedItem = "Dark Wolfgang"
                    // Case ""
                    // frmMain.lstCharacters.SelectedItem = "Dec-Ember"
                                                    Case "6202"
                    frmMain.lstCharacters.SelectedItem = "Dr. Krankcase"
                Case "7702"
                    frmMain.lstCharacters.SelectedItem = "Dr. Neo Cortex"
                    // Case ""
                    // frmMain.lstCharacters.SelectedItem = "Egg Bomber Air Strike"
                                                    Case "6002"
                    frmMain.lstCharacters.SelectedItem = "Ember"
                Case "6C02"
                    frmMain.lstCharacters.SelectedItem = "Flarewolf"
                Case "6502"
                    frmMain.lstCharacters.SelectedItem = "Golden Queen"
                Case "6F02"
                    frmMain.lstCharacters.SelectedItem = "Grave Clobber"
                    // Case ""
                    // frmMain.lstCharacters.SelectedItem = "Hard-Boiled Flarewolf"
                    // Case ""
                    // frmMain.lstCharacters.SelectedItem = "Heartbreaker Buckshot"
                                                    Case "6302"
                    frmMain.lstCharacters.SelectedItem = "Hood Sickle"
                Case "6D02"
                    frmMain.lstCharacters.SelectedItem = "Jingle Bell Chompy Mage"
                Case "7302"
                    frmMain.lstCharacters.SelectedItem = "Kaos"
                Case "5902"
                    frmMain.lstCharacters.SelectedItem = "King Pen"
                    // Case ""
                    // frmMain.lstCharacters.SelectedItem = "Mystical Bad Juju"
                    // Case ""
                    // frmMain.lstCharacters.SelectedItem = "Mystical Tae Kwon Crow"
                                                    Case "6802"
                    frmMain.lstCharacters.SelectedItem = "Mysticat"
                    // Case ""
                    // frmMain.lstCharacters.SelectedItem = "Orange Chain Reaction"
                                                    Case "6702"
                    frmMain.lstCharacters.SelectedItem = "Pain-Yatta"
                    // Case ""
                    // frmMain.lstCharacters.SelectedItem = "Pink Barbella"
                                                    Case "5D02"
                    frmMain.lstCharacters.SelectedItem = "Pit Boss"
                Case "7102"
                    frmMain.lstCharacters.SelectedItem = "Ro-Bow"
                    // Case ""
                    // frmMain.lstCharacters.SelectedItem = "Rock Candy Pain-Yatta"
                    // Case ""
                    // frmMain.lstCharacters.SelectedItem = "Solar Flare Aurora"
                                                    Case "6902"
                    frmMain.lstCharacters.SelectedItem = "Starcast"
                    // Case ""
                    // frmMain.lstCharacters.SelectedItem = "Steel Plated Hood Sickle"
                                                    Case "6402"
                    frmMain.lstCharacters.SelectedItem = "Tae Kwon Crow"
                Case "7502"
                    frmMain.lstCharacters.SelectedItem = "Tidepool"
                Case "5A02"
                    frmMain.lstCharacters.SelectedItem = "Tri-Tip"
                Case "7402"
                    frmMain.lstCharacters.SelectedItem = "Wild Storm"
                Case "6602"
                    frmMain.lstCharacters.SelectedItem = "Wolfgang"

                Case "3601"
                    frmMain.cmbGame.SelectedItem = "Adventure Packs"
                    frmMain.lstCharacters.SelectedItem = "Gryphon Park Observatory"
                Case "3701"
                    frmMain.cmbGame.SelectedItem = "Adventure Packs"
                    frmMain.lstCharacters.SelectedItem = "Enchanted Elven Forest"
            End Select
        } else if (Var = "0330") {
                                                    // Toucan Trap Vars
                                                    frmMain.cmbGame.SelectedItem = "Traps"
            blnTrap = True
            Select Case Fig
                Case "D400"
                    frmMain.lstCharacters.SelectedItem = "Breezy Bird (Toucan)"
                Case "D800"
                    frmMain.lstCharacters.SelectedItem = "Rock Hawk (Toucan)"
                Case "D900"
                    frmMain.lstCharacters.SelectedItem = "Oak Eagle (Toucan)"
            End Select
        } else if (Var = "1030") {
                                                    // Snake Trap Vars
                                                    blnTrap = True
            frmMain.cmbGame.SelectedItem = "Traps"

            Select Case Fig
                Case "D400"
                    frmMain.lstCharacters.SelectedItem = "Cloudy Cobra (Snake)"
                Case "D900"
                    frmMain.lstCharacters.SelectedItem = "Seed Serpent (Snake)"
                Case "D500"
                    frmMain.lstCharacters.SelectedItem = "Spooky Snake (Snake)"
            End Select
        } else if (Var = "1830") {
                                                    blnTrap = True
            frmMain.cmbGame.SelectedItem = "Traps"

            Select Case Fig
                // Sword Trap Vars
                Case "D400"
                    frmMain.lstCharacters.SelectedItem = "Cyclone Sabre (Sword)"
                Case "DA00"
                    frmMain.lstCharacters.SelectedItem = "Dark Dagger (Sword)"
                Case "D900"
                    frmMain.lstCharacters.SelectedItem = "Jade Blade (Sword)"
            End Select
        } else if (Var = "0630") {
                                                    frmMain.cmbGame.SelectedItem = "Traps"
            // Jughead Trap Vars
            blnTrap = True
            Select Case Fig
                Case "D400"
                    frmMain.lstCharacters.SelectedItem = "Drafty Decanter (Jughead)"
                Case "D300"
                    frmMain.lstCharacters.SelectedItem = "Flood Flask (Jughead)"
            End Select
        } else if (Var = "1130") {
                                                    blnTrap = True
            frmMain.cmbGame.SelectedItem = "Traps"
            // Screamer Trap Vars
            Select Case Fig
                Case "D400"
                    frmMain.lstCharacters.SelectedItem = "Storm Warning (Screamer)"
                Case "D700"
                    frmMain.lstCharacters.SelectedItem = "Scorching Stopper (Screamer)"
            End Select
        } else if (Var = "0E30") {
                                                    blnTrap = True
            frmMain.cmbGame.SelectedItem = "Traps"

            Select Case Fig
                // Hourglas Trap Vars
                Case "D400"
                    frmMain.lstCharacters.SelectedItem = "Tempest Timer (Hourglass)"
                Case "D800"
                    frmMain.lstCharacters.SelectedItem = "Dust of Time (Hourglass)"
                Case "D200"
                    frmMain.lstCharacters.SelectedItem = "Arcane Hourglass (Hourglass)"
            End Select
        } else if (Var = "1A30") {
                                                    // Handstand Trap Vars
                                                    blnTrap = True
            frmMain.cmbGame.SelectedItem = "Traps"

            Select Case Fig
                Case "DA00"
                    frmMain.lstCharacters.SelectedItem = "Ghastly Grimace (Handstand)"
                Case "D800"
                    frmMain.lstCharacters.SelectedItem = "Rubble Trouble (Handstand)"
                Case "D600"
                    frmMain.lstCharacters.SelectedItem = "Topsy Techy (Handstand)"
            End Select
        } else if (Var = "1430") {
                                                    // Spider Trap Vars
                                                    blnTrap = True
            frmMain.cmbGame.SelectedItem = "Traps"

            Select Case Fig
                Case "DA00"
                    frmMain.lstCharacters.SelectedItem = "Shadow Spider (Spider)"
            End Select
        } else if (Var = "0430") {
                                                    // Orb Trap Vars
                                                    blnTrap = True
            frmMain.cmbGame.SelectedItem = "Traps"

            Select Case Fig
                Case "D800"
                    frmMain.lstCharacters.SelectedItem = "Banded Boulder (Orb)"
                Case "D500"
                    frmMain.lstCharacters.SelectedItem = "Spirit Sphere (Orb)"
            End Select
        } else if (Var = "0434") {
                                                    blnTrap = True
            frmMain.cmbGame.SelectedItem = "Traps"

            Select Case Fig
                Case "0434"
                    frmMain.lstCharacters.SelectedItem = "Legendary Spirit Sphere (Orb)"
            End Select
        } else if (Var = "0A30") {
                                                    blnTrap = True
            // Hammer Trap Figures
            frmMain.cmbGame.SelectedItem = "Traps"

            Select Case Fig
                Case "D800"
                    frmMain.lstCharacters.SelectedItem = "Slag Hammer (Hammer)"
                Case "D900"
                    frmMain.lstCharacters.SelectedItem = "Weed Whacker (Hammer)"
            End Select
        } else if (Var = "1230") {
                                                    blnTrap = True
            // Totem Trap Figures
            frmMain.cmbGame.SelectedItem = "Traps"

            Select Case Fig
                Case "D800"
                    frmMain.lstCharacters.SelectedItem = "Spinning Sandstorm (Totem)"
                Case "D700"
                    frmMain.lstCharacters.SelectedItem = "Searing Spinner (Totem)"
                Case "D100"
                    frmMain.lstCharacters.SelectedItem = "Spell Slapper (Totem)"
            End Select
        } else if (Var = "1B30") {
                                                    // Yawn Trap Figures
                                                    blnTrap = True
            frmMain.cmbGame.SelectedItem = "Traps"
            // Application.DoEvents()

            Select Case Fig
                Case "D700"
                    frmMain.lstCharacters.SelectedItem = "Blazing Belch (Yawn)"
                Case "D900"
                    frmMain.lstCharacters.SelectedItem = "Shrub Shrieker (Yawn)"
                Case "DB00"
                    frmMain.lstCharacters.SelectedItem = "Beam Scream (Yawn)"
            End Select
        } else if (Var = "0530") {
                                                    // Torch Trap Figures
                                                    blnTrap = True
            frmMain.cmbGame.SelectedItem = "Traps"

            Select Case Fig
                Case "D700"
                    frmMain.lstCharacters.SelectedItem = "Eternal Flame (Torch)"
                Case "D900"
                    frmMain.lstCharacters.SelectedItem = "Emerald Energy (Torch)"
            End Select
        } else if (Var = "0130") {
                                                    // Septer/Log Holder/Tiki Trap Figures
                                                    blnTrap = True
            frmMain.cmbGame.SelectedItem = "Traps"

            Select Case Fig
                Case "D700"
                    frmMain.lstCharacters.SelectedItem = "Fire Flower (Scepter)"
                Case "D200"
                    frmMain.lstCharacters.SelectedItem = "Biter// s Bane (Log Holder)"
                Case "D600"
                    frmMain.lstCharacters.SelectedItem = "Tech Totem (Tiki)"
                Case "D300"
                    frmMain.lstCharacters.SelectedItem = "Tidal Tiki (Tiki)"
            End Select
        } else if (Var = "1730") {
                                                    // Captain// s Hat Trap Figures
                                                    blnTrap = True
            frmMain.cmbGame.SelectedItem = "Traps"

            Select Case Fig
                Case "D700"
                    frmMain.lstCharacters.SelectedItem = "Spark Spear (Captain// s Hat)"
                Case "D500"
                    frmMain.lstCharacters.SelectedItem = "Dream Piercer (Captain// s Hat)"
            End Select
        } else if (Var = "0F30") {
                                                    frmMain.cmbGame.SelectedItem = "Traps"

            Select Case Fig
                Case "DB00"
                    frmMain.lstCharacters.SelectedItem = "Heavenly Hawk (Hawk)"
            End Select
        } else if (Var = "1530") {
                                                    // Rocket Trap Figures
                                                    blnTrap = True
            frmMain.cmbGame.SelectedItem = "Traps"

            Select Case Fig
                Case "DB00"
                    frmMain.lstCharacters.SelectedItem = "Shining Ship (Rocket)"
                Case "D200"
                    frmMain.lstCharacters.SelectedItem = "Rune Rocket (Rocket)"
            End Select
        } else if (Var = "0B30") {
                                                    // Axe Trap Figures
                                                    blnTrap = True
            frmMain.cmbGame.SelectedItem = "Traps"

            Select Case Fig
                Case "D200"
                    frmMain.lstCharacters.SelectedItem = "Axe of Illusion (Axe)"
                Case "D500"
                    frmMain.lstCharacters.SelectedItem = "Haunted Hatchet (Axe)"
                Case "D300"
                    frmMain.lstCharacters.SelectedItem = "Aqua Axe (Axe)"
            End Select
        } else if (Var = "0830") {
                                                    blnTrap = True
            // Skull Trap Figures
            frmMain.cmbGame.SelectedItem = "Traps"

            Select Case Fig
                Case "D200"
                    frmMain.lstCharacters.SelectedItem = "Sorcerous Skull (Skull)"
                Case "D500"
                    frmMain.lstCharacters.SelectedItem = "Spectral Skull (Skull)"
            End Select
        } else if (Var = "0C30") {
                                                    // Hand Trap Figures
                                                    blnTrap = True
            frmMain.cmbGame.SelectedItem = "Traps"

            Select Case Fig
                Case "D600"
                    frmMain.lstCharacters.SelectedItem = "Grabbing Gadget (Hand)"
                Case "D500"
                    frmMain.lstCharacters.SelectedItem = "Grim Gripper (Hand)"
            End Select
        } else if (Var = "1630") {
                                                    // Flying Helmet Trap Figures
                                                    blnTrap = True
            frmMain.cmbGame.SelectedItem = "Traps"

            Select Case Fig
                Case "D600"
                    frmMain.lstCharacters.SelectedItem = "Makers Mana (Flying Helmet)"
                Case "D300"
                    frmMain.lstCharacters.SelectedItem = "Frost Helm (Flying Helmet)"
            End Select
        } else if (Var = "0730") {
                                                    blnTrap = True
            // Angel Trap Figures
            frmMain.cmbGame.SelectedItem = "Traps"

            Select Case Fig
                Case "D600"
                    frmMain.lstCharacters.SelectedItem = "Automatic Angel (Angel)"
                Case "D300"
                    frmMain.lstCharacters.SelectedItem = "Soaking Staff (Angel)"
            End Select
        } else if (Var = "0230") {
                                                    blnTrap = True
            frmMain.cmbGame.SelectedItem = "Traps"

            Select Case Fig
                Case "D300"
                    frmMain.lstCharacters.SelectedItem = "Wet Walter (Log Holder)"
            End Select
        } else if (Var = "0930") {
                                                    blnTrap = True
            frmMain.cmbGame.SelectedItem = "Traps"

            Select Case Fig
                Case "D600"
                    frmMain.lstCharacters.SelectedItem = "Factory Flower (Scepter)"
            End Select
        } else if (Var = "0634") {
                                                    blnTrap = True
            frmMain.cmbGame.SelectedItem = "Traps"

            Select Case Fig
                Case "D300"
                    frmMain.lstCharacters.SelectedItem = "Legendary Flood Flask (Jughead)"
            End Select
        } else if (Var = "0834") {
                                                    blnTrap = True
            frmMain.cmbGame.SelectedItem = "Traps"

            Select Case Fig
                Case "D500"
                    frmMain.lstCharacters.SelectedItem = "Legendary Spectral Skull (Skull)"
            End Select
        } else if (Var = "1E30") {
                                                    blnTrap = True
            frmMain.cmbGame.SelectedItem = "Traps"

            Select Case Fig
                Case "DC00"
                    frmMain.lstCharacters.SelectedItem = "The Kaos Trap"
            End Select
        } else if (Var = "1F35") {
                                                    frmMain.cmbGame.SelectedItem = "Traps"
            blnTrap = True
            Select Case Fig
                Case "DC00"
                    frmMain.lstCharacters.SelectedItem = "Ultimate Kaos Trap"
            End Select
        } else if (Var = "D800") {
                                                    frmMain.cmbGame.SelectedItem = "Traps"
            blnTrap = True
            Select Case Fig
                Case "1B30"
                    frmMain.lstCharacters.SelectedItem = "Beam Scream (Yawn)"
                Case "0F30"
                    frmMain.lstCharacters.SelectedItem = "Heavenly Hawk (Hawk)"
            End Select
        } else if (Var = "1750") {
                                                    frmMain.cmbGame.SelectedItem = "Imaginators"
            Select Case Fig
                Case "EB00"
                    frmMain.lstCharacters.SelectedItem = "Blue Mystery Chest"
            End Select
        } else if (Var = "0150") {
                                                    frmMain.cmbGame.SelectedItem = "Imaginators"
            Select Case Fig
                Case "EB00"
                    frmMain.lstCharacters.SelectedItem = "Bronze Mystery Chest"
            End Select
        } else if (Var = "0250") {
                                                    frmMain.cmbGame.SelectedItem = "Imaginators"
            Select Case Fig
                Case "EB00"
                    frmMain.lstCharacters.SelectedItem = "Silver Mystery Chest"
            End Select
        } else if (Var = "D400") {
                                                    frmMain.cmbGame.SelectedItem = "Traps"
            blnTrap = True
            Select Case Fig
                Case "D400"
                    frmMain.lstCharacters.SelectedItem = "Breezy Bird (Toucan)"
            End Select
        } else if (Var = "0304") {
                                                    frmMain.cmbGame.SelectedItem = "Swap Force"
            Select Case Fig
                Case "F403"
                    frmMain.lstCharacters.SelectedItem = "Legendary Night Shift (Bottom)"
            End Select
        } else if (Var = "0350") {
                                                    frmMain.cmbGame.SelectedItem = "Imaginators"
            Select Case Fig
                Case "EB00"
                    frmMain.lstCharacters.SelectedItem = "Gold Mystery Chest"
            End Select
        } else if (Var = "1950") {
                                                    frmMain.cmbGame.SelectedItem = "Imaginators"
            Select Case Fig
                Case "EB00"
                    frmMain.lstCharacters.SelectedItem = "Platnium Mystery Chest"
            End Select
        } else if (Var = "0752") {
                                                    frmMain.cmbGame.SelectedItem = "Imaginators"
            blnCrystal = True
            Select Case Fig
                Case "AA02"
                    frmMain.lstCharacters.SelectedItem = "Air Crystal"
            End Select
        } else if (Var = "0652") {
                                                    frmMain.cmbGame.SelectedItem = "Imaginators Crystals"
            blnCrystal = True
            Select Case Fig
                Case "B002"
                    frmMain.lstCharacters.SelectedItem = "Dark Crystal"
            End Select
        } else if (Var = "1D52") {
                                                    frmMain.cmbGame.SelectedItem = "Imaginators Crystals"
            blnCrystal = True
            Select Case Fig
                Case "AE02"
                    frmMain.lstCharacters.SelectedItem = "Earth Crystal"
            End Select
        } else if (Var = "0F52") {
                                                    frmMain.cmbGame.SelectedItem = "Imaginators Crystals"
            blnCrystal = True
            Select Case Fig
                Case "AD02"
                    frmMain.lstCharacters.SelectedItem = "Fire Crystal"
            End Select
        } else if (Var = "1E52") {
                                                    frmMain.cmbGame.SelectedItem = "Imaginators Crystals"
            blnCrystal = True
            Select Case Fig
                Case "AF02"
                    frmMain.lstCharacters.SelectedItem = "Life Crystal"
            End Select
        } else if (Var = "0B52") {
                                                    frmMain.cmbGame.SelectedItem = "Imaginators Crystals"
            blnCrystal = True
            Select Case Fig
                Case "B102"
                    frmMain.lstCharacters.SelectedItem = "Light Crystal"
            End Select
        } else if (Var = "0852") {
                                                    frmMain.cmbGame.SelectedItem = "Imaginators Crystals"
            blnCrystal = True
            Select Case Fig
                Case "A802"
                    frmMain.lstCharacters.SelectedItem = "Magic Crystal"
            End Select
        } else if (Var = "1552") {
                                                    frmMain.cmbGame.SelectedItem = "Imaginators Crystals"
            blnCrystal = True
            Select Case Fig
                Case "AC02"
                    frmMain.lstCharacters.SelectedItem = "Tech Crystal"
            End Select
        } else if (Var = "0952") {
                                                    frmMain.cmbGame.SelectedItem = "Imaginators Crystals"
            blnCrystal = True
            Select Case Fig
                Case "AB02"
                    frmMain.lstCharacters.SelectedItem = "Undead Crystal"
            End Select
        } else if (Var = "1C52") {
                                                    frmMain.cmbGame.SelectedItem = "Imaginators Crystals"
            blnCrystal = True
            Select Case Fig
                Case "A902"
                    frmMain.lstCharacters.SelectedItem = "Water Crystal"
            End Select
        } else if (Var = "1554") {
                                                    frmMain.cmbGame.SelectedItem = "Imaginators"
            Select Case Fig
                Case "5B02"
                    frmMain.lstCharacters.SelectedItem = "Candy-Coated Chopscotch"
            End Select
        } else if (Var = "0254") {
                                                    frmMain.cmbGame.SelectedItem = "Imaginators"
            Select Case Fig
                Case "6502"
                    frmMain.lstCharacters.SelectedItem = "Dark Golden Queen"
                Case "5902"
                    frmMain.lstCharacters.SelectedItem = "Dark King Pen"
                Case "6602"
                    frmMain.lstCharacters.SelectedItem = "Dark Wolfgang"
                Case "6E02"
                    frmMain.lstCharacters.SelectedItem = "Mystical Bad Juju"
                Case "6402"
                    frmMain.lstCharacters.SelectedItem = "Mystical Tae Kwon Crow"
                Case "6B02"
                    frmMain.lstCharacters.SelectedItem = "Solar Flare Aurora"
                Case "6302"
                    frmMain.lstCharacters.SelectedItem = "Steel Plated Hood Sickle"
                Case "6602"
                    frmMain.lstCharacters.SelectedItem = "WolfGang Dark"
            End Select
        } else if (Var = "0D54") {
                                                    frmMain.cmbGame.SelectedItem = "Imaginators"
            Select Case Fig
                Case "5F02"
                    frmMain.lstCharacters.SelectedItem = "Egg Bomber Air Strike"
                Case "6C02"
                    frmMain.lstCharacters.SelectedItem = "Hard-Boiled Flarewolf"
            End Select
        } else if (Var = "0E54") {
                                                    frmMain.cmbGame.SelectedItem = "Imaginators"
            Select Case Fig
                Case "6D02"
                    frmMain.lstCharacters.SelectedItem = "Jingle Bell Chompy Mage"
            End Select
        Else
            MessageBox.Show("Error.  Figure not Recognized.")
            // MessageBox.Show(Fig)
        End If
        // Else frmMain.lstCharacters.SelectedIndex = -1
        // End If
                                                }
                                                static void GetFigureID_AlterEgo_Variant()
        Fig = WholeFile(0x10).ToString("X2") + WholeFile(0x11).ToString("X2")
        Var = WholeFile(0x1C).ToString("X2") + WholeFile(0x1D).ToString("X2")
        FigureItOut()
    }
                                            static void Figure()
        MessageBox.Show(Fig & " Figure " & Var & " Variant")
        // MessageBox.Show(Var & " Variant")
    }
# End Region

# Region " List Fill Methods "
                                        // Sorted Alphabetically
                                        static void SpyroAdventure()
        frmMain.lstCharacters.Items.Add("Bash")
        frmMain.lstCharacters.Items.Add("Boomer")
        frmMain.lstCharacters.Items.Add("Camo")
        frmMain.lstCharacters.Items.Add("Chop Chop")
        frmMain.lstCharacters.Items.Add("Cynder")
        frmMain.lstCharacters.Items.Add("Dark Spyro")
        frmMain.lstCharacters.Items.Add("Dino-Rang")
        frmMain.lstCharacters.Items.Add("Double Trouble")
        frmMain.lstCharacters.Items.Add("Drill Sergeant")
        frmMain.lstCharacters.Items.Add("Drobot")
        frmMain.lstCharacters.Items.Add("Eruptor")
        frmMain.lstCharacters.Items.Add("Flameslinger")
        frmMain.lstCharacters.Items.Add("Ghost Roaster")
        frmMain.lstCharacters.Items.Add("Gill Grunt")
        frmMain.lstCharacters.Items.Add("Hex")
        frmMain.lstCharacters.Items.Add("Ignitor")
        frmMain.lstCharacters.Items.Add("Legendary Bash")
        frmMain.lstCharacters.Items.Add("Legendary Chop Chop")
        frmMain.lstCharacters.Items.Add("Legendary Spyro")
        frmMain.lstCharacters.Items.Add("Legendary Trigger Happy")
        frmMain.lstCharacters.Items.Add("Lightning Rod")
        frmMain.lstCharacters.Items.Add("Prism Break")
        frmMain.lstCharacters.Items.Add("Slam Bam")
        frmMain.lstCharacters.Items.Add("Sonic Boom")
        frmMain.lstCharacters.Items.Add("Spyro")
        frmMain.lstCharacters.Items.Add("Stealth Elf")
        frmMain.lstCharacters.Items.Add("Stump Smash")
        frmMain.lstCharacters.Items.Add("Sunburn")
        frmMain.lstCharacters.Items.Add("Terrafin")
        frmMain.lstCharacters.Items.Add("Trigger Happy")
        frmMain.lstCharacters.Items.Add("Voodood")
        frmMain.lstCharacters.Items.Add("Warnado")
        frmMain.lstCharacters.Items.Add("Wham-Shell")
        frmMain.lstCharacters.Items.Add("Whirlwind")
        frmMain.lstCharacters.Items.Add("Wrecking Ball")
        frmMain.lstCharacters.Items.Add("Zap")
        frmMain.lstCharacters.Items.Add("Zook")
    }
                                    static void Giants()
        frmMain.lstCharacters.Items.Add("Bouncer")
        frmMain.lstCharacters.Items.Add("Chill")
        frmMain.lstCharacters.Items.Add("Crusher")
        frmMain.lstCharacters.Items.Add("Eye-Brawl")
        frmMain.lstCharacters.Items.Add("Flashwing")
        frmMain.lstCharacters.Items.Add("Fright Rider")
        frmMain.lstCharacters.Items.Add("Gnarly Tree Rex")
        frmMain.lstCharacters.Items.Add("Granite Crusher")
        frmMain.lstCharacters.Items.Add("Hot Dog")
        frmMain.lstCharacters.Items.Add("Hot Head")
        frmMain.lstCharacters.Items.Add("Jade Flashwing")
        frmMain.lstCharacters.Items.Add("Jet-Vac")
        frmMain.lstCharacters.Items.Add("Legendary Bouncer")
        frmMain.lstCharacters.Items.Add("Legendary Chill")
        frmMain.lstCharacters.Items.Add("Legendary Ignitor")
        frmMain.lstCharacters.Items.Add("Legendary Jet-Vac")
        frmMain.lstCharacters.Items.Add("Legendary Slam Bam")
        frmMain.lstCharacters.Items.Add("Legendary Stealth Elf")
        frmMain.lstCharacters.Items.Add("LightCore Chill")
        frmMain.lstCharacters.Items.Add("LightCore Drobot")
        frmMain.lstCharacters.Items.Add("LightCore Eruptor")
        frmMain.lstCharacters.Items.Add("LightCore Hex")
        frmMain.lstCharacters.Items.Add("LightCore Jet-Vac")
        frmMain.lstCharacters.Items.Add("LightCore Pop Fizz")
        frmMain.lstCharacters.Items.Add("LightCore Prism Break")
        frmMain.lstCharacters.Items.Add("LightCore Shroomboom")
        frmMain.lstCharacters.Items.Add("Molten Hot Dog")
        frmMain.lstCharacters.Items.Add("Ninjini")
        frmMain.lstCharacters.Items.Add("Polar Whirlwind")
        frmMain.lstCharacters.Items.Add("Pop Fizz")
        frmMain.lstCharacters.Items.Add("Punch Pop Fizz")
        frmMain.lstCharacters.Items.Add("Royal Double Trouble")
        frmMain.lstCharacters.Items.Add("Scarlet Ninjini")
        frmMain.lstCharacters.Items.Add("Series 2 Bash")
        frmMain.lstCharacters.Items.Add("Series 2 Chop Chop")
        frmMain.lstCharacters.Items.Add("Series 2 Cynder")
        frmMain.lstCharacters.Items.Add("Series 2 Double Trouble")
        frmMain.lstCharacters.Items.Add("Series 2 Drill Sergeant")
        frmMain.lstCharacters.Items.Add("Series 2 Drobot")
        frmMain.lstCharacters.Items.Add("Series 2 Eruptor")
        frmMain.lstCharacters.Items.Add("Series 2 Flameslinger")
        frmMain.lstCharacters.Items.Add("Series 2 Gill Grunt")
        frmMain.lstCharacters.Items.Add("Series 2 Hex")
        frmMain.lstCharacters.Items.Add("Series 2 Ignitor")
        frmMain.lstCharacters.Items.Add("Series 2 Lightning Rod")
        frmMain.lstCharacters.Items.Add("Series 2 Prism Break")
        frmMain.lstCharacters.Items.Add("Series 2 Slam Bam")
        frmMain.lstCharacters.Items.Add("Series 2 Sonic Boom")
        frmMain.lstCharacters.Items.Add("Series 2 Spyro")
        frmMain.lstCharacters.Items.Add("Series 2 Stealth Elf")
        frmMain.lstCharacters.Items.Add("Series 2 Stump Smash")
        frmMain.lstCharacters.Items.Add("Series 2 Terrafin")
        frmMain.lstCharacters.Items.Add("Series 2 Trigger Happy")
        frmMain.lstCharacters.Items.Add("Series 2 Whirlwind")
        frmMain.lstCharacters.Items.Add("Series 2 Wrecking Ball")
        frmMain.lstCharacters.Items.Add("Series 2 Zap")
        frmMain.lstCharacters.Items.Add("Series 2 Zook")
        frmMain.lstCharacters.Items.Add("Shroomboom")
        frmMain.lstCharacters.Items.Add("Sprocket")
        frmMain.lstCharacters.Items.Add("Swarm")
        frmMain.lstCharacters.Items.Add("Thumpback")
        frmMain.lstCharacters.Items.Add("Tree Rex")
    }
                                static void SwapForce()
        frmMain.lstCharacters.Items.Add("Anchors Away Gill Grunt")
        frmMain.lstCharacters.Items.Add("Boom Jet (Bottom)")
        frmMain.lstCharacters.Items.Add("Boom Jet (Top)")
        frmMain.lstCharacters.Items.Add("Big Bang Trigger Happy")
        frmMain.lstCharacters.Items.Add("Blast Zone (Bottom)")
        frmMain.lstCharacters.Items.Add("Blast Zone (Top)")
        frmMain.lstCharacters.Items.Add("Blizzard Chill")
        frmMain.lstCharacters.Items.Add("Bumble Blast")
        frmMain.lstCharacters.Items.Add("Countdown")
        frmMain.lstCharacters.Items.Add("Dark Blast Zone (Bottom)")
        frmMain.lstCharacters.Items.Add("Dark Blast Zone (Top)")
        frmMain.lstCharacters.Items.Add("Dark Mega Ram Spyro")
        frmMain.lstCharacters.Items.Add("Dark Slobber Tooth")
        frmMain.lstCharacters.Items.Add("Dark Stealth Elf")
        frmMain.lstCharacters.Items.Add("Dark Wash Buckler (Bottom)")
        frmMain.lstCharacters.Items.Add("Dark Wash Buckler (Top)")
        frmMain.lstCharacters.Items.Add("Doom Stone (Bottom)")
        frmMain.lstCharacters.Items.Add("Doom Stone (Top)")
        frmMain.lstCharacters.Items.Add("Dune Bug")
        frmMain.lstCharacters.Items.Add("Enchanted Hoot Loop (Bottom)")
        frmMain.lstCharacters.Items.Add("Enchanted Hoot Loop (Top)")
        frmMain.lstCharacters.Items.Add("Enchanted Star Strike")
        frmMain.lstCharacters.Items.Add("Fire Bone Hot Dog")
        frmMain.lstCharacters.Items.Add("Fire Kraken (Bottom)")
        frmMain.lstCharacters.Items.Add("Fire Kraken (Top)")
        frmMain.lstCharacters.Items.Add("Free Ranger (Bottom)")
        frmMain.lstCharacters.Items.Add("Free Ranger (Top)")
        frmMain.lstCharacters.Items.Add("Freeze Blade (Bottom)")
        frmMain.lstCharacters.Items.Add("Freeze Blade (Top)")
        frmMain.lstCharacters.Items.Add("Fryno")
        frmMain.lstCharacters.Items.Add("Grilla Drilla (Bottom)")
        frmMain.lstCharacters.Items.Add("Grilla Drilla (Top)")
        frmMain.lstCharacters.Items.Add("Grim Creeper")
        frmMain.lstCharacters.Items.Add("Heavy Duty Sprocket")
        frmMain.lstCharacters.Items.Add("Hoot Loop (Bottom)")
        frmMain.lstCharacters.Items.Add("Hoot Loop (Top)")
        frmMain.lstCharacters.Items.Add("Horn Blast Whirlwind")
        frmMain.lstCharacters.Items.Add("Hyper Beam Prism Break")
        frmMain.lstCharacters.Items.Add("Jade Fire Kraken (Bottom)")
        frmMain.lstCharacters.Items.Add("Jade Fire Kraken (Top)")
        frmMain.lstCharacters.Items.Add("Jolly Bumble Blast")
        frmMain.lstCharacters.Items.Add("Kickoff Countdown")
        frmMain.lstCharacters.Items.Add("Knockout Terrafin")
        frmMain.lstCharacters.Items.Add("Lava Barf Eruptor")
        frmMain.lstCharacters.Items.Add("Legendary Free Ranger (Bottom)")
        frmMain.lstCharacters.Items.Add("Legendary Free Ranger (Top)")
        frmMain.lstCharacters.Items.Add("Legendary Grim Creeper")
        frmMain.lstCharacters.Items.Add("Legendary Night Shift (Bottom)")
        frmMain.lstCharacters.Items.Add("Legendary Night Shift (Top)")
        frmMain.lstCharacters.Items.Add("Legendary Zoo Lou")
        frmMain.lstCharacters.Items.Add("LightCore Bumble Blast")
        frmMain.lstCharacters.Items.Add("LightCore Countdown")
        frmMain.lstCharacters.Items.Add("LightCore Flashwing")
        frmMain.lstCharacters.Items.Add("LightCore Grim Creeper")
        frmMain.lstCharacters.Items.Add("LightCore Smolderdash")
        frmMain.lstCharacters.Items.Add("LightCore Star Strike")
        frmMain.lstCharacters.Items.Add("LightCore Warnado")
        frmMain.lstCharacters.Items.Add("LightCore Wham-Shell")
        frmMain.lstCharacters.Items.Add("Magna Charge (Bottom)")
        frmMain.lstCharacters.Items.Add("Magna Charge (Top)")
        frmMain.lstCharacters.Items.Add("Mega Ram Spyro")
        frmMain.lstCharacters.Items.Add("Night Shift (Bottom)")
        frmMain.lstCharacters.Items.Add("Night Shift (Top)")
        frmMain.lstCharacters.Items.Add("Ninja Stealth Elf")
        frmMain.lstCharacters.Items.Add("Nitro Freeze Blade (Bottom)")
        frmMain.lstCharacters.Items.Add("Nitro Freeze Blade (Top)")
        frmMain.lstCharacters.Items.Add("Nitro Magna Charge (Bottom)")
        frmMain.lstCharacters.Items.Add("Nitro Magna Charge (Top)")
        frmMain.lstCharacters.Items.Add("Phantom Cynder")
        frmMain.lstCharacters.Items.Add("Pop Thorn")
        frmMain.lstCharacters.Items.Add("Punk Shock")
        frmMain.lstCharacters.Items.Add("Quickdraw Rattle Shake (Bottom)")
        frmMain.lstCharacters.Items.Add("Quickdraw Rattle Shake (Top)")
        frmMain.lstCharacters.Items.Add("Rattle Shake (Bottom)")
        frmMain.lstCharacters.Items.Add("Rattle Shake (Top)")
        frmMain.lstCharacters.Items.Add("Rip Tide")
        frmMain.lstCharacters.Items.Add("Roller Brawl")
        frmMain.lstCharacters.Items.Add("Rubble Rouser (Bottom)")
        frmMain.lstCharacters.Items.Add("Rubble Rouser (Top)")
        frmMain.lstCharacters.Items.Add("Scorp")
        frmMain.lstCharacters.Items.Add("Scratch")
        frmMain.lstCharacters.Items.Add("Slobber Tooth")
        frmMain.lstCharacters.Items.Add("Smolderdash")
        frmMain.lstCharacters.Items.Add("Springtime Trigger Happy")
        frmMain.lstCharacters.Items.Add("Spy Rise (Bottom)")
        frmMain.lstCharacters.Items.Add("Spy Rise (Top)")
        frmMain.lstCharacters.Items.Add("Star Strike")
        frmMain.lstCharacters.Items.Add("Stink Bomb (Bottom)")
        frmMain.lstCharacters.Items.Add("Stink Bomb (Top)")
        frmMain.lstCharacters.Items.Add("Super Gulp Pop Fizz")
        frmMain.lstCharacters.Items.Add("Thorn Horn Camo")
        frmMain.lstCharacters.Items.Add("Trap Shadow (Bottom)")
        frmMain.lstCharacters.Items.Add("Trap Shadow (Top)")
        frmMain.lstCharacters.Items.Add("Turbo Jet-Vac")
        frmMain.lstCharacters.Items.Add("Twin Blade Chop Chop")
        frmMain.lstCharacters.Items.Add("Volcanic Eruptor")
        frmMain.lstCharacters.Items.Add("Wash Buckler (Bottom)")
        frmMain.lstCharacters.Items.Add("Wash Buckler (Top)")
        frmMain.lstCharacters.Items.Add("Wind-Up")
        frmMain.lstCharacters.Items.Add("Zoo Lou")
    }
                            static void TrapTeam()
        frmMain.lstCharacters.Items.Add("Barkley")
        frmMain.lstCharacters.Items.Add("Bat Spin")
        frmMain.lstCharacters.Items.Add("Blackout")
        frmMain.lstCharacters.Items.Add("Blades")
        frmMain.lstCharacters.Items.Add("Blastermind")
        frmMain.lstCharacters.Items.Add("Bop")
        frmMain.lstCharacters.Items.Add("Breeze")
        frmMain.lstCharacters.Items.Add("Bushwhack")
        frmMain.lstCharacters.Items.Add("Chopper")
        frmMain.lstCharacters.Items.Add("Clear Thunderbolt")
        frmMain.lstCharacters.Items.Add("Cobra Cadabra")
        frmMain.lstCharacters.Items.Add("Dark Food Fight")
        frmMain.lstCharacters.Items.Add("Dark Snap Shot")
        frmMain.lstCharacters.Items.Add("Dark Wildfire")
        frmMain.lstCharacters.Items.Add("Drobit")
        frmMain.lstCharacters.Items.Add("Déjà Vu")
        frmMain.lstCharacters.Items.Add("Echo")
        frmMain.lstCharacters.Items.Add("Eggsellent Weeruptor")
        frmMain.lstCharacters.Items.Add("Elite Chop Chop")
        frmMain.lstCharacters.Items.Add("Elite Eruptor")
        frmMain.lstCharacters.Items.Add("Elite Gill Grunt")
        frmMain.lstCharacters.Items.Add("Elite Spyro")
        frmMain.lstCharacters.Items.Add("Elite Stealth Elf")
        frmMain.lstCharacters.Items.Add("Elite Terrafin")
        frmMain.lstCharacters.Items.Add("Elite Trigger Happy")
        frmMain.lstCharacters.Items.Add("Elite Whirlwind")
        frmMain.lstCharacters.Items.Add("Enigma")
        frmMain.lstCharacters.Items.Add("Eye-Small")
        frmMain.lstCharacters.Items.Add("Fist Bump")
        frmMain.lstCharacters.Items.Add("Fizzy Frenzy Pop Fizz")
        frmMain.lstCharacters.Items.Add("Fling Kong")
        frmMain.lstCharacters.Items.Add("Flip Wreck")
        frmMain.lstCharacters.Items.Add("Food Fight")
        frmMain.lstCharacters.Items.Add("Full Blast Jet-Vac")
        frmMain.lstCharacters.Items.Add("Funny Bone")
        frmMain.lstCharacters.Items.Add("Gearshift")
        frmMain.lstCharacters.Items.Add("Gill Runt")
        frmMain.lstCharacters.Items.Add("Gnarly Barkley")
        frmMain.lstCharacters.Items.Add("Gusto")
        frmMain.lstCharacters.Items.Add("Head Rush")
        frmMain.lstCharacters.Items.Add("High Five")
        frmMain.lstCharacters.Items.Add("Hijinx")
        frmMain.lstCharacters.Items.Add("Hog Wild Fryno")
        frmMain.lstCharacters.Items.Add("Instant Food Fight")
        frmMain.lstCharacters.Items.Add("Instant Snap Shot")
        frmMain.lstCharacters.Items.Add("Jawbreaker")
        frmMain.lstCharacters.Items.Add("Ka-Boom")
        frmMain.lstCharacters.Items.Add("King Cobra Cadabra")
        frmMain.lstCharacters.Items.Add("Knight Light")
        frmMain.lstCharacters.Items.Add("Knight Mare")
        frmMain.lstCharacters.Items.Add("Krypt King")
        frmMain.lstCharacters.Items.Add("Legendary Blades")
        frmMain.lstCharacters.Items.Add("Legendary Bushwhack")
        frmMain.lstCharacters.Items.Add("Legendary Déjà Vu")
        frmMain.lstCharacters.Items.Add("Legendary Jawbreaker")
        frmMain.lstCharacters.Items.Add("Lob-Star")
        frmMain.lstCharacters.Items.Add("Love Potion Pop Fizz")
        frmMain.lstCharacters.Items.Add("Mini-Jini")
        frmMain.lstCharacters.Items.Add("Nitro Head Rush")
        frmMain.lstCharacters.Items.Add("Nitro Krypt King")
        frmMain.lstCharacters.Items.Add("Pet-Vac")
        frmMain.lstCharacters.Items.Add("Power Punch Pet-Vac")
        frmMain.lstCharacters.Items.Add("Rocky Roll")
        frmMain.lstCharacters.Items.Add("Short Cut")
        frmMain.lstCharacters.Items.Add("Small Fry")
        frmMain.lstCharacters.Items.Add("Snap Shot")
        frmMain.lstCharacters.Items.Add("Spotlight")
        frmMain.lstCharacters.Items.Add("Spry")
        frmMain.lstCharacters.Items.Add("Sure Shot Shroomboom")
        frmMain.lstCharacters.Items.Add("Terrabite")
        frmMain.lstCharacters.Items.Add("Thumpling")
        frmMain.lstCharacters.Items.Add("Thunderbolt")
        frmMain.lstCharacters.Items.Add("Tidal Wave Gill Grunt")
        frmMain.lstCharacters.Items.Add("Torch")
        frmMain.lstCharacters.Items.Add("Trail Blazer")
        frmMain.lstCharacters.Items.Add("Tread Head")
        frmMain.lstCharacters.Items.Add("Trigger Snappy")
        frmMain.lstCharacters.Items.Add("Tuff Luck")
        frmMain.lstCharacters.Items.Add("Wallop")
        frmMain.lstCharacters.Items.Add("Weeruptor")
        frmMain.lstCharacters.Items.Add("Whisper Elf")
        frmMain.lstCharacters.Items.Add("Wildfire")
        frmMain.lstCharacters.Items.Add("Winterfest Lob-Star")
    }
                        static void SuperChargers()
        frmMain.lstCharacters.Items.Add("--Characters--")
        frmMain.lstCharacters.Items.Add("Astroblast")
        frmMain.lstCharacters.Items.Add("Big Bubble Pop Fizz")
        frmMain.lstCharacters.Items.Add("Birthday Bash Big Bubble Pop Fizz")
        frmMain.lstCharacters.Items.Add("Bone Bash Roller Brawl")
        frmMain.lstCharacters.Items.Add("Dark Hammer Slam Bowser")
        frmMain.lstCharacters.Items.Add("Dark Spitfire")
        frmMain.lstCharacters.Items.Add("Dark Super Shot Stealth Elf")
        frmMain.lstCharacters.Items.Add("Dark Turbo Charge Donkey Kong")
        frmMain.lstCharacters.Items.Add("Deep Dive Gill Grunt")
        frmMain.lstCharacters.Items.Add("Dive-Clops")
        frmMain.lstCharacters.Items.Add("Double Dare Trigger Happy")
        frmMain.lstCharacters.Items.Add("Eggcited Thrillipede")
        frmMain.lstCharacters.Items.Add("Elite Boomer")
        frmMain.lstCharacters.Items.Add("Elite Dino-Rang")
        frmMain.lstCharacters.Items.Add("Elite Ghost Roaster")
        frmMain.lstCharacters.Items.Add("Elite Slam Bam")
        frmMain.lstCharacters.Items.Add("Elite Voodood")
        frmMain.lstCharacters.Items.Add("Elite Zook")
        frmMain.lstCharacters.Items.Add("Fiesta")
        frmMain.lstCharacters.Items.Add("Frightful Fiesta")
        frmMain.lstCharacters.Items.Add("Hammer Slam Bowser")
        frmMain.lstCharacters.Items.Add("High Volt")
        frmMain.lstCharacters.Items.Add("Hurricane Jet-Vac")
        frmMain.lstCharacters.Items.Add("Lava Lance Eruptor")
        frmMain.lstCharacters.Items.Add("Legendary Astroblast")
        frmMain.lstCharacters.Items.Add("Legendary Bone Bash Roller Brawl")
        frmMain.lstCharacters.Items.Add("Legendary Hurricane Jet-Vac")
        frmMain.lstCharacters.Items.Add("Legendary Sun Runner")
        frmMain.lstCharacters.Items.Add("Missile-Tow Dive-Clops")
        frmMain.lstCharacters.Items.Add("Nightfall")
        frmMain.lstCharacters.Items.Add("Power Blue Splat")
        frmMain.lstCharacters.Items.Add("Power Blue Trigger Happy")
        frmMain.lstCharacters.Items.Add("Shark Shooter Terrafin")
        frmMain.lstCharacters.Items.Add("Smash Hit")
        frmMain.lstCharacters.Items.Add("Spitfire")
        frmMain.lstCharacters.Items.Add("Splat")
        frmMain.lstCharacters.Items.Add("Steel Plated Smash Hit")
        frmMain.lstCharacters.Items.Add("Stormblade")
        frmMain.lstCharacters.Items.Add("Super Shot Stealth Elf")
        frmMain.lstCharacters.Items.Add("Thrillipede")
        frmMain.lstCharacters.Items.Add("Turbo Charge Donkey Kong")

        // frmMain.lstCharacters.Items.Add("--Villain Vehicles--")
        // frmMain.lstCharacters.Items.Add("--Pandergast Vehicles--")
                        frmMain.lstCharacters.Items.Add("--Trophies--")
        frmMain.lstCharacters.Items.Add("Kaos Trophy")
        frmMain.lstCharacters.Items.Add("Land Trophy")
        frmMain.lstCharacters.Items.Add("Sea Trophy")
        frmMain.lstCharacters.Items.Add("Sky Trophy")
    }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                static void Imaginators()
        // Characters
        frmMain.lstCharacters.Items.Add("Air Strike")
        frmMain.lstCharacters.Items.Add("Ambush")
        frmMain.lstCharacters.Items.Add("Aurora")
        frmMain.lstCharacters.Items.Add("Bad Juju")
        frmMain.lstCharacters.Items.Add("Barbella")
        frmMain.lstCharacters.Items.Add("Blaster-Tron")
        frmMain.lstCharacters.Items.Add("Boom Bloom")
        frmMain.lstCharacters.Items.Add("Buckshot")
        frmMain.lstCharacters.Items.Add("Candy-Coated Chopscotch")
        frmMain.lstCharacters.Items.Add("Chain Reaction")
        frmMain.lstCharacters.Items.Add("Chompy Mage")
        frmMain.lstCharacters.Items.Add("Chopscotch")
        frmMain.lstCharacters.Items.Add("Clear Starcast")
        frmMain.lstCharacters.Items.Add("Crash Bandicoot")
        frmMain.lstCharacters.Items.Add("Dark Golden Queen")
        frmMain.lstCharacters.Items.Add("Dark King Pen")
        frmMain.lstCharacters.Items.Add("Dark Wolfgang")
        frmMain.lstCharacters.Items.Add("Dec-Ember")
        frmMain.lstCharacters.Items.Add("Dr. Krankcase")
        frmMain.lstCharacters.Items.Add("Dr. Neo Cortex")
        frmMain.lstCharacters.Items.Add("Egg Bomber Air Strike")
        frmMain.lstCharacters.Items.Add("Ember")
        frmMain.lstCharacters.Items.Add("Flarewolf")
        frmMain.lstCharacters.Items.Add("Golden Queen")
        frmMain.lstCharacters.Items.Add("Grave Clobber")
        frmMain.lstCharacters.Items.Add("Hard-Boiled Flarewolf")
        frmMain.lstCharacters.Items.Add("Heartbreaker Buckshot")
        frmMain.lstCharacters.Items.Add("Hood Sickle")
        frmMain.lstCharacters.Items.Add("Jingle Bell Chompy Mage")
        frmMain.lstCharacters.Items.Add("Kaos")
        frmMain.lstCharacters.Items.Add("King Pen")
        frmMain.lstCharacters.Items.Add("Legendary Pit Boss")
        frmMain.lstCharacters.Items.Add("Legendary Tri-Tip")
        frmMain.lstCharacters.Items.Add("Mystical Bad Juju")
        frmMain.lstCharacters.Items.Add("Mystical Tae Kwon Crow")
        frmMain.lstCharacters.Items.Add("Mysticat")
        frmMain.lstCharacters.Items.Add("Orange Chain Reaction")
        frmMain.lstCharacters.Items.Add("Pain-Yatta")
        frmMain.lstCharacters.Items.Add("Pink Barbella")
        frmMain.lstCharacters.Items.Add("Pit Boss")
        frmMain.lstCharacters.Items.Add("Ro-Bow")
        frmMain.lstCharacters.Items.Add("Rock Candy Pain-Yatta")
        frmMain.lstCharacters.Items.Add("Solar Flare Aurora")
        frmMain.lstCharacters.Items.Add("Starcast")
        frmMain.lstCharacters.Items.Add("Steel Plated Hood Sickle")
        frmMain.lstCharacters.Items.Add("Tae Kwon Crow")
        frmMain.lstCharacters.Items.Add("Tidepool")
        frmMain.lstCharacters.Items.Add("Tri-Tip")
        frmMain.lstCharacters.Items.Add("Wild Storm")
        frmMain.lstCharacters.Items.Add("Wolfgang")
    }

                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            static void Traps()
        frmMain.lstCharacters.Items.Add("--Air--")
        frmMain.lstCharacters.Items.Add("Breezy Bird (Toucan)")
        frmMain.lstCharacters.Items.Add("Cloudy Cobra (Snake)")
        frmMain.lstCharacters.Items.Add("Cyclone Sabre (Sword)")
        frmMain.lstCharacters.Items.Add("Drafty Decanter (Jughead)")
        frmMain.lstCharacters.Items.Add("Storm Warning (Screamer)")
        frmMain.lstCharacters.Items.Add("Tempest Timer (Hourglass)")
        frmMain.lstCharacters.Items.Add("--Dark--")
        frmMain.lstCharacters.Items.Add("Dark Dagger (Sword)")
        frmMain.lstCharacters.Items.Add("Ghastly Grimace (Handstand)")
        frmMain.lstCharacters.Items.Add("Shadow Spider (Spider)")
        frmMain.lstCharacters.Items.Add("--Earth--")
        frmMain.lstCharacters.Items.Add("Banded Boulder (Orb)")
        frmMain.lstCharacters.Items.Add("Dust of Time (Hourglass)")
        frmMain.lstCharacters.Items.Add("Rock Hawk (Toucan)")
        frmMain.lstCharacters.Items.Add("Rubble Trouble (Handstand)")
        frmMain.lstCharacters.Items.Add("Slag Hammer (Hammer)")
        frmMain.lstCharacters.Items.Add("Spinning Sandstorm (Totem)")
        frmMain.lstCharacters.Items.Add("--Fire--")
        frmMain.lstCharacters.Items.Add("Blazing Belch (Yawn)")
        frmMain.lstCharacters.Items.Add("Eternal Flame (Torch)")
        frmMain.lstCharacters.Items.Add("Fire Flower (Scepter)")
        frmMain.lstCharacters.Items.Add("Scorching Stopper (Screamer)")
        frmMain.lstCharacters.Items.Add("Searing Spinner (Totem)")
        frmMain.lstCharacters.Items.Add("Spark Spear (Captain// s Hat)")
        frmMain.lstCharacters.Items.Add("--Life--")
        frmMain.lstCharacters.Items.Add("Emerald Energy (Torch)")
        frmMain.lstCharacters.Items.Add("Jade Blade (Sword)")
        frmMain.lstCharacters.Items.Add("Oak Eagle (Toucan)")
        frmMain.lstCharacters.Items.Add("Seed Serpent (Snake)")
        frmMain.lstCharacters.Items.Add("Shrub Shrieker (Yawn)")
        frmMain.lstCharacters.Items.Add("Weed Whacker (Hammer)")
        frmMain.lstCharacters.Items.Add("--Light--")
        frmMain.lstCharacters.Items.Add("Beam Scream (Yawn)")
        frmMain.lstCharacters.Items.Add("Heavenly Hawk (Hawk)")
        frmMain.lstCharacters.Items.Add("Shining Ship (Rocket)")
        frmMain.lstCharacters.Items.Add("--Magic--")
        frmMain.lstCharacters.Items.Add("Arcane Hourglass (Hourglass)")
        frmMain.lstCharacters.Items.Add("Axe of Illusion (Axe)")
        frmMain.lstCharacters.Items.Add("Biter// s Bane (Log Holder)")
        frmMain.lstCharacters.Items.Add("Rune Rocket (Rocket)")
        frmMain.lstCharacters.Items.Add("Sorcerous Skull (Skull)")
        frmMain.lstCharacters.Items.Add("Spell Slapper (Totem)")
        frmMain.lstCharacters.Items.Add("--Tech--")
        frmMain.lstCharacters.Items.Add("Automatic Angel (Angel)")
        frmMain.lstCharacters.Items.Add("Factory Flower (Scepter)")
        frmMain.lstCharacters.Items.Add("Grabbing Gadget (Hand)")
        frmMain.lstCharacters.Items.Add("Makers Mana (Flying Helmet)")
        frmMain.lstCharacters.Items.Add("Tech Totem (Tiki)")
        frmMain.lstCharacters.Items.Add("Topsy Techy (Handstand)")
        frmMain.lstCharacters.Items.Add("--Undead--")
        frmMain.lstCharacters.Items.Add("Dream Piercer (Captain// s Hat)")
        frmMain.lstCharacters.Items.Add("Grim Gripper (Hand)")
        frmMain.lstCharacters.Items.Add("Haunted Hatchet (Axe)")
        frmMain.lstCharacters.Items.Add("Spectral Skull (Skull)")
        frmMain.lstCharacters.Items.Add("Spirit Sphere (Orb)")
        frmMain.lstCharacters.Items.Add("Spooky Snake (Snake)")
        frmMain.lstCharacters.Items.Add("Legendary Spirit Sphere (Orb)")
        frmMain.lstCharacters.Items.Add("Legendary Spectral Skull (Skull)")
        frmMain.lstCharacters.Items.Add("--Water--")
        frmMain.lstCharacters.Items.Add("Aqua Axe (Axe)")
        frmMain.lstCharacters.Items.Add("Flood Flask (Jughead)")
        frmMain.lstCharacters.Items.Add("Frost Helm (Flying Helmet)")
        frmMain.lstCharacters.Items.Add("Soaking Staff (Angel)")
        frmMain.lstCharacters.Items.Add("Tidal Tiki (Tiki)")
        frmMain.lstCharacters.Items.Add("Wet Walter (Log Holder)")
        frmMain.lstCharacters.Items.Add("Legendary Flood Flask (Jughead)")
        frmMain.lstCharacters.Items.Add("--Kaos--")
        frmMain.lstCharacters.Items.Add("The Kaos Trap")
        frmMain.lstCharacters.Items.Add("Ultimate Kaos Trap")
    }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        static void Vehicles()
        frmMain.lstCharacters.Items.Add("--Land Vehicles--")
        frmMain.lstCharacters.Items.Add("Barrel Blaster")
        frmMain.lstCharacters.Items.Add("Burn-Cycle")
        frmMain.lstCharacters.Items.Add("Crypt Crusher")
        frmMain.lstCharacters.Items.Add("Dark Barrel Blaster")
        frmMain.lstCharacters.Items.Add("Dark Hot Streak")
        frmMain.lstCharacters.Items.Add("E3 Hot Streak")
        frmMain.lstCharacters.Items.Add("Gold Rusher")
        frmMain.lstCharacters.Items.Add("Golden Hot Streak")
        frmMain.lstCharacters.Items.Add("Hot Streak")
        frmMain.lstCharacters.Items.Add("Power Blue Gold Rusher")
        frmMain.lstCharacters.Items.Add("Shark Tank")
        frmMain.lstCharacters.Items.Add("Shield Striker")
        frmMain.lstCharacters.Items.Add("Thump Truck")
        frmMain.lstCharacters.Items.Add("Tomb Buggy")

        frmMain.lstCharacters.Items.Add("--Sea Vehicles--")
        frmMain.lstCharacters.Items.Add("Dark Sea Shadow")
        frmMain.lstCharacters.Items.Add("Dive Bomber")
        frmMain.lstCharacters.Items.Add("Nitro Soda Skimmer")
        frmMain.lstCharacters.Items.Add("Power Blue Splatter Splasher")
        frmMain.lstCharacters.Items.Add("Reef Ripper")
        frmMain.lstCharacters.Items.Add("Sea Shadow")
        frmMain.lstCharacters.Items.Add("Soda Skimmer")
        frmMain.lstCharacters.Items.Add("Splatter Splasher")
        frmMain.lstCharacters.Items.Add("Spring Ahead Dive Bomber")

        frmMain.lstCharacters.Items.Add("--Sky Vehicles--")
        frmMain.lstCharacters.Items.Add("Buzz Wing")
        frmMain.lstCharacters.Items.Add("Clown Cruiser")
        frmMain.lstCharacters.Items.Add("Dark Clown Cruiser")
        frmMain.lstCharacters.Items.Add("Jet Stream")
        frmMain.lstCharacters.Items.Add("Nitro Stealth Stinger")
        frmMain.lstCharacters.Items.Add("Sky Slicer")
        frmMain.lstCharacters.Items.Add("Stealth Stinger")
        frmMain.lstCharacters.Items.Add("Sun Runner")
    }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    static void Crystals()
        // Apparently these Figures ARE Unique Variant but I have NO information on them.  :(
        frmMain.lstCharacters.Items.Add("Air Crystal")
        // frmMain.lstCharacters.Items.Add("Air Acorn")
        // frmMain.lstCharacters.Items.Add("Air Angel")
        // frmMain.lstCharacters.Items.Add("Air Lantern")
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    frmMain.lstCharacters.Items.Add("Dark Crystal")
        // frmMain.lstCharacters.Items.Add("Dark Pyramid")
        // frmMain.lstCharacters.Items.Add("Dark Reactor")
        // frmMain.lstCharacters.Items.Add("Dark Rune")
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    frmMain.lstCharacters.Items.Add("Earth Crystal")
        // frmMain.lstCharacters.Items.Add("Earth Armor")
        // frmMain.lstCharacters.Items.Add("Earth Rocket")
        // frmMain.lstCharacters.Items.Add("Earth Rune")
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    frmMain.lstCharacters.Items.Add("Fire Crystal")
        // frmMain.lstCharacters.Items.Add("Fire Acorn")
        // frmMain.lstCharacters.Items.Add("Fire Angel")
        // frmMain.lstCharacters.Items.Add("Fire Reactor")
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    frmMain.lstCharacters.Items.Add("Life Crystal")
        // frmMain.lstCharacters.Items.Add("Life Acorn")
        // frmMain.lstCharacters.Items.Add("Life Claw")
        // frmMain.lstCharacters.Items.Add("Life Rocket")
        // frmMain.lstCharacters.Items.Add("Life Rune")
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    frmMain.lstCharacters.Items.Add("Light Crystal")
        // frmMain.lstCharacters.Items.Add("Light Angel")
        // frmMain.lstCharacters.Items.Add("Light Fanged")
        // frmMain.lstCharacters.Items.Add("Light Rune")
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    frmMain.lstCharacters.Items.Add("Magic Crystal")
        // frmMain.lstCharacters.Items.Add("Magic Claw")
        // frmMain.lstCharacters.Items.Add("Magic Lantern")
        // frmMain.lstCharacters.Items.Add("Magic Pyramid")
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    frmMain.lstCharacters.Items.Add("Tech Crystal")
        // frmMain.lstCharacters.Items.Add("Tech Armor")
        // frmMain.lstCharacters.Items.Add("Tech Pyramid")
        // frmMain.lstCharacters.Items.Add("Tech Reactor")
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    frmMain.lstCharacters.Items.Add("Undead Crystal")
        // frmMain.lstCharacters.Items.Add("Undead Claw")
        // frmMain.lstCharacters.Items.Add("Undead Fanged")
        // frmMain.lstCharacters.Items.Add("Undead Lantern")
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    frmMain.lstCharacters.Items.Add("Water Crystal")
        // frmMain.lstCharacters.Items.Add("Water Armor")
        // frmMain.lstCharacters.Items.Add("Water Fanged")
        // frmMain.lstCharacters.Items.Add("Water Rocket")
        // frmMain.lstCharacters.Items.Add("Legendary Life Acorn")
        // frmMain.lstCharacters.Items.Add("Legendary Light Fanged")
        // frmMain.lstCharacters.Items.Add("Legendary Magic Lantern")
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                // These Items are mostly, universal.
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                // As such, not going to restrict them based on game.
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                static void Items()
        frmMain.lstCharacters.Items.Add("--Adventures--")
        frmMain.lstCharacters.Items.Add("Anvil Rain")
        frmMain.lstCharacters.Items.Add("Ghost Pirate Swords")
        frmMain.lstCharacters.Items.Add("Healing Elixir")
        frmMain.lstCharacters.Items.Add("Hidden Treasure")
        frmMain.lstCharacters.Items.Add("Sky-Iron Shield")
        frmMain.lstCharacters.Items.Add("Sparx the Dragonfly")
        frmMain.lstCharacters.Items.Add("Time Twister Hourglass")
        frmMain.lstCharacters.Items.Add("Winged Boots")
        frmMain.lstCharacters.Items.Add("--Giants--")
        frmMain.lstCharacters.Items.Add("Dragonfire Cannon")
        frmMain.lstCharacters.Items.Add("Scorpion Striker")
        frmMain.lstCharacters.Items.Add("Golden Dragonfire Cannon")
        frmMain.lstCharacters.Items.Add("Platinum Hidden Treasure")
        frmMain.lstCharacters.Items.Add("--Swap Force--")
        frmMain.lstCharacters.Items.Add("Arkeyan Crossbow")
        frmMain.lstCharacters.Items.Add("Battle Hammer")
        frmMain.lstCharacters.Items.Add("Fiery Forge")
        frmMain.lstCharacters.Items.Add("Groove Machine")
        frmMain.lstCharacters.Items.Add("Platinum Sheep")
        frmMain.lstCharacters.Items.Add("Sky Diamond")
        frmMain.lstCharacters.Items.Add("UFO Hat")
        frmMain.lstCharacters.Items.Add("--Trap Team--")
        frmMain.lstCharacters.Items.Add("Hand of Fate")
        frmMain.lstCharacters.Items.Add("Legendary Hand of Fate")
        frmMain.lstCharacters.Items.Add("Piggy Bank")
        frmMain.lstCharacters.Items.Add("Rocket Ram")
        frmMain.lstCharacters.Items.Add("Tiki Speaky")
        frmMain.lstCharacters.Items.Add("--SuperChargers--")
        frmMain.lstCharacters.Items.Add("Kaos Trophy")
        frmMain.lstCharacters.Items.Add("Land Trophy")
        frmMain.lstCharacters.Items.Add("Sea Trophy")
        frmMain.lstCharacters.Items.Add("Sky Trophy")
        // Chests
        frmMain.lstCharacters.Items.Add("--Imaginators--")
        frmMain.lstCharacters.Items.Add("Blue Imaginite Mystery Chest")
        frmMain.lstCharacters.Items.Add("Bronze Imaginite Mystery Chest")
        frmMain.lstCharacters.Items.Add("Gold Imaginite Mystery Chest")
        frmMain.lstCharacters.Items.Add("Silver Imaginite Mystery Chest")
    }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            static void AdventurePacks()
        // The Commented out Adventure Packs, are unlocked via figure not Item.
        frmMain.lstCharacters.Items.Add("--Adventures--")
        frmMain.lstCharacters.Items.Add("Darklight Crypt")
        frmMain.lstCharacters.Items.Add("Dragon// s Peak")
        frmMain.lstCharacters.Items.Add("Empire of Ice")
        frmMain.lstCharacters.Items.Add("Pirate Seas")
        frmMain.lstCharacters.Items.Add("Volcanic Vault")
        frmMain.lstCharacters.Items.Add("--Swap Force--")
        frmMain.lstCharacters.Items.Add("Fiery Forge")
        frmMain.lstCharacters.Items.Add("Sheep Wreck ==land")
        frmMain.lstCharacters.Items.Add("Tower of Time")
        frmMain.lstCharacters.Items.Add("--Trap Team--")
        frmMain.lstCharacters.Items.Add("Midnight Museum")
        frmMain.lstCharacters.Items.Add("Mirror of Mystery")
        frmMain.lstCharacters.Items.Add("Nightmare Express")
        frmMain.lstCharacters.Items.Add("Sunscraper Spire")
        frmMain.lstCharacters.Items.Add("--Imaginators--")
        // Obtained through Air Sensei Wild Storm
        // frmMain.lstCharacters.Items.Add("Cursed Tiki Temple")
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            frmMain.lstCharacters.Items.Add("Enchanted Elven Forest")
        frmMain.lstCharacters.Items.Add("Gryphon Park Observatory")
        // Obtained through Tech Sensei Ro-Bow
        // frmMain.lstCharacters.Items.Add("Lost Imaginite Mines")
        // Obtained through Crash or Cortex Figures.
        // frmMain.lstCharacters.Items.Add("Thumpin//  Wumpa ==lands")
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                }
