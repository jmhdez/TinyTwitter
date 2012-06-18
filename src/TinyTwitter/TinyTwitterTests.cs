using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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

			var serializer = new XmlSerializer(typeof (OAuthInfo));
			using (var stream = File.OpenRead(tokensFile))
				return (OAuthInfo) serializer.Deserialize(stream);
		}

		[TestMethod]
		public void Write_tweets_and_read_timeline()
		{
			var oauth = GetOAuthInfo();

			var twitter = new TinyTwitter(oauth);

			var status = Guid.NewGuid().ToString();
			twitter.UpdateStatus(status);

			// Wait a little to let twitter update timelines
			Thread.Sleep(TimeSpan.FromSeconds(3));

			var tweets = twitter.GetHomeTimeline();
			Assert.AreEqual(status, tweets.First().Text);
		}
	}
}
