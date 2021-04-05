using System;

namespace SkylandersManagerUI
{
    public class Challenges
    {
		static void GetChallenges()
		{
			var HeroicChallengesArea0 = new byte[4];
			double HeroicChallengesValueArea0;
			var HeroicChallengesArea1 = new byte[4];
			double HeroicChallengesValueArea1;

			var counter = 0;

			do
			{
				HeroicChallengesArea0[counter] = WholeFile[0xD6 + counter];

				counter += 1;
			} while (counter != 4);

			try
			{
				HeroicChallengesValueArea0 = BitConverter.ToUInt32(HeroicChallengesArea0, 0);
			}
			catch (Exception ex)
			{
				HeroicChallengesArea0[0] = 0;
				HeroicChallengesArea0[1] = 0;
				HeroicChallengesArea0[2] = 0;
				HeroicChallengesArea0[3] = 0;
			}

			counter = 0;

			do
			{
				HeroicChallengesArea1[counter] = WholeFile[0x296 + counter];

				counter += 1;
			} while (counter != 4);

			try
			{
				HeroicChallengesValueArea1 = BitConverter.ToUInt32(HeroicChallengesArea1, 0);
			}
			catch (Exception ex)
			{
				HeroicChallengesArea1[0] = 0;
				HeroicChallengesArea1[1] = 0;
				HeroicChallengesArea1[2] = 0;
				HeroicChallengesArea1[3] = 0;
			}

			if (HeroicChallengesValueArea0 > 4294967295)
			{
				HeroicChallengesValueArea0 = 4294967295;
			}

			if (HeroicChallengesValueArea1 > 4294967295)
			{
				HeroicChallengesValueArea1 = 4294967295;
			}

			if (Area0 > Area1)
			{
				frmMain.numHeroicChallenges.Value = HeroicChallengesValueArea0;
			}
			else if (Area1 > Area0)
			{
				frmMain.numHeroicChallenges.Value = HeroicChallengesValueArea1;
			}
			else if (Area0 = Area1)
			{
				frmMain.numHeroicChallenges.Value = HeroicChallengesValueArea0;
			}
		}

		static void WriteChallenges()
		{
			var intHeroicChallenges = frmMain.numHeroicChallenges.Value;
			var HeroicChallenges = BitConverter.GetBytes(intHeroicChallenges);

			var counter = 0;

			// ReCheck this write
			do
			{
				WholeFile[0xD6 + counter] = HeroicChallenges[counter];
				counter += 1;
			} while (counter != 4);

			counter = 0;

			do
			{
				WholeFile[0X296 + counter] = HeroicChallenges[counter];
				counter += 1;
			} while (counter != 4);
		}
	}
}
