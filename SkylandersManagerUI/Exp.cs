using System;

namespace SkylandersManagerUI
{
    public class Exp
    {
		static void GetEXP()
		{
			// 00000-00999 is Level 1
			// 01000-02199 is Level 2
			// 02200-03799 is Level 3
			// 03800-05999 is Level 4
			// 06000-08999 is Level 5
			// 09000-12999 is Level 6
			// 13000-18199 is Level 7
			// 18200-24799 is Level 8
			// 24800-32999 is Level 9
			// 33000-42699 is Level 10
			// 42700-53899 is Level 11
			// 53900-66599 is Level 12
			// 66600-80799 is Level 13
			// 80800-96499 is Level 14
			// 96500-113699 is Level 15
			// 113700-132399 is Level 16
			// 132400-152599 is Level 17
			// 152600-174299 is Level 18
			// 174300-197499 is Level 19
			// 197500 is Level 20
			var EXPArea0 = new byte[4];
			ulong EXPArea0Value;
			ulong EXPArea0Offset113Value;
			var EXPArea1Offset113 = new byte[4];
			ulong EXPArea0Offset118Value;
			var EXPArea0Offset118 = new byte[4];
			var EXPArea1 = new byte[4];
			ulong EXPArea1Value;
			ulong EXPArea1Offset2D3Value;
			var EXPArea1Offset2D3 = new byte[4];
			ulong EXPArea1Offset2D8Value;
			var EXPArea1Offset2D8 = new byte[4];
			ulong TotalEXP;

			// Remember all values are offset 1C0
			var counter = 0;
			do
			{
				EXPArea0[counter] = WholeFile[0x80 + counter];
				counter += 1;
			} while (counter != 2);

			// EXPArea0(2) = 0
			// EXPArea0(3) = 0
			// UInt32 must be 4 bytes.
			EXPArea0Value = BitConverter.ToUInt32(EXPArea0, 0);

			counter = 0;
			do
			{
				EXPArea1Offset113[counter] = WholeFile[0x113 + counter];
				counter += 1;
			} while (counter != 2);
			// EXPArea1(2) = 0
			// EXPArea1(3) = 0
			EXPArea0Offset113Value = BitConverter.ToUInt32(EXPArea1Offset113, 0);

			counter = 0;
			do
			{
				EXPArea0Offset118[counter] = WholeFile[0x118 + counter];
				counter += 1;
			} while (counter != 3);

			// EXPArea1Offset2D3(2) = 0
			// EXPArea1Offset2D3(3) = 0
			EXPArea0Offset118Value = BitConverter.ToUInt32(EXPArea0Offset118, 0);

			// Area1
			counter = 0;
			do
			{
				EXPArea1[counter] = WholeFile[0x240 + counter];
				counter += 1;
			} while (counter != 2);

			// EXPArea1(2) = 0
			// EXPArea1(3) = 0
			EXPArea1Value = BitConverter.ToUInt32(EXPArea1, 0);

			counter = 0;
			do
			{
				EXPArea1Offset2D3[counter] = WholeFile[0x2D3 + counter];
				counter += 1;
			} while (counter != 2);

			// EXPArea1Offset2D3(2) = 0
			// EXPArea1Offset2D3(3) = 0
			EXPArea1Offset2D3Value = BitConverter.ToUInt32(EXPArea1Offset2D3, 0);

			counter = 0;
			do
			{
				EXPArea1Offset2D8[counter] = WholeFile[0x2D8 + counter];
				counter += 1;
			} while (counter != 3);

			// EXPArea1Offset2D8(3) = 0
			EXPArea1Offset2D8Value = BitConverter.ToUInt32(EXPArea1Offset2D8, 0);

			if (Area0 > Area1)
			{
				TotalEXP = EXPArea0Value + EXPArea0Offset113Value + EXPArea0Offset118Value;
			}
			else if (Area1 > Area0)
			{
				TotalEXP = EXPArea1Value + EXPArea1Offset2D3Value + EXPArea1Offset2D8Value;
			}
			else if (Area0 = Area1)
			{
				TotalEXP = EXPArea0Value + EXPArea0Offset113Value + EXPArea0Offset118Value;
			}

			switch (TotalEXP)
			{
				case <= 999:
					frmMain.numLevel.Value = 1;
					break;
				case <= 2199:
					frmMain.numLevel.Value = 2;
					break;
				case <= 3799:
					//  Is Level 3
					frmMain.numLevel.Value = 3;
					break;
				case <= 5999:
					//  Is Level 4
					frmMain.numLevel.Value = 4;
					break;
				case <= 8999:
					// Is Level 5
					frmMain.numLevel.Value = 5;
					break;
				case <= 12999:
					// Is Level 6
					frmMain.numLevel.Value = 6;
					break;
				case <= 18199:
					// Is Level 7
					frmMain.numLevel.Value = 7;
					break;
				case <= 24799:
					// Is Level 8
					frmMain.numLevel.Value = 8;
					break;
				case <= 32999:
					// Is Level 9
					frmMain.numLevel.Value = 9;
					break;
				case <= 42699:
					// Is Level 10
					frmMain.numLevel.Value = 10;
					break;
				case <= 53899:
					// Is Level 11
					frmMain.numLevel.Value = 11;
					break;
				case <= 66599:
					// Is Level 12
					frmMain.numLevel.Value = 12;
					break;
				case <= 80799:
					// Is Level 13
					frmMain.numLevel.Value = 13;
					break;
				case <= 96499:
					// Is Level 14
					frmMain.numLevel.Value = 14;
					break;
				case <= 113699:
					// Is Level 15
					frmMain.numLevel.Value = 15;
					break;
				case <= 132399:
					// Is Level 16
					frmMain.numLevel.Value = 16;
					break;
				case <= 152599:
					// Is Level 17
					frmMain.numLevel.Value = 17;
					break;
				case <= 174299:
					// Is Level 18
					frmMain.numLevel.Value = 18;
					break;
				case <= 197499:
					// Is Level 19
					frmMain.numLevel.Value = 19;
					break;
				case 197500:
					// Is Level 20
					frmMain.numLevel.Value = 20;
					break;
			}
			// MessageBox.Show(TotalEXP)
		}
		static void WriteEXP()
		{
			// We need to setup THREE Byte arrays
			var EXP1 = new byte[2]; // Correct
			var EXP2 = new byte[2]; // Correct
			var EXP3 = new byte[3];// The third EXP Offset is Three Bytes in size.

			// For Fun, we could in theory write a random value between the two min/max
			switch (frmMain.numLevel.Value)
			{
				case 1:
					// 00000-00999 is Level 1
					EXP1 = BitConverter.GetBytes(0);
					EXP2 = BitConverter.GetBytes(0);
					EXP3 = BitConverter.GetBytes(0);
					break;
				case 2:
					// 01000-02199 is Level 2
					EXP1 = BitConverter.GetBytes(1000);
					EXP2 = BitConverter.GetBytes(0);
					EXP3 = BitConverter.GetBytes(0);
					break;
				case 3:
					// 02200-03799 is Level 3
					EXP1 = BitConverter.GetBytes(2200);
					EXP2 = BitConverter.GetBytes(0);
					EXP3 = BitConverter.GetBytes(0);
					break;
				case 4:
					// 03800-05999 is Level 4
					EXP1 = BitConverter.GetBytes(3800);
					EXP2 = BitConverter.GetBytes(0);
					EXP3 = BitConverter.GetBytes(0);
					break;
				case 5:
					// 06000-08999 is Level 5
					EXP1 = BitConverter.GetBytes(6000);
					EXP2 = BitConverter.GetBytes(0);
					EXP3 = BitConverter.GetBytes(0);
					break;
				case 6:
					// 09000-12999 is Level 6
					EXP1 = BitConverter.GetBytes(9000);
					EXP2 = BitConverter.GetBytes(0);
					EXP3 = BitConverter.GetBytes(0);
					break;
				case 7:
					// 13000-18199 is Level 7
					EXP1 = BitConverter.GetBytes(13000);
					EXP2 = BitConverter.GetBytes(0);
					EXP3 = BitConverter.GetBytes(0);
					break;
				case 8:
					// 18200-24799 is Level 8
					EXP1 = BitConverter.GetBytes(18200);
					EXP2 = BitConverter.GetBytes(0);
					EXP3 = BitConverter.GetBytes(0);
					break;
				case 9:
					// 24800-32999 is Level 9
					EXP1 = BitConverter.GetBytes(24800);
					EXP2 = BitConverter.GetBytes(0);
					EXP3 = BitConverter.GetBytes(0);
					break;
				case 10:
					// 33000-42699 is Level 10
					EXP1 = BitConverter.GetBytes(33000);
					EXP2 = BitConverter.GetBytes(0);
					EXP3 = BitConverter.GetBytes(0);
					break;
				case 11:
					// 42700-53899 is Level 11
					EXP1 = BitConverter.GetBytes(33000);
					EXP2 = BitConverter.GetBytes(9700);
					EXP3 = BitConverter.GetBytes(0);
					break;
				case 12:
					// 53900-66599 is Level 12
					EXP1 = BitConverter.GetBytes(33000);
					EXP2 = BitConverter.GetBytes(20900);
					EXP3 = BitConverter.GetBytes(0);
					break;
				case 13:
					// 66600-80799 is Level 13
					EXP1 = BitConverter.GetBytes(33000);
					EXP2 = BitConverter.GetBytes(33000);
					EXP3 = BitConverter.GetBytes(0);
					break;
				case 14:
					// 80800-96499 is Level 14
					EXP1 = BitConverter.GetBytes(33000);
					EXP2 = BitConverter.GetBytes(47800);
					EXP3 = BitConverter.GetBytes(0);
					break;
				case 15:
					// 96500-113699 is Level 15
					EXP1 = BitConverter.GetBytes(33000);
					EXP2 = BitConverter.GetBytes(63500);
					EXP3 = BitConverter.GetBytes(0);
					break;
				case 16:
					// 113700-132399 is Level 16
					EXP1 = BitConverter.GetBytes(33000);
					EXP2 = BitConverter.GetBytes(63500);
					EXP3 = BitConverter.GetBytes(17200);
					break;
				case 17:
					// 132400-152599 is Level 17
					EXP1 = BitConverter.GetBytes(33000);
					EXP2 = BitConverter.GetBytes(63500);
					EXP3 = BitConverter.GetBytes(35900);
					break;
				case 18:
					// 152600-174299 is Level 18
					EXP1 = BitConverter.GetBytes(33000);
					EXP2 = BitConverter.GetBytes(63500);
					EXP3 = BitConverter.GetBytes(56100);
					break;
				case 19:
					// 174300-197499 is Level 19
					EXP1 = BitConverter.GetBytes(33000);
					EXP2 = BitConverter.GetBytes(63500);
					EXP3 = BitConverter.GetBytes(77800);
					break;
				case 20:
					// 197500 is Level 20
					EXP1 = BitConverter.GetBytes(33000);
					EXP2 = BitConverter.GetBytes(63500);
					EXP3 = BitConverter.GetBytes(101000);
					break;
			}

			// Expermential Edit.  Should pass future checks?
			// Area 0 Exp
			// Exit Sub
			WholeFile[0x80] = EXP1[0];
			WholeFile[0x81] = EXP1[1];

			if (frmMain.numLevel.Value > 10)
			{
				WholeFile[0x113] = EXP2[0];
				WholeFile[0x114] = EXP2[1];

				if (frmMain.numLevel.Value > 15)
				{
					WholeFile[0x118] = EXP3[0];
					WholeFile[0x119] = EXP3[1];
					WholeFile[0x11A] = EXP3[2];
					// MessageBox.Show("Area0")
				}
			}
			else
			{
				WholeFile[0x113] = 0x0;
				WholeFile[0x114] = 0x0;
				WholeFile[0x118] = 0x0;
				WholeFile[0x119] = 0x0;
				WholeFile[0x11A] = 0x0;
			}

			// MessageBox.Show("EXP0: " & EXP1 + EXP2 + EXP3
			// MessageBox.Show("EXP1: " & EXPArea1Value + EXPArea1Offset2D3Value + EXPArea1Offset2D8Value)
			// Area 1 EXP
			WholeFile[0x240] = EXP1[0];

			WholeFile[0x241] = EXP1[1];

			if (frmMain.numLevel.Value > 10)
			{
				WholeFile[0x2D3] = EXP2[0];
				WholeFile[0x2D4] = EXP2[1];

				if (frmMain.numLevel.Value > 15)
				{
					WholeFile[0x2D8] = EXP3[0];
					WholeFile[0x2D9] = EXP3[1];
					WholeFile[0x2DA] = EXP3[2];
				}
			}
			else
			{
				WholeFile[0x2D3] = 0x0;
				WholeFile[0x2D4] = 0x0;
				WholeFile[0x2D8] = 0x0;
				WholeFile[0x2D9] = 0x0;
				WholeFile[0x2DA] = 0x0;
			}
			// If Area0 > Area1 Then

			// ElseIf Area1 > Area0 Then

			// ElseIf Area0 = Area1 Then

			// End If
		}
	}
}
