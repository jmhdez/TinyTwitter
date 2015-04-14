using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Xml.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TinyTwitter
{
	[TestClass]
	public class TinyTwitterTests
	{
		private static OAuthInfo GetOAuthInfo()
		{
			var tokensFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test-oauth-info.xml");

			if (!File.Exists(tokensFile))
				Assert.Fail("Cannot find oauth parameter file. Add a file named test-oauth-info.xml to the project with your own OAuth tokens. You can find a sample in sample.test-oauth-info.xml");

			var serializer = new XmlSerializer(typeof(OAuthInfo));
			using (var stream = File.OpenRead(tokensFile))
				return (OAuthInfo)serializer.Deserialize(stream);
		}

		private static TinyTwitter CreateTinyTwitter()
		{
			var oauth = GetOAuthInfo();

			var twitter = new TinyTwitter(oauth);
			return twitter;
		}

		[TestMethod]
		public void Write_tweets_and_read_timeline()
		{
			var twitter = CreateTinyTwitter();

			var status = Guid.NewGuid().ToString();
			twitter.UpdateStatus(status);

			// Wait a little to let twitter update timelines
			Thread.Sleep(TimeSpan.FromSeconds(3));

			var tweets = twitter.GetHomeTimeline();
			Assert.AreEqual(status, tweets.First().Text);
		}

		[TestMethod]
		public void Write_many_tweets()
		{
			// Just to show the problem with HttpWebRequests and TimeoutExceptions

			var twitter = CreateTinyTwitter();

			for (var i = 0; i < 5; i++)
			{
				twitter.UpdateStatus(Guid.NewGuid().ToString());
				Thread.Sleep(TimeSpan.FromMinutes(1));
			}
		}
	}
}
