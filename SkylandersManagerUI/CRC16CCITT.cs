using System;

namespace SkylandersManagerUI
{
	public class CRC16CCITT
	{

		// Our Checksum that will be generated.

		public byte[] Bytes;
		public static int Counter = 0;

		public static string Area0TypeTrapCRC;
		public static string Area1TypeTrapCRC;

		public static string Area0Type4CRC;
		public static string Area1Type4CRC;

		public static string Area0Type3CRC;
		public static string Area1Type3CRC;

		public static string Area0Type2CRC;
		public static string Area1Type2CRC;

		public static string Area0Type1CRC;
		public static string Area1Type1CRC;

		public static string Area0Type0CRC;

		// Type 0 Checksum is all the bytes from 0x000 to 0x01D.
		// Type 1 Checksum is The Bytes from 0x080 to 0x08F, with the Bytes 0x08E and 0x08F being set to 05 and 00 respectively.
		// Type 2 Checksum is The NEXT Four Blocks (Though we are only reading three of them), Excluding the Block 0x0B if we are going from Offset 0x08 and block 0x270 if we are going from Block 0x240.
		// Type 3 Checksum is Like Type 2, but add 14 BLOCKS of Zero at the end of the Array.
		// Type 4 Checksum is The NEXT Four Blocks, after Type 2's Block.It is like Type 2 except that the Inital Two bytes must be set to 06 and 01 respectively.

		// Traps and Crystals use their own Unique things.  Because of course they do.
		// Yes, Type 3 and Type 2 must be done first before we can do Type 1

		public static string GetCrc()
		{
			var crc = 0xFFFF; // Starting value 
			int Polynom = 0x1021; // As in X^16 + X^12 + X^5 + 1 

			bool bit;
			bool c15;
			int i;

			// Calculate the CRC: 
			foreach (var b in bytes)
			{
				for (i = 0; i != 7; i++)
				{
					bit = ((b >> (7 - i) && 1)); // = 1) 
					c15 = ((crc >> 15 && 1)); // = 1) 
					crc <<= 1;

					if (c15 ^ bit)
					{
						crc = CRC16CCITT ^ Polynom;
					}
				}
			}

			foreach (var b in bytes)
			{
				for (i = 0; i != 7; i++)
				{
					bit = ((b >> (7 - i) && 1)); // = 1) 
					c15 = ((crc >> 15 && 1)); // = 1) 
					crc <<= 1;
					if (c15 ^ bit)
					{
						crc = crc ^ Polynom;
					}
				}
			}


			crc = crc && &HFFFF;

			//  De crc-variable is a decimal value. We return a Hex-value, so we need to convert this to hex. 
			//  The 16 in the Convert-method means the Hex-base. 
			var retVal = Convert.ToString(crc, 16);

			if (retVal.Length != 4) {
				do
				{
					retVal = "0" & retVal;

				} while (retVal.Length != 4);
			}
			// MessageBox.Show(retVal)
			return retVal;
		}

		static void WriteCheckSums()
		{
			var NewChecksumType0 = new byte[2];
			var NewChecksumArea0Type1 = new byte[2];
			var NewChecksumArea0Type2 = new byte[2];
			var NewChecksumArea0Type3 = new byte[2];
			var NewChecksumArea0Type4 = new byte[2];

			var NewChecksumArea1Type1 = new byte[2];
			var NewChecksumArea1Type2 = new byte[2];
			var NewChecksumArea1Type3 = new byte[2];
			var NewChecksumArea1Type4 = new byte[2];

			// Since we are getting back a String value, I use the Function to convert that String back to a Byte Array.
			// Type 0
			CalculateSerialXOR();

			NewChecksumType0 = AES.StringToByteArray(CalculateType0);

			if (!blnTrap)
			{
				// Type 3
				NewChecksumArea0Type3 = AES.StringToByteArray(CalculateArea0Type3);
				NewChecksumArea1Type3 = AES.StringToByteArray(CalculateArea1Type3);

				// Type 3
				WholeFile[0x8A] = NewChecksumArea0Type3[0];
				WholeFile[0x8B] = NewChecksumArea0Type3[1];

				WholeFile[0x24A] = NewChecksumArea1Type3[0];
				WholeFile[0x24B] = NewChecksumArea1Type3[1];
			}

			if (blnTrap)
			{
				NewChecksumArea0Type3 = AES.StringToByteArray(CalculateArea0TypeTrap);
				NewChecksumArea1Type3 = AES.StringToByteArray(CalculateArea1TypeTrap);

				WholeFile(0x8A) = NewChecksumArea0Type3[0];
				WholeFile(0x8B) = NewChecksumArea0Type3[1];

				WholeFile(0x24A) = NewChecksumArea1Type3[0];
				WholeFile(0x24B) = NewChecksumArea1Type3[1];
			}

			// Type 2
			NewChecksumArea0Type2 = AES.StringToByteArray(CalculateArea0Type2);
			NewChecksumArea1Type2 = AES.StringToByteArray(CalculateArea1Type2);

			if (!blnTrap)
			{
				// Type 4
				NewChecksumArea0Type4 = AES.StringToByteArray(CalculateArea0Type4);
				NewChecksumArea1Type4 = AES.StringToByteArray(CalculateArea1Type4);
				// Type 4
				WholeFile(&H110) = NewChecksumArea0Type4(0);
				WholeFile(&H111) = NewChecksumArea0Type4(1);



				WholeFile(&H2D0) = NewChecksumArea1Type4(0);
				WholeFile(&H2D1) = NewChecksumArea1Type4(1);
			}
			// Don't do anything related to Type 4 if we are working with a Trap.
			// It will mangle/break the Third Villian in the Trap.
		}

		// We Seek after we Generate the Checksum to set our position
		// We do this because we have been ALL over this file.

		// Type 0
		WholeFile(&H1E) = NewChecksumType0(0);
		WholeFile(&H1F) = NewChecksumType0(1);

		// Type 2
		WholeFile(&H8C) = NewChecksumArea0Type2(0);
		WholeFile(&H8D) = NewChecksumArea0Type2(1);

		WholeFile(&H24C) = NewChecksumArea1Type2(0);
		WholeFile(&H24D) = NewChecksumArea1Type2(1);



		// We calculate Type 1 last because of it's reliance on the other checksums
		// Type 1
		NewChecksumArea0Type1 = AES.StringToByteArray(CalculateArea0Type1);
		NewChecksumArea1Type1 = AES.StringToByteArray(CalculateArea1Type1);

		WholeFile(&H8E) = NewChecksumArea0Type1(0);
		WholeFile(&H8F) = NewChecksumArea0Type1(1);

		WholeFile(&H24E) = NewChecksumArea1Type1(0);

		WholeFile(&H24F) = NewChecksumArea1Type1(1);
	}

	static void Checksums()
	{
		// Get Type 0 Checksum
		VerifyArea0Type0();

		VerifySerialXOR();
		// Get Type 3 Checksum
		VerifyArea0Type3();
		VerifyArea1Type3();

		// Get Type 2 Checksum
		VerifyArea0Type2();
		VerifyArea1Type2();

		// Get Type 1 Checksum
		VerifyArea0Type1();
		VerifyArea1Type1();

		// Get Type 4 Checksum
		VerifyArea0Type4();
		VerifyArea1Type4();
	}

	// #Region "Traps"
	// These may be wrong.
	public static string CalculateArea0TypeTrap()
	{
		// Trap CRC is Special
		Counter = 0;
		int LoopCounter = 0;
		// We ReDim to Resize the Byte Array
		// Is this offsize?
		Array.Resize(Bytes, 34);

		do
		{
			Bytes(counter) = Buffer.GetByte(WholeFile, 0x8D + LoopCounter);
			// Save As
			Counter += 1;
			LoopCounter += 1;
		} while (LoopCounter != 32);

		// Skipping the MiFare Block and getting the last two Bytes
		var TwoByte = 0;
		do
		{
			Bytes(Counter) = Buffer.GetByte(WholeFile, 0xC0 + TwoByte);
			Counter += 1;
			LoopCounter += 1;
			TwoByte += 1;

		} while (LoopCounter != 34);


		Area0TypeTrapCRC = GetCrc().ToUpper();

		return Area0TypeTrapCRC;
	}


	public static string CalculateArea1TypeTrap()
	{
		// Trap CRC is Special
		Counter = 0;
		var LoopCounter = 0;
		// We ReDim to Resize the Byte Array
		// Is this offsize?
		Array.Resize(Bytes, 34);

		do
		{
			Bytes(Counter) = Buffer.GetByte(WholeFile, 0x24D + LoopCounter);
			// Save As
			Counter += 1;
			LoopCounter += 1;
		} while (LoopCounter != 32);

		// Skipping the MiFare Block and getting the last two Bytes
		var TwoByte = 0;

		do
		{
			Bytes(Counter) = Buffer.GetByte(WholeFile, 0x280 + TwoByte);
			Counter += 1;
			LoopCounter += 1;
			TwoByte += 1;
		} while (LoopCounter != 34);

		Area1TypeTrapCRC = GetCrc().ToUpper();
		return Area1TypeTrapCRC;
	}



# end region 
	#region "Type 4"
	public static string CalculateArea0Type4()
	{
		'Generate Type 1 Checksum
		Counter = 0
		Dim LoopCounter As Integer = 0
		'We ReDim to resize our Bytes Array
		ReDim Bytes(63)
		Do Until LoopCounter = 32
			Bytes(Counter) = Buffer.GetByte(WholeFile, &H110 + LoopCounter)

			Counter += 1
			LoopCounter += 1
		Loop
		'MessageBox.Show(Hex(Bytes(31)))
		LoopCounter = 0
		Do Until LoopCounter = 32
			Bytes(Counter) = Buffer.GetByte(WholeFile, &H140 + LoopCounter)
			Counter += 1
			LoopCounter += 1
		Loop
		'MessageBox.Show(Hex(Bytes(63)))
		'We manually set these two bytes
		Bytes(0) = &H6
		Bytes(1) = &H1
		'Get CRC based on the bytes.
		Area0Type4CRC = GetCrc().ToUpper
		Area0Type4CRC = Area0Type4CRC.Remove(0, 2) & Area0Type4CRC.Remove(2, 2)
		'Give back our Checksum
		Return Area0Type4CRC
	End Function

	Public Shared Function VerifyArea0Type4()
		Dim OldCheckSum As String
		OldCheckSum = WholeFile(&H110).ToString("X2") & WholeFile(&H111).ToString("X2")
		'Now I need to get the Checksum
		If OldCheckSum<> CalculateArea0Type4() Then
			frmMain.picArea0Type4.BackColor = Color.Red
		Else
			frmMain.picArea0Type4.BackColor = Color.Green
		End If
		Return "";
	}

	public static string CalculateArea1Type4()
	{
		'Generate Type 1 Checksum
		Counter = 0
		Dim LoopCounter As Integer = 0
		'We ReDim to resize our Bytes Array
		ReDim Bytes(63)
		Do Until LoopCounter = 32
			Bytes(Counter) = Buffer.GetByte(WholeFile, &H2D0 + LoopCounter)
			Counter += 1
			LoopCounter += 1
		Loop

		LoopCounter = 0
		Do Until LoopCounter = 32
			Bytes(Counter) = Buffer.GetByte(WholeFile, &H300 + LoopCounter)
			Counter += 1
			LoopCounter += 1
		Loop
		'We manually set these two bytes
		Bytes(0) = &H6
		Bytes(1) = &H1
		'Get CRC based on the bytes.
		Area1Type4CRC = GetCrc().ToUpper
		Area1Type4CRC = Area1Type4CRC.Remove(0, 2) & Area1Type4CRC.Remove(2, 2)
		'Give back our Checksum
		Return Area1Type4CRC
	}

	public static string VerifyArea1Type4()
	{
		string OldCheckSum = WholeFile(&H2D0).ToString("X2") & WholeFile(&H2D1).ToString("X2");
		// Now I need to get the Checksum
		if (OldCheckSum <> CalculateArea1Type4())
		{
			frmMain.picArea1Type4.BackColor = Color.Red;
		}
		else
		{
			frmMain.picArea1Type4.BackColor = Color.Green;
		}
		Return "";
	}
# End Region

	#region "Type 3"
	public static string CalculateArea0Type3()
	{
		'Generate Type 1 Checksum
		Counter = 0
		Dim LoopCounter As Integer = 0
		'We ReDim to resize our Bytes Array
		ReDim Bytes(271)
		Do Until LoopCounter = 32
			Bytes(Counter) = Buffer.GetByte(WholeFile, &HD0 + LoopCounter)

			Counter += 1
			LoopCounter += 1
		Loop
		LoopCounter = 0
		Do Until LoopCounter = 16
			Bytes(Counter) = Buffer.GetByte(WholeFile, &H100 + LoopCounter)
			Counter += 1
			LoopCounter += 1
		Loop
		'Get CRC based on the bytes.
		Area0Type3CRC = GetCrc().ToUpper
		Area0Type3CRC = Area0Type3CRC.Remove(0, 2) & Area0Type3CRC.Remove(2, 2)
		'Give back our Checksum
		return Area0Type3CRC;
	}

	public static string Function VerifyArea0Type3()
	{
		var OldCheckSum = WholeFile(0x8A).ToString("X2") & WholeFile(0x8B).ToString("X2");
		// Now I need to get the Checksum
		If OldCheckSum<> CalculateArea0Type3() Then
			'MessageBox.Show(OldCheckSum & " is Not " & CalculateArea0Type3())
			frmMain.picArea0Type3.BackColor = Color.Red
		Else
			frmMain.picArea0Type3.BackColor = Color.Green
		End If
		Return "";
	}

	public static string CalculateArea1Type3()
	{
		'Generate Type 1 Checksum
		Counter = 0
		Dim LoopCounter As Integer = 0
		'We ReDim to resize our Bytes Array
		ReDim Bytes(271)
		Do Until LoopCounter = 32
			Bytes(Counter) = Buffer.GetByte(WholeFile, &H290 + LoopCounter)

			Counter += 1
			LoopCounter += 1
		Loop
		LoopCounter = 0
		Do Until LoopCounter = 16
			Bytes(Counter) = Buffer.GetByte(WholeFile, &H2C0 + LoopCounter)
			Counter += 1
			LoopCounter += 1
		Loop
		'Get CRC based on the bytes.
		Area1Type3CRC = GetCrc().ToUpper
		Area1Type3CRC = Area1Type3CRC.Remove(0, 2) & Area1Type3CRC.Remove(2, 2)
		'Give back our Checksum
		Return Area1Type3CRC;
	}

	public static Function VerifyArea1Type3()
	{
		var OldCheckSum = WholeFile(&H24A).ToString("X2") & WholeFile(&H24B).ToString("X2");
		// Now I need to get the Checksum
		if (OldCheckSum != CalculateArea1Type3())
		{
			// MessageBox.Show(OldCheckSum & " is Not " & CalculateArea1Type3())
			frmMain.picArea1Type3.BackColor = Color.Red;
		}
		else 
		{
			frmMain.picArea1Type3.BackColor = Color.Green;
		}
		Return "";
	}
# End Region

	#region "Type 2"
	public static CalculateArea0Type2()
	{
		// Generate Type 1 Checksum
		Counter = 0;
		var LoopCounter = 0;
		// We ReDim to resize our Bytes Array
		Array.Resize( Bytes, 48 );



		Do Until LoopCounter = 32
			Bytes(Counter) = Buffer.GetByte(WholeFile, &H90 + LoopCounter)
			Counter += 1
			LoopCounter += 1
		Loop
		LoopCounter = 0
		Do Until LoopCounter = 16
			Bytes(Counter) = Buffer.GetByte(WholeFile, &HC0 + LoopCounter)
			Counter += 1
			LoopCounter += 1
		Loop
		// Get CRC based on the bytes.
		Area0Type2CRC = GetCrc().ToUpper
		Area0Type2CRC = Area0Type2CRC.Remove(0, 2) & Area0Type2CRC.Remove(2, 2)
		//Give back our Checksum
		Return Area0Type2CRC
	}

	Public Shared Function VerifyArea0Type2()
		Dim OldCheckSum As String
		OldCheckSum = WholeFile(&H8C).ToString("X2") & WholeFile(&H8D).ToString("X2")
		'Now I need to get the Checksum
		If OldCheckSum<> CalculateArea0Type2() Then
			'MessageBox.Show(OldCheckSum & " is Not " & CalculateArea0Type2())
			frmMain.picArea0Type2.BackColor = Color.Red
		Else
			frmMain.picArea0Type2.BackColor = Color.Green
		End If
		Return ""
	End Function

	Public Shared Function CalculateArea1Type2() As String
		'Generate Type 1 Checksum
		Counter = 0
		Dim LoopCounter As Integer = 0
		'We ReDim to resize our Bytes Array
		ReDim Bytes(47)
		Do Until LoopCounter = 32
			Bytes(Counter) = Buffer.GetByte(WholeFile, &H250 + LoopCounter)

			Counter += 1
			LoopCounter += 1
		Loop
		LoopCounter = 0
		Do Until LoopCounter = 16
			Bytes(Counter) = Buffer.GetByte(WholeFile, &H280 + LoopCounter)
			Counter += 1
			LoopCounter += 1
		Loop
		'Get CRC based on the bytes.
		Area1Type2CRC = GetCrc().ToUpper
		Area1Type2CRC = Area1Type2CRC.Remove(0, 2) & Area1Type2CRC.Remove(2, 2)
		'Give back our Checksum
		Return Area1Type2CRC
	End Function

	Public Shared Function VerifyArea1Type2()
		Dim OldCheckSum As String
		OldCheckSum = WholeFile(&H24C).ToString("X2") & WholeFile(&H24D).ToString("X2")
		'Now I need to get the Checksum
		If OldCheckSum<> CalculateArea1Type2() Then
			'MessageBox.Show(OldCheckSum & " is Not " & CalculateArea1Type2())
			frmMain.picArea1Type2.BackColor = Color.Red
		Else
			frmMain.picArea1Type2.BackColor = Color.Green
		End If
		Return ""
	End Function
#End Region

#Region " Type 1 "
	Public Shared Function CalculateArea0Type1() As String
		'Generate Type 1 Checksum
		Counter = 0
		'We ReDim to resize our Bytes Array
		ReDim Bytes(15)
		Do Until Counter = 15
			Bytes(Counter) = Buffer.GetByte(WholeFile, &H80 + Counter)
			Counter += 1
		Loop
		'We manually set these two bytes
		Bytes(14) = &H5
		Bytes(15) = &H0
		'Get CRC based on the bytes.
		Area0Type1CRC = GetCrc().ToUpper
		Area0Type1CRC = Area0Type1CRC.Remove(0, 2) & Area0Type1CRC.Remove(2, 2)
		'Give back our Checksum
		Return Area0Type1CRC
	End Function

	Public Shared Function VerifyArea0Type1()
		Dim OldCheckSum As String
		OldCheckSum = WholeFile(&H8E).ToString("X2") & WholeFile(&H8F).ToString("X2")
		'Now I need to get the Checksum
		If OldCheckSum<> CalculateArea0Type1() Then
			frmMain.picArea0Type1.BackColor = Color.Red
		Else
			frmMain.picArea0Type1.BackColor = Color.Green
		End If
		Return ""
	End Function

	Public Shared Function CalculateArea1Type1() As String
		'Generate Type 1 Checksum
		Counter = 0
		'We ReDim to resize our Bytes Array
		ReDim Bytes(15)
		Do Until Counter = 15
			Bytes(Counter) = Buffer.GetByte(WholeFile, &H240 + Counter)
			Counter += 1
		Loop
		'We manually set these two bytes
		Bytes(14) = &H5
		Bytes(15) = &H0
		'Get CRC based on the bytes.
		Area1Type1CRC = GetCrc().ToUpper
		Area1Type1CRC = Area1Type1CRC.Remove(0, 2) & Area1Type1CRC.Remove(2, 2)
		'Give back our Checksum
		Return Area1Type1CRC
	End Function

	Public Shared Function VerifyArea1Type1()
		Dim OldCheckSum As String
		OldCheckSum = WholeFile(&H24E).ToString("X2") & WholeFile(&H24F).ToString("X2")
		'Now I need to get the Checksum
		If OldCheckSum<> CalculateArea1Type1() Then
			frmMain.picArea1Type1.BackColor = Color.Red
		Else
			frmMain.picArea1Type1.BackColor = Color.Green
		End If
		Return ""
	End Function
#End Region

#Region " Type 0 "
    Public Shared Sub GenerateNewSerial()
		Dim Serial(3) As Byte

		Dim rnd As Random = New Random()


		rnd.NextBytes(Serial)
		WholeFile(0) = Serial(0)

		WholeFile(1) = Serial(1)

		WholeFile(2) = Serial(2)

		WholeFile(3) = Serial(3)


	End Sub

	Public Shared Sub CalculateSerialXOR()
        'Serial is first four bytes, and the XOR of them at Byte 5 0x4
        Dim Serial(3) As Byte

		Serial(0) = WholeFile(&H0)

		Serial(1) = WholeFile(&H1)

		Serial(2) = WholeFile(&H2)

		Serial(3) = WholeFile(&H3)

		Dim SerialXOR(0) As Byte

		SerialXOR(0) = Serial(0) Xor Serial(1) Xor Serial(2) Xor Serial(3)

		WholeFile(&H4) = SerialXOR(0)

	End Sub

	Public Shared Sub VerifySerialXOR()
        'This generally should be good.
        ReDim Bytes(3)

		Counter = 0
        Do Until Counter = 4
            Bytes(Counter) = Buffer.GetByte(WholeFile, &H0 + Counter)
            Counter += 1
        Loop
		Dim SerialXOR(0) As Byte

		SerialXOR(0) = Bytes(0) Xor Bytes(1) Xor Bytes(2) Xor Bytes(3)

		Dim XORValue As Byte = Buffer.GetByte(WholeFile, &H0 + Counter)

		If SerialXOR(0) = XORValue Then

			frmMain.picSerial.BackColor = Color.Green
		Else

			frmMain.picSerial.BackColor = Color.Red
		End If
	End Sub
	Public Shared Function CalculateType0() As String
		'Generate Type 0 Checksum
		'Read in Thirty Bytes.  Which gives us the headers, and not the checksum.
		Counter = 0
		'We ReDim to resize our Bytes Array
		ReDim Bytes(29)
		Do Until Counter = 30
			Bytes(Counter) = Buffer.GetByte(WholeFile, &H0 + Counter)
			Counter += 1
		Loop
		'Get CRC based on the bytes.
		Area0Type0CRC = GetCrc().ToUpper
		Area0Type0CRC = Area0Type0CRC.Remove(0, 2) & Area0Type0CRC.Remove(2, 2)
		'Give back our Checksum
		Return Area0Type0CRC
	End Function

	Public Shared Function VerifyArea0Type0()
		Dim OldCheckSum As String
		OldCheckSum = WholeFile(&H1E).ToString("X2") & WholeFile(&H1F).ToString("X2")
		'Now I need to get the Checksum
		If OldCheckSum<> CalculateType0() Then
			frmMain.picHeader.BackColor = Color.Red
		Else
			frmMain.picHeader.BackColor = Color.Green
		End If
		Return ""
	End Function

	}
}
