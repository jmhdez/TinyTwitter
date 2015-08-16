TinyTwitter
===========

Very simple library to access twitter from C# using the REST API. If you 
are looking for a full-featured library, take a look at [Twitterizer](http://www.twitterizer.net/)
or [TweetSharp](https://github.com/danielcrenna/tweetsharp).

How to use TinyTwitter
----------------------

Just grab the latest version of [TinyTwitter.cs](https://github.com/jmhdez/TinyTwitter/blob/master/src/TinyTwitter/TinyTwitter.cs) and include it in 
your project. That's all. No binary dependecies are needed.

To use TinyTwitter you need to create and register an application
with Twitter to obtain a valid set of OAuth application tokens. More info
about this can be found in [Twitter's docs](https://dev.twitter.com/docs/auth/tokens-devtwittercom).

Using those tokens, you can begin to use TinyTwitter to post 
and/or read tweets from your account:

	var oauth = new OAuthInfo
	{
		AccessToken = "YOUR ACCESS TOKEN",
		AccessSecret = "YOUR ACCES SECRET",
		ConsumerKey = "YOUR CONSUMER KEY",
		ConsumerSecret = "YOUR CONSUMER SECRET"
	};
	
	var twitter = new TinyTwitter(oauth);
	
	// Update status, i.e, post a new tweet
	twitter.UpdateStatus("I'm tweeting from C#");
	
	// Get home timeline tweets
	var tweets = twitter.GetHomeTimeline();
	
	foreach (var tweet in tweets)
		Console.WriteLine("{0}: {1}", tweet.UserName, tweet.Text);

Copyright and license
---------------------

Copyright 2012-2015 Juan M. Hernández.

Code licensed under the [Apache License 2.0] (http://www.apache.org/licenses/LICENSE-2.0) or the [MIT License] (http://opensource.org/licenses/MIT).
